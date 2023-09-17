using ChatApp.Utilities.Enums;

namespace ChatApp.ViewModels
{
    public class FriendViewModel
    {

    }

    public class FindFriendViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public FriendShipStatus Status { get; set; }
    }
}
