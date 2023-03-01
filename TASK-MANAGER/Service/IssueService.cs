using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASK_MANAGER.DbContexts;
using TASK_MANAGER.Models;
using TASK_MANAGER.Service;

namespace TASK_MANAGER.Service
{
    public class IssueService : IIssueService
    {
        private ProjectContext _context;
        public IssueService(ProjectContext context)
        {
            _context = context;
        }

        public ResponseModel AssignIssueToUser(int assigneeId,int IssueId)
        {    
            ResponseModel model = new ResponseModel();
            UserService userService;
             Issue temp = GetIssueDetailsById(IssueId);
             User user = _context.Find<User>(assigneeId);
             temp.Assignee=user;
             _context.SaveChanges();
              model.IsSuccess = true;
              model.Messsage = "Issue assigned to User";
              return model;
        }

        public ResponseModel DeleteIssue(int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Issue _temp = GetIssueDetailsById(id);
                Project project;
                project = _context.Find<Project>(_temp.ProjectId);
                if (_temp != null)
                {
                    _context.Remove<Issue>(_temp);
                    // user.Projects.Remove(_temp);
                    project.Issues.Remove(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Issue Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Issue Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public List<Issue> GetAllIssuesList()
        {
            List<Issue> issueList;
            try
            {
                issueList = _context.Issues.Include(x => x.Project).Include(p =>p.Assignee).Include(p=>p.Reporter).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return issueList;
        }

        public Issue GetIssueDetailsById(int id)
        {
            Issue issue;
            try
            {
                issue = _context.Issues.Where(p => p.Id == id)
            .Include(p => p.Project)
            .Include(p =>p.Assignee)
            .Include(p=>p.Reporter)
            .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return issue;
        }

        public ResponseModel ResetStatus(int issueid,int statusid)
        {
            ResponseModel model = new ResponseModel();
            try
            {   
                string[] Status={"open","InReview","CodeComplete","QA Testing ","Done Status"};
                Issue issue;
                issue=_context.Find<Issue>(issueid);
                if(statusid<0 && statusid>4){
                    model.Messsage = "Enter valid status id";
                    return model;
                }
                if(statusid>issue.status){
                    model.Messsage = "Complete the status in right order";
                    return model;
                }
                issue.status=issue.status;
                model.Messsage = "Issue status updated Successfully  Status:  "+ Status[issue.status];
                _context.SaveChanges();
                // Console.WriteLine("Creater of Project "+project.Creator.Id);
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel SaveIssue(IssueRequest issueModel, int ProjectId,int ReporterId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Project project;
                project = _context.Find<Project>(ProjectId);
                User user;
                user=_context.Find<User>(ReporterId);
                Issue issue = new Issue()
                {
                    Type = issueModel.Type,
                    Description = issueModel.Description,
                    status = 0,
                    Reporter=user,
                    Project = project

                };

                _context.Add<Issue>(issue);
                project.Issues.Add(issue);
                model.Messsage = "Issue Inserted Successfully";
                _context.SaveChanges();
                // Console.WriteLine("Creater of Project "+project.Creator.Id);rojectId
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel UpdateProject(IssueUpdateRequest issueModel, int issueId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Issue issue;
                issue=_context.Find<Issue>(issueId);


                issue.Type=issueModel.Type;
                issue.Description=issueModel.Description;

                _context.Update<Issue>(issue);
                model.Messsage = "Issue Update Successfully";
                _context.SaveChanges();
                // Console.WriteLine("Creater of Project "+project.Creator.Id);
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel UpdateStatus(int issueid)
        {
            ResponseModel model = new ResponseModel();
            try
            {   
                string[] Status={"open","InReview","CodeComplete","QA Testing ","Done Status"};
                Issue issue;
                issue=_context.Find<Issue>(issueid);
                if(issue.status==4){
                    model.Messsage = "Issue is resolved" + Status[issue.status];
                    return model;
                }
                issue.status=issue.status+1;
                model.Messsage = "Issue status updated Successfully  Stateus:  "+ Status[issue.status];
                _context.SaveChanges();
                // Console.WriteLine("Creater of Project "+project.Creator.Id);
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}