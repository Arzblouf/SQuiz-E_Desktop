using System;
using System.Windows.Forms;
using StadiumProject.Controllers;

namespace StadiumProject
{
    public partial class LoginView : UserControl
    {

        public event EventHandler LoginButtonClicked;
        public event EventHandler RegisterButtonClicked;

        private readonly AuthController loginController = new AuthController();

        public LoginView()
        {
            InitializeComponent();
            bddNameLabel.Text = new Data.Database().bddName;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var result = loginController.Login(
                emailTextBox.Text,
                passwordTextBox.Text
            );

            if (result.Success)
            {
                Session.CurrentUserID = loginController.GetUserIdByEmail(emailTextBox.Text);
                LoginButtonClicked.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(result.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToRegisterButton_Click(object sender, EventArgs e)
        {
            RegisterButtonClicked.Invoke(this, EventArgs.Empty);
        }

        public void ClearFields()
        {
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseAppButton_MouseEnter(object sender, EventArgs e)
        {
            CloseAppButton.BackColor = System.Drawing.Color.Crimson;
        }

        private void CloseAppButton_MouseLeave(object sender, EventArgs e)
        {
            CloseAppButton.BackColor = System.Drawing.Color.CornflowerBlue;
        }
    }
}
