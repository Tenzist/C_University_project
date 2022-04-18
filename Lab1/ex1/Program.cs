using System;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Teams teams = new Teams(
                new Team("Alpha",  "S1mple", "Zywoo", "Niko"),
                new Team("Beta",  "Alex","Axel"),
                new Team("Charlie",  "David"),
                new Team("Delta",  "Kirill","Amogus","Viktor","Domix")
            );
            teams.Print();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Find by TeamName:");
            string sequence = Console.ReadLine();
            Teams newTeams = new Teams(teams.ContainsCharacters(sequence));
            Console.BackgroundColor = default;
            newTeams.Print();
        }
    }
}