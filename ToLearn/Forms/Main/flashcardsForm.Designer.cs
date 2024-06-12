namespace ToLearn.Forms
{
    partial class FlashcardsForm
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
            decksComboBox = new ComboBox();
            descriptionTextBox = new TextBox();
            learnButton = new Button();
            reviewButton = new Button();
            showUnitsButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            createNewButton = new Button();
            closeButton = new Button();
            SuspendLayout();
            // 
            // decksComboBox
            // 
            decksComboBox.AccessibleName = "Choose a deck";
            decksComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            decksComboBox.FormattingEnabled = true;
            decksComboBox.Location = new Point(0, 0);
            decksComboBox.Name = "decksComboBox";
            decksComboBox.Size = new Size(121, 23);
            decksComboBox.TabIndex = 0;
            decksComboBox.Tag = "Decks";
            decksComboBox.SelectedIndexChanged += decksComboBox_SelectedIndexChanged;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.AccessibleName = "Description";
            descriptionTextBox.Location = new Point(8, 8);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ReadOnly = true;
            descriptionTextBox.Size = new Size(100, 23);
            descriptionTextBox.TabIndex = 1;
            descriptionTextBox.Tag = "Description";
            // 
            // learnButton
            // 
            learnButton.Location = new Point(16, 16);
            learnButton.Name = "learnButton";
            learnButton.Size = new Size(75, 23);
            learnButton.TabIndex = 2;
            learnButton.Tag = "Learn";
            learnButton.Text = "Learn";
            learnButton.UseVisualStyleBackColor = true;
            learnButton.Click += learnButton_Click;
            // 
            // reviewButton
            // 
            reviewButton.Location = new Point(24, 24);
            reviewButton.Name = "reviewButton";
            reviewButton.Size = new Size(75, 23);
            reviewButton.TabIndex = 3;
            reviewButton.Tag = "Review";
            reviewButton.Text = "Review";
            reviewButton.UseVisualStyleBackColor = true;
            // 
            // showUnitsButton
            // 
            showUnitsButton.Location = new Point(32, 32);
            showUnitsButton.Name = "showUnitsButton";
            showUnitsButton.Size = new Size(75, 23);
            showUnitsButton.TabIndex = 4;
            showUnitsButton.Tag = "ShowUnits";
            showUnitsButton.Text = "Show units";
            showUnitsButton.UseVisualStyleBackColor = true;
            showUnitsButton.Click += showUnitsButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(40, 40);
            editButton.Name = "editButton";
            editButton.Size = new Size(75, 23);
            editButton.TabIndex = 5;
            editButton.Tag = "Edit";
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(48, 48);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 6;
            deleteButton.Tag = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // createNewButton
            // 
            createNewButton.Location = new Point(56, 56);
            createNewButton.Name = "createNewButton";
            createNewButton.Size = new Size(75, 23);
            createNewButton.TabIndex = 7;
            createNewButton.Tag = "CreateNew";
            createNewButton.Text = "Create a new deck";
            createNewButton.UseVisualStyleBackColor = true;
            createNewButton.Click += createNewButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(64, 64);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 8;
            closeButton.Tag = "Close";
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // FlashcardsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(closeButton);
            Controls.Add(createNewButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(showUnitsButton);
            Controls.Add(reviewButton);
            Controls.Add(learnButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(decksComboBox);
            Name = "FlashcardsForm";
            Text = "flashcardsForm";
            Load += FlashcardsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox decksComboBox;
        private TextBox descriptionTextBox;
        private Button learnButton;
        private Button reviewButton;
        private Button showUnitsButton;
        private Button editButton;
        private Button deleteButton;
        private Button createNewButton;
        private Button closeButton;
    }
}