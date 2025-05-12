using System;

class Program 
{

    //dotnet new console -n HelloWord
    //dotnet run

    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "qwerty"},
        {"usuario", "pass"},
        {"tet", "test"}
    };

    static void Main(string[] args)
    {
        //  Agregar comentarios ...
        Console.WriteLine("Hello, World!   *** 12/05/2025 ***");
        Console.WriteLine("Tienes que iniciar sesión");

        //Definir el usuario y la contraseña
        string usuarioCorrecto = "admin";
        String passCorreccto = "qwerty";

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = Console.ReadLine();

        Console.WriteLine("Escribe tu usuario");
        string? passIngresado = Console.ReadLine();

        if (usuarioIngresado != null)
        {

            if (usuarios.ContainsKey(usuarioIngresado) && usuarios[usuarioIngresado] == passIngresado)
            {
                Console.WriteLine("Has ingresado con éxito");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{i}. Hola Usuario, gracias!!!");
                }
            } 
            else
            { 
                Console.WriteLine("Usuario y/o incorrectos");
            }
        }
        
        Console.WriteLine("\n Presiona Enter para salir del programa ...");
        Console.ReadLine();
    }

}