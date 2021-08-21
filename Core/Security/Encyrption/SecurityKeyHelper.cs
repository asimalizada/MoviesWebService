using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encyrption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecuritykey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
