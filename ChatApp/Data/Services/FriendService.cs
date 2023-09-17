using ChatApp.Data.Models.Friend;
using ChatApp.Pages;
using ChatApp.Utilities;
using ChatApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ChatApp.Data.Services
{
    public class FriendService : IFriendService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public FriendService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<List<FindFriendViewModel>> FindFriends()
        {
            var userId = SharedServices.GetUserId();
            var users = _context.Users.Where(x=>x.Id != userId).ToList();
            var friends = await _context.Friends.Where(x => x.PartyA == userId).ToListAsync();
            return users.Select(x =>
            {
                var userFriend = friends.FirstOrDefault(f => f.PartyB == x.Id);
                return new FindFriendViewModel
                {
                    Name = x.UserName,
                    Id = x.Id,
                    Email = x.Email,
                };
            }).ToList();
        }

        public async Task<bool> AddFriend(string userId, string partyId)
        {
            var friendRequest = new Friend
            {
                PartyA = userId,
                PartyB = partyId,
                Status = Utilities.Enums.FriendShipStatus.Pending
            };
            await _context.AddAsync(friendRequest);
            return await _context.SaveChangesAsync() > 0;
        }
    }

    public interface IFriendService
    {
        Task<bool> AddFriend(string userId, string partyId);
        List<FindFriendViewModel> FindFriends();
    }
}
