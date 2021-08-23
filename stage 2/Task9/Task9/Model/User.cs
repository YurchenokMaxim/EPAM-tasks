namespace Task9
{
    public class User
    {
        public string username { get;private set; }

        public string password { get;private set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
