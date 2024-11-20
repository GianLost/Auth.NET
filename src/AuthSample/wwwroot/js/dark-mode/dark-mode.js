$(() => {
    function applySavedTheme() {
        const theme = localStorage.getItem('theme'); // Retrieves theme preference

        if (theme) {
            // If the theme was saved, apply the corresponding theme
            $('body').addClass(theme);
        } else {
            // If there is no saved preference, check the system preferences
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                $('body').addClass('darkmode');
            } else {
                $('body').addClass('lightmode');
            }
        }
    }

    // Function to switch the theme
    function toggleTheme() {
        if ($('body').hasClass('darkmode')) {
            $('body').removeClass('darkmode').addClass('lightmode');
            localStorage.setItem('theme', 'lightmode'); // Save the preference
        } else {
            $('body').removeClass('lightmode').addClass('darkmode');
            localStorage.setItem('theme', 'darkmode'); // Save the preference
        }
    }

    // Aplica o tema salvo quando a página carrega
    applySavedTheme();

    // Add button click event to switch theme
    $('#theme-toggle').on('click', toggleTheme);
});
