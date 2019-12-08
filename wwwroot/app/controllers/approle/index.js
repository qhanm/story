var IndexAppRole = function () {

    this.Initial = function () {
        registerEvent();
    }

    registerEvent = function () {

        var roleId = '';

        $(document).on("click", ".btnDelete", function () {

            roleId = $(this).data("id");

            alertify.alert()
                .setting({
                    'title': '<i class="fa fa-question-circle text-danger" aria-hidden="true"></i>',
                    'label': '<button class="btn btn-danger btnSubmitDelete">Delete</button>',
                    'message': '<p class="text-danger">Are you sure delete item ?</p>',
                    'onok': function () {
                        
                    }
                }).set('modal', false).show();
        })

        $(document).on("click", ".btnSubmitDelete", function () {
            $.ajax({
                type: "POST",
                url: "/admin/role/delete/" + roleId,
                success: function (response) {
                    $(".ajs-content").html("<p class='text-success'>Delete item success</p>");
                    $(".ajs-ok").html("<button class='btn btn-default btnCloseAndReload'>Close</button>");
                },
                error: function (response) {
                    alertify.error('An error occurred during processing');
                    console.log(response);
                }
            })
        })

        $(document).on("click", ".btnCloseAndReload", function () {
            window.location.reload();
        })
    }

    registerHandle = function () {
        
    }
}