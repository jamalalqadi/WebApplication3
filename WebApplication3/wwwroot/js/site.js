function Delete(url, RowId) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        $(RowId).remove();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}

$(function () {

    $("#search1").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        $("table tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });

    });

});

const bac = $("div").css("background-color");
const color = $("*").css("color");
const b2 = $("td:contains('Create New')").css('background-color');
$(function () {
    var si = $("*,.sidebar,main,tr,a").css("font-size", ".875rem");

    $("#light").dblclick(function () {
        $("*").css({
            "background-image": "linear-gradient(#545a5f,#343a40 60%,#31373c)"
            , "color": "#fff"
        }),
            $("td:contains('Create New')").css("background-color", "#73a839")

    });
    $("#light").click(function () {
        $(" *,.sidebar, main, tr,table").css({
            "background-image": "linear-gradient(#FFF,#FFF 20%,#FFB)", "color":"black"


        }), $("div").css("color", color), $("nav").css({ "background-image": "linear-gradient(#545a5f,#343a40 60%,#31373c)" })
    });
    console.log(bac);

    $("#increases").click(function () {
        $("*,.sidebar,main,tr,a").css("font-size","30px"),
            $("*").css("overflow-x","auto")

    });
 
    $("#reset").click(function () {
       
            $("td:contains('Create New')").css("background-color", b2),
        $("*,.sidebar,main,tr,a").css("font-size", "0.875rem"), 

            $("*").css("overflow-x", "auto")

    });


});