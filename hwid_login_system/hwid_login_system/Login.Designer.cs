namespace hwid_login_system
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginForm = new ChromeForm();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new ChromeButton();
            this.loginButton = new ChromeButton();
            this.existingAcc = new System.Windows.Forms.RadioButton();
            this.newAcc = new System.Windows.Forms.RadioButton();
            this.passBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loginForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginForm
            // 
            this.loginForm.BackColor = System.Drawing.Color.White;
            this.loginForm.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.loginForm.Controls.Add(this.label2);
            this.loginForm.Controls.Add(this.keyBox);
            this.loginForm.Controls.Add(this.cancelButton);
            this.loginForm.Controls.Add(this.loginButton);
            this.loginForm.Controls.Add(this.existingAcc);
            this.loginForm.Controls.Add(this.newAcc);
            this.loginForm.Controls.Add(this.passBox);
            this.loginForm.Controls.Add(this.usernameBox);
            this.loginForm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.loginForm.Customization = "AAAA/1paWv9ycnL/";
            this.loginForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loginForm.Image = null;
            this.loginForm.Location = new System.Drawing.Point(0, 0);
            this.loginForm.Movable = true;
            this.loginForm.Name = "loginForm";
            this.loginForm.NoRounding = false;
            this.loginForm.Sizable = false;
            this.loginForm.Size = new System.Drawing.Size(337, 188);
            this.loginForm.SmartBounds = true;
            this.loginForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.loginForm.TabIndex = 0;
            this.loginForm.TabStop = false;
            this.loginForm.Text = "HWID Login System";
            this.loginForm.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.loginForm.Transparent = false;
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(110, 88);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(100, 23);
            this.keyBox.TabIndex = 6;
            this.keyBox.Text = "key";
            this.keyBox.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cancelButton.Image = null;
            this.cancelButton.Location = new System.Drawing.Point(165, 115);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.NoRounding = false;
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Transparent = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loginButton.Image = null;
            this.loginButton.Location = new System.Drawing.Point(59, 115);
            this.loginButton.Name = "loginButton";
            this.loginButton.NoRounding = false;
            this.loginButton.Size = new System.Drawing.Size(100, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.Transparent = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // existingAcc
            // 
            this.existingAcc.AutoSize = true;
            this.existingAcc.Checked = true;
            this.existingAcc.Location = new System.Drawing.Point(172, 144);
            this.existingAcc.Name = "existingAcc";
            this.existingAcc.Size = new System.Drawing.Size(88, 19);
            this.existingAcc.TabIndex = 3;
            this.existingAcc.TabStop = true;
            this.existingAcc.Text = "Existing Acc";
            this.existingAcc.UseVisualStyleBackColor = true;
            this.existingAcc.CheckedChanged += new System.EventHandler(this.existingAcc_CheckedChanged);
            // 
            // newAcc
            // 
            this.newAcc.AutoSize = true;
            this.newAcc.Location = new System.Drawing.Point(73, 144);
            this.newAcc.Name = "newAcc";
            this.newAcc.Size = new System.Drawing.Size(72, 19);
            this.newAcc.TabIndex = 2;
            this.newAcc.Text = "New Acc";
            this.newAcc.UseVisualStyleBackColor = true;
            this.newAcc.CheckedChanged += new System.EventHandler(this.newAcc_CheckedChanged);
            // 
            // passBox
            // 
            this.passBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passBox.Location = new System.Drawing.Point(165, 61);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '·';
            this.passBox.Size = new System.Drawing.Size(105, 23);
            this.passBox.TabIndex = 1;
            this.passBox.Text = "Password";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(50, 61);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(109, 23);
            this.usernameBox.TabIndex = 0;
            this.usernameBox.Text = "email@email.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(271, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "emudevs.com";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 188);
            this.Controls.Add(this.loginForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.loginForm.ResumeLayout(false);
            this.loginForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ChromeForm loginForm;
        private System.Windows.Forms.TextBox keyBox;
        private ChromeButton cancelButton;
        private ChromeButton loginButton;
        private System.Windows.Forms.RadioButton existingAcc;
        private System.Windows.Forms.RadioButton newAcc;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label2;

    }
}

