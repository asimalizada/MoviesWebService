using System;
using System.Text;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassHash
            (string password, out byte[] passHash, out byte[] passSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool ConfirmPassHash(string password, byte[] passHash, byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passHash[i]) return false;
                }

                return true;
            }
        }
    }
}
