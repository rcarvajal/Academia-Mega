using Xunit;
using FluentAssertions;
using Moq;
using TiendaMVC.Controllers;
using TiendaMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AccountControllerTest
{
    private AccountController GetControllerWithSession(ApiClient apiClient, string token = null)
    {
        var controller = new AccountController(apiClient);
        var httpContext = new DefaultHttpContext();
        if (token != null)
            httpContext.Session = new TestSession { ["JWToken"] = token };
        else
            httpContext.Session = new TestSession();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };
        return controller;
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsViewWithError()
    {
        // Arrange
        var mockAPI = new Mock<ApiClient>();
        mockAPI.Setup(s => s.LoginAsync(It.IsAny<User>()))
               .ReturnsAsync(false);

        var accObj = GetControllerWithSession(mockAPI.Object);

        var dto = new User { Username = "x", Password = "mala" };
        var result = await accObj.Login(dto);

        var view = result.Should().BeOfType<ViewResult>().Subject;
        view.Model.Should().Be(dto);

        accObj.ModelState.IsValid.Should().BeFalse();
        accObj.ModelState[string.Empty].Errors.Should()
            .ContainSingle(e => e.ErrorMessage == "Usuario o contraseña no validos");
    }

    [Fact]
    public async Task Login_ValidCredentials_RedirectsToProductos()
    {
        var mockAPI = new Mock<ApiClient>();
        mockAPI.Setup(s => s.LoginAsync(It.IsAny<User>()))
               .ReturnsAsync(true);

        var accObj = GetControllerWithSession(mockAPI.Object);

        var dto = new User { Username = "user", Password = "pass" };
        var result = await accObj.Login(dto);

        var redirect = result.Should().BeOfType<RedirectToActionResult>().Subject;
        redirect.ActionName.Should().Be("Index");
        redirect.ControllerName.Should().Be("Productos");
    }

    [Fact]
    public void Login_Get_WithToken_RedirectsToProductos()
    {
        var mockAPI = new Mock<ApiClient>();
        var accObj = GetControllerWithSession(mockAPI.Object, token: "token123");

        var result = accObj.Login();

        var redirect = result.Should().BeOfType<RedirectToActionResult>().Subject;
        redirect.ActionName.Should().Be("Index");
        redirect.ControllerName.Should().Be("Productos");
    }

    [Fact]
    public void Login_Get_WithoutToken_ReturnsView()
    {
        var mockAPI = new Mock<ApiClient>();
        var accObj = GetControllerWithSession(mockAPI.Object);

        var result = accObj.Login();

        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public async Task Register_InvalidModel_ReturnsView()
    {
        var mockAPI = new Mock<ApiClient>();
        var accObj = GetControllerWithSession(mockAPI.Object);
        accObj.ModelState.AddModelError("Username", "Required");

        var user = new User();
        var result = await accObj.Register(user);

        var view = result.Should().BeOfType<ViewResult>().Subject;
        view.Model.Should().Be(user);
    }

    [Fact]
    public async Task Register_ValidUser_RedirectsToProductos()
    {
        var mockAPI = new Mock<ApiClient>();
        mockAPI.Setup(s => s.RegisterAsync(It.IsAny<User>()))
               .ReturnsAsync(true);

        var accObj = GetControllerWithSession(mockAPI.Object);

        var user = new User { Username = "nuevo", Password = "pass" };
        var result = await accObj.Register(user);

        var redirect = result.Should().BeOfType<RedirectToActionResult>().Subject;
        redirect.ActionName.Should().Be("Index");
        redirect.ControllerName.Should().Be("Productos");
    }

    [Fact]
    public async Task Register_UserAlreadyExists_ReturnsViewWithError()
    {
        var mockAPI = new Mock<ApiClient>();
        mockAPI.Setup(s => s.RegisterAsync(It.IsAny<User>()))
               .ReturnsAsync(false);

        var accObj = GetControllerWithSession(mockAPI.Object);

        var user = new User { Username = "existente", Password = "pass" };
        var result = await accObj.Register(user);

        var view = result.Should().BeOfType<ViewResult>().Subject;
        view.Model.Should().Be(user);
        accObj.ModelState[string.Empty].Errors.Should()
            .ContainSingle(e => e.ErrorMessage == "Usuario ya registrado");
    }

    [Fact]
    public void Register_Get_WithToken_RedirectsToProductos()
    {
        var mockAPI = new Mock<ApiClient>();
        var accObj = GetControllerWithSession(mockAPI.Object, token: "token123");

        var result = accObj.Register();

        var redirect = result.Should().BeOfType<RedirectToActionResult>().Subject;
        redirect.ActionName.Should().Be("Index");
        redirect.ControllerName.Should().Be("Productos");
    }

    [Fact]
    public void Register_Get_WithoutToken_ReturnsView()
    {
        var mockAPI = new Mock<ApiClient>();
        var accObj = GetControllerWithSession(mockAPI.Object);

        var result = accObj.Register();

        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Logout_RemovesTokenAndRedirectsToLogin()
    {
        var mockAPI = new Mock<ApiClient>();
        var accObj = GetControllerWithSession(mockAPI.Object, token: "token123");

        var result = accObj.Logout();

        var redirect = result.Should().BeOfType<RedirectToActionResult>().Subject;
        redirect.ActionName.Should().Be("Login");
        accObj.HttpContext.Session.GetString("JWToken").Should().BeNull();
    }
}

// Helper session class for testing
public class TestSession : ISession
{
    private readonly Dictionary<string, byte[]> _sessionStorage = new Dictionary<string, byte[]>();

    public IEnumerable<string> Keys => _sessionStorage.Keys;
    public string Id => "TestSessionId";
    public bool IsAvailable => true;

    public void Clear() => _sessionStorage.Clear();
    public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    public void Remove(string key) => _sessionStorage.Remove(key);
    public void Set(string key, byte[] value) => _sessionStorage[key] = value;
    public bool TryGetValue(string key, out byte[] value) => _sessionStorage.TryGetValue(key, out value);

    public byte[] this[string key]
    {
        get => _sessionStorage.ContainsKey(key) ? _sessionStorage[key] : null;
        set => _sessionStorage[key] = value;
    }

    public string GetString(string key)
    {
        return _sessionStorage.TryGetValue(key, out var value) ? System.Text.Encoding.UTF8.GetString(value) : null;
    }

    public void SetString(string key, string value)
    {
        _sessionStorage[key] = System.Text.Encoding.UTF8.GetBytes(value);
    }
}
