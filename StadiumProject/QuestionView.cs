using StadiumProject.Controllers;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace StadiumProject
{
    public partial class QuestionView : UserControl
    {
        public event EventHandler SubmitQuestionRequested;
        public event EventHandler CancelRequested;

        private int currentQuestionId = -1;
        private bool isTrue = false;
        private readonly QuestionController questionController = new QuestionController();
        private readonly QuestionTypeController questionTypeController = new QuestionTypeController();
        private readonly AnswerController answerController = new AnswerController();
        private readonly AnsweringController answeringController = new AnsweringController();

        public QuestionView()
        {
            InitializeComponent();
            ConfigureAnswerDGV();
            LoadQuestionTypes();
            LoadWeight();
        }

        private void ConfigureAnswerDGV()
        {
            answerDGV.AutoGenerateColumns = false;
            answerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            answerDGV.MultiSelect = false;
            answerDGV.ReadOnly = true;
            answerDGV.AllowUserToAddRows = false;

            answerDGV.Columns.Clear();

            answerDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", DataPropertyName = "id", Visible = false });
            answerDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "Réponse", HeaderText = "Réponse", DataPropertyName = "content", Width = 200 });
            answerDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "Numéro de la réponse", HeaderText = "#", DataPropertyName = "num_answer", Width = 50 });
            answerDGV.Columns.Add(new DataGridViewTextBoxColumn { Name = "Bonne réponse ?", HeaderText = "Bonne réponse", DataPropertyName = "valid_answer", Width = 50 });
        }

        private void LoadQuestionTypes()
        {
            var questionTypes = questionTypeController.GetAllQuestionTypes();
            questionTypeComboBox.DataSource = questionTypes;
            questionTypeComboBox.DisplayMember = "label";
            questionTypeComboBox.ValueMember = "id";
        }

        private void LoadAnswers()
        {
            if (currentQuestionId == -1)
            {
                answerDGV.DataSource = null;
                return;
            }
            var answers = answeringController.GetAnswersByQuestionId(currentQuestionId);
            answerDGV.DataSource = answers;
        }

        private void LoadVraiFauxOptions()
        {
            vraiFauxComboBox.Items.Clear();
            vraiFauxComboBox.Items.Add("Vrai");
            vraiFauxComboBox.Items.Add("Faux");
        }

        private void LoadWeight()
        {
            weightCheckedListBox.Items.Add("1");
            weightCheckedListBox.Items.Add("2");
            weightCheckedListBox.Items.Add("3");
            weightCheckedListBox.Items.Add("8000");

            weightCheckedListBox.SetItemChecked(0, true);
        }

        public void setCreateMode()
        {
            questionLabel.Text = "Créer une nouvelle question";

            questionTitleTextBox.Text = "";
            questionTypeComboBox.Enabled = true;
            questionTypeComboBox.SelectedIndex = -1;
            answerDGV.DataSource = null;
            weightCheckedListBox.Enabled = false;

            vraiFauxLabel.Text = "Disponible uniquement pour les questions de type 'Vrai ou Faux'.";
            vraiFauxComboBox.Enabled = false;
            answerLabel.Text = "Ajoute des réponses à ta question après l'avoir créée.";
            answerTextBox.Enabled = false;
            rightAnswerCheckBox.Enabled = false;
            addAnswerButton.Enabled = false;
        }

        public void setEditMode(int questionId)
        {
            currentQuestionId = questionId;
            questionLabel.Text = "Modifier la question";

            var question = questionController.GetQuestionById(currentQuestionId);
            if (question != null)
            {
                questionTitleTextBox.Text = question.caption;
                questionTypeComboBox.SelectedValue = question.id_type;
                questionTypeComboBox.Enabled = false;
                weightCheckedListBox.Enabled = true;

                if (question.id_type == 1)
                {
                    answerLabel.Text = "Uniquement pour les questions de type QCM.";
                    answerTextBox.Enabled = false;
                    rightAnswerCheckBox.Enabled = false;
                    addAnswerButton.Enabled = false;

                    vraiFauxLabel.Text = "La bonne réponse est-elle vraie ou fausse ?";
                    vraiFauxComboBox.Enabled = true;
                    LoadVraiFauxOptions();
                }
                else if (question.id_type == 2)
                {
                    answerTextBox.Enabled = true;
                    rightAnswerCheckBox.Enabled = true;
                    addAnswerButton.Enabled = true;

                    vraiFauxComboBox.Enabled = false;

                    LoadAnswers();
                }
            }
            else
            {
                MessageBox.Show("Question introuvable.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void weightCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < weightCheckedListBox.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    weightCheckedListBox.SetItemChecked(i, false);
                }
            }
        }

        private void addAnswerButton_Click(object sender, EventArgs e)
        {
            var validAnswer = rightAnswerCheckBox.Checked;
            if (validAnswer && answeringController.CheckValidAnswer(currentQuestionId))
            {
                MessageBox.Show("Une bonne réponse a déjà été ajoutée. Supprimer là d'abord.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = answerController.CreateAnswer(answerTextBox.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var linkResult = answeringController.LinkAnswer(currentQuestionId, result.id, validAnswer);
            if (linkResult.Success)
            {
                MessageBox.Show("Réponse ajoutée.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                answerTextBox.Clear();
                LoadAnswers();
            }
            else
            {
                MessageBox.Show(linkResult.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void answerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int answerId = (int)answerDGV.Rows[e.RowIndex].Cells["id"].Value;

            var confirm = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer cette réponse ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var result = answeringController.UnlinkAnswer(currentQuestionId, answerId);
                if (result.Success)
                {
                    answerController.DeleteAnswer(answerId);
                    LoadAnswers();
                }
                else
                {
                    MessageBox.Show(result.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionTitleTextBox.Text) || questionTypeComboBox.SelectedIndex <0)
            {
                MessageBox.Show("Le texte de la question ne peut pas être vide.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentQuestionId == -1)
            {
                var result = questionController.CreateQuestion(questionTitleTextBox.Text, (int)questionTypeComboBox.SelectedValue);
                MessageBox.Show("Question créée avec succès.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int weight = 1;
                if (weightCheckedListBox.Items.Count > 0 && int.TryParse(weightCheckedListBox.CheckedItems[0].ToString(), out int parsedWeight))
                {
                    weight = parsedWeight;
                }

                var questionType = questionTypeController.GetTypeByQuestionId(currentQuestionId);
                if (questionType.id == 1)
                {
                    isTrue = (vraiFauxComboBox.SelectedIndex == 0);
                    var rightResult = answeringController.LinkAnswer(currentQuestionId, 1, isTrue);
                    var wrongResult = answeringController.LinkAnswer(currentQuestionId, 2, !isTrue);
                    answeringController.UpdateWeight(currentQuestionId, weight);
                }
                else
                {
                    if (answerDGV.Rows.Count < 2)
                    {
                        MessageBox.Show("Veuillez ajouter au moins deux réponses pour ce type de question.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (answeringController.CheckValidAnswer(currentQuestionId) == false)
                    {
                        MessageBox.Show("Veuillez ajouter une bonne réponse.", "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var result = questionController.UpdateQuestion(currentQuestionId, questionTitleTextBox.Text, questionType.id);
                    answeringController.UpdateWeight(currentQuestionId, weight);
                    MessageBox.Show("Question modifiée avec succès.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            SubmitQuestionRequested.Invoke(this, EventArgs.Empty);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelRequested.Invoke(this, EventArgs.Empty);
        }
    }
}