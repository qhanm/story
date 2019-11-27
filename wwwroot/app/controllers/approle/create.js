var CreateAppRole = function () {

    this.Initial = function () {
        registerEvent();
    }

    registerEvent = function () {

        $('.checkFlat').on('ifChanged', function (event) {
            var dataParent = $(this).data("parent");

            if (dataParent === undefined)
            {
                console.log("vvv")
            }
            else
            {
                var arrDataParent = dataParent.split("-");

                if (arrDataParent.length == 0)
                {
                    return false;
                }

                // check all function parent
                if (arrDataParent[0] === "all") {
                    var idPermission = $(this).attr("id");

                    toggleCheckBox(this, idPermission);

                    //var idPermission = $(this).attr("id");

                    //var listAllPermission = $.find("[data-child='" + idPermission + "']");

                    //var Checked = "check";

                    //if ($(this).parent('[class*="icheckbox"]').hasClass("checked") == true) {
                    //    Checked = "uncheck";
                    //}


                    //$.each(listAllPermission, function (key, value) {
                    //    $(value).iCheck(Checked);
                    //})
                }
                // check all [read, update, create, delete, approved]
                else
                {
                    var functionCode = arrDataParent[1];

                    var idPermission = "permission-" + arrDataParent[0] + "-" + arrDataParent[1];
                    console.log(idPermission);
                    console.log(arrDataParent);
                    toggleCheckBox(this, idPermission, true);


                }
            }
            
        });

        $(document).on("click", "#btnSubmit", function () {
           
            $.each($('.checkFlat:checkbox'), function (k, v) {
                console.log($(v).val());
            })
    
            console.log($("#frmCreate").serialize())
        })
    }

    registerHadle = function () {

    }

    postData = function () {
        $.ajax({
            type: "POST",
            url: "/admin/role/savechanges",
            data: {},
            success: function (response) {

            },
            error: function (response) {
                console.log(responses);
            }
        })
    }

    toggleCheckBox = function (iThis, idPermission, isChangeDomFind = false)
    {

        if (isChangeDomFind == true) {
            var listAllPermission = $.find("." + idPermission);
        } else {
            var listAllPermission = $.find("[data-child='" + idPermission + "']");
        }

        var Checked = "check";

        if ($(iThis).parent('[class*="icheckbox"]').hasClass("checked") == true) {
            Checked = "uncheck";
        }

        $.each(listAllPermission, function (key, value) {
            $(value).iCheck(Checked);
        })
    }

    parseDataObjectCheckBoxList = function () {

    }
}