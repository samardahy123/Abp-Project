$(function () {
    var l = abp.localization.getResource('CoursesAppMVC');

    var createModal = new abp.ModalManager(abp.appPath + 'Courses/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Courses/EditModal');


    var dataTable = $('#CoursesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(coursesAppMVC.course.course.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'CourseDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        coursesAppMVC.course.course
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
                {
                    title: l('Instructor'),
                    data: "instructorName"
                },
                
                {
                    title: l('StartDate'),
                    data: "startDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
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

$('#NewCourseButton').click(function (e) {
    e.preventDefault();
    createModal.open();
});
});







