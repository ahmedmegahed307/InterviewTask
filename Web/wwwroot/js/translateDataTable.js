$(document).ready(function () {
    $('#Records').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/test",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": true
        }],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            { "data": "text", "name": "text", "autowidth": true },
            { "data": "translated", "name": "translated", "autowidth": true },

            
            //{
            //    "render": function (data, type, row) { return '<a href="/Home/Delete" class="btn btn-danger" onclick=DeleteRecord("' + row.id + '"); > Delete </a>' },
            //    "orderable": false
            //}
            {
                "render": function (data, type, row) { return '<a href="/Home/Delete/' + row.id + '" class="btn btn-danger"  > Delete </a>' },
                "orderable": false
            }
            
         
            

        ]
    });

});