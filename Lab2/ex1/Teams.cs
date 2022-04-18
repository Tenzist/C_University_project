using System;
namespace ex1
{
    public class Teams
    {
        public Team[] ЕTeams { get; set; }
        public Teams(params Team[] memb)
        {
            ЕTeams = memb;
        }
        
        public void Print()
        {
            Console.WriteLine("----------CreativeTeams----------");
            foreach (Team memb in ЕTeams)
            {
                memb.Print();
            }
        }
        public Team[] ContainsCharacters(string characters)
        {
            Team[] found = new Team[0];
            foreach (Team memb in ЕTeams)
            {
                if (memb.TeamName.Contains(characters))
                {
                    Array.Resize(ref found, found.Length + 1);
                    found[found.Length - 1] = memb;
                }
            }
            return found;
        }
    }
}