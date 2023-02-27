using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.Models;

namespace TASK_MANAGER.Service
{
    public interface IUserService
    {
        ResponseModel SaveUser(UserRequest userModel);

    }
}