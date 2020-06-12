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
    public class RoleManageService
    {

        private UnitOfWork UoW = new UnitOfWork();

        public List<RoleDTO> Get()
        {
            List<RoleDTO> rolesDTO = new List<RoleDTO>();

            foreach (var role in UoW.RoleRepo.GetAll())
            {

                rolesDTO.Add(new RoleDTO
                {
                    Id = role.Id,
                    RoleName = role.RoleName,
                    RoleDescription = role.RoleDescription,
                    UserCount = role.UserCount
                });

            }

            return rolesDTO;

        }

        public RoleDTO GetById(int Id)
        {
            RoleDTO roleDTO = new RoleDTO();

            Role role = UoW.RoleRepo.GetById(Id);

            if (role != null)
            {
                roleDTO = new RoleDTO
                {
                    Id= role.Id,
                    RoleName = role.RoleName,
                    RoleDescription = role.RoleDescription,
                    UserCount = role.UserCount
                };
            }

            return roleDTO;
        }

        public bool Save(RoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                return false;
            }

            Role role = new Role
            {
                RoleName = roleDTO.RoleName,
                RoleDescription = roleDTO.RoleDescription,
                UserCount = roleDTO.UserCount
            };

            try
            {
                UoW.RoleRepo.Insert(role);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(RoleDTO roleDTO)
        {

            if (roleDTO == null)
            {
                return false;
            }

            Role role = new Role
            {
                Id = roleDTO.Id,
                RoleName = roleDTO.RoleName,
                RoleDescription = roleDTO.RoleDescription,
                UserCount = roleDTO.UserCount
            };

            try
            {

                UoW.RoleRepo.Update(role);
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
                Role role = UoW.RoleRepo.GetById(id);
                UoW.RoleRepo.Delete(role);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateRoleUserInfo(RoleDTO role)
        {

            if (role == null)
            {
                return false;
            }

            role.UserCount = UoW.UserRepo.GetAll(u => u.RoleId == role.Id).Count();

            if (Update(role))
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
