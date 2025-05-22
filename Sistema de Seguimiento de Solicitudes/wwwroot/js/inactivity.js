let inactivityTimeout;

// Cambiar el numero para cerrar sesion automaticamente 
let logoutTimeInMinutes = 15;

function resetInactivityTimer(dotnetHelper) {
    clearTimeout(inactivityTimeout);
    inactivityTimeout = setTimeout(() => {
        dotnetHelper.invokeMethodAsync("CerrarSesionAuto");
    }, logoutTimeInMinutes * 60 * 1000);
}

function startInactivityWatcher(dotnetHelper) {
    document.addEventListener("mousemove", () => resetInactivityTimer(dotnetHelper));
    document.addEventListener("keydown", () => resetInactivityTimer(dotnetHelper));
    document.addEventListener("click", () => resetInactivityTimer(dotnetHelper));
    resetInactivityTimer(dotnetHelper);
}
