$(document).ready(function () {
    var url = "Item/LoadItems";
    $('#itemTable').dataTable({
        processing: true,
        serverSide: true,
        filter: true,
        paging: true,
        ajax: {
            url: url,
            type: "POST",
            datatype: "json"
        },
        columnDefs: [{
            targets: [0],
            visible: false,
            searchable: false
        },
            {
                targets: [1],
                orderable: false,
                searchable: false
            },
            {
                targets: [5],
                orderable: false,
                searchable: false
            }        ],
        columns: [
            { data: "id", name: "Id", autoWidth: true },
            {
                data: "entity_Category.name",
                name: "Category",
                autoWidth: true
            },
            { data: "name", name: "Name", autoWidth: true },
            { data: "itemCode", name: "ItemCode", autoWidth: true },
            { data: "price", name: "Price", autoWidth: true },
            {
                data : "id",
                render: function (d) {
                    return "<a href='#' class='btn btn-dark' onclick=Edit('" + d + "'); >Edit</a> " +
                        "<a href='#' class='btn btn-danger' onclick=Delete('" + d + "'); >Delete</a>";
                }
            },
        ]
    });
});
function Delete(id) {
    alertify.confirm('Are you sure you want to delete this record?', function () {
        $.ajax({
            url: "/Item/Delete/" + id,
            method: "GET",
            success: function (data) {
                ReloadTable();
                if (data.result.statusCode == "200")
                    alertify.success(data.result.message);
                else if (data.result.statusCode == "500")
                    alertify.error(data.result.message);
            },
            error: function (err) {
                console.error(err);
            }
        })
    }, null);
}
function Edit(id) {
    window.location.href = "/Item/Create/" + id;
}
function ReloadTable() {
    $('#itemTable').DataTable().ajax.reload();
}