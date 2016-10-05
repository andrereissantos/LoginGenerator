using System;
using System.IO;
namespace LoginGenerator
{

    class Program
    {

        static void Main(string[] args)
        {
            Utils utils = new Utils();
            string helpText = "LoginGenerator \n"
                            + "Este programa gera um nome de login a partir do primeiro e último nome.\n"
                            + "Edite o arquivo NOMES.TXT para simular um nome existente \n\n\n"
                            + "Comandos:\n\n\n"
                            + "/? para exibir esta mensagem \n"
                            + "+[nome] : Adiciona um nome à lista de nomes existentes (apenas na sessão)\n\n"
                            + "/l: Exibe os nomes carregados na memória \n\n\n ";

            Console.Clear();
            Console.Write(helpText);

            while (true)
            {
                Console.Write("Nome completo: ");
                var str = Console.ReadLine();

                if (str.Length == 0) { return; }

                if (str.Substring(0, 1) == "+")
                {
                    utils.AccountNames.Add(str.Substring(1, str.Length - 1));
                }

                if (str == "/l")
                {
                    foreach (var name in utils.AccountNames)
                        Console.WriteLine(name);
                    continue;
                }
                if (str == "cls")
                {
                    Console.Clear();
                    continue;
                }
                if (str == "/?")
                {
                    Console.WriteLine(helpText);
                    continue;
                }


                Console.WriteLine(utils.GenerateLogin(str));


            }
        }
    }
}
