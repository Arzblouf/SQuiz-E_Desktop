namespace StadiumProject
{
    partial class QuestionView
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.questionTitleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.questionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.vraiFauxComboBox = new System.Windows.Forms.ComboBox();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.vraiFauxLabel = new System.Windows.Forms.Label();
            this.answerLabel = new System.Windows.Forms.Label();
            this.answerDGV = new System.Windows.Forms.DataGridView();
            this.answerListLabel = new System.Windows.Forms.Label();
            this.addAnswerButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.rightAnswerCheckBox = new System.Windows.Forms.CheckBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.weightCheckedListBox = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.answerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Noto Sans Lao", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(385, 12);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(220, 28);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Salut c\'est Frank Leboeuf !";
            // 
            // questionTitleTextBox
            // 
            this.questionTitleTextBox.Location = new System.Drawing.Point(60, 106);
            this.questionTitleTextBox.Name = "questionTitleTextBox";
            this.questionTitleTextBox.Size = new System.Drawing.Size(240, 22);
            this.questionTitleTextBox.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(69, 87);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(218, 16);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Donnez un titre à votre frank leboeuf";
            // 
            // questionTypeComboBox
            // 
            this.questionTypeComboBox.FormattingEnabled = true;
            this.questionTypeComboBox.Location = new System.Drawing.Point(60, 188);
            this.questionTypeComboBox.Name = "questionTypeComboBox";
            this.questionTypeComboBox.Size = new System.Drawing.Size(240, 24);
            this.questionTypeComboBox.TabIndex = 3;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(57, 169);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(256, 16);
            this.typeLabel.TabIndex = 4;
            this.typeLabel.Text = "Choisissez le type de votre Frank Leboeuf";
            // 
            // vraiFauxComboBox
            // 
            this.vraiFauxComboBox.FormattingEnabled = true;
            this.vraiFauxComboBox.Location = new System.Drawing.Point(60, 264);
            this.vraiFauxComboBox.Name = "vraiFauxComboBox";
            this.vraiFauxComboBox.Size = new System.Drawing.Size(266, 24);
            this.vraiFauxComboBox.TabIndex = 5;
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(60, 358);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(240, 22);
            this.answerTextBox.TabIndex = 6;
            // 
            // vraiFauxLabel
            // 
            this.vraiFauxLabel.AutoSize = true;
            this.vraiFauxLabel.Location = new System.Drawing.Point(57, 245);
            this.vraiFauxLabel.Name = "vraiFauxLabel";
            this.vraiFauxLabel.Size = new System.Drawing.Size(269, 16);
            this.vraiFauxLabel.TabIndex = 7;
            this.vraiFauxLabel.Text = "Seulement si la réponse est vraie ou fausse.";
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(109, 339);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(135, 16);
            this.answerLabel.TabIndex = 8;
            this.answerLabel.Text = "Entrez vos réponses :";
            // 
            // answerDGV
            // 
            this.answerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answerDGV.Location = new System.Drawing.Point(513, 106);
            this.answerDGV.Name = "answerDGV";
            this.answerDGV.RowHeadersWidth = 51;
            this.answerDGV.RowTemplate.Height = 24;
            this.answerDGV.Size = new System.Drawing.Size(384, 236);
            this.answerDGV.TabIndex = 9;
            this.answerDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.answerDGV_CellContentClick);
            // 
            // answerListLabel
            // 
            this.answerListLabel.AutoSize = true;
            this.answerListLabel.Location = new System.Drawing.Point(651, 87);
            this.answerListLabel.Name = "answerListLabel";
            this.answerListLabel.Size = new System.Drawing.Size(113, 16);
            this.answerListLabel.TabIndex = 10;
            this.answerListLabel.Text = "Vos réponses ici :";
            // 
            // addAnswerButton
            // 
            this.addAnswerButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addAnswerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addAnswerButton.Location = new System.Drawing.Point(112, 459);
            this.addAnswerButton.Name = "addAnswerButton";
            this.addAnswerButton.Size = new System.Drawing.Size(132, 23);
            this.addAnswerButton.TabIndex = 11;
            this.addAnswerButton.Text = "Ajouter la réponse.";
            this.addAnswerButton.UseVisualStyleBackColor = false;
            this.addAnswerButton.Click += new System.EventHandler(this.addAnswerButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Firebrick;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cancelButton.Location = new System.Drawing.Point(3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(16, 544);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.YellowGreen;
            this.saveButton.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(872, 473);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(104, 59);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Enregistrer";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // rightAnswerCheckBox
            // 
            this.rightAnswerCheckBox.AutoSize = true;
            this.rightAnswerCheckBox.Location = new System.Drawing.Point(89, 406);
            this.rightAnswerCheckBox.Name = "rightAnswerCheckBox";
            this.rightAnswerCheckBox.Size = new System.Drawing.Size(185, 20);
            this.rightAnswerCheckBox.TabIndex = 14;
            this.rightAnswerCheckBox.Text = "Est-ce la bonne réponse ?";
            this.rightAnswerCheckBox.UseVisualStyleBackColor = true;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(566, 364);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(284, 16);
            this.weightLabel.TabIndex = 15;
            this.weightLabel.Text = "Combien de point rapporte la bonne réponse ?";
            // 
            // weightCheckedListBox
            // 
            this.weightCheckedListBox.FormattingEnabled = true;
            this.weightCheckedListBox.Location = new System.Drawing.Point(644, 406);
            this.weightCheckedListBox.Name = "weightCheckedListBox";
            this.weightCheckedListBox.Size = new System.Drawing.Size(120, 89);
            this.weightCheckedListBox.TabIndex = 16;
            this.weightCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.weightCheckedListBox_ItemCheck);
            // 
            // QuestionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.weightCheckedListBox);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.rightAnswerCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addAnswerButton);
            this.Controls.Add(this.answerListLabel);
            this.Controls.Add(this.answerDGV);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.vraiFauxLabel);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.vraiFauxComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.questionTypeComboBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.questionTitleTextBox);
            this.Controls.Add(this.questionLabel);
            this.Name = "QuestionView";
            this.Size = new System.Drawing.Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)(this.answerDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.TextBox questionTitleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox questionTypeComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox vraiFauxComboBox;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Label vraiFauxLabel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.DataGridView answerDGV;
        private System.Windows.Forms.Label answerListLabel;
        private System.Windows.Forms.Button addAnswerButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox rightAnswerCheckBox;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.CheckedListBox weightCheckedListBox;
    }
}
