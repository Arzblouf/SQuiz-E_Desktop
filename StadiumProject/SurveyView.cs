using System;
using System.Windows.Forms;
using StadiumProject.Controllers;

namespace StadiumProject
{
    public partial class SurveyView : UserControl
    {
        public event EventHandler SubmitSurveyRequested;
        public event EventHandler CancelRequested;

        private int currentSurveyID = -1;
        private readonly ThemeController themeController = new ThemeController();
        private readonly SurveyController surveyController = new SurveyController();
        private readonly QuestionController questionController = new QuestionController();

        public SurveyView()
        {
            InitializeComponent();
            ConfigureQuestionDGV();
        }

        private void ConfigureQuestionDGV()
        {
            surveyQuestionDGV.AutoGenerateColumns = false;
            surveyQuestionDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            surveyQuestionDGV.MultiSelect = false;
            surveyQuestionDGV.ReadOnly = true;
            surveyQuestionDGV.AllowUserToAddRows = false;

            surveyQuestionDGV.Columns.Clear();

            surveyQuestionDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "num_question", HeaderText = "#", DataPropertyName = "num_question", Width = 50 });
            surveyQuestionDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_question", HeaderText = "ID", DataPropertyName = "id_question", Visible = false });
            surveyQuestionDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "caption", HeaderText = "Question", DataPropertyName = "caption", Width = 100 });
            surveyQuestionDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "label", HeaderText = "Type de question", DataPropertyName = "label", Width = 100});
            }

        private void LoadSurveyQuestions()
        {
            if (currentSurveyID == -1)
            {
                surveyQuestionDGV.DataSource = null;
                return;
            }
            var questions = questionController.GetSurveyQuestions(currentSurveyID);
            surveyQuestionDGV.DataSource = questions;
            LoadAvailableQuestions();
        }

        private void LoadAvailableQuestions()
        {
            if (currentSurveyID == -1)
            {
                var allQuestions = questionController.GetAllQuestions();
                questionComboBox.DataSource = allQuestions;
            }
            else
            {
                var availableQuestions = questionController.getAvailableQuestions(currentSurveyID);
                questionComboBox.DataSource = availableQuestions;
            }
            questionComboBox.DisplayMember = "caption";
            questionComboBox.ValueMember = "id";
        }

        public void setCreateMode()
        {
            SurveyLabel.Text = " Crée ton propre questionnaire ici :";

            titleTextBox.Text = "";
            themeComboBox.SelectedIndex = -1;
            publishCheckBox.Checked = false;

            surveyQuestionDGV.DataSource = null;
            addQuestionButton.Enabled = false;
            questionComboBox.Enabled = false;
            surveyQuestionLabel.Text = "Ajoute des questions à ton questionnaire après l'avoir créé.";

            LoadThemes();
        }

        public void setEditMode(int surveyID)
        {
            currentSurveyID = surveyID;
            SurveyLabel.Text = " Modifie ton questionnaire ici :";

            addQuestionButton.Enabled = true;
            questionComboBox.Enabled = true;
            surveyQuestionLabel.Text = "Gère les questions de ton questionnaire :";
            LoadThemes();

            var survey = surveyController.GetSurveyById(surveyID);
            if (survey != null)
            {
                titleTextBox.Text = survey.title;
                publishCheckBox.Checked = survey.publish;
                themeComboBox.SelectedValue = survey.id_theme;
                LoadSurveyQuestions();
            }
            else
            {
                MessageBox.Show("Sondage introuvable.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThemes()
        {
            var themes = themeController.GetAllThemes();
            themeComboBox.DataSource = themes;
            themeComboBox.DisplayMember = "name";
            themeComboBox.ValueMember = "id";
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            if (currentSurveyID == -1 || questionComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un questionnaire et une question.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int questionID = (int)questionComboBox.SelectedValue;
            var result = questionController.AddQuestionToSurvey(currentSurveyID, questionID);
            surveyController.UpdateNbQuestions(currentSurveyID);
            if (result.Success)
            {
                LoadSurveyQuestions();
            }
            else
            {
                MessageBox.Show(result.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void surveyQuestionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentSurveyID == -1)
            {
                return;
            }

            int questionID = (int)surveyQuestionDGV.Rows[e.RowIndex].Cells["id_question"].Value;
            string questionCaption = surveyQuestionDGV.Rows[e.RowIndex].Cells["caption"].Value.ToString();

            var confirm = MessageBox.Show($"Êtes-vous sûr de vouloir retirer la question \"{questionCaption}\" du sondage ?", "Confirmer le retrait", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var result = questionController.RemoveQuestionFromSurvey(currentSurveyID, questionID);
                if (result.Success)
                {
                    LoadSurveyQuestions();
                }
                else
                {
                    MessageBox.Show(result.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveSurveyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || themeComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentSurveyID == -1)
            {
                surveyController.CreateSurvey(titleTextBox.Text, (int)themeComboBox.SelectedValue, publishCheckBox.Checked);
                MessageBox.Show("Questionnaire crée avec success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                surveyController.UpdateSurvey(currentSurveyID, titleTextBox.Text, (int)themeComboBox.SelectedValue, publishCheckBox.Checked);
                MessageBox.Show("Questionnaire modifié avec success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SubmitSurveyRequested.Invoke(this, EventArgs.Empty);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelRequested.Invoke(this, EventArgs.Empty);
        }
    }
}
