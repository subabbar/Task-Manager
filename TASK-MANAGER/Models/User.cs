using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_MANAGER.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Password{ get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}