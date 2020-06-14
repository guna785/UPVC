var addEmpUrl = "/Employee/AddEmployee";
var editEmpUrl = "/Employee/EditEmployee";
var addClientUrl = "";
var editClientUrl = "";
var addSuplierUrl = "";
var editSuplierUrl = "";

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
}

