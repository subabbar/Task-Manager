using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.Models;

namespace TASK_MANAGER.Service
{
    public interface IIssueService
    {
        ResponseModel AssignIssueToUser(int assigneeId,int ProjectId);
        ResponseModel DeleteIssue(int id);
        List<Issue> GetAllIssuesList();
        Issue GetIssueDetailsById(int id);
        ResponseModel SaveIssue(IssueRequest issueModel,int projectId,int ReporterId);
        ResponseModel UpdateProject(IssueUpdateRequest issueModel, int issueId);
    }
}