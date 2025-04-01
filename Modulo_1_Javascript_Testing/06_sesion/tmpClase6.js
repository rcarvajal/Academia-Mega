/*
const titulo = document.getElementById("titulo")
const parrafo = document.getElementsByClassName("mensaje");
const botones = document.getElementsByTagName("button");

const primerParrafo = document.querySelector(".mensaje");
const todosLosParrafos = document.querySelectorAll(".mensaje");

console.log(titulo);
console.log(titulo.textContent);

titulo.textContent = "Bienvenidos a mi página web";
titulo.style.color = "blue";

primerParrafo.innerHTML = "<strong>Texto en negritas!!! </string>";
*/

document.getElementById("cambiarTexto").addEventListener("click", function(){
    document.getElementById("titulo").textContent = "Text cambiado con Javascript";
});

document.getElementById("boton").addEventListener("click", function(){
    document.getElementById("resultado").textContent = "Botón click";
});


const hoverTexto = document.getElementById("hoverTexto");
hoverTexto.addEventListener("mouseover",  function(){
    hoverTexto.style.color  = "red";
});
hoverTexto.addEventListener("mouseout",  function(){
    hoverTexto.style.color  = "black";
});


const hoverDiv = document.getElementById("hoverDiv");
hoverDiv.addEventListener("mouseover",  function(){
    hoverDiv.style.backgroundColor  = "blue";
});
hoverDiv.addEventListener("mouseout",  function(){
    hoverDiv.style.backgroundColor  = "white";
});


////////////////////////////////////////////////////////////////////////////////////////

const usuario = {
    nombre: "Roberto",
    edad: 47,
    ciudad: "Guadalajara"
}
console.log(usuario);

const usuarioJson = JSON.stringify(usuario);
console.log("JSON EN TEXTO:",usuarioJson);

const usuarioObjecto = JSON.parse(usuarioJson)
console.log("JSON EN OBJETO:", usuarioObjecto);
console.log("JSON EN OBJETO:", usuarioObjecto.nombre);

localStorage.setItem("usuario", usuarioJson);

const datosGuardados = localStorage.getItem("usuario");
const datosObjecto = JSON.parse(datosGuardados) ;
console.log(datosObjecto);

localStorage.removeItem("usuario");