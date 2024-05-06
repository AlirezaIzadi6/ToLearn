namespace ToLearn.Forms
{
    partial class AccountForm_LoggedIn
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
            Button closeButton;
            statusTextBox = new TextBox();
            logoutButton = new Button();
            closeButton = new Button();
            SuspendLayout();
            // 
            // statusTextBox
            // 
            statusTextBox.AccessibleName = "Status";
            statusTextBox.Location = new Point(0, 0);
            statusTextBox.Name = "statusTextBox";
            statusTextBox.Size = new Size(100, 23);
            statusTextBox.TabIndex = 0;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(8, 8);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(16, 16);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // AccountForm_LoggedIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(closeButton);
            Controls.Add(logoutButton);
            Controls.Add(statusTextBox);
            Name = "AccountForm_LoggedIn";
            Text = "AccountForm_LoggedIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox statusTextBox;
        private Button logoutButton;
    }
}