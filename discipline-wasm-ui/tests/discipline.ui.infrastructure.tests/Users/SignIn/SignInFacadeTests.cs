using System.Net;
using System.Net.Http.Json;
using discipline.ui.communication.http.Auth;
using discipline.ui.communication.http.Auth.DTOs;
using discipline.ui.communication.http.Users;
using discipline.ui.communication.http.Users.Requests;
using discipline.ui.infrastructure.Users.SignIn;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Refit;
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
                && arg.Password == password), CancellationToken.None)
            .Returns(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(tokens)
            });
        
        //act
        var result = await _signInFacade.HandleAsync(email, password, CancellationToken.None);
        
        //assert
        result.AsT0.ShouldBeTrue();
    }
    
    [Fact]
    public async Task SignIn_ShouldSetToken_WhenCorrectlySignedInByHttpService()
    {
        //arrange
        var email = "test@email.com";
        var password = "password";

        var tokens = new TokensDto(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        _userHttpClient
            .SignIn(Arg.Is<SignInRequestDto>(arg
                => arg.Email == email 
                   && arg.Password == password), CancellationToken.None)
            .Returns(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(tokens)
            });
        
        //act
        _ = await _signInFacade.HandleAsync(email, password, CancellationToken.None);
        
        //assert
        await _tokenHandler
            .Received(1)
            .SetAsync(tokens);
    }
    
    [Fact]
    public async Task SignIn_ShouldReturnMessage_WhenStatusCodeIsNotSuccess()
    {
        //arrange
        var email = "test@email.com";
        var password = "password";

        var problemDetails = new ProblemDetails()
        {
            Detail = "tests_error_message"
        };
        _userHttpClient
            .SignIn(Arg.Is<SignInRequestDto>(arg
                => arg.Email == email 
                   && arg.Password == password), CancellationToken.None)
            .Returns(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = JsonContent.Create(problemDetails)
            });
        
        //act
        var result = await _signInFacade.HandleAsync(email, password, CancellationToken.None);
        
        //assert
        result.AsT1.ShouldBe(problemDetails.Detail);
    }
    
    [Fact]
    public async Task SignIn_ShouldReturnMessageServerCommunicationError_WhenClientThrowsException()
    {
        //arrange
        var email = "test@email.com";
        var password = "password";


        _userHttpClient
            .SignIn(Arg.Is<SignInRequestDto>(arg
                => arg.Email == email
                   && arg.Password == password), CancellationToken.None)
            .ThrowsAsync(new HttpRequestException());
        
        //act
        var result = await _signInFacade.HandleAsync(email, password, CancellationToken.None);
        
        //assert
        result.AsT1.ShouldBe("Server communication error");
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