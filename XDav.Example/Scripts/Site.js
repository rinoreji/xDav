$(function () {
    $('.fileLink').click(function (e) {
        $('#SelectedFileName').text($(this).text());
        var url = getscheme($(this).text()) + ':ofe|u|http://localhost:32351/xdav/' + $(this).text();
        $('#EditBtn').attr('href', url);
    });

    function getscheme(filename) {
        if (filename.split('.').pop().indexOf('xls') > -1)
            return 'ms-excel';

        return 'ms-word';
    }
});