using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_LAB.Classes
{
    internal class DataContext
    {
        private static List<UserAccount> allUsers = new List<UserAccount>();        
        
        public static void addUser(string n, int phone, int facture, int gas)
        {
            UserAccount ua = new UserAccount
            {
                number = n,
                phoneSum = phone,
                factureSum = facture,
                gasSum = gas
            };
            allUsers.Add(ua);
        }

        public static List<UserAccount> GetContext()
        {
            return allUsers;
        }
    }
}
