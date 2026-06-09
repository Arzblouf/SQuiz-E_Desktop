namespace StadiumProject
{
    partial class LoginView
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
            this.CloseAppButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.GoToRegisterButton = new System.Windows.Forms.Button();
            this.registerHereLabel = new System.Windows.Forms.Label();
            this.noAccountLabel = new System.Windows.Forms.Label();
            this.bddNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseAppButton
            // 
            this.CloseAppButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CloseAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseAppButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseAppButton.Location = new System.Drawing.Point(14, 19);
            this.CloseAppButton.Name = "CloseAppButton";
            this.CloseAppButton.Size = new System.Drawing.Size(169, 23);
            this.CloseAppButton.TabIndex = 19;
            this.CloseAppButton.Text = "Fermer l\'aplication";
            this.CloseAppButton.UseVisualStyleBackColor = false;
            this.CloseAppButton.Click += new System.EventHandler(this.CloseAppButton_Click);
            this.CloseAppButton.MouseEnter += new System.EventHandler(this.CloseAppButton_MouseEnter);
            this.CloseAppButton.MouseLeave += new System.EventHandler(this.CloseAppButton_MouseLeave);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(443, 447);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(87, 23);
            this.loginButton.TabIndex = 18;
            this.loginButton.Text = "Connexion";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(253, 318);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(168, 16);
            this.passwordLabel.TabIndex = 17;
            this.passwordLabel.Text = "Entrez votre mot de passe :";
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(298, 243);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(119, 16);
            this.emailLabel.TabIndex = 16;
            this.emailLabel.Text = "Entrez votre email :";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Location = new System.Drawing.Point(443, 318);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(333, 22);
            this.passwordTextBox.TabIndex = 15;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailTextBox.Location = new System.Drawing.Point(443, 243);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(333, 22);
            this.emailTextBox.TabIndex = 14;
            // 
            // loginLabel
            // 
            this.loginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(411, 118);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(154, 16);
            this.loginLabel.TabIndex = 13;
            this.loginLabel.Text = "Veuillez vous connecter :";
            // 
            // GoToRegisterButton
            // 
            this.GoToRegisterButton.Location = new System.Drawing.Point(889, 46);
            this.GoToRegisterButton.Name = "GoToRegisterButton";
            this.GoToRegisterButton.Size = new System.Drawing.Size(93, 23);
            this.GoToRegisterButton.TabIndex = 12;
            this.GoToRegisterButton.Text = "Inscription";
            this.GoToRegisterButton.UseVisualStyleBackColor = true;
            this.GoToRegisterButton.Click += new System.EventHandler(this.GoToRegisterButton_Click);
            // 
            // registerHereLabel
            // 
            this.registerHereLabel.AutoSize = true;
            this.registerHereLabel.Location = new System.Drawing.Point(884, 26);
            this.registerHereLabel.Name = "registerHereLabel";
            this.registerHereLabel.Size = new System.Drawing.Size(113, 16);
            this.registerHereLabel.TabIndex = 11;
            this.registerHereLabel.Text = "Inscrivez vous ici :";
            // 
            // noAccountLabel
            // 
            this.noAccountLabel.AutoSize = true;
            this.noAccountLabel.Location = new System.Drawing.Point(887, 6);
            this.noAccountLabel.Name = "noAccountLabel";
            this.noAccountLabel.Size = new System.Drawing.Size(108, 16);
            this.noAccountLabel.TabIndex = 10;
            this.noAccountLabel.Text = "Pas de compte ?";
            // 
            // bddNameLabel
            // 
            this.bddNameLabel.AutoSize = true;
            this.bddNameLabel.Location = new System.Drawing.Point(457, 405);
            this.bddNameLabel.Name = "bddNameLabel";
            this.bddNameLabel.Size = new System.Drawing.Size(44, 16);
            this.bddNameLabel.TabIndex = 20;
            this.bddNameLabel.Text = "label1";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.Controls.Add(this.bddNameLabel);
            this.Controls.Add(this.CloseAppButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.GoToRegisterButton);
            this.Controls.Add(this.registerHereLabel);
            this.Controls.Add(this.noAccountLabel);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(1000, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseAppButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Button GoToRegisterButton;
        private System.Windows.Forms.Label registerHereLabel;
        private System.Windows.Forms.Label noAccountLabel;
        private System.Windows.Forms.Label bddNameLabel;
    }
}
