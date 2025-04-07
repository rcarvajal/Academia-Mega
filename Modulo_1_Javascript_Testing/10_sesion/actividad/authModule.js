const authModule = (function(){
    //simular usuario
    const userDB = {
        username: "admin",
        password: "1234"
    }

    let currrentUser = null;

    return{
        login(username, password){
            if(username === userDB.username && password === userDB.password) {
                currrentUser = userSingleton.getInstance(username);
                console.log(`Usuario Autenticado: ${currrentUser.name}`);
            } else {
                console.log("Credenciales incorrectas");
            }
        },
        logout() {
            if (currrentUser) { 
                console.log(`Hasta Luego: ${currrentUser.name}`);
                currrentUser = null;
                userSingleton.clearInstance();
            } else {
                console.log("No hay usuario autenticado");
            }
        }
    }
})();