# C# для QA — ресурсы

## Knowledge

- [Metanit — Руководство по C#](https://metanit.com/sharp/)
  Лучший русскоязычный учебник по C#, бесплатный и без воды. Use for: сверить понимание любого синтаксиса из уроков.
- [Microsoft Learn — Тур по C#](https://learn.microsoft.com/ru-ru/dotnet/csharp/tour-of-csharp/)
  Официальный обзор языка от Microsoft. Use for: первоисточник по структуре программ, типам, классам.
- [xUnit.net документация](https://xunit.net/)
  Документация тестового фреймворка: `[Fact]`, `[Theory]`, `Assert`. Use for: расшифровка атрибутов и assert'ов в чужих тестах.
- [Selenium — документация](https://www.selenium.dev/documentation/)
  Официальные доки по WebDriver. Use for: что означают `FindElement`, `NoSuchElementException`, локаторы.
- [Playwright для .NET](https://playwright.dev/dotnet/)
  Современная альтернатива Selenium, везде async/await. Use for: если в компании выберут Playwright.

## Wisdom (Communities)

- [Stack Overflow — тег [c#]](https://stackoverflow.com/questions/tagged/c%23)
  Почти любая ошибка из stack trace уже разобрана. Use for: вставить тип ошибки в поиск.
- [Ministry of Testing](https://www.ministryoftesting.com/)
  Крупнейшее сообщество тестировщиков, разделы по автоматизации. Use for: практики из индустрии, а не только теория.
- Своя команда: ребята, которые внедряют агента
  Use for: узнать, какой фреймворк выбрали (xUnit/NUnit, Selenium/Playwright) — откалибруем примеры под реальный стек.

## Gaps

- Неизвестен реальный стек автотестов в компании (xUnit vs NUnit, Selenium vs Playwright, BDD-обёртки типа SpecFlow). Как узнаем — добавлю примеры под него.
