// ============================================================
// LoginPage — PAGE OBJECT.
//
// Page Object — главный паттерн UI-автотестов:
//   - тест НЕ знает про селекторы и структуру страницы
//   - класс страницы инкапсулирует: где поля, как кликать
//   - тест читается как сценарий: page.EnterLogin().Submit()
//
// Зачем: поменялся id кнопки — правим ОДНО место тут,
// а не 50 тестов.
// ============================================================

namespace TestExample.Pages;

public class LoginPage
{
    // readonly — ссылка задаётся один раз в конструкторе.
    private readonly FakeDriver _driver;

    // СЕЛЕКТОРЫ — "адреса" элементов на странице.
    // В реальном проекте тут будет By.Id / By.CssSelector / XPath.
    // Обычно выносят наверх, чтобы было видно все "зависимости" от верстки.
    private const string LoginField = "#login";
    private const string PasswordField = "#password";
    private const string SubmitButton = "#submit";
    private const string ErrorMessage = ".error-message";

    // Конструктор: странице нужен driver, через который работать.
    public LoginPage(FakeDriver driver)
    {
        _driver = driver;
    }

    // --- Методы-действия (шаги пользователя) ---

    public LoginPage Open()
    {
        _driver.GoTo("https://app.example.com/login");
        return this; // return this = метод возвращает саму страницу.
                     // Позволяет писать цепочкой: page.Open().EnterLogin(...)
    }

    public LoginPage EnterLogin(string login)
    {
        _driver.Type(LoginField, login);
        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        _driver.Type(PasswordField, password);
        return this;
    }

    public LoginPage Submit()
    {
        _driver.Click(SubmitButton);
        return this;
    }

    // --- Методы-проверки (читаем состояние) ---

    public bool IsOnDashboard() => _driver.CurrentUrl == "/dashboard";

    public bool IsErrorVisible() => _driver.IsVisible(ErrorMessage);
}
