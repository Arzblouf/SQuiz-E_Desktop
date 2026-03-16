namespace StadiumProject
{
    partial class IssueView
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
            this.IssueDGV = new System.Windows.Forms.DataGridView();
            this.BacktoMenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IssueDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // IssueDGV
            // 
            this.IssueDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IssueDGV.Location = new System.Drawing.Point(237, 103);
            this.IssueDGV.Name = "IssueDGV";
            this.IssueDGV.RowHeadersWidth = 51;
            this.IssueDGV.RowTemplate.Height = 24;
            this.IssueDGV.Size = new System.Drawing.Size(523, 335);
            this.IssueDGV.TabIndex = 0;
            // 
            // BacktoMenuButton
            // 
            this.BacktoMenuButton.BackColor = System.Drawing.SystemColors.Control;
            this.BacktoMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BacktoMenuButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BacktoMenuButton.Location = new System.Drawing.Point(24, 30);
            this.BacktoMenuButton.Name = "BacktoMenuButton";
            this.BacktoMenuButton.Size = new System.Drawing.Size(102, 48);
            this.BacktoMenuButton.TabIndex = 1;
            this.BacktoMenuButton.Text = "Revenir au menu.";
            this.BacktoMenuButton.UseVisualStyleBackColor = false;
            this.BacktoMenuButton.Click += new System.EventHandler(this.BacktoMenuButton_Click);
            // 
            // IssueView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BacktoMenuButton);
            this.Controls.Add(this.IssueDGV);
            this.Name = "IssueView";
            this.Size = new System.Drawing.Size(1000, 550);
            ((System.ComponentModel.ISupportInitialize)(this.IssueDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView IssueDGV;
        private System.Windows.Forms.Button BacktoMenuButton;
    }
}
