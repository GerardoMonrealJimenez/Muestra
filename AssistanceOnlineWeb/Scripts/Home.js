// Codigo que se ejecuta una vez que se halla cargado la página
$(document).ready(function () {
    getCourses();

    getEnrolledCourses();
});

//Obtiene el modelo que se mostrara en el modal
function ModalView() {

    $.ajax({
        url: 'modalAddCourse', 
        type: 'GET',
        data: {

        }, 
        success: function (data) 
        {
            $('#AC_modal').html(data);
            $('#formModal').modal('show');
        },
        error: function (error) {
            alert("Controller"); 
            $('#ajaxLoader').hide();

        }
    });

}
//Metodo de exito para la inserción de curso
function succesAddCourse() {
    $('#formModal').modal('hide');
    getCourses();
}
///Funcion que se ejecuta antes de la llamada ascincrona
function beginAddCourse() {

}
//Funcion que se ejecuta si la llamada ascincrona falla
function failAddCourse() {
    alert("Fail"); 
}
// llamada ascincrona para obtener los cursos
function getCourses() {
    $.ajax({
        url: 'courses',
        type: 'GET',
        data: {

        },
        success: function (data) {
            $('#pan_Courses').html(data);
        },
        error: function (error) {
            alert("Controller");
            $('#ajaxLoader').hide();

        }
    });
}
// llamada ascincrona para obtener los cursos en los que estas inscrito
function getEnrolledCourses() {
    $.ajax({
        url: 'enrolledCourses',
        type: 'GET',
        data: {

        },
        success: function (data) {
            $('#pan_CoursesEnrroled').html(data);
        },
        error: function (error) {
            alert("Controller");
            $('#ajaxLoader').hide();

        }
    });
}