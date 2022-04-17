$(function () {
    var l = abp.localization.getResource('AkilliLojistik');
    var serviceId = $('input#Service_Id').val();
    var materialModal = new abp.ModalManager({
        viewUrl: '/Services/MaterialModal',
        scriptUrl: '/Pages/Services/MaterialModal.js',
        modalClass: 'MaterialModal'
    });
    var operationModal = new abp.ModalManager(abp.appPath + 'Services/OperationModal');
    var createAccessoryModal = new abp.ModalManager(abp.appPath + 'Services/CreateAccessoryModal');
    var editAccessoryModal = new abp.ModalManager(abp.appPath + 'Services/EditAccessoryModal');
    var serviceId = $('#Service_Id').val();
    var usedRequestParams = { serviceId: serviceId, serviceMaterialType: 1 };
    var usedMaterialDataTable = $('#UsedMaterialsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[3, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(cedid.akilliLojistik.serviceMaterials.serviceMaterial.getList, usedRequestParams),
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
                                        materialModal.open({ id: data.record.id, serviceId: serviceId, serviceMaterialType: 1 });
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
                    title: l('StockCodeId'),
                    data: "stockCodeText"
                },
                {
                    title: l('WareHouseCodeId'),
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

    var suggestRequestParams = { serviceId: serviceId, serviceMaterialType: 2 };
    var suggestMaterialDataTable = $('#SuggestMaterialsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[3, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(cedid.akilliLojistik.serviceMaterials.serviceMaterial.getList, suggestRequestParams),
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
                                        materialModal.open({ id: data.record.id, serviceId: serviceId, serviceMaterialType: 2 });
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
                    title: l('StockCodeId'),
                    data: "stockCodeText"
                },
                {
                    title: l('WareHouseCodeId'),
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

    var oeprationRequestParams = { serviceId: serviceId };
    var operationDataTable = $('#OperationsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[3, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(cedid.akilliLojistik.serviceOperations.serviceOperation.getList, oeprationRequestParams),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AkilliLojistik.ServiceOperations.Edit'),
                                    action: function (data) {
                                        operationModal.open({ id: data.record.id, serviceId: serviceId });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AkilliLojistik.ServiceOperations.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ServiceOperationDeletionConfirmationMessage',
                                            data.record.description
                                        );
                                    },
                                    action: function (data) {
                                        cedid.akilliLojistik.serviceOperations.serviceOperation.delete(data.record.id)
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
                    title: l('Technician'),
                    data: "technician"
                },
                {
                    title: l('OperationDate'),
                    data: "operationDate"
                },
                {
                    title: l('Description'),
                    data: "description"
                },
                {
                    title: l('StatusCode'),
                    data: "statusCodeText"
                }
            ]
        })
    );

    materialModal.onResult(function () {
        usedMaterialDataTable.ajax.reload();
    });

    operationModal.onResult(function () {
        usedMaterialDataTable.ajax.reload();
    });
    

    $('#NewUsedMaterial').click(function (e) {
        e.preventDefault();
        materialModal.open({ serviceId: serviceId, serviceMaterialType: 1 });
    });

    $('#NewSuggestMaterial').click(function (e) {
        e.preventDefault();
        materialModal.open({ serviceId: serviceId, serviceMaterialType: 2 });
    });

    $('#ServicesButton').click(function (e) {
        var url = "/Services/Index";
        window.location.href = url;
    });
    $('#NewOperation').click(function (e) {
        e.preventDefault();
        operationModal.open({ serviceId: serviceId });
    });


});
