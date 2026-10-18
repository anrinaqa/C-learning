// Интерактивный квиз для уроков.
// Разметка: <div class="quiz"><h3>Проверь себя</h3>
//   <div class="quiz-q">
//     <p class="q-text">Вопрос?</p>
//     <ul>
//       <li data-ok="true">правильный ответ</li>
//       <li data-ok="false">неправильный</li>
//     </ul>
//     <p class="feedback" data-good="Верно!" data-bad="Не совсем. Объяснение..."></p>
//   </div>
// </div>
// Клик по варианту -> мгновенная обратная связь, вопрос блокируется.

document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".quiz-q").forEach(function (q) {
        var items = q.querySelectorAll("li");
        var feedback = q.querySelector(".feedback");

        items.forEach(function (li) {
            li.addEventListener("click", function () {
                if (li.classList.contains("locked")) return;

                items.forEach(function (el) { el.classList.add("locked"); });

                var isRight = li.dataset.ok === "true";
                li.classList.add(isRight ? "correct" : "wrong");

                if (!isRight) {
                    // покажем, какой был правильный
                    items.forEach(function (el) {
                        if (el.dataset.ok === "true") el.classList.add("correct");
                    });
                }

                if (feedback) {
                    feedback.textContent = isRight
                        ? (feedback.dataset.good || "Верно!")
                        : (feedback.dataset.bad || "Не совсем.");
                    feedback.classList.add(isRight ? "good" : "bad");
                }
            });
        });
    });
});
