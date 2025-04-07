import {saludar, despedir, suma, resta, multiplicar, dividir} from "./saludo.js";
import { obtenerFechaActual, obtenerHoraActual} from "./fecha.js";

const nombre = "Ulises";

console.log(saludar(nombre));
console.log(despedir(nombre));

console.log("suma(1,2): ", suma(1,2));
console.log("resta(1,2): ", resta(1,2));
console.log("multiplilcar(1,2): ", multiplicar(1,2));
console.log("dividir(2,2): ", dividir(2,2));

console.log("fecha actual:", obtenerFechaActual());
console.log("hora actual:", obtenerHoraActual());