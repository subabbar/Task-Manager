using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TASK_MANAGER.Models
{
    public class Issue
    {   
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int status { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public ICollection<Label> Labels { get; set; }
        public User? Assignee { get; set; }
        public User? Reporter { get; set; }

    }
}