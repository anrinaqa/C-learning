// ============================================================
// ТОЧКА ВХОДА — с этого файла начинается выполнение программы.
//
// Как запустить урок:
//   1. Открой терминал в папке LearningCSharp
//   2. Выполни:  dotnet run
//   3. Введи номер урока, который хочешь посмотреть
// ============================================================

using LearningCSharp.Lessons;

Console.WriteLine("=== Учебные уроки по C# ===");
Console.WriteLine("Доступные уроки:");
Console.WriteLine("  1 - Анатомия файла C# (using, namespace, class, метод)");
Console.WriteLine("  2 - Переменные и типы данных");
Console.WriteLine("  3 - Методы: параметры и возвращаемые значения");
Console.WriteLine("  4 - Классы и объекты");
Console.WriteLine("  5 - Условия и логика (if/else, &&, ||)");
Console.WriteLine("  6 - Коллекции и циклы (List, foreach)");
Console.WriteLine("  7 - Ошибки: исключения и как читать stack trace");
Console.WriteLine("  8 - Async/await — почему в тестах всё асинхронное");
Console.WriteLine("  9 - Синтаксис, который путает новичков (=>, ?, ??, <T>)");
Console.WriteLine();
Console.Write("Введи номер урока: ");

var input = Console.ReadLine();

switch (input)
{
    case "1": Lesson01Anatomy.Run(); break;
    case "2": Lesson02Variables.Run(); break;
    case "3": Lesson03Methods.Run(); break;
    case "4": Lesson04Classes.Run(); break;
    case "5": Lesson05Conditions.Run(); break;
    case "6": Lesson06Collections.Run(); break;
    case "7": Lesson07Errors.Run(); break;
    case "8": await Lesson08Async.Run(); break;
    case "9": Lesson09Syntax.Run(); break;
    default:
        Console.WriteLine("Нет такого урока. Введи число от 1 до 9.");
        break;
}
