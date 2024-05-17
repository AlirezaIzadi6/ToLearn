namespace ToLearn.Forms.Flashcards
{
    partial class CreateUnitForm
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
            nameTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            createButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.AccessibleName = "Name";
            nameTextBox.Location = new Point(0, 0);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 23);
            nameTextBox.TabIndex = 0;
            nameTextBox.Tag = "Name";
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
            // createButton
            // 
            createButton.Location = new Point(16, 16);
            createButton.Name = "createButton";
            createButton.Size = new Size(75, 23);
            createButton.TabIndex = 2;
            createButton.Tag = "Create";
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
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
            // CreateUnitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(cancelButton);
            Controls.Add(createButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(nameTextBox);
            Name = "CreateUnitForm";
            Text = "Create new unit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox descriptionTextBox;
        private Button createButton;
        private Button cancelButton;
    }
}