namespace UI.Auth {
    public interface IAuthenticationService {
        Task<AuthenticationResult> Login(string email, string password);
    }
}