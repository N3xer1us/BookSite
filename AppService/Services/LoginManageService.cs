using AppService.DTOs;
using Data;
using Data.Entities;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Services
{
    public class LoginManageService
    {
        private BookSiteDBContext db = new BookSiteDBContext();

        public UserDTO CheckAccount(string Username , string Password)
        {
            User testUser = db.Users.Where(u => u.Username == Username && u.Password == Password).FirstOrDefault();

            if(testUser==null)
            {
                return null;
            }
            else
            {

                UserDTO user = new UserDTO
                {
                    Id = testUser.Id,
                    Username = testUser.Username,
                    Password = testUser.Password,
                    FirstName = testUser.FirstName,
                    LastName = testUser.LastName,
                    userRole = new RoleDTO
                    {
                        Id = testUser.UserRole.Id,
                        RoleName = testUser.UserRole.RoleName,
                        RoleDescription = testUser.UserRole.RoleDescription,
                        UserCount = testUser.UserRole.UserCount
                    },
                    Email = testUser.Email,
                    DOB = testUser.DOB,
                    isOnline = testUser.isOnline
                };

                return user;

            }
        }

    }
}
