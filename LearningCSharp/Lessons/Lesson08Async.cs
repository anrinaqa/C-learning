// ============================================================
// УРОК 8. ASYNC/AWAIT
//
// Async = "не жди на месте, делай другое, пока ждёшь ответ".
// UI-тесты на Playwright/REST-тесты почти всегда async.
// ============================================================

namespace LearningCSharp.Lessons;

public static class Lesson08Async
{
    // Подпись async-метода: async Task Имя()
    //   Task = "операция, которая завершится позже"
    //   Task<string> = "завершится и вернёт строку"
    public static async Task Run()
    {
        Console.WriteLine("Начали выполнение");

        // await — "дождись результата, потом иди дальше".
        // БЕЗ await метод запустится и уйдёт в фон —
        // классический баг: тест "зелёный", но ничего не проверил.
        string pageText = await FetchPageAsync("/login");
        Console.WriteLine($"Получили: {pageText}");

        // Последовательность сохраняется — как обычный код:
        var status = await GetStatusAsync();
        var user = await GetUserAsync(status);
        Console.WriteLine($"Итог: {user}");
    }

    // Имитация сетевого запроса (Task.Delay = "подожди N мс").
    private static async Task<string> FetchPageAsync(string url)
    {
        await Task.Delay(100); // как будто ждём сервер
        return $"<html>страница {url}</html>";
    }

    private static async Task<int> GetStatusAsync()
    {
        await Task.Delay(50);
        return 200;
    }

    private static async Task<string> GetUserAsync(int status)
    {
        await Task.Delay(50);
        return status == 200 ? "admin" : "anonymous";
    }
}

// ============================================================
// ЧТО ЗАПОМНИТЬ:
//  - async + Task в сигнатуре = метод асинхронный
//  - await = "подожди тут"; без него — код уедет в фон
//  - В тестах: await page.ClickAsync(...), await page.WaitFor...
//  - Если видишь "Task" в типе — где-то выше должен быть await
//
// ТИПИЧНЫЙ БАГ, который надо ловить глазами:
//   page.ClickAsync("#btn");       // забыли await!
//   Assert.IsTrue(page.IsVisible); // проверка раньше, чем клик
// Компилятор это пропустит, а тест будет мигающим (flaky).
// ============================================================
