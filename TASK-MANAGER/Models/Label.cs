using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_MANAGER.Models
{
    public class Label
    {   
        Label
        (){
            this.Issues=new HashSet<Issue>();
        }
        public int Id { get; set; }
        public string desc { get; set; }
        public ICollection<Issue> Issues { get; set; }
    }
}