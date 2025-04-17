window.getPageSizeBasedOnResolution = () => {
    const width = window.innerWidth;

    // Define tus rangos de resolución
    if (width < 576) {
        // Por ejemplo, dispositivos móviles pequeños
        return 8;

    }
    if (width < 1370) {
        // Móviles en horizontal o pantallas algo mayores
        return 10;

    }
    if (width < 2050) {
        // Tablet
        return 12;

    } else {
        // Escritorio y pantallas grandes
        return 15;
    }
};
