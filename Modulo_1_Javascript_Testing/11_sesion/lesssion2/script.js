document.getElementById("formularioNotas").addEventListener("submit", function(e){
    e.preventDefault();
    const nota1 = parseFloat( document.getElementById("nota1").value );
    const nota2 = parseFloat( document.getElementById("nota2").value );
    const nota3 = parseFloat( document.getElementById("nota3").value );
    
    const resultado = document.getElementById("resultado");

    try {
        const promedio = calcularPromedio(nota1, nota2, nota3);
        console.log(promedio); 

        resultado.textContent = `El promedio es: ${promedio.toFixed(2)}`;
        resultado.style.color = promedio>=6?"green":"orange";
    } catch(error) {
        console.log(error.message);

        resultado.textContent = error.message;
        resultado.style.color = "red";
    }


})

function calcularPromedio(m1, m2, m3) {
    console.log("Calculanmdo promedio... ");

    if ([n1, n2, n3].some(isNaN)) {
        throw new Error("Todas las notas deben ser números válidos");
    }
    if ([n1, n2, n3].some(n=>n<0 || n>10)) {
        throw new Error("Todas las notas deben estar entre 1 y 10");
    }

    console.log(n1+n2+n3);
    return (n1+n2+n3) / 3;

}