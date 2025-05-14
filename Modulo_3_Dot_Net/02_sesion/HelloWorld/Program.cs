using System;
using System.ComponentModel;
using System.Text;

class Program 
{

    //dotnet new console -n HelloWord
    //dotnet run

    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "qwerty"},
        {"usuario", "pass"},
        {"test", "test"}
    };

    private const int MAX_ATTEMPTS = 3;

    static void Main(string[] args)
    {
        //  Agregar comentarios ...
        Console.WriteLine("Hello, World!   *** 12/05/2025 ***");
        Console.WriteLine("Tienes que iniciar sesión");

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = TryLogin();

        if (usuarioIngresado != null)
        {
            Console.WriteLine($"Hola {usuarioIngresado}");
        }
        else
        {
            Console.WriteLine("Has excedido el número máximo de intentos");
        }

        Console.WriteLine("Presione Enter para salir");
        Console.ReadLine();
    }

    private static string? TryLogin()
    {
        int intentosRestantes = MAX_ATTEMPTS;
        
        while (intentosRestantes > 0)
        {
            Console.WriteLine($"\nIntentos restantes: {intentosRestantes}");
            Console.Write("Ingrese tu numero de usuario: ");
            string? userLogged = Console.ReadLine();
            Console.WriteLine("Escribe tu contraseña");
            string? passIngresado = ReadPassword();

            if (string.IsNullOrWhiteSpace(userLogged) || string.IsNullOrWhiteSpace(passIngresado))
            {
                Console.WriteLine("\nErrorEl usuario y contraseña no puede estar vacios.");
                intentosRestantes--;
                continue;
            }

            if (usuarios.ContainsKey(userLogged) && usuarios[userLogged] == passIngresado)
            {
                Console.WriteLine("\nAcceso concedido...");
                return userLogged;  
            } 
            else
            { 
                Console.WriteLine("Usuario y/o incorrectos");
                Console.WriteLine("\n Intente de nuevo ...");
                intentosRestantes--;    
            }
        }
        
        return null;
    }

    private static string? ReadPassword()
    {
        StringBuilder password = new StringBuilder();
        ConsoleKeyInfo keyInfo;

        do {
            keyInfo = Console.ReadKey(true);
            if (!char.IsControl(keyInfo.KeyChar))
            {
                password.Append(keyInfo.KeyChar);
                Console.Write("*");
            }
            else if(keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password.Remove(password.Length -1, 1);
                Console.Write("\b \b");
            }

        } while(keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password.ToString();
    }

}