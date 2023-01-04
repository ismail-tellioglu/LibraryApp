$('body').on('click', '#btn-book-search', function (e) {
    e.preventDefault();
    let bookName = $('#BookName').val();
    let author = $('#Author').val();
    let isdn = $('#ISDN').val();

    if (!bookName && !author && !isdn) {
        $("#modal-content").html("Please fill at least one of inputs fields");
        $(".modal-title").html("Warning");
        $('#myModal').modal("show");
        return;
    }
    $.ajax({
        type: 'Post',
        url: '/Home/SearchBooks',
        data: { BookName: bookName, Author: author, ISDN: isdn },
        success: function (data) {
            $("#search-result-container").empty().html(data);
        },
        error: function (data) {
            alert("Error");
        }
    });
});
$('body').on('click', '.btn-checkout', function (e) {
    e.preventDefault();
    //alert($(this).data('bookid'));
    let isdn = $(this).data('bookid');
    $.ajax({
        type: 'Get',
        url: '/Home/CheckOut?isdn=' + isdn,
        success: function (data) {
            $(".modal-title").html("Check Out");
            $("#modal-content").html(data);
            $('#myModal').modal("show");
        },
        error: function (data) {
            alert("Error");
        }
    });
});
$('body').on('click', '#btn-book-checkout', function (e) {
    e.preventDefault();
    let memberId = $('#MemberId').val();
    let isdn = $('#ISDNToCeheckOut').val();
    $.ajax({
        type: 'Post',
        url: '/Home/CheckOut',
        data: { MemberId: memberId, ISDNToCeheckOut: isdn },
        success: function (data) { 
            $('#myModal').modal("hide");
            $('#btn-book-search').trigger("click");
            setTimeout(function () {
                $(".modal-title").html("Information");
                $("#modal-content").html("Check out is successful");
                $('#myModal').modal("show");

            }, 1000)
        },
        error: function (data) {
            $('#myModal').modal("hide");
            setTimeout(function () {
                $(".modal-title").html("Error");
                $("#modal-content").html(data.responseText);
                $('#myModal').modal("show");

            }, 1000)
        }
    });
});