/*---------------------------------換頁-------------------------------------------------------------*/
document.addEventListener("DOMContentLoaded", function () {
    const maxPages = 3; // 你的最大頁數
    const paginationContainer = document.getElementById("pagination");
    const prevButton = paginationContainer.querySelector(".prev");
    const nextButton = paginationContainer.querySelector(".next");

    // 動態生成頁數按鈕
    for (let i = 1; i <= maxPages; i++) {
        const pageItem = document.createElement("li");
        pageItem.classList.add("page-item");
        const pageLink = document.createElement("a");
        pageLink.classList.add("page-link");
        pageLink.href = "#";
        pageLink.textContent = i;
        pageItem.appendChild(pageLink);
        paginationContainer.insertBefore(pageItem, nextButton);
    }
});


//展廳
$('#artAreaLink').on("click", function (e) {
    localStorage.setItem('spaceName', '人文藝術中心');
    localStorage.setItem('SpaceTab', '1');
    GetOverview(localStorage.getItem('spaceName'), localStorage.getItem('period'));
});
$('#107MovieLink').on("click", function (e) {
    localStorage.setItem('spaceName', '107電影院');
    localStorage.setItem('SpaceTab', '2');
    GetOverview(localStorage.getItem('spaceName'), localStorage.getItem('period'));
});

$('#blackBoxLink').on("click", function (e) {
    localStorage.setItem('spaceName', '黑盒子劇場');
    localStorage.setItem('SpaceTab', '3');
    GetOverview(localStorage.getItem('spaceName'), localStorage.getItem('period'));
});

switch (localStorage.getItem('SpaceTab')) {
    case '1':
        $('#artAreaLink').css({ 'color': 'white', 'background': '#098A9B' });
        $('#107MovieLink').css({ 'color': '#3D7188', 'background': '#D2EEEE' });
        $('#blackBoxLink').css({ 'color': '#3D7188', 'background': '#D2EEEE' });

        break;

    case '2':
        $('#107MovieLink').css({ 'color': 'white', 'background': '#098A9B' });
        $('#artAreaLink').css({ 'color': '#3D7188', 'background': '#D2EEEE' });
        $('#blackBoxLink').css({ 'color': '#3D7188', 'background': '#D2EEEE' });

        break;

    case '3':
        $('#blackBoxLink').css({ 'color': 'white', 'background': '#098A9B' });
        $('#artAreaLink').css({ 'color': '#3D7188', 'background': '#D2EEEE' });
        $('#107MovieLink').css({ 'color': '#3D7188', 'background': '#D2EEEE' });

        break;
}

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