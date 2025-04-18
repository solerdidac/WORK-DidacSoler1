let toggleButton = document.getElementById('darkModeToggle');

// Función para aplicar el modo oscuro
function enableDarkMode() {
    document.body.classList.add('dark-mode');
    document.querySelector('.header').classList.add('dark-mode');
    document.querySelector('.footer').classList.add('dark-mode');
    document.querySelectorAll('.nav-links a').forEach(link => link.classList.add('dark-mode'));
    document.querySelectorAll('.main-content').forEach(content => content.classList.add('dark-mode'));
    document.querySelector('.description-text').classList.add('dark-mode');
    document.querySelectorAll('.description-section').forEach(section => section.classList.add('dark-mode'));
    document.querySelectorAll('.opinion-form').forEach(form => form.classList.add('dark-mode'));
    toggleButton.textContent = 'Modo Claro';
    localStorage.setItem('darkMode', 'enabled');
}

// Función para desactivar el modo oscuro
function disableDarkMode() {
    document.body.classList.remove('dark-mode');
    document.querySelector('.header').classList.remove('dark-mode');
    document.querySelector('.footer').classList.remove('dark-mode');
    document.querySelectorAll('.nav-links a').forEach(link => link.classList.remove('dark-mode'));
    document.querySelectorAll('.main-content').forEach(content => content.classList.remove('dark-mode'));
    document.querySelector('.description-text').classList.remove('dark-mode');
    document.querySelectorAll('.description-section').forEach(section => section.classList.remove('dark-mode'));
    document.querySelectorAll('.opinion-form').forEach(form => form.classList.remove('dark-mode'));
    toggleButton.textContent = 'Modo Oscuro';
    localStorage.setItem('darkMode', 'disabled');
}

// Verificar el estado de modo oscuro en localStorage
if (localStorage.getItem('darkMode') === 'enabled') {
    enableDarkMode();
}

// Alternar entre modos
toggleButton.addEventListener('click', () => {
    if (document.body.classList.contains('dark-mode')) {
        disableDarkMode();
    } else {
        enableDarkMode();
    }
});
