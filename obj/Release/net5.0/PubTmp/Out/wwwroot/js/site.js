// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('a[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            $('#modalshow').html(data);
            $('#modalshow').find('.modal').modal("show");
        })
    })
})

function typecase(btn) {
    $('.case').removeClass("active");
    $('.case').addClass("bg-light");
    document.getElementById('TNewContract').style.display = 'none';
    document.getElementById('TCheckContract').style.display = 'none';
    document.getElementById('TWaitPayContract').style.display = 'none';
    document.getElementById('TWaitScheduleContract').style.display = 'none';
    document.getElementById('TScheduleContract').style.display = 'none';
    document.getElementById('TScheduleContractToday').style.display = 'none';    
    document.getElementById('TEndContract').style.display = 'none';
    if (btn == 'NewContract') {
        $('#NewContract').addClass("active");
        $('#NewContract').removeClass("bg-light");
        document.getElementById('TNewContract').style.display = '';
    }
    if (btn == 'CheckContract') {
        $('#CheckContract').addClass("active");
        $('#CheckContract').removeClass("bg-light");
        document.getElementById('TCheckContract').style.display = '';
    }
    if (btn == 'WaitPayContract') {
        $('#WaitPayContract').addClass("active");
        $('#WaitPayContract').removeClass("bg-light");
        document.getElementById('TWaitPayContract').style.display = '';
    }
    if (btn == 'WaitScheduleContract') {
        $('#WaitScheduleContract').addClass("active");
        $('#WaitScheduleContract').removeClass("bg-light");
        document.getElementById('TWaitScheduleContract').style.display = '';
    }
    if (btn == 'ScheduleContract') {
        $('#ScheduleContract').addClass("active");
        $('#ScheduleContract').removeClass("bg-light");
        document.getElementById('TScheduleContract').style.display = '';
    }
    if (btn == 'ScheduleContractToday') {
        $('#ScheduleContractToday').addClass("active");
        $('#ScheduleContractToday').removeClass("bg-light");
        document.getElementById('TScheduleContractToday').style.display = '';
    }
    if (btn == 'EndContract') {
        $('#EndContract').addClass("active");
        $('#EndContract').removeClass("bg-light");
        document.getElementById('TEndContract').style.display = '';
    }
}