using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_LAB.Classes
{
    internal class AtmManager
    {
        public static string context = "";
        public static UserAccount currUser;
        public static List<bool> choosenServices = new List<bool>() { false, false, false };
    }
}
