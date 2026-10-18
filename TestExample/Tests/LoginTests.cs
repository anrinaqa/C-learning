// ============================================================
// LoginTests — КАК УСТРОЕН ТЕСТОВЫЙ КЛАСС (xUnit).
//
// Типичная анатомия тестового проекта:
//   [Fact]            — метод = один тест
//   [Theory]+[InlineData] — один тест с разными данными
//   Assert.*          — проверки: "ожидали X, получили Y"
//   Arrange/Act/Assert — структура тела теста
// ============================================================

using TestExample.Pages;

namespace TestExample.Tests;

public class LoginTests
{
    private readonly FakeDriver _driver;
    private readonly LoginPage _loginPage;

    // КОНСТРУКТОР тестового класса вызывается ПЕРЕД КАЖДЫМ тестом.
    // Это аналог [SetUp] в NUnit — "подготовь чистое окружение".
    // В реальном проекте тут открывается браузер.
    public LoginTests()
    {
        _driver = new FakeDriver();
        _loginPage = new LoginPage(_driver);
    }

    // Правильный тест читается как ручной ТК:
    // "Открыть логин -> ввести валидные данные -> отправить -> на Dashboard"
    [Fact]
    public void ValidLogin_RedirectsToDashboard()
    {
        // Arrange (подготовка) — уже сделана в конструкторе.

        // Act (действие)
        _loginPage
            .Open()
            .EnterLogin("admin")
            .EnterPassword("pass123")
            .Submit();

        // Assert (проверка) — Assert.Что(ожидаемое, фактическое)
        Assert.True(_loginPage.IsOnDashboard());
    }

    [Fact]
    public void InvalidLogin_ShowsErrorMessage()
    {
        _loginPage
            .Open()
            .EnterLogin("hacker")
            .EnterPassword("wrong")
            .Submit();

        Assert.True(_loginPage.IsErrorVisible());
        Assert.False(_loginPage.IsOnDashboard());
    }

    // [Theory] + [InlineData] — параметризованный тест:
    // ОДИН сценарий прогоняется с РАЗНЫМИ данными.
    // Это как твои таблицы тестовых данных в ТК!
    // Каждая строка InlineData = отдельный запуск.
    [Theory]
    [InlineData("admin", "pass123", true)]
    [InlineData("admin", "wrong", false)]
    [InlineData("", "pass123", false)]
    public void Login_VariousCredentials(string login, string password, bool shouldSucceed)
    {
        _loginPage
            .Open()
            .EnterLogin(login)
            .EnterPassword(password)
            .Submit();

        Assert.Equal(shouldSucceed, _loginPage.IsOnDashboard());
    }

    // Assert.Equal(expected, actual) — "должно равняться".
    // Порядок аргументов: СНАЧАЛА ожидаемое, ПОТОМ фактическое.
    // При падении xUnit пишет: "Expected: X, Actual: Y".
}

// ============================================================
// КАК ВЫГЛЯДИТ УПАВШИЙ ТЕСТ:
//
//   Failed Login_VariousCredentials(login: "admin", password: "x") ...
//   Assert.Equal() Failure
//   Expected: True
//   Actual:   False
//      at TestExample.Tests.LoginTests.Login_VariousCredentials(...)
//      in Tests\LoginTests.cs:line 75
//
// Читаешь: КАКОЙ тест -> ЧТО ожидали -> ЧТО получили -> ГДЕ (файл:строка)
// ============================================================
