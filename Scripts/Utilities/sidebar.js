$('#sidebarToggle').click(() => {
    if ($("#sidebar").hasClass("sidebar-collapse")) {
        $("#sidebar").removeClass("sidebar-collapse");
        $("#main").removeClass("exp");
        $("#sidebarToggle").html("<i class='fa-solid fa-bars'></i>")
    }
    else {
        $("#sidebar").addClass("sidebar-collapse");
        $("#main").addClass("exp");
        $("#sidebarToggle").html("<i class='fa-solid fa-bars-staggered'></i>")
    }
})

switch (sidebarLink) {
    case 1:
        $('.sidebar-item')[0].classList.add('sidebar-active');
        break;
    case 2:
        $('.sidebar-item')[1].classList.add('sidebar-active');
        break;
    case 3:
        $('.sidebar-item')[2].classList.add('sidebar-active');
        break;
    case 4:
        $('.sidebar-item')[3].classList.add('sidebar-active');
        break;
    case 5:
        $('.sidebar-item')[4].classList.add('sidebar-active');
        break;
    case 6:
        $('.sidebar-item')[5].classList.add('sidebar-active');
        break;

    default:
        $('sidebar-item').removeClass('sidebar-active');
        break;
}