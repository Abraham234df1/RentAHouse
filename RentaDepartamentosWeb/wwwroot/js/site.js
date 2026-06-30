// Fades in elements with the .fade-in-up class when they scroll into view.
(function () {
    function onScrollReveal() {
        var items = document.querySelectorAll('.fade-in-up');
        var windowHeight = window.innerHeight;

        items.forEach(function (item) {
            var rect = item.getBoundingClientRect();
            if (rect.top < windowHeight - 80) {
                item.classList.add('visible');
            }
        });
    }

    function focusFieldHighlight() {
        var fields = document.querySelectorAll('.form-control, .form-select');

        fields.forEach(function (field) {
            field.addEventListener('focus', function () {
                field.classList.add('field-focus');
            });

            field.addEventListener('blur', function () {
                field.classList.remove('field-focus');
            });
        });
    }

    document.addEventListener('DOMContentLoaded', function () {
        onScrollReveal();
        focusFieldHighlight();
        window.addEventListener('scroll', onScrollReveal, { passive: true });
    });
})();
