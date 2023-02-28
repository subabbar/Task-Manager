using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TASK_MANAGER.Models;
using TASK_MANAGER.Service;

namespace TASK_MANAGER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        IIssueService _issueService;

        public IssueController(IIssueService service)
        {
            _issueService = service;
        }

        [HttpPost]
        [Route("[action]/projectId/ReporterId")]
        public IActionResult SaveIssue(IssueRequest issueModel,int projectId,int ReporterId)
        {
            try
            {
                var model = _issueService.SaveIssue(issueModel,projectId,ReporterId);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAllIssues()
        {
            try
            {
                var issues = _issueService.GetAllIssuesList();
                if (issues == null) return NotFound();
                return Ok(issues);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetIssueById(int id)
        {
            try
            {
                var Issues = _issueService.GetIssueDetailsById(id);
                if (Issues == null) return NotFound();
                return Ok(Issues);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteIssue(int id)
        {
            try
            {
                var model = _issueService.DeleteIssue(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]/issueId")]
        public IActionResult UpdateIssue(IssueUpdateRequest issueModel, int issueId)
        {
            try
            {
                var model = _issueService.UpdateProject(issueModel, issueId);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]/AssigneId/ProjectId")]
        public IActionResult AssignIssueToUser(int AssigneeId,int ProjectId)
        {
            try
            {
                var model = _issueService.AssignIssueToUser(AssigneeId,ProjectId);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}