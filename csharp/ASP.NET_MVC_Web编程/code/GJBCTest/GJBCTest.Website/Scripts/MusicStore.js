$(function () {
    $("#dealImg").mouseover(function () {
        $(this).effect("bounce", { time: 3, distance: 40 });
    });
    $("#searchArtist").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        //$.getJSON(form.attr("action"), form.serialize(), function (data) {
        //    var html = Mustache.to_html($("#artistTemplate").html(), { artists: data });
        //    $("#index_div_table").empty().append(html);
        //});
        //**使用$.ajax获得更多灵活性***//
        $.ajax({
            url: form.attr("action"),
            data: form.serialize(),
            beforeSend: function () {
                $("#ajax-loader").show();
            },
            complete: function () {
                $("#ajax-loader").hide();
            },
            error: searchFailed,
            success: function (data) {
                var html = Mustache.to_html($("#artistTemplate").html(), { artists: data });
                $("#index_div_table").empty().append(html);
            }

        });
    });
});
function searchFailed() {
    alert('有异常发生,查询失败！');
}

