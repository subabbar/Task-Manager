using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_MANAGER.Models
{
    public class IssueUpdateRequest
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int AssigneId { get; set; }
    }
}