// ============================================================
// УРОК 5. УСЛОВИЯ И ЛОГИКА
//
// if/else — "если условие истинно — сделай это, иначе — то".
// В автотестах условия внутри assert'ов и проверок состояния.
// ============================================================

namespace LearningCSharp.Lessons;

public static class Lesson05Conditions
{
    public static void Run()
    {
        int statusCode = 200;
        string pageTitle = "Dashboard";
        bool isErrorShown = false;

        // Базовый if / else if / else:
        if (statusCode == 200)
        {
            Console.WriteLine("Страница загрузилась успешно");
        }
        else if (statusCode == 404)
        {
            Console.WriteLine("Страница не найдена");
        }
        else
        {
            Console.WriteLine($"Неожиданный код: {statusCode}");
        }

        // Операторы сравнения:
        //   ==  равно          (два знака =! один = это присваивание)
        //   !=  не равно
        //   > < >= <=  больше/меньше
        // Логические операторы:
        //   &&  И     (оба условия истинны)
        //   ||  ИЛИ   (хотя бы одно)
        //   !   НЕ    (переворот: !true == false)

        if (statusCode == 200 && pageTitle == "Dashboard")
        {
            Console.WriteLine("И код, и заголовок верные");
        }

        if (statusCode == 500 || isErrorShown)
        {
            Console.WriteLine("Есть признак ошибки");
        }

        if (!isErrorShown)
        {
            Console.WriteLine("Ошибок на странице нет");
        }

        // switch — "много if'ов подряд" по одному значению:
        switch (statusCode)
        {
            case 200:
                Console.WriteLine("OK");
                break;
            case 404:
                Console.WriteLine("Not Found");
                break;
            default: // как else — "всё остальное"
                Console.WriteLine("Другое");
                break;
        }

        // Тернарный оператор — короткий if в одну строку:
        //   условие ? если_true : если_false
        string result = statusCode == 200 ? "PASS" : "FAIL";
        Console.WriteLine($"Результат: {result}");
    }
}

// ============================================================
// ЧТО ЗАПОМНИТЬ:
//  - == сравнивает, = присваивает (путать — классика багов)
//  - && И, || ИЛИ, ! НЕ
//  - условие ? A : B — мини-if
// ============================================================
