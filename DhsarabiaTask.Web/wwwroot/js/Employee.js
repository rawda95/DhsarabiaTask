$(document).on('submit', '#addEmployeeForm', function (e) {
    e.preventDefault();
    $('.overlay-spinner').css('display', 'flex');
    $("#CancelAddEmployeeModal").click();
        if ($(this).valid()) {

            var formData = new FormData(this);
            let employeeName = $("#employeeName").val();

            $.ajax({
                cache: false,
                url: $(this).attr('action'),
                type: $(this).attr('method'),
                data: formData,
                contentType: false,
                processData: false,
                success: function (response) {
                    $('.overlay-spinner').css('display', 'none');
                    console.dir(response);

                        swal({
                            text: "Your Employee has been added successfully!",
                            icon: 'success',

                        }).then((result) => {
                            AddNewEmploeeToTable(response.id,response.firstName);
                        });  
                }
            });
        }
});



$(document).on('submit', '#deleteEmployeeForm', function (e) {
    e.preventDefault();
    $('.overlay-spinner').css('display', 'flex');
    $("#CanceldeleteEmployeeModal").click();
    if ($(this).valid()) {

        var formData = new FormData(this);
        let employeeId = $(this).find(".EmployeeId").val();
        console.log(employeeId);

        $.ajax({
            cache: false,
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                $('.overlay-spinner').css('display', 'none');
                $(`#${employeeId}`).remove();

                if ($("table tbody tr").length == 0) {
                    $("table").attr("hidden","hidden");
                }
                swal({
                    text: "Your Employee has been deleted successfully!",
                    icon: 'success',

                }).then((result) => {
                });
            }
        });
    }
});


$(document).on('submit', '#editEmployeeForm', function (e) {
    e.preventDefault();
    $('.overlay-spinner').css('display', 'flex');
    $("#CanceleditEmployeeModal").click();
    if ($(this).valid()) {

        var formData = new FormData(this);
        let employeeId = $(this).find(".EmployeeId").val();
        let employeeName = $(this).find(".EmployeeFirstName").val();
        


        $.ajax({
            cache: false,
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                $('.overlay-spinner').css('display', 'none');
                UpdateEmploeeUI(employeeId, employeeName);

                swal({
                    text: "Your Employee has been added successfully!",
                    icon: 'success',

                }).then((result) => {
                });
            }
        });
    }
});


function AddNewEmploeeToTable(employeeId,employeeName) {

    let html = `<tr id="employeeId">

                                <td class="employeeName">${employeeName}</td>

                                <td>
                                    <a href="#editEmployeeModal" onclick="EditEmployeeClick(this,'@employee.Id')" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                                    <a href="#deleteEmployeeModal" onclick="DeleteEmployeeClick('@employee.Id')" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                                </td>
                            </tr>`;

    if ($("table")[0].hasAttribute("hidden")) {
        $('.table').removeAttr('hidden');
    }
    $("table").append(html);
}

function UpdateEmploeeUI(EmployeeId, employeeName) {
    $(`#${EmployeeId}`).find(".employeeName").text(employeeName);
}


function DeleteEmployeeClick(employeeId) {
        $("#deleteEmployeeModal .EmployeeId").val(employeeId);
}

function EditEmployeeClick(elem ,employeeId) {
    $("#editEmployeeModal .EmployeeId").val(employeeId);
    var employeeName = $(elem.parentElement.parentElement).find(".employeeName").text();
    $("#editEmployeeModal .EmployeeFirstName").val(employeeName);

}