
$(document).ready(function () {
  
    getAllEmployees();
    Add();

        });

function Add() {
    
    var employee = {
        FullName : $('#Name').val(),
        Email : $('#Email').val(),
        Salary : $('#Salary').val(),
        Gender: $('#Gender').val(),
    };



    $.ajax({
        url: 'https://localhost:44352/api/employee/register',
        type: 'post',
        data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            // getAllEmployees();
            alert(" Data Inserted Successfully");
        },
        error: function (err) {
            alert("Error");
            console.log(err);
        }
    });
}


function getAllEmployees() {

    $.ajax({
        url: 'https://localhost:44352/api/employee/select',
        dataType: "json",
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            alert(data.result[0].ID);

            for (let key in data) {
                alert(key, data[key].ID);
            }
            var EmployeeData = $('#employee tbody');
               //employee.empty();
            //$.each(data, function (index, val) {
            $(data).each(function (emp,index) {
                employee.append('<tr><td>' + emp.ID + '</td><td>'+ emp.FullName + '</td><td>' + emp.Email + '</td><td>'+ emp.Salary + '</td><td>' + emp.Gender + '</td></tr>');
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}  