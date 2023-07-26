using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quinto_Projeto
{
    internal class Program
    {
        public struct DDCadastraisSTRUCT 
        {
            public string nome;
            public DateTime DTNasc;
            public string NMRua;
            public UInt32 NMcasa;

        }
        public enum Resultado_e
        {
            Sucesso = 0,
            Sair = 1,
            Excecao = 2
        }
        public static void MostrarMensagem (string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        public static Resultado_e PegaString(ref string minhaString, string mensagem)
        {
            Resultado_e retorno;
            Console.WriteLine(mensagem);
            string temp = Console.ReadLine();
            if (temp == "s" || temp == "S")
            {
                retorno = Resultado_e.Sair;
            }
            else
            {
                minhaString = temp;
                retorno = Resultado_e.Sucesso;
            }
            Console.Clear();
            return retorno;
        }
        public static Resultado_e PegaData(ref DateTime data, string mensagem)
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine (mensagem);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                        retorno = Resultado_e.Sair;
                    else
                    {
                        data = Convert.ToDateTime(temp);
                        retorno = Resultado_e.Sucesso;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXEÇÃO: " + e.Message);
                    Console.WriteLine("Presione qualquer telca para continuar");
                    Console.ReadKey();
                    Console.Clear ();
                    retorno = Resultado_e.Excecao;
                }
            }while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }
        public static Resultado_e PegaUInt32(ref UInt32 numeroUint32, string mensagem)
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                        retorno = Resultado_e.Sair;
                    else
                    {
                        numeroUint32 = Convert.ToUInt32(temp);
                        retorno = Resultado_e.Sucesso;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXEÇÃO: " + e.Message);
                    Console.WriteLine("Presione qualquer telca para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Excecao;
                }
            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }
        public static void CadastroUIsuario(ref List<DDCadastraisSTRUCT> ListaUsuarios)
        {
            DDCadastraisSTRUCT cadastroUsuario;
            cadastroUsuario.nome = "";
            cadastroUsuario.DTNasc = new DateTime();
            cadastroUsuario.NMRua = "";
            cadastroUsuario.NMcasa = 0;
            if (PegaString(ref cadastroUsuario.nome, "Digite o nome completo ou digite S para sair") != Resultado_e.Sucesso)
                return;
            if (PegaData(ref cadastroUsuario.DTNasc, "Digite a data de nascimento no formato DD/MM/AAAA ou digite S para sair") != Resultado_e.Sucesso)
                return;
            if (PegaString(ref cadastroUsuario.NMRua, "Digite o nome da Rua ou digite S para sair") != Resultado_e.Sucesso)
                return;
            if (PegaUInt32(ref cadastroUsuario.NMcasa, "Digite o numero da casa ou digite S para sair") != Resultado_e.Sucesso)
                return;
            ListaUsuarios.Add(cadastroUsuario);
        }
        static void Main(string[] args)
        {
            List <DDCadastraisSTRUCT> ListaUsuarios = new List <DDCadastraisSTRUCT>();
            string opcao = "";
            do
            {
                Console.WriteLine("Diogite C para cadastrar um novo usuário ou S para sair;");
                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if(opcao == "c")
                {
                    // Cadas trar usuario
                    CadastroUIsuario(ref ListaUsuarios);
                }
                else if (opcao == "s")
                {
                    //Sair da Aplicação
                    MostrarMensagem("Encerrando o Programa");
                }
                else
                {
                    //Opção desconhecida
                    MostrarMensagem("Opção desconhecida");
                }
            } while (opcao != "s");

            Console.ReadKey();
        }
    }
}
