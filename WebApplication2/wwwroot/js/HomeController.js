
$(document).ready(function () {
   alert("document ")
    getAllEmployees();

        });

function Add() {
    alert("in add")
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
          //  getAllEmployees();
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
        method: 'get',
        success: function (data) {
            var EmployeeData = $('#employee tbody');
            //Employee.empty();

            $(data).each(function (emp) {
                Employee.append('<tr><td>' + emp.ID + '</td><td>'
                    + emp.FullName + '</td><td>' + emp.Email + '</td><td>'
                    + emp.Salary + '</td><td>' + emp.Gender + '</td><td>');
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}  


