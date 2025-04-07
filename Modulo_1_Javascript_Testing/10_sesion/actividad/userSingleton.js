const userSingleton = (function(){
    let instance = null;

    function creaInstance(name){
        return{
            name,
            loginTime: new Date().toLocaleDateString()
        }
    }

    return{
        getInstance(name){
            if(!instance){
                instance = creaInstance(name);
            }
            return instance
        },
        clearInstance(){
            instance =  null;
        }
    }
})();