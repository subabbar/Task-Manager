using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TASK_MANAGER.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Password{ get; set; }
        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }

        internal object Include(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}