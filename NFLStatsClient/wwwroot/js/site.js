// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function() {
    var callStats = function(postData, url) {
        $.ajax({
            data: postData,
            type: 'POST',
            url: url
        }).done(function (data, textStatus, jqXhr) {
            if (jqXhr.getResponseHeader("content-type") === "text/html; charset=utf-8") {
                $(".table-contents").html(jqXhr.responseText);
            } else {
                var a = document.createElement('a');
                var blob = new Blob([data], { type: "text/csv" });
                var target = window.URL.createObjectURL(blob);
                a.href = target;
                a.download = "Stats";
                document.body.append(a);
                a.click();
                a.remove();
                window.URL.revokeObjectURL(url);
            }
        }).fail(function(jqXhr, textStatus, errorThrown) {
            //TODO
        });
    };

    var setUrl = function(event) {
        var url;
        if (event.target.nodeName !== "SPAN") {
            url = $('#url').val()
        } else {
            url = $(event.target).data("url");
        }

        return url;
    }
    var setPageNumber = function(event) {
        if ($(event.target).is($('#nextPage'))) {
            var curPageNum = parseInt($('#PageNumber').val());
            var pageNumber = curPageNum + 1;
            $('#PageNumber').val(pageNumber.toString());
        } else {
            $('#PageNumber').val("1");
        }
    }

    var handleSortOrder = function(event) {
        if (event.target.nodeName === "TH") {
            var target = $(event.target);
            if (target.hasClass('sort')) {
                target.toggleClass('asc');
            } else {
                $('.statistics-table th').removeClass();
                target.addClass('sort');
            }
        }
    }

    var setPostData = function(event) {

        setPageNumber(event);
        handleSortOrder(event);
        var url = setUrl(event);
        var postData = {
            "PageNumber": parseInt($('#PageNumber').val()),
            "SortAscending": $('.statistics-table th').hasClass('asc'),
            "PlayerNameFilter": $('#search').val(),
            "SortBy": $('.sort').data("columnName")
        }
        callStats(postData, url);
    }

    $('.statistics-table th').click(setPostData);
    $('#search').keyup(setPostData);
    $('#nextPage').click(setPostData);
    $('#subSet').click(setPostData);
    $('#fullSet').click(setPostData);


    $(document).ready(function() {
        var sort = $('#SortBy').val();
        $(`[data-column-name='${sort}']`).addClass('sort');
    });
})();

