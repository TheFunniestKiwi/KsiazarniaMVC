var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#datatable').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "street", "width": "15%" },
            { "data": "province", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
						<a href="/Admin/Company/Upsert?id=${data}"
						class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a>
                        <a onClick=Delete('/Admin/Company/Delete/${data}')
						class="btn btn-primary mx-2"><i class="bi bi-trash-fill"></i>Delete</a>
					</div>`
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure',
        text: 'This action is not reversible',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Delete'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload()
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}