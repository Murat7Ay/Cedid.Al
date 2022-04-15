$(function () {
    var l = abp.localization.getResource('AkilliLojistik');
    var serviceId = $('input#Service_Id').val();
    var materialModal = new abp.ModalManager({
        viewUrl: '/Services/MaterialModal',
        scriptUrl: '/Pages/Services/MaterialModal.js',
        modalClass: 'MaterialModal'
    });
    var createOperationModal = new abp.ModalManager(abp.appPath + 'Services/CreateOperationModal');
    var editOperationModal = new abp.ModalManager(abp.appPath + 'Services/EditOperationModal');
    var createAccessoryModal = new abp.ModalManager(abp.appPath + 'Services/CreateAccessoryModal');
    var editAccessoryModal = new abp.ModalManager(abp.appPath + 'Services/EditAccessoryModal');

    var usedMaterialDataTable = $('#UsedMaterialsTable').DataTable(
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
                                        materialModal.open({ id: data.record.id, serviceId: serviceId, serviceMaterialType : 1 });
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

    materialModal.onResult(function () {
        usedMaterialDataTable.ajax.reload();
    });

    $('#NewUsedMaterial').click(function (e) {
        e.preventDefault();
        materialModal.open({ serviceId: serviceId, serviceMaterialType: 1 });
    });

    $('#ServiceList').click(function (e) {
        var url = "/Services/Index";
        window.location.href = url;
    });
    
});
