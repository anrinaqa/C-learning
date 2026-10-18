// ============================================================
// УРОК 4. КЛАССЫ И ОБЪЕКТЫ
//
// Класс = чертёж. Объект = экземпляр по чертежу.
// В тестах классы повсюду: WebDriver, Page Object'ы, модели данных.
// ============================================================

namespace LearningCSharp.Lessons;

public static class Lesson04Classes
{
    public static void Run()
    {
        // new — создание объекта (экземпляра класса).
        // TestUser — тип, user — имя переменной.
        var user = new TestUser("admin", "qwerty123");

        // Через точку достаём то, что внутри объекта:
        Console.WriteLine($"Логин: {user.Login}");     // свойство
        Console.WriteLine($"Пароль: {user.Password}"); // свойство
        user.PrintInfo();                              // метод

        // Свойства можно менять (если есть set):
        user.AttemptCount = 2;
        user.PrintInfo();

        // static — принадлежит КЛАССУ, а не объекту.
        // Вызывается через имя класса, без new:
        var defaultUser = TestUser.CreateDefault();
        defaultUser.PrintInfo();
        // user.CreateDefault(); // ОШИБКА: static не вызывается у объекта

        // Цепочки вызовов — типичная картина в автотестах:
        // driver.FindElement(By.Id("btn")).Click();
        // читается слева направо:
        //   у driver вызвали FindElement -> получили элемент -> Click()
    }
}

// Класс TestUser — чертёж "тестового пользователя".
public class TestUser
{
    // СВОЙСТВА (properties) — данные объекта.
    // { get; set; } — можно читать и менять.
    // { get; } — только чтение (задаётся в конструкторе).
    public string Login { get; }
    public string Password { get; }
    public int AttemptCount { get; set; }

    // КОНСТРУКТОР — метод без имени типа, вызывается при new.
    // Здесь: new TestUser("admin", "qwerty123") придёт сюда.
    public TestUser(string login, string password)
    {
        Login = login;
        Password = password;
        AttemptCount = 0;
    }

    // Обычный метод объекта.
    public void PrintInfo()
    {
        Console.WriteLine($"User {Login}, попыток входа: {AttemptCount}");
    }

    // static метод — "фабрика". Не привязан к конкретному объекту.
    public static TestUser CreateDefault()
    {
        return new TestUser("default_user", "pass123");
    }
}

// ============================================================
// ЧТО ЗАПОМНИТЬ:
//  - new Класс(...) — создание объекта
//  - объект.Свойство / объект.Метод() — доступ через точку
//  - static: Класс.Метод() без создания объекта
//  - get/set: можно ли менять свойство снаружи
// ============================================================
