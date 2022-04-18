using System.Collections.Generic;
using System.Linq;

namespace TeamLib
{
    public class TeamSWithLinq<TMember> : TeamS<TMember>
    {
        public TeamSWithLinq(params Team<TMember>[] teams) : base(teams)
        {
        }

        public new List<Team<TMember>> ContainsCharacters(string characters)
        {
            var found = from team in Teams
                        where team.Name.Contains(characters)
                        select team;

            return new List<Team<TMember>>(found);
        }

        public new void SortByTitle()
        {
            Teams = new List<Team<TMember>>(
                from team in Teams
                orderby team.Name
                select team);
        }

        public new void SortByAuthorsCount()
        {
            Teams = new List<Team<TMember>>(
                from team in Teams
                orderby team.Members.Count
                select team);
        }

        public static TeamSWithLinq<TMember> operator +
            (TeamSWithLinq<TMember> teamS, Team<TMember> newTeam)
        {
            var newTeams = new List<Team<TMember>>(teamS.Teams);
            newTeams.Add(newTeam);
            return new TeamSWithLinq<TMember>() { Teams = newTeams };
        }

        public static TeamSWithLinq<TMember> operator -
            (TeamSWithLinq<TMember> teamS, Team<TMember> oldTeam)
        {
            var newTeams = new List<Team<TMember>>(
                from team in teamS.Teams
                where !team.Equals(oldTeam)
                select team);
            return new TeamSWithLinq<TMember>() { Teams = newTeams };
        }

    }
    
}