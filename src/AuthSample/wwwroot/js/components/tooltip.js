var tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
var tooltipList = [];

tooltipTriggerList.forEach(function (tooltipTriggerEl) {
    var tooltip = new bootstrap.Tooltip(tooltipTriggerEl);
    tooltipList.push(tooltip);

    // Add a click event to hide the tooltip on click
    tooltipTriggerEl.addEventListener('mouseleave', function () {
        tooltip.hide();
    });
});