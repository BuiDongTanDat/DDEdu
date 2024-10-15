$(document).ready(function () {
    var newsToShow = 2; // Số lượng tin tức sẽ hiển thị thêm mỗi lần

    // Hàm để cập nhật số lượng tin tức cho tab hiện tại
    function updateNewsCount(tab) {
        var $newsItems = $(tab).find(".news-item");
        var totalNews = $newsItems.length; // Tổng số tin tức trong tab
        var currentVisible = 3; // Số lượng tin tức hiện đang hiển thị

        $newsItems.addClass("d-none");
        $newsItems.filter(':lt(' + currentVisible + ')').removeClass("d-none");

        // Cập nhật nút "View More"
        if (totalNews <= currentVisible) {
            $(tab).siblings(".view-more").text("Minimize");
        } else {
            $(tab).siblings(".view-more").text("View More");
        }

        // Lưu trữ dữ liệu trong tab
        $(tab).data('currentVisible', currentVisible);
        $(tab).data('totalNews', totalNews);
    }

    // Khởi tạo cho tất cả các tab
    $(".tab-pane").each(function () {
        updateNewsCount(this);
    });

    // Xử lý sự kiện khi nhấn nút "View More"
    $(".view-more").click(function () {
        var tab = $(this).closest('.tab-pane'); // Lấy tab hiện tại
        var $newsItems = tab.find(".news-item");
        var totalNews = tab.data('totalNews'); // Tổng số tin tức trong tab
        var currentVisible = tab.data('currentVisible'); // Số lượng tin tức hiện đang hiển thị

        if ($(this).text() === "View More") {
            // Hiển thị thêm các tin tức
            currentVisible += newsToShow;
            $newsItems.filter(':lt(' + currentVisible + ')').removeClass("d-none");

            // Kiểm tra nếu đã hiển thị hết các tin tức
            if (currentVisible >= totalNews) {
                $(this).text("Minimize");
            }
        } else {
            // Ẩn bớt các tin tức, chỉ để lại 3 tin đầu tiên
            currentVisible = 3;
            $newsItems.addClass("d-none");
            $newsItems.filter(':lt(' + currentVisible + ')').removeClass("d-none");
            $(this).text("View More");
        }

        // Cập nhật lại số lượng tin tức hiện đang hiển thị
        tab.data('currentVisible', currentVisible);
    });
});
