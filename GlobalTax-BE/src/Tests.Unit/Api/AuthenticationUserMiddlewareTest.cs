using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace GlobalTax.Tests.Unit.Api;

public class AuthenticationUserMiddlewareTest
{
    //[Fact]
    //public async Task AuthenticatedUserMiddleware_WhenUserIsAuthenticated_ShouldPopulateUserInfoToAuthenticatedUserService()
    //{
    //    AuthenticatedUserService authenticatedUserService = new();
    //    var middleware = new AuthenticatedUserMiddleware(next: _ => Task.CompletedTask);
    //    var identity = new ClaimsIdentity(new List<Claim>
    //    {
    //        new(ClaimTypes.Name, "testuser"),
    //        new("NWUserId", "testnwuserid"),
    //        new(ClaimTypes.Role, "testrole"),
    //        new("act", "testactor"),
    //        new("permission", "permission1"),
    //        new("permission", "permission2")
    //    }, "Custom");
    //    var context = new DefaultHttpContext()
    //    {
    //        User = new ClaimsPrincipal(identity)
    //    };
    //    await middleware.InvokeAsync(context, authenticatedUserService);
        
    //    Assert.Equal("testuser", authenticatedUserService.Username);
    //    Assert.Equal(2, authenticatedUserService.UserPermissions!.Count);
    //    Assert.Equal("testrole", authenticatedUserService.UserRole);
    //    Assert.Equal("testactor", authenticatedUserService.Actor);
    //    Assert.Equal("testnwuserid", authenticatedUserService.NwUserId);
    //}
    
    //[Fact]
    //public async Task AuthenticatedUserMiddleware_WhenUserIsNotAuthenticated_ShouldNotPopulateUserInfoToAuthenticatedUserService()
    //{
    //    AuthenticatedUserService authenticatedUserService = new();
    //    var middleware = new AuthenticatedUserMiddleware(next: _ => Task.CompletedTask);
        
    //    var context = new DefaultHttpContext();
        
    //    await middleware.InvokeAsync(context, authenticatedUserService);
        
    //    Assert.Null(authenticatedUserService.Username);
    //    Assert.Null(authenticatedUserService.UserPermissions);
    //    Assert.Null(authenticatedUserService.UserRole);
    //    Assert.Null(authenticatedUserService.Actor);
    //    Assert.Null(authenticatedUserService.NwUserId);
    //}
}