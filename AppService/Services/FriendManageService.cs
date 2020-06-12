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
    public class FriendManageService
    {

        private UnitOfWork UoW = new UnitOfWork();

        public List<FriendDTO> GetByUserId(int Id)
        {

            List<FriendDTO> friendsDTO = new List<FriendDTO>();

            foreach (var friend in UoW.FriendRepo.GetAll(u => u.UserId == Id))
            {

                friendsDTO.Add(new FriendDTO
                {
                    Id= friend.Id,
                    Friend = new UserDTO
                    {
                        Id = friend.FriendUser.Id,
                        Username = friend.FriendUser.Username,
                        FirstName = friend.FriendUser.FirstName,
                        LastName = friend.FriendUser.LastName,
                        Email = friend.FriendUser.Email,
                        DOB = friend.FriendUser.DOB,
                        userRole = new RoleDTO
                        {
                            Id = friend.FriendUser.UserRole.Id,
                            RoleName = friend.FriendUser.UserRole.RoleName,
                            RoleDescription = friend.FriendUser.UserRole.RoleDescription,
                            UserCount = friend.FriendUser.UserRole.UserCount   
                        },
                        isOnline = friend.FriendUser.isOnline
                    },
                    CreatedOn = friend.CreatedOn
                });

            }

            return friendsDTO;

        }

        public bool Save(FriendDTO friendDTO)
        {
            if (friendDTO == null)
            {
                return false;
            }

            Friend friend = new Friend
            {
                UserId = friendDTO.User.Id,
                FriendId = friendDTO.Friend.Id,
                CreatedOn = friendDTO.CreatedOn            
            };

            try
            {
                UoW.FriendRepo.Insert(friend);
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
                Friend friend = UoW.FriendRepo.GetById(id);
                UoW.FriendRepo.Delete(friend);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
