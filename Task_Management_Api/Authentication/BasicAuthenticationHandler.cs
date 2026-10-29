using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Task_Management_Api.Data;

namespace Task_Management_Api.Authentication;

public class BasicAuthenticationHandler
    : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly TaskManagementDbContext _dbContext;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        TaskManagementDbContext dbContext)
        : base(options, logger, encoder)
    {
        _dbContext = dbContext;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
        {
            return AuthenticateResult.NoResult();
        }

        if (!AuthenticationHeaderValue.TryParse(
                authorizationHeader,
                out var headerValue) ||
            !string.Equals(
                headerValue.Scheme,
                "Basic",
                StringComparison.OrdinalIgnoreCase))
        {
            return AuthenticateResult.NoResult();
        }

        if (string.IsNullOrWhiteSpace(headerValue.Parameter))
        {
            return AuthenticateResult.Fail("Invalid Authorization header.");
        }

        string username;
        string password;

        try
        {
            var credentialBytes = Convert.FromBase64String(headerValue.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes);
            var separatorIndex = credentials.IndexOf(':');

            if (separatorIndex <= 0)
            {
                return AuthenticateResult.Fail("Invalid credentials format.");
            }

            username = credentials[..separatorIndex];
            password = credentials[(separatorIndex + 1)..];
        }
        catch (FormatException)
        {
            return AuthenticateResult.Fail("Invalid Base64 credentials.");
        }

        var user = await _dbContext.Users
            .SingleOrDefaultAsync(u => u.Username == username);

        if (user is null || !user.Active)
        {
            return AuthenticateResult.Fail("Invalid username or password.");
        }

        var passwordIsValid = BCrypt.Net.BCrypt.Verify(
            password,
            user.PasswordHash);

        if (!passwordIsValid)
        {
            return AuthenticateResult.Fail("Invalid username or password.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
