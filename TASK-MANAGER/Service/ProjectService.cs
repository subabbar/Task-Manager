using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.Models;
using TASK_MANAGER.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                User user;
                user = _context.Find<User>(projectModel.Creator);
                Project project = new Project()
                {
                    Creator = projectModel.Creator,
                    Description = projectModel.Description,
                    User = user
                };
                _context.Add<Project>(project);
                _context.SaveChanges();
                Console.WriteLine("Creater of Project " + project.Id);
                user.Projects.Add(project);
                Console.WriteLine("Creater of Project ");
                Console.WriteLine("Creater of Project " + project.Creator);
                model.Messsage = "Project Inserted Successfully";
                _context.SaveChanges();
                // Console.WriteLine("Creater of Project "+project.Creator.Id);
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }



        public List<Project> GetAllProjectsList()
        {
            List<Project> projectList;
            try
            {
                projectList = _context.Projects.Include(z => z.User).Include(x => x.Issues).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return projectList;
        }

        public Project GetProjectDetailsById(int Projectid)
        {
            Project project;
            try
            {
                project = _context.Projects.Where(p => p.Id == Projectid)
            .Include(p => p.User)
            .Include(p => p.Issues)
            .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return project;
        }

        public ResponseModel UpdateProject(ProjectRequest projectModel, int projectId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User user;
                user = _context.Find<User>(projectModel.Creator);
                if (user == null)
                {
                    model.IsSuccess = false;
                    model.Messsage = "Enter the valid Creator Id";
                return model;
                }
                Project project = _context.Find<Project>(projectId);

                if (project.Creator != projectModel.Creator)
                {
                    User user1;
                    user1 = _context.Find<User>(project.Creator);
                    user1.Projects.Remove(project);
                    project.Creator = projectModel.Creator;
                    project.User=user;
                    Console.WriteLine("of Project ");
                    // user.Projects.Add(project);
                    // Console.WriteLine("Creater of Project " + user1.Projects.Count);
                }
                project.Description = projectModel.Description;
                _context.Update<Project>(project);
                model.Messsage = "Employee Inserted Successfully";
                _context.SaveChanges();
                // Console.WriteLine("Creater of Project "+project.Creator.Id);
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteProject(int projectId)
        {
            ResponseModel model = new ResponseModel();
        try {
            Project _temp = GetProjectDetailsById(projectId);
            User user;
            user = _context.Find<User>(_temp.Creator);
            if (_temp != null) {
                _context.Remove < Project > (_temp);
                user.Projects.Remove(_temp);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "Project Deleted Successfully";
            } else {
                model.IsSuccess = false;
                model.Messsage = "Project Not Found";
            }
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
        }
    }

}