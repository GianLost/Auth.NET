import { BODY, THEME_TOGGLE_BUTTON, THEME_STORAGE_KEY, DARK_MODE_CLASS, LIGHT_MODE_CLASS } from "../constants/components-constant.js";

// Aplica o tema salvo ou o tema do sistema
function applySavedOrSystemTheme() {
    const savedTheme = localStorage.getItem(THEME_STORAGE_KEY);

    if (savedTheme) {
        BODY.classList.add(savedTheme);
    } else {
        const prefersDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
        BODY.classList.add(prefersDarkMode ? DARK_MODE_CLASS : LIGHT_MODE_CLASS);
    }
}

// Alterna entre os temas e salva a preferência
function toggleTheme() {
    if (BODY.classList.contains(DARK_MODE_CLASS)) {
        BODY.classList.replace(DARK_MODE_CLASS, LIGHT_MODE_CLASS);
        localStorage.setItem(THEME_STORAGE_KEY, LIGHT_MODE_CLASS);
    } else {
        BODY.classList.replace(LIGHT_MODE_CLASS, DARK_MODE_CLASS);
        localStorage.setItem(THEME_STORAGE_KEY, DARK_MODE_CLASS);
    }
}

// Função para inicializar o modo escuro
export function initializeDarkMode() {
    applySavedOrSystemTheme();

    // Verifica se o botão de alternância de tema existe antes de adicionar o evento
    if (THEME_TOGGLE_BUTTON.length) {
        THEME_TOGGLE_BUTTON[0].addEventListener('click', toggleTheme);
    }
}

// Inicializa o Dark Mode após o DOM estar pronto
$(() => {
    initializeDarkMode();
});