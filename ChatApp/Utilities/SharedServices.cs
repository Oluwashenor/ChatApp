using System.Security.Claims;

namespace ChatApp.Utilities
{
    public static class SharedServices
    {
        private readonly static HttpContextAccessor httpContextAccessor = new();
        public static string GetUserId()
        {
            var httpAccessor = httpContextAccessor.HttpContext;
            var claims = httpAccessor.User.Identity as ClaimsIdentity;
            return claims.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
