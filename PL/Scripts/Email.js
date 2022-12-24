
function validateEmail(email) {
    // La expresión regular para verificar el formato de la dirección de correo
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);