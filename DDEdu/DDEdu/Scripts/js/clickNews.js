$(document).ready(function () {
    var newsToShow = 2; // Number of news items to show each time

    function updateNewsCount(tab) {
        var $newsItems = $(tab).find(".news-item");
        var totalNews = $newsItems.length;
        var currentVisible = 3; // Initially visible items

        // Hide all news items
        $newsItems.addClass("d-none");
        // Show the first 'currentVisible' items
        $newsItems.filter(':lt(' + currentVisible + ')').removeClass("d-none");

        // Update "View More" button
        if (totalNews <= currentVisible) {
            $(tab).find(".view-more").text("Minimize");
        } else {
            $(tab).find(".view-more").text("View More");
        }

        // Store the current visible count and total news in the tab
        $(tab).data('currentVisible', currentVisible);
        $(tab).data('totalNews', totalNews);
    }

    // Initialize all tabs
    $(".tab-pane").each(function () {
        updateNewsCount(this);
    });

    // Handle tab change
    $('button[data-bs-toggle="tab"]').on('click', function () {
        var targetTab = $(this).data('bs-target'); // Get the target tab ID
        updateNewsCount($(targetTab)); // Update news count for the newly activated tab
    });

    // Handle "View More" button click event
    $(".view-more").click(function () {
        var tab = $(this).closest('.tab-pane'); // Get the current tab
        var $newsItems = tab.find(".news-item");
        var totalNews = tab.data('totalNews');
        var currentVisible = tab.data('currentVisible');

        if ($(this).text() === "View More") {
            currentVisible += newsToShow;
            $newsItems.filter(':lt(' + currentVisible + ')').removeClass("d-none");

            if (currentVisible >= totalNews) {
                $(this).text("Minimize");
            }
        } else {
            currentVisible = 3; // Reset to show only the first 3
            $newsItems.addClass("d-none");
            $newsItems.filter(':lt(' + currentVisible + ')').removeClass("d-none");
            $(this).text("View More");
        }

        // Update the current visible count
        tab.data('currentVisible', currentVisible);
    });
});
