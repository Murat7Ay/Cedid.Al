$(function () {
    var l = abp.localization.getResource('AkilliLojistik');
    var createUsedMaterialModal = new abp.ModalManager(abp.appPath + 'Services/CreateUsedMaterialModal');
    var editUsedMaterialModal = new abp.ModalManager(abp.appPath + 'Services/EditUsedMaterialModal');
    var createSuggestMaterialModal = new abp.ModalManager(abp.appPath + 'Services/CreateSuggestMaterialModal');
    var editSuggestMaterialModal = new abp.ModalManager(abp.appPath + 'Services/EditSuggestMaterialModal');
    var createOperationModal = new abp.ModalManager(abp.appPath + 'Services/CreateOperationModal');
    var editOperationModal = new abp.ModalManager(abp.appPath + 'Services/EditOperationModal');
    var createAccessoryModal = new abp.ModalManager(abp.appPath + 'Services/CreateAccessoryModal');
    var editAccessoryModal = new abp.ModalManager(abp.appPath + 'Services/EditAccessoryModal');

    var dataTable = $('#UsedMaterialsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[3, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(cedid.akilliLojistik.serviceMaterials.serviceMaterial.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AkilliLojistik.ServiceMaterials.Edit'),
                                    action: function (data) {
                                        editUsedMaterialModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AkilliLojistik.ServiceMaterials.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ServiceMaterialDeletionConfirmationMessage',
                                            data.record.plateNoText
                                        );
                                    },
                                    action: function (data) {
                                        cedid.akilliLojistik.serviceMaterials.serviceMaterial.delete(data.record.id)
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
                    title: l('StockCode'),
                    data: "stockCodeText"
                },
                {
                    title: l('WareHouseCode'),
                    data: "wareHouseCodeText"
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('Description'),
                    data: "description"
                }                
                
            ]
        })
    );

    createUsedMaterialModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editUsedMaterialModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUsedMaterial').click(function (e) {
        e.preventDefault();
        createUsedMaterialModal.open();
    });

    $('#ServiceList').click(function (e) {
        var url = "/Services/Index";
        window.location.href = url;
    });
    
});
