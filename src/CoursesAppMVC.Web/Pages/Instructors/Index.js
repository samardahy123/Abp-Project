$(function () {
    var l = abp.localization.getResource('CoursesAppMVC');
    var createModal = new abp.ModalManager(abp.appPath + 'Instructors/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Instructors/EditModal');

    var dataTable = $('#InstructorsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(coursesAppMVC.isnstructors.instructor.getList),
           
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('CoursesApp.Instructors.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('CoursesApp.Instructors.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'InstructorDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        coursesAppMVC.isnstructors.instructor
                                            .delete(data.record.id)
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
                    title: l('Name'),
                    data: "name"
                },
               
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewInstructorButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
