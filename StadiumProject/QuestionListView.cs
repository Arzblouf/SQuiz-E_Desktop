using System;
using System.Windows.Forms;
using StadiumProject.Controllers;

namespace StadiumProject
{
    public partial class QuestionListView : UserControl
    {
        public event EventHandler BackToMenuClicked;
        public event EventHandler CreateQuestionRequested;
        public event EventHandler<int> ModifyQuestionRequested;

        private int selectedQuestionID = -1;

        private readonly QuestionController questionController = new QuestionController();
        private readonly AnsweringController answeringController = new AnsweringController();

        public QuestionListView()
        {
            InitializeComponent();
            ConfigureDGV();
        }

        private void ConfigureDGV()
        {
            DGVQuestion.AutoGenerateColumns = false;
            DGVQuestion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVQuestion.MultiSelect = false;
            DGVQuestion.ReadOnly = true;
            DGVQuestion.AllowUserToAddRows = false;

            DGVQuestion.Columns.Clear();
            DGVQuestion.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "id", Name = "ID", Visible = false });
            DGVQuestion.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Caption", DataPropertyName = "caption", Name = "Caption", Width = 300 });
            DGVQuestion.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type de la question", DataPropertyName = "label", Name = "Type" });
        }

        public void LoadQuestions()
        {
            var questions = questionController.GetAllQuestions();
            DGVQuestion.DataSource = questions;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadQuestions();
            }
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            BackToMenuClicked.Invoke(this, EventArgs.Empty);
        }

        private void DGVQuestion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0)
            {
                return;
            }

            DGVQuestion.ClearSelection();
            DGVQuestion.Rows[e.RowIndex].Selected = true;

            selectedQuestionID = Convert.ToInt32(DGVQuestion.Rows[e.RowIndex].Cells["ID"].Value);
            CMSGridQuestion.Show(DGVQuestion, DGVQuestion.PointToClient(Cursor.Position));
        }

        private void TSMICreateQuestion_Click(object sender, EventArgs e)
        {
            CreateQuestionRequested.Invoke(this, EventArgs.Empty);
        }

        private void TSMIModifyQuestion_Click(object sender, EventArgs e)
        {
            if (selectedQuestionID < 0)
            {
                return;
            }
            ModifyQuestionRequested.Invoke(this, selectedQuestionID);
        }

        private void TSMIDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (selectedQuestionID < 0)
            {
                return;
            }

            var confirm = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette question ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var linkResult = answeringController.DeleteAllByQuestion(selectedQuestionID);
                if (linkResult.Success)
                {
                    var result = questionController.DeleteQuestion(selectedQuestionID);
                    MessageBox.Show(result.Message, result.Success ? "Question supprimée" : "Erreur", MessageBoxButtons.OK, result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    LoadQuestions();
                }
                else
                {
                    MessageBox.Show(linkResult.Message, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
