namespace ToLearn.Forms.Flashcards
{
    partial class EditDeckForm
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
            titleTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.AccessibleName = "Title";
            titleTextBox.Location = new Point(0, 0);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(100, 23);
            titleTextBox.TabIndex = 0;
            titleTextBox.Tag = "Title";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.AccessibleName = "Description";
            descriptionTextBox.Location = new Point(8, 8);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(100, 23);
            descriptionTextBox.TabIndex = 1;
            descriptionTextBox.Tag = "Description";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(16, 16);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 2;
            saveButton.Tag = "Save";
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(24, 24);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Tag = "Cancel";
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // EditDeckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(titleTextBox);
            Name = "EditDeckForm";
            Text = "Edit deck";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private Button saveButton;
        private Button cancelButton;
    }
}