using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TASK_MANAGER.Models
{
    public class Label
    {   
        [Key]
        public int Id { get; set; }
        public string desc { get; set; }
        public Issue? Issue { get; set; }
    }
}