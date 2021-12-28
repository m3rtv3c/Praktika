using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Helper
    {

        private static PraktikaEntities s_PraktikaEntities;
        public static UserActivity currentUserActivity;
        public static UserData currentUser;
        public static PraktikaEntities GetContext()
        {
            if (s_PraktikaEntities == null)
            {
                s_PraktikaEntities = new PraktikaEntities();

            }
            return s_PraktikaEntities;
        }
        public static string MD5Hash(string password)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)))
                .Replace("-", "").ToLower();
        }
    }
}
