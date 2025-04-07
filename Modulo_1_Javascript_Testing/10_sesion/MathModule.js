const mathModule = (function() {
    //variables privadas
    const PI = 3.1416;

    //funciones privadas
    function cuadrado(x) {
        return x * x;
    }

    //funciones publicas
    return{
        areaCirculo(radio){
            return PI * cuadrado(radio);
        },
        suma(a, b) {
            return a + b;
        }
    }
})();


console.log(mathModule.areaCirculo(10));
console.log(mathModule.suma(10+10));