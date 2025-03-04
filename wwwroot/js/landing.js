function scrollToSection(id) {
    const element = document.getElementById(id);
    element.scrollIntoView({ behavior: 'smooth', block:'end' });
}

window.addScrollEvent = (dotnetHelper) => {
    window.addEventListener("scroll", () => {
        let scrollPos = window.scrollY;
        dotnetHelper.invokeMethodAsync("OnScroll", scrollPos);
    });
};
