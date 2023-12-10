namespace UI.Model;

public class Admin
{
    public string Email { get; set; }
    public string Password { get; set; }

    public Admin(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }
}
