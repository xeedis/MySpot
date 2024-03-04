using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySpot.Application.DTO;
using MySpot.Infrastructure;
using MySpot.Infrastructure.Auth;
using MySpot.Infrastructure.Time;
using Xunit;

namespace MySpot.Tests.Integration.Controllers;

public abstract class ControllerTestBase : IClassFixture<OptionsProvider>
{
    private readonly Authenticator _authenticator;
    protected HttpClient Client { get; }

    protected JwtDto Authorize(Guid userId, string role)
    {
        var jwt = _authenticator.CreateToken(userId, role);
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.AccessToken);

        return jwt;
    }
    
    public ControllerTestBase(OptionsProvider optionsProvider)
    {
        var authOptions = optionsProvider.Get<AuthOptions>("auth");
        _authenticator = new Authenticator(new OptionsWrapper<AuthOptions>(authOptions), new Clock());
        var app = new MySpotTestApp(ConfigureServices);
        Client = app.Client;
    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {
        
    }
}