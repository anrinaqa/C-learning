// ============================================================
// УРОК 3. МЕТОДЫ
//
// Метод = именованный кусок кода, который можно вызвать.
// Тесты почти целиком состоят из вызовов методов:
//   page.Login(user, pass)  driver.FindElement(...)  и т.д.
// ============================================================

namespace LearningCSharp.Lessons;

public static class Lesson03Methods
{
    public static void Run()
    {
        // ВЫЗОВ метода: ИмяМетода(аргументы);
        string text = BuildGreeting("Анна", 3);
        Console.WriteLine(text);

        // Аргументы идут в порядке параметров:
        int sum = Add(10, 20);            // positional — по позиции
        Console.WriteLine($"10 + 20 = {sum}");

        // Именованные аргументы — указываешь имя параметра.
        // Встречается в тестах постоянно: timeout: 5000
        PrintUser(name: "admin", role: "tester");
        PrintUser(role: "dev", name: "bob"); // порядок не важен

        // Метод, который ничего не возвращает — void:
        LogMessage("просто пишем в консоль");

        // Метод может иметь параметры по умолчанию:
        Greet();          // используется значение по умолчанию
        Greet("Света");   // своё значение
    }

    // Разбор сигнатуры:
    //   public static string BuildGreeting(string name, int attempt)
    //                   |              |         |           |
    //           возвращаемый тип   параметр 1  параметр 2
    // "return" — что метод отдаёт обратно вызвавшему.
    private static string BuildGreeting(string name, int attempt)
    {
        return $"Привет, {name}! Попытка №{attempt}";
        // После return метод завершается.
    }

    private static int Add(int a, int b)
    {
        return a + b;
    }

    // void — метод что-то делает, но ничего не возвращает.
    private static void LogMessage(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }

    private static void PrintUser(string name, string role)
    {
        Console.WriteLine($"Пользователь: {name}, роль: {role}");
    }

    // = "Друг" — значение параметра по умолчанию.
    // Если вызвали Greet() без аргумента — будет "Друг".
    private static void Greet(string name = "Друг")
    {
        Console.WriteLine($"Здравствуй, {name}!");
    }
}

// ============================================================
// ЧТО ЗАПОМНИТЬ:
//  - Метод вызывается: Имя(аргумент1, аргумент2)
//  - void = ничего не возвращает; иначе смотри на тип перед именем
//  - return — выход из метода с результатом
//  - аргументы с именами (name: "x") — частый приём в тестовом коде
// ============================================================
