using System.Net;
using System.Net.Http.Json;
using discipline.ui.communication.http.Users;
using discipline.ui.communication.http.Users.Requests;
using discipline.ui.infrastructure.Auth.Tokens.Abstractions;
using discipline.ui.infrastructure.Auth.Tokens.DTOs;
using discipline.ui.infrastructure.Users.SignIn;
using NSubstitute;
using Shouldly;
using Xunit;

namespace discipline.ui.infrastructure.tests.Users.SignIn;

public sealed class SignInFacadeTests
{
    [Fact]
    public async Task SignIn_ShouldReturnTrue_WhenCorrectlySignedInByHttpService()
    {
        //arrange
        var email = "test@email.com";
        var password = "password";

        var tokens = new TokensDto(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        _userHttpClient
            .SignIn(Arg.Is<SignInRequestDto>(arg
                => arg.Email == email 
                && arg.Password == password))
            .Returns(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(tokens)
            });
        
        //act
        var result = await _signInFacade.SignIn(email, password, CancellationToken.None);
        
        //assert
        result.AsT1.ShouldBeNull();
        result.AsT0.ShouldBeTrue();
    }
    
    private readonly IUserHttpClient _userHttpClient;
    private readonly ITokenHandler _tokenHandler;
    private readonly SignInFacade _signInFacade;

    public SignInFacadeTests()
    {
        _userHttpClient = Substitute.For<IUserHttpClient>();
        _tokenHandler = Substitute.For<ITokenHandler>();
        _signInFacade = new SignInFacade(_userHttpClient, _tokenHandler);
    }
}