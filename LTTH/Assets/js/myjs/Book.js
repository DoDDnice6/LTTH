
var uri = '/api/BOOKs/';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            $('#ListBook').html('<thead><tr><th>ID</th><th>Tên Sách</th><th>Tác Giả</th><th>Nha Xuat Ban</th><th>Tác Vụ</th></tr></thead><tbody></tbody>')
            $.each(data, function (key, item) {
                $('#ListBook tbody').append('<tr id=Book' + item.ID + '><td>' + item.ID + '</td><td>' + item.Name + '</td><td>' + item.Author + '</td><td>' + item.PublishID.Name + '</td><td><button class="btn" data-toggle="modal" data-target="#myModal" data-id=' + item.ID + ' onclick="detail(' + item.ID + ')">Chi Tiết</buton><button class="btn" onclick="Delete(' + item.ID + ')">Xóa</buton></tr>')
            });
        });
});


//Tao model

function insert() {
    $('#modal-body').html(`<input type="Text" id="name"/><button onclick="insert_()" class="btn">Thêm mới</button>`);
    $('#myModal').modal('show');
}
function insert_(){
    var para = {
        Name: $('#Name').val(),
        Author: $('#Author').val(),
        Price: $('#Price').val(),
        NumberPage: $('#NumberPage').val(),
        CategoryID: $('#CategoryID').val(),
        Note: $('#Note').val(),
        PublishID:1
    };

    $.ajax({
        url: `/api/BOOKs/`,
        type: `POST`,
        datatype: `JSON`,
        data: JSON.stringify(para),
        contentType: "application/json; charset=utf-8",
        success: function () {
            window.location.reload();
        }      
    })
}

//Chi tiet
function detail(id) {
    $.getJSON(uri + id)
        .done(function (data) {
               
            $('#modal-body').html(`<input type="Text" value="` + data.Name + '" id="name' + data.ID + '"/><button onclick="modify(' + data.ID + ')" class="btn">Save</button>');

            $('#myModal').modal('show');
        })
}
//End function


//Function Xoa model
function Delete(id)
{
    $.ajax({
        url: '/api/BOOKs/' + id,
        contentType: "application/json; charset=utf-8",
        type: 'DELETE',
    })
}
//End Xoa model
    

//Function Sua model
function modify(id)
{
    var para = {
        ID: id,
        Name: $('#name' + id).val(),
        PublishID:1
    };


    $.ajax({
        url: '/api/BOOKs/'+id,
        type: 'PUT',
        datatype: 'json',
        cache: true,
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(para),
        success: function () {
            window.location.reload();
        }
    })
}
//End sua model



function find() {
    var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#product').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error: ' + err);
        });
}