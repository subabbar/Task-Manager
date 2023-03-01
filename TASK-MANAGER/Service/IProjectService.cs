using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.Models;

namespace TASK_MANAGER.Service
{
    public interface IProjectService
    {
        ResponseModel SaveProject(ProjectRequest projectModel);
        List<Project> GetAllProjectsList();
        Project GetProjectDetailsById(int Projectid);
        ResponseModel UpdateProject(ProjectRequest projectModel,int projectId);
        ResponseModel DeleteProject(int id);
        List<Project> GetPojectByUserid(int userid);
    }
}