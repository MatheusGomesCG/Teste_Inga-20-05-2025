using System;
using System.Globalization;

namespace TesteInga;

class Program
{
    static async Task Main(string[] args)
    {
        bool exit = false;
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        int id = 0;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==== MENU EVENTO ====");
            Console.WriteLine("[1] - CADASTRAR EVENTO");
            Console.WriteLine("[2] - VER DETALHES");
            Console.WriteLine("[3] - SAIR");
            Console.Write("Escolha uma da opções: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("==== MENU CADASTRO ====");
                    Console.Write("Digite o nome do evento: ");
                    string nameEvent = Console.ReadLine();

                    Console.Write("Digite a data do evento: (dd/MM/yyyy) ");
                    string inputUser = Console.ReadLine();
                    string format = "dd/MM/yyyy";

                    bool sucess = DateTime.TryParseExact(inputUser, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateConvert);

                    while (!sucess || dateConvert < DateTime.Now.Date)
                    {
                        Console.Write("Digite uma data válida: ");
                        inputUser = Console.ReadLine();
                        sucess = DateTime.TryParseExact(inputUser, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateConvert);
                    }

                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    id++;
                    dict.Add("id", id);
                    dict.Add("nome", nameEvent);
                    dict.Add("dataEvento", dateConvert);

                    if (dateConvert <= DateTime.Now.AddDays(30))
                    {
                        dict.Add("tipoEvento", "próximo");
                    }
                    else if (dateConvert <= DateTime.Now.AddDays(180))
                    {
                        dict.Add("tipoEvento", "planejado");
                    }
                    else
                    {
                        dict.Add("tipoEvento", "distante");
                    }

                    list.Add(dict);

                    Console.WriteLine("EVENTO CADASTRADO COM SUCESSO!");
                    await Task.Delay(2000);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("==== EVENTOS CADASTRADOS ====");
                    foreach (var item in list)
                    {
                        foreach (var obj in item)
                        {
                            if (obj.Value is DateTime date)
                            {
                                Console.WriteLine($"{obj.Key} = {date.ToString("dd/MM/yyyy")}");
                            }
                            else
                            {
                                Console.WriteLine($"{obj.Key} = {obj.Value}");
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("DIGITE QUALQUER TECLA PARA VOLTAR AO MENU");
                    Console.ReadLine();
                    break;

                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA!!!!");
                    await Task.Delay(2000);
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("OBRIGADO POR USAR O NOSSO SISTEMA");
    }
}