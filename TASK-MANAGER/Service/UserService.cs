using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.Models;
using Microsoft.EntityFrameworkCore;
using TASK_MANAGER.DbContexts;

namespace TASK_MANAGER.Service
{
    public class UserService : IUserService
    {
        private ProjectContext _context;
        public UserService(ProjectContext context)
        {
            _context = context;
        }

        public ResponseModel SaveUser(UserRequest userModel)
        {

            ResponseModel model = new ResponseModel();
            try
            {
                User user = new User()
                {
                    username = userModel.username,
                    Name = userModel.Name,
                    Password = userModel.Password,
                };
                _context.Add<User>(user);
                model.Messsage = "User Inserted Successfully";
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


        public List<User> GetusersList()
        {
            List<User> userList;
            try
            {
                userList = _context.Users.Include(z => z.Projects).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }

        public User GetUserDetailsById(int id)
        {
            User user;
            try
            {
                user = _context.Users.Where(p => p.Id == id)
            .Include(p => p.Projects)
            .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }
    }
}


