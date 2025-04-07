console.log("...");

document.getElementById("testForm").addEventListener("submit", function(e){
    e.preventDefault();   //Evita el comportamiento por defecto del formulario

    const nombre = document.getElementById("nombre").value.trim();
    const edad = document.getElementById("edad").value.trim();
    const resultado = document.getElementById("resultado");
    console.log(nombre, edad);

    try{
        validarDatos(nombre, edad);
        resultado.textContent = `Hola ${nombre}, tienes ${edad} años`;
        resultado.style.color = "green";
    }catch(error){
        console.log("error", error);
        resultado.textContent = error.mensage;
        resultado.style.color = "red";
    }

})


//function para validar los datos
function validarDatos(){
    console.log("validando datos...");

    if (!nombre || !edad){
        throw new Error ("Por favor completa todos los campos");
    }
    if (edad <= 0){
        throw new Error ("La edad debe ser un numero valido");
    } 
    if (!nombre.length > 30){
        throw new Error ("El nombre es demasiado largo");
    }

    console.log("Datos validados correctamente");
}
