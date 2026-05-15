using Moji.Application.Interfaces;
using System.Security.Claims;
namespace Moji.API.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;
        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor= accessor;
        }
        public int UserId
        {
            get
            {
                return int.Parse(_accessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            }
        }

        public int UniversityId
        {
            get
            {
                return int.Parse(_accessor.HttpContext!.User.FindFirst("UniversityId")!.Value);
            }
        }
    }
}
