using Backend.Services;

namespace UI.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly ICustomerService _customerService;

    public AuthenticationService(ICustomerService customerService) => this._customerService = customerService;

    public Task<AuthenticationResult> Login(string email, string password)
    {
        if (ConfigurationManager.GetAdminEmail() == email && ConfigurationManager.GetAdminPassword() == password)
        {
            var result = new AuthenticationResult
            {
                IsAuthenticated = true,
                Role = UserRole.Admin,
                Email = email
            };
            return Task.FromResult(result);
        }

        if (this._customerService.Login(email, password) != null)
        {
            var result = new AuthenticationResult
            {
                IsAuthenticated = true,
                Role = UserRole.Customer,
                Email = email
            };
            return Task.FromResult(result);
        }
        return Task.FromResult(new AuthenticationResult
        {
            IsAuthenticated = false
        });
    }
}
