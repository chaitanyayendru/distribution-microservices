using System.Collections.Generic;

namespace AuthService.Domain
{
    public class ProductAgent
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Avatar { get; private set; }
        public List<string> AvailableProducts { get; private set; }

        public ProductAgent(string login, string password, string avatar, List<string> availableProducts)
        {
            Login = login;
            Password = password;
            Avatar = avatar;
            AvailableProducts = availableProducts;
        }

        public bool PasswordMatches(string passwordToTest) => Password == passwordToTest;
    }
}