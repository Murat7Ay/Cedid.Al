$(function () {
    var l = abp.localization.getResource('AkilliLojistik');
    var createModal = new abp.ModalManager(abp.appPath + 'Parameters/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Parameters/EditModal');

    var dataTable = $('#ParametersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(cedid.akilliLojistik.parameters.parameter.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AkilliLojistik.Parameters.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AkilliLojistik.Parameters.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ParameterDeletionConfirmationMessage',
                                            data.record.text
                                        );
                                    },
                                    action: function (data) {
                                        cedid.akilliLojistik.parameters.parameter.delete(data.record.id)
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
                    title: l('Code'),
                    data: "code"
                },
                {
                    title: l('Text'),
                    data: "text"
                },
                {
                    title: l('IsActive'),
                    data: "isActive"
                },
                {
                    title: l('Spec1'),
                    data: "spec1"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewParameterButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
