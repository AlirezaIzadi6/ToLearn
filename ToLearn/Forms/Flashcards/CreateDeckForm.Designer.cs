namespace ToLearn.Forms.Flashcards
{
    partial class CreateDeckForm
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
            createButton = new Button();
            titleTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // createButton
            // 
            createButton.Location = new Point(0, 0);
            createButton.Name = "createButton";
            createButton.Size = new Size(75, 23);
            createButton.TabIndex = 2;
            createButton.Tag = "Create";
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            // 
            // titleTextBox
            // 
            titleTextBox.AccessibleName = "Deck title";
            titleTextBox.Location = new Point(8, 8);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(100, 23);
            titleTextBox.TabIndex = 0;
            titleTextBox.Tag = "Title";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.AccessibleName = "Deck description";
            descriptionTextBox.Location = new Point(16, 16);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(100, 23);
            descriptionTextBox.TabIndex = 1;
            descriptionTextBox.Tag = "Description";
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
            // 
            // CreateDeckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(cancelButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(createButton);
            Name = "CreateDeckForm";
            Text = "Create Deck";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createButton;
        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private Button cancelButton;
    }
}