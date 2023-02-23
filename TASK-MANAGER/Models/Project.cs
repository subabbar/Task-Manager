using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_MANAGER.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Creator{ get; set; }
    }
}