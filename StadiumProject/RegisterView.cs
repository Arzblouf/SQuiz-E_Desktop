using System;
using System.Windows.Forms;
using StadiumProject.Controllers;

namespace StadiumProject
{
    public partial class RegisterView : UserControl
    {
        public event EventHandler RegisterButtonClicked;
        public event EventHandler BackToLoginButtonCliked;

        private readonly AuthController registerController = new AuthController();

        public RegisterView()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var result = registerController.Register(
                usernameTextBox.Text,
                emailTextBox.Text,
                passwordTextBox.Text,
                confirmPasswordTextBox.Text
            );

            MessageBox.Show(result.Message, result.Success ? "Inscription confirmée !" : "Erreur...", MessageBoxButtons.OK, result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (result.Success)
            {
                RegisterButtonClicked.Invoke(this, EventArgs.Empty);
            }
        }

        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            BackToLoginButtonCliked.Invoke(this, EventArgs.Empty);
        }
    }
}
