function expect(actual) {
    return {
        toBe(expected) {
            if (actual === expected){
                console.log(`Paso: ${actual} === ${expected}`);
            } else {
                console.log(`Fallo: se esperaba ${expected} pero se obtuvo ${actual}`);
            }
        },
        toEqual(expected) {
            const passed = JSON.stringify(actual) === JSON.stringify(expected);
            if (passed){
                console.log(`Paso: Objetos iguales`);
            } else {
                console.log(`Fallo: Objetos diferentes`);
            }
        }
    }
}

function sumar(a,b) {
    return a + b;
}

expect(sumar(2,3)).toBe(5);
expect(sumar(10,0)).toBe(10);


///////////////////////////////////////////////////////////////////////////////////
function validarUsuario(usuario){
    return usuario.nombre && /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(usuario.correo);
}

const usuarioValido = { nombre: "Anna", correo:"asda@gmail.com" };
const usuarioValido2 = { nombre: "Anna2", correo:"asda@gmail.com" };
const usuarioInvalido = { nombre: "Anna", correo:"asda@gmail" };

expect(validarUsuario(usuarioValido)).toBe(true);
expect(validarUsuario(usuarioInvalido)).toBe(true);

expect(usuarioValido).toEqual(usuarioValido);
expect(usuarioValido).toEqual(usuarioValido2);

