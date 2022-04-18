using System;
using System.Collections.Generic;
using Teams;

namespace Team
{
    class Team
    {
        static void Main(string[] args)
        {
            Team<Member> team = new Team<Member>();
            team += new Teamm<Member>("Alpha", 2020, 
                                          new Member() { Name = "S1mple"},
                                          new Member() { Name = "B1t"},
                                          new Member() { Name = "headtr1ck"});
            team += new Teamm<Member>(@"Beta", 2019,
                                          new Member() { Name = "perfecto"});
            team += new Teamm<Member>("Charlie", 2007, 
                                          new Member() { Name = "Blade"},
                                          new Member(){Name = "Glave"});
            
            Console.WriteLine(team);
            Console.WriteLine("Write team name:");
            string sequence = Console.ReadLine();
            Team<Member> newTeam = new Team<Member>()
            {
                Teams = team.ContainsMember(sequence)
            };

            Console.WriteLine("Your team:");
            Console.WriteLine(newTeam);
            Console.WriteLine();

            try
            {
                team.WriteTeams("teams.xml");

                team.SortByName();
                Console.WriteLine("by names:");
                Console.WriteLine(team);
                Console.WriteLine();
                team.WriteTeams("ByName.xml");

                team.SortByMembersCount();
                Console.WriteLine("By members:");
                Console.WriteLine(team);
                Console.WriteLine();
                team.WriteTeams("ByMembersCount.xml");

                team.ReadTeam("Teams.xml");
                Console.WriteLine("First:");
                Console.WriteLine(team);
                Console.WriteLine();

                Teamm<Member> beta = team[2];
                team -= beta;
                Console.WriteLine("after deleted:");
                Console.WriteLine(team);
                Console.WriteLine();

                TitledTeam<string> titledTeam = new TitledTeam<string>("Delta");
                titledTeam += new Teamm<string>("Delta2", 2022, "Nik0");
                Console.WriteLine("new Team:");
                Console.WriteLine(titledTeam);
                titledTeam.WriteTeams("newTeam.xml");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}