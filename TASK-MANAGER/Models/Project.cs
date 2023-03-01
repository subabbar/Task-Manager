using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TASK_MANAGER.Models
{
    public class Project
    {  
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public int  Creator{ get; set; }

        public ICollection<Issue>? Issues { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

    }
}