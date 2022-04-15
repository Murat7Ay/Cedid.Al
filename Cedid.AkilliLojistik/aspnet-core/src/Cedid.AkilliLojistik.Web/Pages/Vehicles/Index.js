$(function () {
    var l = abp.localization.getResource('AkilliLojistik');
    var createModal = new abp.ModalManager(abp.appPath + 'Vehicles/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Vehicles/EditModal');

    var dataTable = $('#VehiclesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[4, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(cedid.akilliLojistik.vehicles.vehicle.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AkilliLojistik.Vehicles.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AkilliLojistik.Vehicles.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'VehicleDeletionConfirmationMessage',
                                            data.record.plateNo
                                        );
                                    },
                                    action: function (data) {
                                        cedid.akilliLojistik.vehicles.vehicle.delete(data.record.id)
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
                    data: "plateNo"
                },
                {
                    title: l('BrandId'),
                    data: "brandText"
                },
                {
                    title: l('TrafficReleaseDate'),
                    data: "trafficReleaseDate"
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

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewVehicleButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
