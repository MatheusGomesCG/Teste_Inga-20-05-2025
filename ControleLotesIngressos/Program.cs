using System;

namespace TesteInga;

class Program
{
    static void Main(string[] args)
    {
        decimal ticketNormal = 30.00M;
        decimal ticketVip = 60.00M;
        string inputUser;
        int totalTickets;
        decimal totalValue;

        Console.Clear();
        Console.Write("Ingressos padrão disponíveis: ");
        inputUser = Console.ReadLine();
        int maxTicketNormal = IsValidInt(inputUser);

        Console.Write("Ingressos VIP disponíveis: ");
        inputUser = Console.ReadLine();
        int maxTicketVip = IsValidInt(inputUser);

        Console.WriteLine();
        Console.Write("Quantos ingressos padrão deseja comprar? ");
        inputUser = Console.ReadLine();
        int buyTicketNormal = IsValidInt(inputUser);
        buyTicketNormal = IsValidTicket(maxTicketNormal, buyTicketNormal);
        totalTickets = buyTicketNormal;
        maxTicketNormal -= buyTicketNormal;

        Console.Write("Quantos ingressos VIP deseja comprar? ");
        inputUser = Console.ReadLine();
        int buyTicketVip = IsValidInt(inputUser);
        buyTicketVip = IsValidTicket(maxTicketVip, buyTicketVip);
        totalTickets += buyTicketVip;
        maxTicketVip -= buyTicketVip;

        totalValue = (buyTicketNormal * ticketNormal) + (buyTicketVip * ticketVip);

        Console.WriteLine();
        Console.WriteLine("Venda confirmada!");

        Console.WriteLine();
        Console.WriteLine("Resumo:");
        Console.WriteLine($"Total vendidos: {totalTickets}");
        Console.WriteLine($"Total arrecadado: {totalValue:C}");
        Console.WriteLine($"Ingressos padrão restantes: {maxTicketNormal}");
        Console.WriteLine($"Ingressos VIP restantes: {maxTicketVip}");

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

    static int IsValidTicket(int maxTicket, int quantity)
    {
        while (quantity > maxTicket)
        {
            Console.WriteLine("Valor digitado superior a quantidade máxima");
            Console.Write("Digite um valor válido: ");
            string inputUser = Console.ReadLine();
            quantity = IsValidInt(inputUser);
        }

        return quantity;
    }

}