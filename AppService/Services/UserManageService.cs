using AppService.DTOs;
using Data.Entities;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Services
{
    public class UserManageService
    {

        private UnitOfWork UoW = new UnitOfWork();

        public List<UserDTO> Get()
        {
            List<UserDTO> usersDTO = new List<UserDTO>();

            foreach(var user in UoW.UserRepo.GetAll())
            {

                usersDTO.Add(new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    DOB = user.DOB,
                    userRole = new RoleDTO
                    {
                        Id = user.UserRole.Id,
                        RoleName = user.UserRole.RoleName,
                        RoleDescription = user.UserRole.RoleDescription,
                        UserCount = user.UserRole.UserCount
                    },
                    isOnline = user.isOnline
                });

            }

            return usersDTO;

        }

        public UserDTO GetById(int Id)
        {
            UserDTO userDTO = new UserDTO();

            User user = UoW.UserRepo.GetById(Id);

            if (user != null)
            {
                userDTO = new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    DOB = user.DOB,
                    userRole = new RoleDTO
                    {
                        Id = user.UserRole.Id,
                        RoleName = user.UserRole.RoleName,
                        RoleDescription = user.UserRole.RoleDescription,
                        UserCount = user.UserRole.UserCount
                    },
                    isOnline = user.isOnline
                };
            }

            return userDTO;
        }

        public bool Save(UserDTO userDTO)
        {
            if(userDTO == null)
            {
                return false;
            }

            User user = new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                DOB = userDTO.DOB,
                RoleId = userDTO.userRole.Id,
                isOnline = userDTO.isOnline
            };

            try
            {
                UoW.UserRepo.Insert(user);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(UserDTO userDTO)
        {

           if(userDTO == null)
            {
                return false;
            }

            User user = new User
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                DOB = userDTO.DOB,
                RoleId = userDTO.userRole.Id,
                isOnline = userDTO.isOnline
            };

            try
            {
              
                  UoW.UserRepo.Update(user);
                  UoW.Save();
                  return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                   User user = UoW.UserRepo.GetById(id);
                   UoW.UserRepo.Delete(user);
                   UoW.Save();
                   return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetUserStatus(UserDTO userDTO , bool status)
        {
            if (userDTO == null)
            {
                return false;
            }

            userDTO.isOnline = status;

            if (Update(userDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
