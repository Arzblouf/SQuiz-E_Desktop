using StadiumProject.Data;
using StadiumProject.Models;
using System.Collections.Generic;

namespace StadiumProject.Controllers
{
    public class IssueController
    {
        private readonly IssueRepository issueRepository;

        public IssueController()
        {
            issueRepository = new IssueRepository();
        }

        public List<Issue> GetAllIssues()
        {
            return issueRepository.GetAllIssues();
        }
    }
}
