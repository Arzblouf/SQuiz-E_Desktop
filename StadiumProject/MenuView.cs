using System;
using System.Windows.Forms;
using StadiumProject.Controllers;

namespace StadiumProject
{
    public partial class MenuView : UserControl
    {
        public event EventHandler LogoutButtonClicked;
        public event EventHandler CreateSurveyRequested;
        public event EventHandler<int> ModifySurveyRequested;
        public event EventHandler AddQuestionRequested;

        private int selectedSurveyID = -1;

        private readonly SurveyController surveyController = new SurveyController();
        public MenuView()
        {
            InitializeComponent();
            ConfigureDGV();
        }

        private void ConfigureDGV()
        {
            DGVSurvey.AutoGenerateColumns = false;
            DGVSurvey.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVSurvey.MultiSelect = false;
            DGVSurvey.ReadOnly = true;
            DGVSurvey.AllowUserToAddRows = false;

            DGVSurvey.Columns.Clear();
            DGVSurvey.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "id", Name = "ID", Visible = false });
            DGVSurvey.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Titre", DataPropertyName = "title", Name = "Title" });
            DGVSurvey.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thème", DataPropertyName = "name", Name = "Theme" });
            DGVSurvey.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre de questions", DataPropertyName = "nb_questions", Name = "NbQuestions" });
            DGVSurvey.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Publié", DataPropertyName = "publish", Name = "Publish" });
        }

        public void LoadSurveys()
        {
            var surveys = surveyController.GetAllSurveys();
            DGVSurvey.DataSource = surveys;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadSurveys();
            }
        }
        
        private void logoutButton_Click(object sender, EventArgs e)
        {
            LogoutButtonClicked.Invoke(this, EventArgs.Empty);
        }

        private void oopsieLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Fonctionnalité en cours de développement !", "À venir...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DGVSurvey_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0)
            {
                return;
            }

            DGVSurvey.ClearSelection();
            DGVSurvey.Rows[e.RowIndex].Selected = true;

            selectedSurveyID = Convert.ToInt32(DGVSurvey.Rows[e.RowIndex].Cells["ID"].Value);
            CMSGridMenu.Show(DGVSurvey, DGVSurvey.PointToClient(Cursor.Position));
        }

        private void TSMICreateSurvey_Click(object sender, EventArgs e)
        {
            CreateSurveyRequested.Invoke(this, EventArgs.Empty);
        }

        private void TSMIModifySurvey_Click(object sender, EventArgs e)
        {
            if (selectedSurveyID < 0)
            {
                return;
            }
            ModifySurveyRequested.Invoke(this, selectedSurveyID);
        }

        private void TSMIDeleteSurvey_Click(object sender, EventArgs e)
        {
            if (selectedSurveyID < 0)
            {
                return;
            }

            var confirm = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce questionnaire ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var result = surveyController.DeleteSurvey(selectedSurveyID);
                MessageBox.Show(result.Message, result.Success ? "Questionnaire supprimé" : "Erreur", MessageBoxButtons.OK, result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                LoadSurveys();
            }
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            AddQuestionRequested.Invoke(this, EventArgs.Empty);
        }
    }
}