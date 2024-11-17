$(() => {
    function applySavedTheme() {
        const theme = localStorage.getItem('theme'); // Recupera a preferência de tema

        if (theme) {
            // Se o tema estiver salvo, aplica o tema correspondente
            $('body').addClass(theme);
        } else {
            // Caso não haja preferência salva, verifica o sistema
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                $('body').addClass('darkmode');
            } else {
                $('body').addClass('lightmode');
            }
        }
    }

    // Função para alternar o tema
    function toggleTheme() {
        if ($('body').hasClass('darkmode')) {
            $('body').removeClass('darkmode').addClass('lightmode');
            localStorage.setItem('theme', 'lightmode'); // Salva a preferência
        } else {
            $('body').removeClass('lightmode').addClass('darkmode');
            localStorage.setItem('theme', 'darkmode'); // Salva a preferência
        }
    }

    // Aplica o tema salvo quando a página carregar
    applySavedTheme();

    // Adiciona o evento de clique no botão para alternar o tema
    $('#theme-toggle').on('click', toggleTheme);
});
