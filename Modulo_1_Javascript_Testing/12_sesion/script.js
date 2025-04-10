document.getElementById("loginForm").addEventListener("submit", function(e){
    e.preventDefault();
    
    const user = document.getElementById("username").value.trim();
    const pass = document.getElementById("password").value.trim();
    const message = document.getElementById("message");

    // validaciones simples
    if(user === "" || pass === ""){
        message.textContent = "Todos los campos son obligatorios";
        message.style.color = "red";
        return;
    }
    if (user === "admin" && pass === "1234"){
        message.textContent = "Login exitoso";
        message.style.color = "green";
    } else {
        message.textContent = "Usuario o contraseña incorrectos!!";
        message.style.color = "red";  
    }

})