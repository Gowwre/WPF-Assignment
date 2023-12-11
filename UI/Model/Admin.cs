namespace UI.Model {
    public class Admin {
        public Admin(string email, string password) {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}