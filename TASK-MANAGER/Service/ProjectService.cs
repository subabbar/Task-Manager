using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.Models;
using TASK_MANAGER.DbContexts;
namespace TASK_MANAGER.Service
{
    public class ProjectService : IProjectService
    {
        private ProjectContext _context;
        public ProjectService(ProjectContext context)
        {
            _context = context;
        }


        public ResponseModel SaveProject(ProjectRequest projectModel)
        {

            ResponseModel model = new ResponseModel();
            try
            {
                Project project = new Project()
                {
                    Description = projectModel.Description,
                    Creator = _context.Find<User>(projectModel.Creator),
                };
                _context.Add<Project>(project);
                model.Messsage = "Employee Inserted Successfully";
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}