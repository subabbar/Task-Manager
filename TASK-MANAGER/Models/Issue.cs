using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_MANAGER.Models
{
    public class Issue
    {   
        Issue(){
            this.Labels=new HashSet<Label>();
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int ReporterId { get; set; }
        public int AssigneId { get; set; }
        public string status { get; set; }
        public ICollection<Label> Labels { get; set; }
    }
}