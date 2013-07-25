jQuery(document).ready(function () {
    // Alternating table rows:
    $('.expiring-insurance-table tbody tr:nth-child(4n+1), .expiring-insurance-table tbody tr:nth-child(4n+2)').addClass("alt-row"); // Add class "alt-row" to even table rows

    $('.show-details').click(function () {
        $(this).parent().parent().next('tr.details').toggleClass("hidden");
        return false;
    });

    $('.expiring-insurance-table').find('tr.summary').filter(function () {
        return $(this).data('similarrecords') > 1;
    }).next('tr.details').find('.hidden').removeClass('hidden');

    
    $('.create-email').on('click', function () {
        var to = $(this).parent('td').prev('td').find('a.broker-email').attr('href');
        var subject = "Request";
        var body = "The body";
        window.location.href = to + "?subject=" + subject + "&body=" + body;
        return false;
    });

});
