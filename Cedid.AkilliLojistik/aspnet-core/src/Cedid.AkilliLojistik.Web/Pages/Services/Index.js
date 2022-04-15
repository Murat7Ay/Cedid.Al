$(function () {
    var l = abp.localization.getResource('AkilliLojistik');
    var createModal = new abp.ModalManager(abp.appPath + 'Services/CreateModal');

    var dataTable = $('#ServicesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[2, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(cedid.akilliLojistik.services.service.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AkilliLojistik.Services.Edit'),
                                    action: function (data) {
                                        var url = "/Services/Edit?Id=" + data.record.id;
                                        window.location.href = url;
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AkilliLojistik.Services.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ServiceDeletionConfirmationMessage',
                                            data.record.plateNoText
                                        );
                                    },
                                    action: function (data) {
                                        cedid.akilliLojistik.services.service.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('PlateNo'),
                    data: "plateNoText"
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewServiceButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
