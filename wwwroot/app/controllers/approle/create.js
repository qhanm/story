var CreateAppRole = function (isUpdate) {

    console.log(isUpdate);

    this.Initial = function () {
        registerEvent();
        registerHadle();
    }

    registerEvent = function () {

        $('.checkFlat').on('ifChanged', function (event) {
            var dataParent = $(this).data("parent");

            if (dataParent === undefined)
            {
                //var dataChild = $(this).data("child");
                var dataChild = $(this).attr("id");
                var arrDataChild = dataChild.split("-");

                if (arrDataChild.length == 0) {
                    return false;
                }
                if (arrDataChild[1] === "all") {
                    var idPermission = arrDataChild[2] + "-" + "check";

                    toggleCheckBox(this, idPermission, true);
                }

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

                }
                // check all [read, update, create, delete, approved]
                //else
                //{
                //    //var functionCode = arrDataParent[1];

                //    var idPermission = "permission-" + arrDataParent[0] + "-" + arrDataParent[1];

                //    toggleCheckBox(this, idPermission, true);
                //}
            }
            
        });

        $(document).on("click", "#btnSubmit", function () {
            var modelFunctions = parseDataObjectCheckBoxList();
            var modelRole = parseDataSerializeToRoleModel();

            modelFunctions = Object.assign(modelFunctions);

            modelRole = Object.assign(modelRole);

            modelFunctions = JSON.stringify(modelFunctions);

            modelRole = JSON.stringify(modelRole);

            postData(modelFunctions, modelRole);
        })
    }

    registerHadle = function () {
        if (isUpdate == 1)
        {
            getListPermission();
        }
    }

    postData = function (modelFunctions, modelRole) {



        $.ajax({
            type: "POST",
            url: "/admin/role/savechanges",
            data: {
                modelFunctions,
                modelRole
            },
            dataType: "json",
            success: function (response) {
                $("#errorContent").html("");
                if (response.Status == 0) {
                    $("#errorContent").html("<p class='text-danger'>" + response.Message + "</p>");
                    alertify.error('An error occurred during processing');
                } else {
                    alertify.success('Create permission success');
                    setTimeout(function () {
                        location.href = "/admin/role/index";
                    }, 1200);
                }
            },
            error: function (response) {
                alertify.error('An error occurred during processing');
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

    parseDataSerializeToRoleModel = function ()
    {
        var arrFrmSerialize = $("#frmCreate").serializeArray();

        var objResult = new Object();

        $.each(arrFrmSerialize, function (key, value) {
            let arrItem = value.name.split(".");

            if (arrItem.length === 0)
            {
                return false;
            }

            if (arrItem[1] === "Name")
            {
                objResult.Name = value.value;
            }

            if (arrItem[1] === "Description") {
                objResult.Description = value.value;
            }

            if (arrItem[1] === "Status") {
                if (value.value == "Active") {
                    objResult.Status = ConstantCustom.Status.Active;
                } else {
                    objResult.Status = ConstantCustom.Status.Deactive;
                }
            }
        })

        var roleId = $("#role-id").val();

        objResult.Id = roleId;

        return objResult;
    }

    parseDataObjectCheckBoxList = function ()
    {
        var roleId = $("#role-id").val();

        var checkBoxList = [];

        $.each($('.checkFlat:checkbox'), function (k, v) {
            let checked = $(v).parent().hasClass("checked") == true ? 1 : 0;
            let arrName = $(v).attr("name").split(".");
            checkBoxList.push({ function: arrName[1], action: arrName[2], value: checked });
        })

        var countCheckBoxList = checkBoxList.length;

        var listTemp = [];

        var result = [];

        for (let i = 0; i < countCheckBoxList; i++) {

            if (listTemp.indexOf(checkBoxList[i]['function']) !== -1)
            {
                continue;
            }

            let listFunction = checkBoxList.filter(x => x["function"] == checkBoxList[i]["function"]);

            let structFunction = new Object();

            $.each(listFunction, function (key, value) {

                if (value.action === "All")
                {
                    structFunction.FunctionId = value.function;
                    structFunction.Id = $("#permission-all-" + value.function).data("value");
                }

                if (value.action === "UpdateAll" || value.action === "Update")
                {
                    structFunction.Update = value.value;
                }

                if (value.action === "ReadAll" || value.action === "Read") {
                    structFunction.Read = value.value;
                }

                if (value.action === "CreateAll" || value.action === "Create") {
                    structFunction.Create = value.value;
                }

                if (value.action === "DeleteAll" || value.action === "Delete") {
                    structFunction.Delete = value.value;
                }

                if (value.action === "ApprovedAll" || value.action === "Approved") {
                    structFunction.Approved = value.value;
                }

                structFunction.RoleId = roleId;
            })
            result.push(structFunction);

            listTemp.push(checkBoxList[i]["function"]);
        }

        var objectResut = {};

        $.each(result, function (key, obj) {
            objectResut[key] = obj;
        })
        return objectResut; 
    }

    // return object {actioncode(read, update, ...) => true || false}
    getActionPermission = function (actionName = "", value = "") {
        var result = new Object();
        switch (actionName) {
            case "Read":
                result = { Read: value };
                break;
            case "Update":
                result = { Read: value };
                break;
            case "Read":
                result = { Update: value };
                break;
            case "Delete":
                result = { Delete: value };
                break;
            case "Approved":
                result = { Approved: value };
                break;
        }
        return result;
    }

    getListPermission = function ()
    {
        var permissionId = $("#role-id").val();

        $.ajax({
            type: "GET",
            url: "/admin/role/get-permission-by-id/" + permissionId,
            success: function (response) {
                var datas = response.Datas;

                $.each(datas, function (key, value) {
                    if (value.Create == true && value.Function.ParentId !== null)
                    {
                        $("#permission-create-" + value.FunctionId).iCheck("check");
                    }

                    if (value.Read == true && value.Function.ParentId !== null) {
                        $("#permission-read-" + value.FunctionId).iCheck("check");
                    }

                    if (value.Update == true && value.Function.ParentId !== null) {
                        $("#permission-update-" + value.FunctionId).iCheck("check");
                    }

                    if (value.Delete == true && value.Function.ParentId !== null) {
                        $("#permission-delete-" + value.FunctionId).iCheck("check");
                    }

                    if (value.Approved == true && value.Function.ParentId !== null) {
                        $("#permission-approved-" + value.FunctionId).iCheck("check");
                    }
                })
                
            },
            error: function (reponse) {
                console.log(reponse);
                alertify.error('An error occurred during processing');
            }
        })
    }
}