// Оглавление курса — выдвижная панель слева.
// Подключается одной строкой: <script src="../assets/menu.js" defer></script>
// Список уроков единственный — при добавлении урока правится только тут.

var COURSE = {
    lessons: [
        { file: "0001-anatomiya-fayla-csharp.html", title: "Анатомия файла C#",   ready: true },
        { file: "0002-peremennye-i-tipy.html",      title: "Переменные и типы",   ready: true },
        { file: "0003-metody.html",                 title: "Методы",              ready: true },
        { file: "0004-klassy-i-obekty.html",        title: "Классы и объекты",    ready: true },
        { file: "0005-usloviya.html",               title: "Условия и логика",    ready: true },
        { file: "0006-kollekcii-i-cikly.html",      title: "Коллекции и циклы" },
        { file: "0007-oshibki-i-stacktrace.html",   title: "Ошибки и stack trace" },
        { file: "0008-async-await.html",            title: "Async/await" },
        { file: "0009-strannyj-sintaksis.html",     title: "Странный синтаксис" }
    ],
    reference: [
        { file: "../reference/sintaksis-decoder.html", title: "Расшифровщик синтаксиса" },
        { file: "../reference/chtenie-oshibok.html",   title: "Как читать упавший тест" }
    ],
    practice: [
        { file: "zadaniye-uroki-1-4.html", title: "Детектив: уроки 1–4", ready: true }
    ]
};

document.addEventListener("DOMContentLoaded", function () {
    var inLessons = location.pathname.indexOf("/lessons/") !== -1;
    var inReference = location.pathname.indexOf("/reference/") !== -1;
    var inPractice = location.pathname.indexOf("/practice/") !== -1;
    var here = location.pathname.split("/").pop();

    var btn = document.createElement("button");
    btn.className = "toc-btn";
    btn.innerHTML = "&#9776; Уроки";
    btn.setAttribute("aria-label", "Оглавление курса");

    var panel = document.createElement("nav");
    panel.className = "toc-panel";

    var html = "<h2>Уроки</h2><ol>";
    COURSE.lessons.forEach(function (l, i) {
        // ссылка: уроки -> файл в той же папке; из reference -> ../lessons/
        var href = inLessons ? l.file : "../lessons/" + l.file;
        var isHere = inLessons && here === l.file;
        var span = "Урок " + (i + 1) + ". " + l.title;
        if (isHere) {
            html += '<li class="here">' + span + "</li>";
        } else if (l.ready) {
            html += '<li><a href="' + href + '">' + span + "</a></li>";
        } else {
            html += '<li class="soon">' + span + "</li>";
        }
    });
    html += "</ol><h2>Шпаргалки</h2><ul>";
    COURSE.reference.forEach(function (r) {
        var href = inReference ? r.file.split("/").pop() : r.file;
        var isHere = inReference && here === r.file.split("/").pop();
        html += isHere
            ? '<li class="here">' + r.title + "</li>"
            : '<li><a href="' + href + '">' + r.title + "</a></li>";
    });
    html += "</ul><h2>Практика</h2><ul>";
    COURSE.practice.forEach(function (p) {
        var href = inPractice ? p.file : "../practice/" + p.file;
        var isHere = inPractice && here === p.file;
        html += isHere
            ? '<li class="here">' + p.title + "</li>"
            : '<li><a href="' + href + '">' + p.title + "</a></li>";
    });
    html += "</ul>";
    panel.innerHTML = html;

    var backdrop = document.createElement("div");
    backdrop.className = "toc-backdrop";

    function toggle() {
        panel.classList.toggle("open");
        backdrop.classList.toggle("open");
    }

    btn.addEventListener("click", toggle);
    backdrop.addEventListener("click", toggle);

    document.addEventListener("keydown", function (e) {
        if (e.key === "Escape" && panel.classList.contains("open")) toggle();
    });

    document.body.appendChild(btn);
    document.body.appendChild(backdrop);
    document.body.appendChild(panel);
});
