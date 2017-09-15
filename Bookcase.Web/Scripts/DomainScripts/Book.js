$(document).ready(function() {
    $("#grid").kendoGrid({
        height: 400,
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                field: "Title",
                width: 100
            },
            {
                field: "PublishingHouse",
                width: 60
            },
            {
                field: "Year",
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