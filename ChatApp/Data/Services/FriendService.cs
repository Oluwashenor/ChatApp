using ChatApp.Data.Models.Friend;
using ChatApp.Pages;
using ChatApp.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        public List<FindFriendViewModel> FindFriends()
        {
            var users = _context.Users.ToList();
            return users.Select(x =>
            new FindFriendViewModel
            {
                Name = x.UserName,
                Id = x.Id,
                Email = x.Email
            }).ToList();
        }

        public async Task<bool> AddFriend(ClaimsPrincipal user, string partyId)
        {
            var userId = _userManager.GetUserId(user);
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
        Task<bool> AddFriend(ClaimsPrincipal user, string partyId);
        List<FindFriendViewModel> FindFriends();
    }
}
