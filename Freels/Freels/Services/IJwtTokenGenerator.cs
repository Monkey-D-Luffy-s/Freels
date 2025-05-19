using Microsoft.AspNetCore.Identity;

namespace Freels.Services
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(IdentityUser user);
    }
}
