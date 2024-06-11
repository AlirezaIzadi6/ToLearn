namespace ToLearn.Forms.Account
{
    partial class RegisterForm
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
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            registerButton = new Button();
            cancelButton = new Button();
            userNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.AccessibleName = "Email";
            emailTextBox.Location = new Point(0, 0);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(100, 23);
            emailTextBox.TabIndex = 0;
            emailTextBox.Tag = "Email";
            // 
            // passwordTextBox
            // 
            passwordTextBox.AccessibleName = "Password";
            passwordTextBox.Location = new Point(8, 8);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.Tag = "Password";
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(16, 16);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(75, 23);
            registerButton.TabIndex = 3;
            registerButton.Tag = "Register";
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(24, 24);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Tag = "Cancel";
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.AccessibleName = "Username";
            userNameTextBox.Location = new Point(0, 0);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(100, 23);
            userNameTextBox.TabIndex = 1;
            userNameTextBox.Tag = "UserName";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(userNameTextBox);
            Controls.Add(cancelButton);
            Controls.Add(registerButton);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Name = "RegisterForm";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private Button registerButton;
        private Button cancelButton;
        private TextBox userNameTextBox;
    }
}