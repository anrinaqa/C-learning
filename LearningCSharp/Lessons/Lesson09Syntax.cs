// ============================================================
// УРОК 9. СИНТАКСИС, КОТОРЫЙ ПУТАЕТ НОВИЧКОВ
//
// Сборник конструкций, которые ты встретишь в чужом коде
// и которые выглядят странно, пока не расшифруешь.
// ============================================================

namespace LearningCSharp.Lessons;

public static class Lesson09Syntax
{
    public static void Run()
    {
        // --- 1. ЛЯМБДА: =>  ---
        // "берём x и делаем с ним то-то". Мини-метод без имени.
        var numbers = new List<int> { 1, 5, 10, 15 };
        var big = numbers.Where(x => x > 5).ToList();
        // читается: "из numbers взять те x, где x > 5"
        Console.WriteLine($"Больше 5: {string.Join(", ", big)}");

        // => у метода — "тело из одного выражения":
        //   int Double(int n) => n * 2;   ==   { return n * 2; }
        Console.WriteLine($"Double(21) = {Double(21)}");

        // --- 2. NULL-ОПЕРАТОРЫ: ?. ?? ?= ---
        string? maybeName = GetName();

        // ?. — "если не null, возьми свойство; если null — результат null"
        int? length = maybeName?.Length;
        Console.WriteLine($"Длина имени: {length}");

        // ?? — "если слева null, возьми справа"
        string safeName = maybeName ?? "гость";
        Console.WriteLine($"Имя: {safeName}");

        // Комбинация, частая в тестах:
        //   var text = element?.Text?.Trim() ?? "";
        //   "если элемент есть — возьми текст и обрежь; нет — пустая строка"

        // --- 3. GENERICS: <T> ---
        // List<int>, List<string>, Dictionary<string, int> —
        // уголки говорят "из чего состоит". Task<bool> — асинхронно вернёт bool.
        var dict = new Dictionary<string, int>
        {
            ["chrome"] = 120,
            ["firefox"] = 115
        };
        Console.WriteLine($"Chrome version: {dict["chrome"]}");

        // --- 4. АТРИБУТЫ: [Something] ---
        // "Ярлыки" над методами/классами. В тестах — маркировка:
        //   [Test] / [Fact] — "это тест, запусти меня"
        //   [SetUp] — "выполни перед каждым тестом"
        // Сами по себе ничего не делают — их читает фреймворк.
        ExampleWithAttribute();

        // --- 5. using (не тот, что сверху файла!) ---
        // using var x = ... — "когда выйдешь из метода, убери за собой".
        // В тестах: driver, соединения с БД, файлы.
        using var reader = new StringReader("строка из 'файла'");
        Console.WriteLine(reader.ReadLine());
        // reader "умрёт" сам при выходе из Run() — не нужен Close()
    }

    [Example("пример атрибута")]
    private static void ExampleWithAttribute()
    {
        Console.WriteLine("Метод с атрибутом [Example] вызвался обычно");
    }

    private static int Double(int n) => n * 2;

    private static string? GetName() => null;
}

// Атрибут — маленький класс, наследующий Attribute.
// Тебе писать их почти не придётся, но увидеть можешь.
public class ExampleAttribute : Attribute
{
    public ExampleAttribute(string note) { }
}

// ============================================================
// ШПАРГАЛКА-РАСШИФРОВКА:
//   x => x + 1        мини-функция "x преврати в x+1"
//   obj?.Prop         если obj null -> null, иначе Prop
//   a ?? b            если a null -> b, иначе a
//   List<T>           список из T (T = любой тип)
//   [Test]            метка для тестового фреймворка
//   using var x       автоматическая "уборка" после метода
//   var               тип понятен из правой части
// ============================================================
