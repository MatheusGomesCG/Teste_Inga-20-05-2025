using System;
using System.Threading.Tasks;

namespace TesteInga;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Clear();
        Console.Write("Digite a quantidade de vagas no evento: ");
        string inputUser = Console.ReadLine();
        int totalParticipants = IsValidInt(inputUser);

        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        for (int i = 0; i < totalParticipants; i++)
        {
            Console.Clear();
            Console.Write("Digite o nome do participante: ");
            string name = Console.ReadLine();

            while (name.Length <= 5)
            {
                Console.Write("Nome inválido!!! Digite um nome válido: ");
                continue;
            }

            Console.Write("Digite a idade: ");
            inputUser = Console.ReadLine();
            int age = IsValidInt(inputUser);
            
            if (age < 18 || age > 60)
            {
                Console.WriteLine("Idade não permitida no evento!!!");
                await Task.Delay(2000);
                continue;
            }
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Nome", name);
            dict.Add("Idade", age);

            list.Add(dict);
        }
        Console.WriteLine("NOMES APROVADOS:");
        foreach (var item in list)
        {
            foreach (var obj in item)
            {
                Console.Write($"{obj.Value} ");
            }
            Console.WriteLine();
        }

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