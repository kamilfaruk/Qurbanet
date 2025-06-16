using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Qurbanet.Services.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;
                if (user?.Identity?.IsAuthenticated ?? false)
                {
                    var idString = user.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (int.TryParse(idString, out var id))
                    {
                        return id;
                    }
                }
                return null;
            }
        }
    }
}
