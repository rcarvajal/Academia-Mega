function obtenerUsuario(id) {
    try { 
        if (typeof id !== "number") throw new Error("El ID debe ser un numero");

        const usuarios = {1: "Ana", 2: "Carlos", 3:"Maria"};
        if (!usuarios[id]) throw new Error("Usuario no encontrado");
        

        return `Usuario encontrado: ${usuarios[id]}`;
    } catch(error) {
        console.error("Error;", error.message);
        return null;
    } 
}

console.log(obtenerUsuario(2)  );
console.log(obtenerUsuario(3)  );
console.log(obtenerUsuario(1)  );
console.log(obtenerUsuario("."));
console.log(obtenerUsuario(-3) );