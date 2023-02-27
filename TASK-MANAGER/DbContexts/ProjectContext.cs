using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASK_MANAGER.Models;

namespace TASK_MANAGER.DbContexts
{
    public class ProjectContext:DbContext
    {
        public DbSet<Project> Projects{ get; set;}
        public DbSet<Issue> Issues{get; set;}
        public DbSet<Label> Labels{get; set;}
        public DbSet<User> Users{get; set;}
        public ProjectContext(DbContextOptions options):base(options){
            
        }
    }
}