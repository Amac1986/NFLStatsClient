// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function() {
    var callStats = function(postData) {
        $.ajax({
            data: postData,
            type: 'POST',
            url: $('#url').val()
        }).done(function(data, textStatus, jqXhr) {
            $(".table-contents").html(jqXhr.responseText);
        }).fail(function(jqXhr, textStatus, errorThrown) {
            //TODO
        });
    };

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

        var postData = {
            "PageNumber": parseInt($('#PageNumber').val()),
            "SortAscending": $('.statistics-table th').hasClass('asc'),
            "PlayerNameFilter": $('#search').val(),
            "SortBy": $('.sort').data("columnName")
        }
        callStats(postData);
    }

    $('.statistics-table th').click(setPostData);
    $('#search').keyup(setPostData);
    $('#nextPage').click(setPostData);


    $(document).ready(function() {
        var sort = $('#SortBy').val();
        $(`[data-column-name='${sort}']`).addClass('sort');
    });
})();

