// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    $(document).ready(function(){
        $("[name=btnradiolang]").not(":checked").click(function () {
            if ($(this).val() == "TH") {
                window.location.href = 'Home/SetThai';
            } else {
                window.location.href = 'Home/SetEnglish';
            }
        })

        $(".navbar li.nav-item, .navbar li.nav-item li.dropend").mouseover(function () {
            //$(this).click()
            if (window.innerWidth > 992) {
                $(this).children("ul.dropdown-menu").addClass("show").attr("data-bs-popper", "dropdown");
            }
        })
        $(".navbar li.nav-item, .navbar li.nav-item li.dropend").mouseout(function () {
            //$(this).click()
            if (window.innerWidth > 992) {
                $(this).children("ul.dropdown-menu").removeClass("show").removeAttr("data-bs-popper");
            }
        })

        if (window.innerWidth > 992) {

        }
    });

document.addEventListener('click', function (e) {
    // Hamburger menu
    if (e.target.classList.contains('hamburger-toggle')) {
        e.target.children[0].classList.toggle('active');
    }
})

function MM_openBrWindow(theURL, winName, features) { //v2.0
    window.open(theURL, winName, features);
}
function redirect(url) {
    var delayInMilliseconds = 100;
    setTimeout(function () {
        window.location.href = url; 
    }, delayInMilliseconds);
}
function redirectNewTab(url) {
    var delayInMilliseconds = 100;
    setTimeout(function () {
        window.open(url, "_blank");
    }, delayInMilliseconds);
}
//data-bs-popper