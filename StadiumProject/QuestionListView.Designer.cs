namespace StadiumProject
{
    partial class QuestionListView
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
            this.components = new System.ComponentModel.Container();
            this.backToMenuButton = new System.Windows.Forms.Button();
            this.DGVQuestion = new System.Windows.Forms.DataGridView();
            this.questionLabel = new System.Windows.Forms.Label();
            this.CMSGridQuestion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMICreateQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIModifyQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIDeleteQuestion = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuestion)).BeginInit();
            this.CMSGridQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backToMenuButton.Location = new System.Drawing.Point(17, 23);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(83, 45);
            this.backToMenuButton.TabIndex = 0;
            this.backToMenuButton.Text = "Revenir au menu.";
            this.backToMenuButton.UseVisualStyleBackColor = true;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            // 
            // DGVQuestion
            // 
            this.DGVQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVQuestion.Location = new System.Drawing.Point(182, 101);
            this.DGVQuestion.Name = "DGVQuestion";
            this.DGVQuestion.RowHeadersWidth = 51;
            this.DGVQuestion.RowTemplate.Height = 24;
            this.DGVQuestion.Size = new System.Drawing.Size(578, 327);
            this.DGVQuestion.TabIndex = 1;
            this.DGVQuestion.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVQuestion_CellMouseClick);
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(329, 34);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(277, 20);
            this.questionLabel.TabIndex = 2;
            this.questionLabel.Text = "Créez et modifiez les questions ici :";
            // 
            // CMSGridQuestion
            // 
            this.CMSGridQuestion.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSGridQuestion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMICreateQuestion,
            this.TSMIModifyQuestion,
            this.TSMIDeleteQuestion});
            this.CMSGridQuestion.Name = "CMSGridQuestion";
            this.CMSGridQuestion.Size = new System.Drawing.Size(211, 104);
            // 
            // TSMICreateQuestion
            // 
            this.TSMICreateQuestion.Name = "TSMICreateQuestion";
            this.TSMICreateQuestion.Size = new System.Drawing.Size(210, 24);
            this.TSMICreateQuestion.Text = "Créer";
            this.TSMICreateQuestion.Click += new System.EventHandler(this.TSMICreateQuestion_Click);
            // 
            // TSMIModifyQuestion
            // 
            this.TSMIModifyQuestion.Name = "TSMIModifyQuestion";
            this.TSMIModifyQuestion.Size = new System.Drawing.Size(210, 24);
            this.TSMIModifyQuestion.Text = "Modifier";
            this.TSMIModifyQuestion.Click += new System.EventHandler(this.TSMIModifyQuestion_Click);
            // 
            // TSMIDeleteQuestion
            // 
            this.TSMIDeleteQuestion.Name = "TSMIDeleteQuestion";
            this.TSMIDeleteQuestion.Size = new System.Drawing.Size(210, 24);
            this.TSMIDeleteQuestion.Text = "Supprimer";
            this.TSMIDeleteQuestion.Click += new System.EventHandler(this.TSMIDeleteQuestion_Click);
            // 
            // QuestionListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.DGVQuestion);
            this.Controls.Add(this.backToMenuButton);
            this.Name = "QuestionListView";
            this.Size = new System.Drawing.Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuestion)).EndInit();
            this.CMSGridQuestion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToMenuButton;
        private System.Windows.Forms.DataGridView DGVQuestion;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.ContextMenuStrip CMSGridQuestion;
        private System.Windows.Forms.ToolStripMenuItem TSMICreateQuestion;
        private System.Windows.Forms.ToolStripMenuItem TSMIModifyQuestion;
        private System.Windows.Forms.ToolStripMenuItem TSMIDeleteQuestion;
    }
}
