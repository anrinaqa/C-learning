// ============================================================
// УРОК 7. ОШИБКИ: ИСКЛЮЧЕНИЯ И STACK TRACE
//
// Самый практичный урок. Умение читать ошибку = 70% навыка
// "найти, где сломалось".
// ============================================================

namespace LearningCSharp.Lessons;

public static class Lesson07Errors
{
    public static void Run()
    {
        // try/catch — "попробуй выполнить, а если упадёт — лови ошибку".
        // В тестах встречается в ожиданиях, retry-механизмах.
        try
        {
            ThrowExampleError();
        }
        catch (InvalidOperationException ex)
        {
            // ex.Message — текст ошибки, ex.StackTrace — где случилась.
            Console.WriteLine($"Поймали ошибку: {ex.Message}");
            Console.WriteLine("--- Stack trace (выдержка) ---");
            Console.WriteLine(ex.StackTrace);
        }

        Console.WriteLine();

        // finally — выполнится ВСЕГДА (и при ошибке, и без).
        // В тестах: "закрыть браузер, даже если тест упал".
        try
        {
            Console.WriteLine("Открыли браузер...");
        }
        finally
        {
            Console.WriteLine("...закрыли браузер (в любом случае)");
        }

        DemoNullError();
    }

    // Исключение (Exception) — "программа упала в этой точке".
    // throw = "бросить" исключение.
    private static void ThrowExampleError()
    {
        var element = FindElementOnPage();
        // Типичный сценарий падения автотеста:
        if (element == null)
        {
            throw new InvalidOperationException("Элемент '#submit-btn' не найден на странице");
        }
    }

    private static string? FindElementOnPage()
    {
        return null; // имитация: элемент не нашёлся
    }

    private static void DemoNullError()
    {
        Console.WriteLine("--- Самая частая ошибка: NullReferenceException ---");
        try
        {
            string? text = null;
            Console.WriteLine(text!.Length); // обращение к null -> падение
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"NullReferenceException: {ex.Message}");
        }
    }
}

// ============================================================
// КАК ЧИТАТЬ STACK TRACE (след вызовов):
//
//   System.NullReferenceException: Object reference not set...
//      at MyTests.LoginPage.EnterLogin() in
//         C:\project\Pages\LoginPage.cs:line 42        <-- ТВОЙ КОД, смотри сюда!
//      at MyTests.LoginTests.Test1() in LoginTests.cs:line 15
//
// Правила чтения:
//  1. Первая строка — ТИП ошибки и её текст.
//  2. Читай stack trace СВЕРХУ ВНИЗ, ищи первую строку
//     из СВОЕГО кода (а не из System./NuGet-пакетов).
//  3. :line N — номер строки в файле. Открывай и смотри.
//
// ЧАСТЫЕ ТИПЫ ОШИБОК В АВТОТЕСТАХ:
//  NullReferenceException   — обратились к null
//  NoSuchElementException   — Selenium не нашёл элемент (селектор?)
//  TimeoutException         — не дождались (элемент/страница)
//  Assert.*Exception        — тест прошёл, но результат не тот
// ============================================================
