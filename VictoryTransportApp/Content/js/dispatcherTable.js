var table;

$(document).ready(function () {
    $.ajax({
        url: 'WebServices/DispatcherService.asmx/GetDispatchers',
        method: 'post',
        dataType: 'json',
        success: function (data) {
            table  = $('#dispatchertable').DataTable({
                //dom: 'Bfrtip',
                dom: 'lBfrtip',
                paging: true,
                buttons: [
                    'searchPanes', 'pdf', 'excel', 'print', 'copy', 'colvis'
                ],
                scrollX: true,
                data: data,
                columns: [
                    { 'data': 'Uid', visible: false },
                    { 'data': 'Name' },
                    { 'data': 'Phone' },
                    { 'data': 'Email' },
                    { 'data': 'Ssn' },
                    {
                        data: 'Uid',
                        render: function (data, type, row, meta) {
                            return `<div class="text-center">
                                        <a href="EditDispatcher.aspx?id=${data}" class='btn btn-outline-success btn-sm' style='cursor:pointer;'>
                                            Edit
                                        </a>
                                    </div>`
                        }, "width": "5%"
                    }
                ]
            });
        }
    });

    $('#dispatchertable').on('click', 'tr', function () {
        //console.log('Tıklandı...');
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    $('#ButonDeleteRow').click(function () {
        //table.row('.selected').remove().draw(false);
        var uid = table.row('.selected').data().Uid;
        console.log(uid);
        var url = "Dispatchers.aspx/deleteDispatcher"

        Swal.fire({
            title: 'Do you want to delete the selected Dispatcher?',
            showDenyButton: true,
            confirmButtonText: `Delete`,
            denyButtonText: `Don't delete`,
        }).then((result) => {
            if (result.isDenied) {
                return false;
            } else if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ dispatcher_id: uid }),
                    datatype: "json",
                    success: function (response) {
                        console.log(response);
                        if (response.d === "done") {
                            toastr.success('Dispatcher is deleted.');
                            //Swal.fire('Dispatcher is deleted.', '', 'info')
                            //table.ajax.reload();
                            //$('#dispatchertable').DataTable().ajax.reload(null,false);
                            $('#dispatchertable').DataTable().destroy();
                        }
                        else {
                            Swal.fire('Error when deleting!', '', 'info')
                        }
                    }
                });

                
                
                //return true;
            }


            //if (result.isConfirmed) {
            //    Swal.fire('Deleted!', '', 'success')
            //} else if (result.isDenied) {
            //    Swal.fire('Changes are not saved', '', 'info')
            //}
        })

        
    });

    //$('#dispatchertable').on('click', 'delete_dispatcher', function () {
    //    console.log('Tıklandı...');
    //    var row = $(this).closest('tr');

    //    var data = table.row(row).data().position;
    //    console.log(data);
    //});
});
