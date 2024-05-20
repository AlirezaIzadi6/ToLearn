namespace ToLearn.Forms.Flashcards
{
    partial class ShowCardsForm
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
            cardsComboBox = new ComboBox();
            editButton = new Button();
            deleteButton = new Button();
            createNewButton = new Button();
            closeButton = new Button();
            SuspendLayout();
            // 
            // cardsComboBox
            // 
            cardsComboBox.AccessibleName = "Cards";
            cardsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cardsComboBox.FormattingEnabled = true;
            cardsComboBox.Location = new Point(0, 0);
            cardsComboBox.Name = "cardsComboBox";
            cardsComboBox.Size = new Size(121, 23);
            cardsComboBox.TabIndex = 0;
            cardsComboBox.Tag = "Cards";
            cardsComboBox.SelectedIndexChanged += cardsComboBox_SelectedIndexChanged;
            // 
            // editButton
            // 
            editButton.Enabled = false;
            editButton.Location = new Point(8, 8);
            editButton.Name = "editButton";
            editButton.Size = new Size(75, 23);
            editButton.TabIndex = 1;
            editButton.Tag = "Edit";
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Enabled = false;
            deleteButton.Location = new Point(16, 16);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 2;
            deleteButton.Tag = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // createNewButton
            // 
            createNewButton.Location = new Point(24, 24);
            createNewButton.Name = "createNewButton";
            createNewButton.Size = new Size(75, 23);
            createNewButton.TabIndex = 3;
            createNewButton.Tag = "CreateNew";
            createNewButton.Text = "Create new card";
            createNewButton.UseVisualStyleBackColor = true;
            createNewButton.Click += createNewButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(32, 32);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 4;
            closeButton.Tag = "Close";
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // ShowCardsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(closeButton);
            Controls.Add(createNewButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(cardsComboBox);
            Name = "ShowCardsForm";
            Text = "Show cards";
            Load += ShowCardsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cardsComboBox;
        private Button editButton;
        private Button deleteButton;
        private Button createNewButton;
        private Button closeButton;
    }
}