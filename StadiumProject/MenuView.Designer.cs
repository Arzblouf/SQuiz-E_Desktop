using StadiumProject.Data;

namespace StadiumProject
{
    partial class MenuView
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
            this.oopsieLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.DGVSurvey = new System.Windows.Forms.DataGridView();
            this.CMSGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMICreate = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIModify = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.addQuestionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSurvey)).BeginInit();
            this.CMSGridMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // oopsieLabel
            // 
            this.oopsieLabel.AutoSize = true;
            this.oopsieLabel.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oopsieLabel.Location = new System.Drawing.Point(217, 422);
            this.oopsieLabel.Name = "oopsieLabel";
            this.oopsieLabel.Size = new System.Drawing.Size(483, 38);
            this.oopsieLabel.TabIndex = 6;
            this.oopsieLabel.Text = "Crée votre propre questionnaire  !";
            this.oopsieLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oopsieLabel_MouseDown);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(11, 16);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(104, 23);
            this.logoutButton.TabIndex = 5;
            this.logoutButton.Text = "Déconnexion";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.Bisque;
            this.WelcomeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(231, 45);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(469, 20);
            this.WelcomeLabel.TabIndex = 4;
            this.WelcomeLabel.Text = "Bienvenue sur Questionnaire Creator 3000 v3.0.0 2026";
            this.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DGVSurvey
            // 
            this.DGVSurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSurvey.Location = new System.Drawing.Point(224, 125);
            this.DGVSurvey.Name = "DGVSurvey";
            this.DGVSurvey.RowHeadersWidth = 51;
            this.DGVSurvey.RowTemplate.Height = 24;
            this.DGVSurvey.Size = new System.Drawing.Size(474, 258);
            this.DGVSurvey.TabIndex = 7;
            this.DGVSurvey.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVSurvey_CellMouseClick);
            // 
            // CMSGridMenu
            // 
            this.CMSGridMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMICreate,
            this.TSMIModify,
            this.TSMIDelete});
            this.CMSGridMenu.Name = "CMSGridMenu";
            this.CMSGridMenu.Size = new System.Drawing.Size(173, 76);
            // 
            // TSMICreate
            // 
            this.TSMICreate.Name = "TSMICreate";
            this.TSMICreate.Size = new System.Drawing.Size(172, 24);
            this.TSMICreate.Text = "Create Survey";
            this.TSMICreate.Click += new System.EventHandler(this.TSMICreateSurvey_Click);
            // 
            // TSMIModify
            // 
            this.TSMIModify.Name = "TSMIModify";
            this.TSMIModify.Size = new System.Drawing.Size(172, 24);
            this.TSMIModify.Text = "Modify Survey";
            this.TSMIModify.Click += new System.EventHandler(this.TSMIModifySurvey_Click);
            // 
            // TSMIDelete
            // 
            this.TSMIDelete.Name = "TSMIDelete";
            this.TSMIDelete.Size = new System.Drawing.Size(172, 24);
            this.TSMIDelete.Text = "Delete Survey";
            this.TSMIDelete.Click += new System.EventHandler(this.TSMIDeleteSurvey_Click);
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Location = new System.Drawing.Point(825, 16);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(161, 28);
            this.addQuestionButton.TabIndex = 8;
            this.addQuestionButton.Text = "Ajouter des questions ?";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            this.addQuestionButton.Click += new System.EventHandler(this.addQuestionButton_Click);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.DGVSurvey);
            this.Controls.Add(this.oopsieLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "MenuView";
            this.Size = new System.Drawing.Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSurvey)).EndInit();
            this.CMSGridMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oopsieLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.DataGridView DGVSurvey;
        private System.Windows.Forms.ContextMenuStrip CMSGridMenu;
        private System.Windows.Forms.ToolStripMenuItem TSMICreate;
        private System.Windows.Forms.ToolStripMenuItem TSMIModify;
        private System.Windows.Forms.ToolStripMenuItem TSMIDelete;
        private System.Windows.Forms.Button addQuestionButton;
    }
}
