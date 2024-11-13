function applySavedTheme() {
    const theme = localStorage.getItem('theme'); // Recupera a preferência de tema

    if (theme) {
        // Se o tema estiver salvo, aplica o tema correspondente
        document.body.classList.add(theme);
    } else {
        // Caso não haja preferência salva, verifica o sistema
        if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
            document.body.classList.add('darkmode');
        } else {
            document.body.classList.add('lightmode');
        }
    }
}

// Função para alternar o tema
function toggleTheme() {
    if (document.body.classList.contains('darkmode')) {
        document.body.classList.remove('darkmode');
        document.body.classList.add('lightmode');
        localStorage.setItem('theme', 'lightmode'); // Salva a preferência
    } else {
        document.body.classList.remove('lightmode');
        document.body.classList.add('darkmode');
        localStorage.setItem('theme', 'darkmode'); // Salva a preferência
    }
}

// Aplica o tema salvo quando a página carregar
applySavedTheme();

// Adiciona o evento de clique no botão para alternar o tema
const toggleButton = document.getElementById('theme-toggle');
if (toggleButton) {
    toggleButton.addEventListener('click', toggleTheme);
}