var addEmpUrl = "/Employee/AddEmployee";
var editEmpUrl = "/Employee/EditEmployee";
var addClientUrl = "/Client/AddClient";
var editClientUrl = "/Client/EditClient";
var addSuplierUrl = "/Suplier/AddSuplier";
var editSuplierUrl = "/Suplier/EditSuplier";
var addMaterialType = "/Meterial/AddMaterialType/";

function JsonPOST(url, data) {
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        processData: false,
        async: true,
        success: function (response) {
            sweetAlert('Congratulations!', response.status, 'success');
            $(".modal").modal("hide");
        },
        error: function (e) {
            swal("Oops", e.responseText, "error");
            $(".modal").modal("hide");
        }
    });
}

function DoAction(action, data) {
    if (action === "Add Employee") {
        JsonPOST(addEmpUrl, data);
        LoadData();
    }
    else if (action === "Edit Employee") {
        JsonPOST(editEmpUrl, data);
        LoadData();
    }
    else if (action === "Add Client") {
        JsonPOST(addClientUrl, data);
        LoadData();
    }
    else if (action === "Edit Client") {
        JsonPOST(editClientUrl, data);
        LoadData();
    }
    else if (action === "Add Suplier") {
        JsonPOST(addSuplierUrl, data);
        LoadData();
    }
    else if (action === "Edit Suplier") {
        JsonPOST(editSuplierUrl, data);
        LoadData();
    }
    else if (action === "Add Material Type") {
        JsonPOST(addMaterialType, data);
        LoadData();
    }
}

