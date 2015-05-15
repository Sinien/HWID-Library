/*
             _____           ____              
            |   __|_____ _ _|    \ ___ _ _ ___ 
            |   __|     | | |  |  | -_| | |_ -|
            |_____|_|_|_|___|____/|___|\_/|___|
     Copyright (C) 2013 EmuDevs <http://www.emudevs.com/>
 
  This program is free software; you can redistribute it and/or modify it
  under the terms of the GNU General Public License as published by the
  Free Software Foundation; either version 2 of the License, or (at your
  option) any later version.
 
  This program is distributed in the hope that it will be useful, but WITHOUT
  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
  FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
  more details.
 
  You should have received a copy of the GNU General Public License along
  with this program. If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.IO;

namespace hwid_login_system
{
    public partial class Login : Form
    {
        public static string userInfo;
        bool loggedin = false;
        bool hwid = false;
        bool exists = false;
        string cpuid = null;
        string moserial = null;
        string hwidstr;
        string passInfo;
        string keyInfo;

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();

            foreach (ManagementObject mo in mbsList)
            {
                cpuid = mo["ProcessorID"].ToString();
            }

            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();

            foreach (ManagementObject mo in moc)
            {
                moserial = (string)mo["SerialNumber"];
            }

            hwidstr = cpuid + moserial;
        }

        private void existingAcc_CheckedChanged(object sender, EventArgs e)
        {
            keyBox.Visible = false;
        }

        private void newAcc_CheckedChanged(object sender, EventArgs e)
        {
            keyBox.Visible = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userInfo = usernameBox.Text;
            passInfo = passBox.Text;
            keyInfo = keyBox.Text;

            if (userInfo == "")
                MessageBox.Show("Please fill in the username field!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (passInfo == "")
                MessageBox.Show("Please fill in the password field!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                existcheck();
        }

        public void existcheck()
        {
            string userResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "user", "email", "email", userInfo, true);

            if (string.IsNullOrEmpty(userResult))
            {
                exists = false;
                MessageBox.Show("This account does not exist, checking if new user...");
                newaccount();
            }
            else
            {
                exists = true;
                logincheck();
            }
        }

        private void logincheck()
        {
            passInfo = CreateHash(passInfo);
            string userResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "user", "email", "email", userInfo, true);
            string passResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "user", "password", "password", passInfo, true);
            string statusResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_INT32, "user", "status", "email", userInfo, true);


            if (exists && passInfo == passResult)
            {
                loggedin = true;
                statuscheck();
            }
            else
            {
                loggedin = false;
                MessageBox.Show("Username or Password is invalid, please try again!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void statuscheck()
        {
            string statusResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_INT32, "user", "status", "email", userInfo, true);

            if (statusResult == "0")
            {
                MessageBox.Show("Your account is locked!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (statusResult == "1")
                hwidcheck();
            else if (statusResult == "3")
                resethwid();
        }

        private void hwidcheck()
        {
            string hwidResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "user", "hwid", "hwid", hwidstr, true);

            if (hwidResult == hwidstr)
            {
                hwid = true;
                complete();
            }
            else
            {
                hwid = false;
                MessageBox.Show("Invalid HWID info! Your account is now locked.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void complete()
        {
            if (loggedin && hwid)
            {
                MessageBox.Show("Logged in successfully!");
                //Continue to whatever you needed a login for here
            }
            else
                MessageBox.Show("Something else went wrong..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void newaccount()
        {
            passInfo = CreateHash(passInfo);
            string keyResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "keys", "keystring", "keystring", keyInfo, true);
            string[] userInput = { "", userInfo, passInfo, keyInfo, hwidstr, "1" };

            if (userInfo.IndexOf("@") > 0)
            {

                if (keyInfo == "")
                    MessageBox.Show("The key field is blank");
                else
                {
                    if (keyInfo == keyResult)
                    {
                        Database.databaseAccess.InsertInto("user", userInput);
                        Database.databaseAccess.DeleteFrom("keys", "keystring", keyInfo);
                        MessageBox.Show("Account created");

                        using (StreamWriter sw = new StreamWriter("builder.nom"))
                        {
                            sw.WriteLine(userInfo + "\n");
                            sw.WriteLine(passInfo);
                        }
                        MessageBox.Show("Logged in successfully!");
                        //Continue to whatever you needed a login for here
                    }
                    else
                        MessageBox.Show("Invalid key. Be sure you have entered it correctly.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Your username must be a valid email address!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void resethwid()
        {
            Database.databaseAccess.UpdateUserInfo("user", "hwid", hwidstr, "email", userInfo);
            Database.databaseAccess.UpdateUserInfo("user", "status", "1", "email", userInfo);
            MessageBox.Show("Your account was reset and updated, please log in again.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        public static string CreateHash(string unHashed)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(unHashed);
            data = x.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.emudevs.com");
        }
    }
}
