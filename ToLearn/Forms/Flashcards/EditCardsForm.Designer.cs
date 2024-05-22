namespace ToLearn.Forms.Flashcards
{
    partial class EditCardsForm
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
            cardsTextBox = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // cardsTextBox
            // 
            cardsTextBox.AccessibleName = "Cards";
            cardsTextBox.Location = new Point(0, 0);
            cardsTextBox.Multiline = true;
            cardsTextBox.Name = "cardsTextBox";
            cardsTextBox.Size = new Size(100, 23);
            cardsTextBox.TabIndex = 0;
            cardsTextBox.Tag = "Cards";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(8, 8);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 1;
            saveButton.Tag = "Save";
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(16, 16);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Tag = "Cancel";
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // EditCardsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(cardsTextBox);
            Name = "EditCardsForm";
            Text = "Edit cards";
            Load += EditCardsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox cardsTextBox;
        private Button saveButton;
        private Button cancelButton;
    }
}