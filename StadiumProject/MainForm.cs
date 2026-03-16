using System.Windows.Forms;

namespace StadiumProject
{
    public partial class MainForm : Form
    {
        private readonly LoginView loginView = new LoginView { Dock = DockStyle.Fill };
        private readonly RegisterView registerView = new RegisterView { Dock = DockStyle.Fill };
        private readonly MenuView menuView = new MenuView { Dock = DockStyle.Fill };
        private readonly SurveyView surveyView = new SurveyView { Dock = DockStyle.Fill };
        private readonly QuestionView questionView = new QuestionView { Dock = DockStyle.Fill };
        private readonly QuestionListView questionListView = new QuestionListView { Dock = DockStyle.Fill };
        private readonly IssueView issueView = new IssueView { Dock = DockStyle.Fill };

        public MainForm()
        {
            InitializeComponent();

            loginView.RegisterButtonClicked += (s, e) => ShowView(registerView);
            loginView.LoginButtonClicked += (s, e) => ShowView(menuView);

            registerView.BackToLoginButtonCliked += (s, e) => ShowView(loginView);
            registerView.RegisterButtonClicked += (s, e) =>
            {
                loginView.ClearFields();
                ShowView(loginView);
            };

            menuView.LogoutButtonClicked += (s, e) =>
            {
                loginView.ClearFields();
                ShowView(loginView);
            };
            menuView.CreateSurveyRequested += (s, e) =>
            {
                surveyView.setCreateMode();
                ShowView(surveyView);
            };
            menuView.ModifySurveyRequested += (s, surveyID) =>
            {
                surveyView.setEditMode(surveyID);
                ShowView(surveyView);
            };
            menuView.AddQuestionRequested += (s, e) => ShowView(questionListView);
            menuView.ToIssueRequested += (s, e) => ShowView(issueView);

            surveyView.SubmitSurveyRequested += (s, e) => ShowView(menuView);
            surveyView.CancelRequested += (s, e) => ShowView(menuView);

            questionView.SubmitQuestionRequested += (s, e) => ShowView(questionListView);
            questionView.CancelRequested += (s, e) => ShowView(questionListView);

            questionListView.BackToMenuClicked += (s, e) => ShowView(menuView);
            questionListView.CreateQuestionRequested += (s, e) =>
            {
                questionView.setCreateMode();
                ShowView(questionView);
            };
            questionListView.ModifyQuestionRequested += (s, questionID) =>
            {
                questionView.setEditMode(questionID);
                ShowView(questionView);
            };

            issueView.BackToMenuRequested += (s, e) => ShowView(menuView);

            this.Controls.Add(loginView);
            this.Controls.Add(registerView);
            this.Controls.Add(menuView);
            this.Controls.Add(surveyView);
            this.Controls.Add(questionView);
            this.Controls.Add(questionListView);
            this.Controls.Add(issueView);

            ShowView(loginView);
        }

        private void ShowView(UserControl view)
        {
            loginView.Visible = false;
            registerView.Visible = false;
            menuView.Visible = false;
            surveyView.Visible = false;
            questionView.Visible = false;
            questionListView.Visible = false;
            issueView.Visible = false;

            view.Visible = true;
            view.BringToFront();
        }
    }
}
