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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            /*var result = loginController.Login(
                emailTextBox.Text,
                passwordTextBox.Text
            );

            if (result.Success)
            {
                LoginButtonClicked.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(result.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            LoginButtonClicked.Invoke(this, EventArgs.Empty);
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
    }
}
