namespace UI.Auth {
    public class AuthenticationResult {
        public bool IsAuthenticated { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
    }
}