using System;

namespace ex1
{
    public class Team
    {
        public string TeamName { get; set; }
        public string[] Members { get; set; }

        public Team(string teamName, params string[] members)
        {
            TeamName = teamName;
            Members = members;
        }

        public void Print()
        {
            Console.WriteLine("Name: \"{0}\". Amount of Members: {1}", TeamName, Members.Length);
            Console.WriteLine("Members:");
            for (int i = 0; i < Members.Length; i++)
            {
                Console.Write("     {0}", Members[i]);
                if (i < Members.Length - 1)
                {
                    Console.WriteLine(",");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}