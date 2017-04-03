var RecordsService = function () {

    var deleteRecord = function (recId, success) {
        $.ajax({
            url: "/api/history/" + recId,
            method: "DELETE",
            success: success
        });
    };

    var getAllRecords = function (container, dateFormat, deleteButton, editButton) {

        $(container).DataTable({
            ajax: {
                url: "/api/history",
                dataSrc: ""
            },
            columns: [
                {
                    data: "day",
                    render: dateFormat
                },
                {
                    data: "tmax"
                },
                {
                    data: "tmin"
                },
                {
                    data: "tmean"
                },
                {
                    data: "precip"
                },
                {
                    data: "snow"
                },
                {
                    data: "snowdepth"
                },
                {
                    data: "id",
                    render: deleteButton
                },
                {
                    data: "id",
                    render: editButton
                }
            ]
        });
    };

    var getReadOnlyRecords = function (container, dateFormat) {

        $(container).DataTable({
            ajax: {
                url: "/api/history",
                dataSrc: ""
            },
            columns: [
                {
                    data: "day",
                    render: dateFormat
                },
                {
                    data: "tmax"
                },
                {
                    data: "tmin"
                },
                {
                    data: "tmean"
                },
                {
                    data: "precip"
                },
                {
                    data: "snow"
                },
                {
                    data: "snowdepth"
                }
            ]
        });
    };

    return {

        deleteRecord: deleteRecord,
        getAllRecords: getAllRecords,
        getReadOnlyRecords: getReadOnlyRecords
    }

}();