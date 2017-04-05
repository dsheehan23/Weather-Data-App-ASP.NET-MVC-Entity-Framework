var RecordsController = function (recordsService) {

    var button;
    var table;

    var initReadOnly = function (container) {

        recordsService.getReadOnlyRecords(container, dateFormat);
    }

    var init = function (container) {

        table = recordsService.getAllRecords(container, dateFormat, deleteButton, editButton);
        $(container).on("click", ".js-delete", deleteRecord);
        
    };

    var success = function () {
        table.row(button.parents("tr")).remove().draw();
    };

    var deleteRecord = function () {

        button = $(this);
        var recId = button.attr("data-history-id");
        bootbox.confirm("Are you sure you want to delete this record?", function (result) {
            if (result) 
                recordsService.deleteRecord(recId, success);
        });
    };

    var dateFormat = function (data, type, row) {
        var dataSplit = data.split("T");
        return type === "display" || type === "filter" ?
            dataSplit[0] :
            data;
    };

    var deleteButton = function (data) {
        return "<button class='btn-link js-delete' data-history-id=" + data + ">Delete</button>";
    };

    var editButton = function (data) {
        return "<button class='btn-link js-edit' data-history-id=" + data + ">Edit</button>";
    };

    return {
        init: init,
        initReadOnly: initReadOnly
    }

}(RecordsService);

