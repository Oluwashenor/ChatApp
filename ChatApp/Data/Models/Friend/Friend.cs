using ChatApp.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Data.Models.Friend
{
    public class Friend : BaseModel
    {
        [Required]
        public string PartyA { get; set; }
        [Required]
        public string PartyB { get; set; }
        public FriendShipStatus Status { get; set; }
    }
}
