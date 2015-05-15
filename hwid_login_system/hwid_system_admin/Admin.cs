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
using System.IO;
using System.Windows.Forms;

namespace hwid_login_system
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            string randomString = GetRandomString();
            string[] insertString = { randomString };
            int stringLength = 12;
            Guid.NewGuid().ToString("N").Substring(0, stringLength);
            Database.databaseAccess.InsertInto("keys", insertString);
            stringBox.Text = randomString;
            MessageBox.Show("String added to keys table.");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            string userResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "user", "email", "email", stringBox.Text, true);

            if (string.IsNullOrEmpty(userResult))
                MessageBox.Show("This account does not exist.");
            else
            {
                Database.databaseAccess.UpdateUserInfo("user", "status", "3", "email", stringBox.Text);
                MessageBox.Show("Account has been reset.");
            }
        }

        private void banuserButton_Click(object sender, EventArgs e)
        {
            string userResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "user", "email", "email", stringBox.Text, true);

            if (string.IsNullOrEmpty(userResult))
                MessageBox.Show("This account does not exist.");
            else
            {
                Database.databaseAccess.UpdateUserInfo("user", "status", "0", "email", stringBox.Text);
                MessageBox.Show("User Locked.");
            }
        }

        private void deluserButton_Click(object sender, EventArgs e)
        {
            string userResult = Database.databaseAccess.GetColumnData(ValueType.VALUETYPE_STRING, "user", "email", "email", stringBox.Text, true);

            if (string.IsNullOrEmpty(userResult))
                MessageBox.Show("This account does not exist.");
            else
            {
                Database.databaseAccess.DeleteFrom("user", "email", stringBox.Text);
                MessageBox.Show("User Deleted.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.emudevs.com");
        }
    }
}
