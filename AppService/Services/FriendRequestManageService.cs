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
    public class FriendRequestManageService
    {

        private UnitOfWork UoW = new UnitOfWork();

        public List<FriendRequestDTO> GetByUserId(int Id)
        {

            List<FriendRequestDTO> friendRequestsDTO = new List<FriendRequestDTO>();

            foreach (var friendRequest in UoW.FriendRequestRepo.GetAll(u => u.ReceiverId == Id))
            {

                friendRequestsDTO.Add(new FriendRequestDTO
                {
                    Id= friendRequest.Id,
                    Sender= new UserDTO
                    {
                        Id = friendRequest.Sender.Id,
                        Username = friendRequest.Sender.Username,
                        FirstName = friendRequest.Sender.FirstName,
                        LastName = friendRequest.Sender.LastName,
                        Email = friendRequest.Sender.Email,
                        DOB = friendRequest.Sender.DOB,
                        userRole = new RoleDTO
                        {
                            Id = friendRequest.Sender.UserRole.Id,
                            RoleName = friendRequest.Sender.UserRole.RoleName,
                            RoleDescription = friendRequest.Sender.UserRole.RoleDescription,
                            UserCount = friendRequest.Sender.UserRole.UserCount
                        },
                        isOnline = friendRequest.Sender.isOnline
                    },
                    Receiver = new UserDTO
                    {
                        Id = friendRequest.Receiver.Id,
                        Username = friendRequest.Receiver.Username,
                        FirstName = friendRequest.Receiver.FirstName,
                        LastName = friendRequest.Receiver.LastName,
                        Email = friendRequest.Receiver.Email,
                        DOB = friendRequest.Receiver.DOB,
                        userRole = new RoleDTO
                        {
                            Id = friendRequest.Receiver.UserRole.Id,
                            RoleName = friendRequest.Receiver.UserRole.RoleName,
                            RoleDescription = friendRequest.Receiver.UserRole.RoleDescription,
                            UserCount = friendRequest.Receiver.UserRole.UserCount
                        },
                        isOnline = friendRequest.Receiver.isOnline
                    },
                    Message= friendRequest.Message,
                    SentOn = friendRequest.SentOn
                });

            }

            return friendRequestsDTO;

        }

        public bool Save(FriendRequestDTO friendRequestDTO)
        {
            if (friendRequestDTO == null)
            {
                return false;
            }

            FriendRequest friendRequest = new FriendRequest
            {
                SenderId = friendRequestDTO.Sender.Id,
                ReceiverId = friendRequestDTO.Receiver.Id,
                Message= friendRequestDTO.Message,
                SentOn = friendRequestDTO.SentOn
            };

            try
            {
                UoW.FriendRequestRepo.Insert(friendRequest);
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
                FriendRequest friendRequest = UoW.FriendRequestRepo.GetById(id);
                UoW.FriendRequestRepo.Delete(friendRequest);
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
