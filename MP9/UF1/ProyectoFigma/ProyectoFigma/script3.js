// Obtiene el botón de alternancia y el cuerpo del documento
const toggleButton = document.getElementById('darkModeToggle');
const body = document.body;

// Verifica si el modo oscuro está activado previamente y ajusta el estado del botón
if (localStorage.getItem('darkMode') === 'enabled') {
    body.classList.add('dark-mode');
    toggleButton.innerText = 'Modo Claro';
}

// Función para alternar el modo oscuro y claro
toggleButton.addEventListener('click', () => {
    // Si el cuerpo tiene la clase 'dark-mode', la elimina, si no, la agrega
    if (body.classList.contains('dark-mode')) {
        body.classList.remove('dark-mode');
        toggleButton.innerText = 'Modo Oscuro';
        localStorage.setItem('darkMode', 'disabled');
    } else {
        body.classList.add('dark-mode');
        toggleButton.innerText = 'Modo Claro';
        localStorage.setItem('darkMode', 'enabled');
    }
});
