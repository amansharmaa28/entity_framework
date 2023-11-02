﻿    $(document).ready(function () {
    GetCountry();
    $('#Country').change(function () {
        var id = $(this).val();
        $('#State').empty();
        $('#State').append('<Option>--Select State--</Option>');
        $.ajax({
            url: '/Cascade/State?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#State').append('<Option value=' + data.id + '>' + data.name + '</Option>');

                });
            }

        });
    });

    $('#State').change(function () {
        var id = $(this).val();
        $('#City').empty();
        $('#City').append('<Option>--Select City--</Option>');
        $.ajax({
            url: '/Cascade/City?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#City').append('<Option value=' + data.id + '>' + data.name + '</Option>');

                });
            }

        });
    });    
});

function GetCountry() {
    $.ajax({
        url: '/Cascade/Country',
        success: function (result) {
            $.each(result, function (i,data) {
                $('#Country').append('<Option value = '+data.id+ '>'+data.name+' </Option>');

            });
        }
    });
}
   