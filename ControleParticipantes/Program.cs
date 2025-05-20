using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace TesteInga;

class Program
{
    static void Main(string[] args)
    {
        List<string> participants = new List<string>();
        Console.Clear();
        Console.Write("Digite a quantidade máxima de participantes: ");
        string inputUser = Console.ReadLine();
        int maxParticipants = IsValidInt(inputUser);
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==== MENU CADASTRO PARTICIPANTES ====");
            Console.WriteLine("[1] - CADASTRAR");
            Console.WriteLine("[2] - LISTAR NOMES");
            Console.WriteLine("[3] - SAIR");
            Console.Write("DIGITE UMA DAS OPÇÕES: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    if (participants.Count < maxParticipants)
                    {
                        Console.Write("Digite o nome que deseja cadastrar: ");
                        string nameParticipant = Console.ReadLine();
                        bool nameExist = participants.Any(x => x == nameParticipant);

                        if (nameExist)
                        {
                            Console.WriteLine("Nome já cadastrado!");
                            await Task.Delay(2000);
                        }
                        else
                        {
                            participants.Add(nameParticipant);
                            Console.WriteLine("Participante cadastrado com sucesso!");
                            await Task.Delay(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Limite máximo de participantes atingidos!");
                        await Task.Delay(2000);
                    }
                    break;

                case "2":
                    participants.Sort();
                    Console.Clear();
                    Console.WriteLine("PARTICIPANTES CADASTRADOS:");
                    foreach (var item in participants)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    Console.WriteLine("APERTE QUALQUER BOTÃO PARA RETORNAR AO MENU");
                    Console.ReadLine();
                    break;
                case "3":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA!! DIGITE UMA OPÇÃO VÁLIDA");
                    await Task.Delay(2000);
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("OBRIGADO POR USAR O SISTEMA!");
    }

    static int IsValidInt(string inputUser)
    {
        bool sucess = int.TryParse(inputUser, out int maxParticpants);
        while (!sucess || maxParticpants <= 0)
        {
            Console.WriteLine("Entrada inválida!!!! Por favor digite um valor válido");
            Console.Write("Digite a quantidade máxima de participantes: ");
            inputUser = Console.ReadLine();
            sucess = int.TryParse(inputUser, out maxParticpants);
        }

        return maxParticpants;
    }
}