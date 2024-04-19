function increaseFontSize(number) {
    var stepsArray = [16, 20, 24];
    document.body.style.fontSize = stepsArray[number] + 'px';
    sessionStorage.setItem("fontNumber", number);
}

function changeContrast(number) {
    var stylesheet = document.getElementById('stylesheet');
    stylesheet.href = "/css/Contrast-" + number + ".css";
    document.body.classList.add("high-contrast");
    sessionStorage.setItem("contrastNumber", number);

}

document.addEventListener("DOMContentLoaded", function () {
    var contrastCookie = sessionStorage.getItem("contrastNumber");
    var fontSizeValue = sessionStorage.getItem("fontNumber");
    console.log(contrastCookie);

    if (contrastCookie != null) {
        changeContrast(contrastCookie);
    }

    if (fontSizeValue != null) {
        increaseFontSize(fontSizeValue);
    }

});