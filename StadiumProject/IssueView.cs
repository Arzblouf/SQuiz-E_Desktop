using StadiumProject.Controllers;
using System;
using System.Windows.Forms;

namespace StadiumProject
{
    public partial class IssueView : UserControl
    {
        public event EventHandler BackToMenuRequested;

        private readonly IssueController issueController = new IssueController();
        public IssueView()
        {
            InitializeComponent();
            ConfigureDGV();
        }

        public void ConfigureDGV()
        {
            IssueDGV.AutoGenerateColumns = false;
            IssueDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            IssueDGV.MultiSelect = false;
            IssueDGV.ReadOnly = true;
            IssueDGV.AllowUserToAddRows = false;

            IssueDGV.Columns.Clear();
            IssueDGV.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "id", Name = "ID", Visible = false });
            IssueDGV.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description", DataPropertyName = "description", Name = "Description", Width = 400});
            IssueDGV.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Utilisateur", DataPropertyName = "username", Name = "Utilisateur"});
        }

        public void LoadIssues()
        {
            var issues = issueController.GetAllIssues();
            IssueDGV.DataSource = issues;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadIssues();
            }
        }

        private void BacktoMenuButton_Click(object sender, EventArgs e)
        {
            BackToMenuRequested.Invoke(this, EventArgs.Empty);
        }
    }
}
