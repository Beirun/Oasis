window.showDatePicker = function (id) {

    document.getElementById("dateInput-"+id).showPicker();
};

document.addEventListener("DOMContentLoaded", function () {
    const dateInput = document.getElementById("dateInput-"+ id);

    if (dateInput) {
        dateInput.addEventListener("mousedown", function (event) {
            event.preventDefault(); // Prevents default focus behavior and highlights
            this.showPicker(); // Opens the date picker manually
        });

        dateInput.addEventListener("focus", function () {
            this.style.outline = "none"; // Removes outline on focus
            this.style.caretColor = "transparent"; // Hides the blinking cursor
        });
    }
});
