$(document).ready(function() {
    $("#grid").kendoGrid({
        height: 550,
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                field: "Name",
                width: 100
            },
            {
                field: "DateOfBirth",
                width: 60
            },
            {
                field: "Country",
                width: 50
            },
            {
                field: "Edit",
                width: 30
            },
            {
                field: "Details",
                width: 40
            },
            {
                field: "Delete",
                width: 40
            }
        ]
    });
});