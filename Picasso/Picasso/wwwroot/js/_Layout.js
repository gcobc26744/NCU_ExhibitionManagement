/*---------------------------------scroll to top-------------------------------------------------------------*/
// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () {
    showScrollTopButton();
};

function showScrollTopButton() {
    var scrollToTopBtn = document.getElementById("scrollToTopBtn");

    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        scrollToTopBtn.style.display = "block";
    } else {
        scrollToTopBtn.style.display = "none";
    }
}

function scrollToTop() {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE, and Opera
}

$("#loginForm").on("submit", function (e) {

    e.preventDefault();
        
    $.ajax({
        type: "POST",
        url: "/Member/Login/",
        dataType: "json",
        data: {
            account: $("#loginAccount").val(),
            password: $("#loginPassword").val()
        },
        success: function (response) {

            switch (response) {
                case "member":
                    window.location.href = "/Exhibition/Overview/";
                    break;

                case "Administrator":
                    window.location.href = "/Administrator/Index/";
                    break;

                case "":
                    alert("登入失敗！請重新輸入帳號密碼。");
                    break;
            }
        },
        error: function () {
            alert("系統發生錯誤");
            debugger
        }
    });
});

$("#logoutBtn").on("click", function () {
    window.location.href = "/Member/Logout/";
})

$("#registerForm").on("submit", function (e) {

    e.preventDefault();

    $.ajax({
        type: "GET",
        url: "/Member/CheckMemberAccountDuplicate?account=" + $("#registerAccount").val(),
        dataType: "json",
        success: function (response) {

            if (response) {
                $.ajax({
                    type: "POST",
                    url: "/Member/Register/",
                    dataType: "json",
                    data: {
                        account: $("#registerAccount").val(),
                        password: $("#registerPassword").val(),
                        confirmPassword: $("#confirmPassword").val(),
                        username: $("#username").val(),
                        memberPhone: $("#memberPhone").val(),
                        memberEmail: $("#memberEmail").val()
                    },
                    success: function (response) {

                        if (response) {
                            alert("會員註冊成功！");
                            window.location.href = "/Exhibition/Index/";
                        }
                        else {
                            alert("會員註冊失敗！請重新註冊。");
                        }
                    },
                    error: function () {
                        alert("系統發生錯誤");
                    }
                });
            }
            else {
                alert("會員名稱已註冊，請重新嘗試！");
            }
        },
        error: function () {
            alert("系統發生錯誤");
        }
    });
});

//展期
$('#currentExhibitionLink').on("click", function (e) {
    localStorage.setItem('period', 'current');
    GetOverview(localStorage.getItem('spaceName'), localStorage.getItem('period'));
});
$('#futureExhibitionLink').on("click", function (e) {
    localStorage.setItem('period', 'future');
    GetOverview(localStorage.getItem('spaceName'), localStorage.getItem('period'));
});

$('#pastExhibitionLink').on("click", function (e) {
    localStorage.setItem('period', 'past');
    GetOverview(localStorage.getItem('spaceName'), localStorage.getItem('period'));
});

function GetOverview(spaceName, period) {
    $.ajax({
        type: "POST",
        url: "/Exhibition/GetOverview/",
        dataType: "json",
        data: {
            spaceName: spaceName,
            period: period
        },
        success: function (response) {
            if (response) {
                window.location.href = "/Exhibition/Overview/";
            }
        },
        error: function () {
            alert("系統發生錯誤");
        }
    });
}

$("#loginBtn").on("click", function () {
    $("#loginForm")[0].reset();
})

$("#registerBtn").on("click", function () {
    $("#registerForm")[0].reset();
})