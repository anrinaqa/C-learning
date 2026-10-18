// ============================================================
// УРОК 6. КОЛЛЕКЦИИ И ЦИКЛЫ
//
// Коллекция = переменная, которая хранит много значений.
// В тестах: список элементов на странице, строки таблицы,
// наборы тестовых данных.
// ============================================================

namespace LearningCSharp.Lessons;

public static class Lesson06Collections
{
    public static void Run()
    {
        // МАССИВ — фиксированная длина:
        string[] browsers = { "chrome", "firefox", "edge" };
        Console.WriteLine($"Первый браузер: {browsers[0]}"); // нумерация с 0!

        // List<T> — список с изменяемой длиной. <string> = "список строк".
        // Уголки <T> — generics: "список ЧЕГО". Подробнее — урок 9.
        var testUsers = new List<string> { "admin", "user1", "user2" };
        testUsers.Add("guest");           // добавить
        testUsers.Remove("user1");        // удалить
        Console.WriteLine($"Пользователей: {testUsers.Count}");

        // foreach — "для каждого элемента сделай...". Самый частый цикл.
        foreach (var browser in browsers)
        {
            Console.WriteLine($"Проверяем в {browser}");
        }

        // for — цикл со счётчиком. Читается:
        //   старт;   условие продолжения;   шаг после каждого круга
        for (int i = 0; i < testUsers.Count; i++)
        {
            Console.WriteLine($"[{i}] {testUsers[i]}");
        }

        // while — крутится, пока условие истинно.
        // В тестах: "жди, пока элемент появится".
        int waited = 0;
        bool elementVisible = false;
        while (!elementVisible && waited < 3)
        {
            waited++;
            Console.WriteLine($"Жду элемент... {waited} сек");
            if (waited == 3) elementVisible = true; // имитация
        }

        // LINQ — "SQL для коллекций". Магия C#, в тестах сплошь и рядом:
        var names = new List<string> { "anna", "bob", "alex", "alina" };

        var aNames = names.Where(n => n.StartsWith("a")).ToList();
        Console.WriteLine($"Имена на 'a': {string.Join(", ", aNames)}");

        var first = names.FirstOrDefault(n => n == "bob");
        Console.WriteLine($"Нашли: {first}");

        bool hasAdmin = names.Any(n => n == "admin");
        Console.WriteLine($"Есть admin? {hasAdmin}");
    }
}

// ============================================================
// ЧТО ЗАПОМНИТЬ:
//  - Индексы с НУЛЯ: list[0] — первый элемент
//  - foreach — главный цикл; for — когда нужен индекс
//  - List<T>, массив T[] — тип в уголках/скобках = "из чего состоит"
//  - LINQ: Where (фильтр), Any (есть ли), FirstOrDefault (первый)
// ============================================================
