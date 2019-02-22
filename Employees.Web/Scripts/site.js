function findEmployees() {
    $('#emplyeesList').html('');

    $.get('/api/region/' + $('#regionId').val() + '/employees', function (data) {
        var list = data.map(i => '<li>' + i.Name + ' ' + i.Surname + ' ' + i.RegionId +'</li>');
        $('#emplyeesList').html(list.join(''));
    });
}