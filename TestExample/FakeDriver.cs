// ============================================================
// FakeDriver — ИМИТАЦИЯ браузерного драйвера.
//
// В реальном проекте на этом месте будет:
//   IWebDriver driver = new ChromeDriver();       // Selenium
//   var page = await browser.NewPageAsync();      // Playwright
//
// Смысл идентичный: объект "держит" страницу, через него
// тест вводит текст, кликает и читает состояние элементов.
// ============================================================

namespace TestExample;

public class FakeDriver
{
    // _page — "состояние страницы": какие элементы и что в них.
    private readonly Dictionary<string, string> _fields = new();
    private readonly List<string> _visibleElements = new();

    public string? CurrentUrl { get; private set; }

    // Аналог driver.Navigate().GoToUrl(url) / page.GotoAsync(url)
    public void GoTo(string url)
    {
        CurrentUrl = url;
        // "Открыли страницу логина" — на ней видны поля и кнопка:
        if (url.Contains("login"))
        {
            _visibleElements.AddRange(new[] { "#login", "#password", "#submit" });
        }
    }

    // Аналог element.SendKeys(text)
    public void Type(string selector, string text)
    {
        _fields[selector] = text;
    }

    // Аналог element.Click() — у нас "отправка формы"
    public void Click(string selector)
    {
        if (selector == "#submit")
        {
            bool ok = _fields.GetValueOrDefault("#login") == "admin"
                   && _fields.GetValueOrDefault("#password") == "pass123";

            if (ok)
                CurrentUrl = "/dashboard";
            else
                _visibleElements.Add(".error-message");
        }
    }

    public bool IsVisible(string selector) => _visibleElements.Contains(selector);

    public string? GetText(string selector) => _fields.GetValueOrDefault(selector);
}
