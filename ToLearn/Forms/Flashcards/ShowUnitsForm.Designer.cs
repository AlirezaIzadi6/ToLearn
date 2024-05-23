namespace ToLearn.Forms.Flashcards
{
    partial class ShowUnitsForm
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
            showCardsButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            createNewUnitButton = new Button();
            closeButton = new Button();
            unitsComboBox = new ComboBox();
            editCardsButton = new Button();
            SuspendLayout();
            // 
            // showCardsButton
            // 
            showCardsButton.Enabled = false;
            showCardsButton.Location = new Point(8, 8);
            showCardsButton.Name = "showCardsButton";
            showCardsButton.Size = new Size(75, 23);
            showCardsButton.TabIndex = 1;
            showCardsButton.Tag = "ShowCards";
            showCardsButton.Text = "Show cards";
            showCardsButton.UseVisualStyleBackColor = true;
            showCardsButton.Click += showCardsButton_Click;
            // 
            // editButton
            // 
            editButton.Enabled = false;
            editButton.Location = new Point(16, 16);
            editButton.Name = "editButton";
            editButton.Size = new Size(75, 23);
            editButton.TabIndex = 2;
            editButton.Tag = "Edit";
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Enabled = false;
            deleteButton.Location = new Point(24, 24);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 3;
            deleteButton.Tag = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // createNewUnitButton
            // 
            createNewUnitButton.Location = new Point(32, 32);
            createNewUnitButton.Name = "createNewUnitButton";
            createNewUnitButton.Size = new Size(75, 23);
            createNewUnitButton.TabIndex = 4;
            createNewUnitButton.Tag = "CreateNewUnit";
            createNewUnitButton.Text = "Create a new unit";
            createNewUnitButton.UseVisualStyleBackColor = true;
            createNewUnitButton.Click += createNewUnitButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(40, 40);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 5;
            closeButton.Tag = "Close";
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // unitsComboBox
            // 
            unitsComboBox.AccessibleName = "List of units";
            unitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            unitsComboBox.FormattingEnabled = true;
            unitsComboBox.Location = new Point(0, 0);
            unitsComboBox.Name = "unitsComboBox";
            unitsComboBox.Size = new Size(121, 23);
            unitsComboBox.TabIndex = 0;
            unitsComboBox.Tag = "Units";
            unitsComboBox.SelectedIndexChanged += unitsComboBox_SelectedIndexChanged;
            // 
            // editCardsButton
            // 
            editCardsButton.Enabled = false;
            editCardsButton.Location = new Point(0, 0);
            editCardsButton.Name = "editCardsButton";
            editCardsButton.Size = new Size(75, 23);
            editCardsButton.TabIndex = 2;
            editCardsButton.Tag = "EditCards";
            editCardsButton.Text = "Edit cards";
            editCardsButton.UseVisualStyleBackColor = true;
            editCardsButton.Click += editCardsButton_Click;
            // 
            // ShowUnitsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(editCardsButton);
            Controls.Add(unitsComboBox);
            Controls.Add(closeButton);
            Controls.Add(createNewUnitButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(showCardsButton);
            Name = "ShowUnitsForm";
            Text = "Show Unit";
            Load += ShowUnitsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button showCardsButton;
        private Button editButton;
        private Button deleteButton;
        private Button createNewUnitButton;
        private Button closeButton;
        private ComboBox unitsComboBox;
        private Button editCardsButton;
    }
}