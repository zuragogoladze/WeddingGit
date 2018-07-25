$(document).ready(function () {
    $("#openNav").click(function () {
        $("#mySidenav").width("280px");
    });
    $("#closeNav").click(function () {
        $("#mySidenav").width("0");
    });
    var firstRow;
    $("#addPictureForm").on("click", function () {
        firstRow = $(".customRow")[0].outerHTML;
        $(".customRow:first-child").before(firstRow);
    });
    $("#upload").click(function () {
        var data = new FormData();
        for (var i = 0; i < $(".addFile").length; i++) {
            var file = $(".addFile")[i].files[0];
            data.append("Image", file);
        }
        $.ajax({
            method: "POST",
            url: "/Admin/UploadFile",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: data,
            success: function (result) {
                if (result == true) {
                    location.href = "/Admin/AddPicture";
                }
            }
        });

    });
    $(".addOrDeleteSliderPicture").on("click", function () {
        var pictureID = $(this).data("id");
        $.ajax({
            url: "/Admin/ActivatePicture",
            method: "post",
            data: { "ID": pictureID },
            success: function (response) {
                if (response == 0) {
                    $("td").find("[data-id='" + pictureID + "']").text("გააქტიურება");
                    $("tr").find("[data-isactive='" + pictureID + "']").text("False");
                } else {
                    $("td").find("[data-id='" + pictureID + "']").text("დეაქტივაცია");
                    $("tr").find("[data-isactive='" + pictureID + "']").text("True");
                }
            }
        });
    });
    $("#upload").click(function () {
        var data = new FormData();
        for (var i = 0; i < $(".addFile").length; i++) {
            var file = $(".addFile")[i].files[0];
            data.append("Image", file);
        }
        $.ajax({
            method: "POST",
            url: "/Admin/UploadFile",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: data,
            success: function (result) {
                if (result == true) {
                    location.href = "/Admin/AddPicture";
                }
            }
        });

    });
    var pic;
    $("#addPhotographer").on("click",
        function () {
            var name = $("#name").val();
            var surname = $("#surname").val();
            var info = $("#info").val();
            var number = $("#number").val();
            var email = $("#email").val();
            var facebook = $("#facebook").val();
            var instagram = $("#instagram").val();
            var profession = $("#profession").val();
            var data = new FormData();
            for (var i = 0; i < $(".profile").length; i++) {
                var file = $(".profile")[i].files[0];
                data.append("Image", file);
            }
            var galery = new FormData();
            for (var it = 0; it < $(".galery").length; it++) {
                var galeryfile = $(".galery")[it].files[0];
                galery.append("Img", galeryfile);
            }
            $.ajax({
                method: "POST",
                url: "/Admin/UploadProfile",
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                data: data,
                success:
                    function (result) {
                        $.ajax({
                            method: "post",
                            url: "/Admin/UploadInfo",
                            data: {
                                "name": name,
                                "surname": surname,
                                "info": info,
                                "number": number,
                                "email": email,
                                "facebook": facebook,
                                "instagram": instagram,
                                "picturename": result,
                                "profession": profession
                            },
                            success: function () {
                                $.ajax({
                                    method: "POST",
                                    url: "/Admin/Uploadgalery/" + result,
                                    contentType: false, // Not to set any content header
                                    processData: false, // Not to process data
                                    data: galery
                                });
                                location.href="/Admin/Index";
                            }
                        });
                    }
            });
        });
});
