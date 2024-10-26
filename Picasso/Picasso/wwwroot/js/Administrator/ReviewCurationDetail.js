if (!($("select option:selected").text() == "待審核")) {
    $('select').attr("disabled", true);
}

$('select').on('change', function () {
    $.ajax({
        type: "POST",
        url: "/Administrator/ReviewCurationDetail/",
        dataType: "json",
        data: {
            exhibitionId: $("#exhibitionId").val(),
            exhibitionStatus: $("select option:selected").text()
        },
        success: function (response) {
            if (response) {
                $('select').attr("disabled", true);

                alert('狀態修改成功！');
            }
            else {
                alert('狀態修改失敗！');
            }
        },
        error: function () {
            alert("系統發生錯誤");
        }
    });
})