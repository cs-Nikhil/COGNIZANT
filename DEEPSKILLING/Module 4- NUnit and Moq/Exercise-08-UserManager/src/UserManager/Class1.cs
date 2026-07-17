using System;
using System.Collections.Generic;

namespace UserManager
{
    public class UserManagerService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public bool RegisterUser(string username, string password)
        {
            if (_users.ContainsKey(username))
            {
                return false;
            }

            _users[username] = password;
            return true;
        }

        public bool ValidateUser(string username, string password)
        {
            string storedPassword;
            return _users.TryGetValue(username, out storedPassword) && storedPassword == password;
        }
    }
}
