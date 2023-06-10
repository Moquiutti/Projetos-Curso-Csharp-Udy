using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoginConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Digite o nome do seu usuário:");
                string usuario = Console.ReadLine();
                Console.WriteLine("Digite a sua senha:");
                string senha = "";
                while (true)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.Enter)
                        break;
                    else
                    {
                        senha += tecla.KeyChar;
                    }
                }
                if (usuario == "Valeria" && senha == "1234")
                {
                    Console.WriteLine("Usuário logado com sucesso");
                    break;
                }
                else
                {
                    Console.WriteLine("Usuário ou senha incorreto");
                    Console.WriteLine("Pressione qualquer tecla ppara continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
        }
    }
}
