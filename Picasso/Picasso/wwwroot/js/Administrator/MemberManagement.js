var memberId;

var modalConfirm = function (callback) {

    $(".deleteBtn").on("click", function () {
        $("#mi-modal").modal('show');
        memberId = $(this).next().val()
    });

    $("#modal-btn-no").on("click", function () {
        callback(true);
        $("#mi-modal").modal('hide');
    });

    $("#modal-btn-delete").on("click", function () {
        callback(false);
        $("#mi-modal").modal('hide');
    });
};

modalConfirm(function (confirm) {
    if (confirm) {
        
    } else {
        //Acciones si el usuario no confirma
        $.ajax({
            type: "GET",
            url: "/Administrator/DeleteMember?memberId=" + memberId,
            dataType: "json",
            success: function (response) {
                if (response) {
                    alert('會員刪除成功！');
                    window.location.href = "/Administrator/MemberManagement/";
                }
                else {
                    alert('會員刪除失敗！');
                }
            },
            error: function () {
                alert("系統發生錯誤");
            }
        });
    }
});