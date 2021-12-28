using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    public partial class UserData
    {
        public int Age
        {
            get
            {
                if (DateBirth.HasValue)
                {
                    return DateTime.Now.Year - DateBirth.Value.Year;
                }
                return 0;
            }
        }

    }

    public partial class UserActivity
    {
        public TimeSpan? TimeSpent
        {
            get
            {
                if (logoutTime.HasValue)
                {
                    return (logoutTime.Value.TimeOfDay - loginTime.TimeOfDay);
                }
                return null;
            }
           
         }

        public bool IsNotReason
        {
            get
            {
                return reason == null;
            }
        }
    }
   
}
