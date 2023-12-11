using DataAccess.Services;

namespace UI.Auth {
    public class AuthenticationService : IAuthenticationService {
        private readonly ICustomerService _customerService;

        public AuthenticationService(ICustomerService customerService) {
            _customerService = customerService;
        }

        public Task<AuthenticationResult> Login(string email, string password) {
            if (ConfigurationManager.GetAdminEmail() == email && ConfigurationManager.GetAdminPassword() == password) {
                AuthenticationResult result =
                    new AuthenticationResult { IsAuthenticated = true, Role = UserRole.Admin, Email = email };
                return Task.FromResult(result);
            }

            if (_customerService.Login(email, password) != null) {
                AuthenticationResult result =
                    new AuthenticationResult { IsAuthenticated = true, Role = UserRole.Customer, Email = email };
                return Task.FromResult(result);
            }

            return Task.FromResult(new AuthenticationResult { IsAuthenticated = false });
        }
    }
}