using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TASK_MANAGER.Service;
using TASK_MANAGER.Models;

namespace TASK_MANAGER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabelController : ControllerBase
    {   
        ILabelService _labelService;

        public LabelController(ILabelService service)
        {
            _labelService = service;
        }
        
        [HttpPost]
        [Route("[action]/IssueId")]
        public IActionResult AddLabel(LabelRequest labelModel,int issueId)
        {
            try
            {
                var model = _labelService.AddLabel(labelModel,issueId);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteLabel(int Labelid)
        {
            try
            {
                var model = _labelService.DeleteLabel(Labelid);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}