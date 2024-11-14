namespace RentAndSell.Car.FormApp
{
    partial class Register
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
            txtFirstName = new TextBox();
            groupBox1 = new GroupBox();
            lblMessage = new Label();
            btnLogin = new Button();
            btnSave = new Button();
            txtPasswordAgain = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(6, 31);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Adınız";
            txtFirstName.Size = new Size(138, 23);
            txtFirstName.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblMessage);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtPasswordAgain);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Location = new Point(0, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(352, 268);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "YENİ KAYIT";
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(162, 34);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(158, 205);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "Message";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(81, 216);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Girişe Git";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(0, 216);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtPasswordAgain
            // 
            txtPasswordAgain.Location = new Point(6, 176);
            txtPasswordAgain.Name = "txtPasswordAgain";
            txtPasswordAgain.PasswordChar = '*';
            txtPasswordAgain.PlaceholderText = "Şifreniz Tekrar";
            txtPasswordAgain.Size = new Size(138, 23);
            txtPasswordAgain.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(6, 147);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Şifreniz";
            txtPassword.Size = new Size(138, 23);
            txtPassword.TabIndex = 0;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(6, 118);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Kullanıcı Adınız";
            txtUserName.Size = new Size(138, 23);
            txtUserName.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(6, 89);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-Posta Adresiniz";
            txtEmail.Size = new Size(138, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(6, 60);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Soyadınız";
            txtLastName.Size = new Size(138, 23);
            txtLastName.TabIndex = 0;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 378);
            Controls.Add(groupBox1);
            Name = "Register";
            Text = "Register";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtFirstName;
        private GroupBox groupBox1;
        private TextBox txtUserName;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtPasswordAgain;
        private TextBox txtPassword;
        private Label lblMessage;
        private Button btnLogin;
        private Button btnSave;
    }
}