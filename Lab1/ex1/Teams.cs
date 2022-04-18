using System;
namespace ex1
{
    public class Teams
    {
        public Team[] Books { get; set; }
        public Teams(params Team[] books)
        {
            Books = books;
        }
        public void Print()
        {
            Console.WriteLine("----------CreativeTeams:----------");
            foreach (Team book in Books)
            {
                book.Print();
            }
        }
        public Team[] ContainsCharacters(string characters)
        {
            Team[] found = new Team[0];
            foreach (Team book in Books)
            {
                if (book.TeamName.Contains(characters))
                {
                    Array.Resize(ref found, found.Length + 1);
                    found[found.Length - 1] = book;
                }
            }
            return found;
        }
    }
}