using System;
using System.Globalization;
using System.Threading.Tasks;

namespace TesteInga;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Quantos participantes? ");
        string inputUser = Console.ReadLine();
        int totalParticipants = IsValidInt(inputUser);
        int count = 0;

        List<string> name = new List<string>();
        List<string> present = new List<string>();
        List<string> ausent = new List<string>();

        for (int i = 0; i < totalParticipants; i++)
        {
            Console.Write("Nome: ");
            string nameUser = Console.ReadLine();
            name.Add(nameUser);
        }

        Console.WriteLine();
        foreach (var item in name)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write($"{item} esteve presente? (S/N): ");
                inputUser = Console.ReadLine();
                char choice = char.Parse(inputUser.ToUpper());
                switch (choice)
                {
                    case 'S':
                        present.Add(item);
                        count++;
                        exit = true;
                        break;
                    case 'N':
                        ausent.Add(item);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida digite uma opção válida");
                        await Task.Delay(2000);
                        break;
                }
            }

        }

        Console.WriteLine();
        Console.WriteLine("Presentes:");
        foreach (var item in present)
        {
            Console.WriteLine($"- {item}");
        }

        Console.WriteLine();
        Console.WriteLine("Ausentes:");
        foreach (var item in ausent)
        {
            Console.WriteLine($"- {item}");
        }

        decimal presentPercentual = (count / (name.Count * 1.00M)) * 100.00M ;
        Console.WriteLine();
        Console.WriteLine($"Percentual de presença: {presentPercentual.ToString("F2")}%");


    }
    static int IsValidInt(string inputUser)
    {
        bool sucess = int.TryParse(inputUser, out int number);
        while (!sucess || number <= 0)
        {
            Console.Write("Entrada inválida!!!! Por favor digite um valor válido: ");
            inputUser = Console.ReadLine();
            sucess = int.TryParse(inputUser, out number);
        }

        return number;
    }
}