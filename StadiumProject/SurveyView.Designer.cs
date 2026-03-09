namespace StadiumProject
{
    partial class SurveyView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SurveyLabel = new System.Windows.Forms.Label();
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.themeLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.publishCheckBox = new System.Windows.Forms.CheckBox();
            this.saveSurveyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.surveyQuestionLabel = new System.Windows.Forms.Label();
            this.surveyQuestionDGV = new System.Windows.Forms.DataGridView();
            this.questionComboBox = new System.Windows.Forms.ComboBox();
            this.addQuestionLabel = new System.Windows.Forms.Label();
            this.addQuestionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.surveyQuestionDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SurveyLabel
            // 
            this.SurveyLabel.AutoSize = true;
            this.SurveyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SurveyLabel.Location = new System.Drawing.Point(369, 26);
            this.SurveyLabel.Name = "SurveyLabel";
            this.SurveyLabel.Size = new System.Drawing.Size(246, 20);
            this.SurveyLabel.TabIndex = 0;
            this.SurveyLabel.Text = "Create and Edit our survey :";
            // 
            // themeComboBox
            // 
            this.themeComboBox.FormattingEnabled = true;
            this.themeComboBox.Location = new System.Drawing.Point(119, 123);
            this.themeComboBox.Name = "themeComboBox";
            this.themeComboBox.Size = new System.Drawing.Size(132, 24);
            this.themeComboBox.TabIndex = 2;
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Location = new System.Drawing.Point(116, 86);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(111, 16);
            this.themeLabel.TabIndex = 3;
            this.themeLabel.Text = "Choose a theme :";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(335, 86);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(94, 16);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Choose a title :";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(338, 125);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(225, 22);
            this.titleTextBox.TabIndex = 5;
            // 
            // publishCheckBox
            // 
            this.publishCheckBox.AutoSize = true;
            this.publishCheckBox.Location = new System.Drawing.Point(661, 123);
            this.publishCheckBox.Name = "publishCheckBox";
            this.publishCheckBox.Size = new System.Drawing.Size(147, 20);
            this.publishCheckBox.TabIndex = 7;
            this.publishCheckBox.Text = "Publish the survey ?";
            this.publishCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveSurveyButton
            // 
            this.saveSurveyButton.BackColor = System.Drawing.Color.OliveDrab;
            this.saveSurveyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveSurveyButton.Font = new System.Drawing.Font("Microsoft Yi Baiti", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSurveyButton.Location = new System.Drawing.Point(855, 475);
            this.saveSurveyButton.Name = "saveSurveyButton";
            this.saveSurveyButton.Size = new System.Drawing.Size(102, 45);
            this.saveSurveyButton.TabIndex = 8;
            this.saveSurveyButton.Text = "Save";
            this.saveSurveyButton.UseVisualStyleBackColor = false;
            this.saveSurveyButton.Click += new System.EventHandler(this.saveSurveyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Maroon;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Yi Baiti", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.Location = new System.Drawing.Point(44, 475);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(102, 45);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // surveyQuestionLabel
            // 
            this.surveyQuestionLabel.AutoSize = true;
            this.surveyQuestionLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surveyQuestionLabel.Location = new System.Drawing.Point(83, 194);
            this.surveyQuestionLabel.Name = "surveyQuestionLabel";
            this.surveyQuestionLabel.Size = new System.Drawing.Size(160, 23);
            this.surveyQuestionLabel.TabIndex = 10;
            this.surveyQuestionLabel.Text = "Survey Questions :";
            // 
            // surveyQuestionDGV
            // 
            this.surveyQuestionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surveyQuestionDGV.Location = new System.Drawing.Point(86, 229);
            this.surveyQuestionDGV.Name = "surveyQuestionDGV";
            this.surveyQuestionDGV.RowHeadersWidth = 51;
            this.surveyQuestionDGV.RowTemplate.Height = 24;
            this.surveyQuestionDGV.Size = new System.Drawing.Size(354, 209);
            this.surveyQuestionDGV.TabIndex = 11;
            this.surveyQuestionDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.surveyQuestionDGV_CellContentClick);
            // 
            // questionComboBox
            // 
            this.questionComboBox.FormattingEnabled = true;
            this.questionComboBox.Location = new System.Drawing.Point(592, 304);
            this.questionComboBox.Name = "questionComboBox";
            this.questionComboBox.Size = new System.Drawing.Size(305, 24);
            this.questionComboBox.TabIndex = 12;
            // 
            // addQuestionLabel
            // 
            this.addQuestionLabel.AutoSize = true;
            this.addQuestionLabel.Location = new System.Drawing.Point(658, 243);
            this.addQuestionLabel.Name = "addQuestionLabel";
            this.addQuestionLabel.Size = new System.Drawing.Size(181, 16);
            this.addQuestionLabel.TabIndex = 13;
            this.addQuestionLabel.Text = "Add a question to the survey :";
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Location = new System.Drawing.Point(661, 360);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(163, 33);
            this.addQuestionButton.TabIndex = 14;
            this.addQuestionButton.Text = "Add Question";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            this.addQuestionButton.Click += new System.EventHandler(this.addQuestionButton_Click);
            // 
            // SurveyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.addQuestionLabel);
            this.Controls.Add(this.questionComboBox);
            this.Controls.Add(this.surveyQuestionDGV);
            this.Controls.Add(this.surveyQuestionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveSurveyButton);
            this.Controls.Add(this.publishCheckBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.themeLabel);
            this.Controls.Add(this.themeComboBox);
            this.Controls.Add(this.SurveyLabel);
            this.Name = "SurveyView";
            this.Size = new System.Drawing.Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)(this.surveyQuestionDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SurveyLabel;
        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.CheckBox publishCheckBox;
        private System.Windows.Forms.Button saveSurveyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label surveyQuestionLabel;
        private System.Windows.Forms.DataGridView surveyQuestionDGV;
        private System.Windows.Forms.ComboBox questionComboBox;
        private System.Windows.Forms.Label addQuestionLabel;
        private System.Windows.Forms.Button addQuestionButton;
    }
}
