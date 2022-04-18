using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace TeamLib
{
    public struct Members
    {

        [XmlAttribute()]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            Members members = (Members)obj;
            return members.Name == Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class Team<TMember>
    {
        [XmlAttribute()]
        public string Name { get; set; }

        [XmlAttribute()]
        public int Year { get; set; }

        public List<TMember> Members { get; set; }

        public Team()
        {
            Name = "";
            Members = new List<TMember>();
        }
    
        public Team(string name, int year, params TMember[] members)
        {
            Name = name;
            Year = year;
            Members = new List<TMember>(members);
        }

        override public string ToString()
        {
            string s = string.Format("Name: \"{0}\". Creation Year: {1}", Name, Year);
            s += "\n" + "   Members:";
            for (int i = 0; i < Members.Count; i++)
            {
                s += string.Format(" {0}", Members[i]);
                if (i < Members.Count - 1)
                {
                    s += ",";
                }
                else
                {
                    s += "\n";
                }
            }
            return s;
        }
        
        public override bool Equals(object obj)
        {
            Team<TMember> b = obj as Team<TMember>;

            if (b != null)
            {
                if (b.Members.Count != Members.Count)
                {
                    return false;
                }
                for (int i = 0; i < Members.Count; i++)
                {
                    if (!b.Members[i].Equals(Members[i]))
                    {
                        return false;
                    }
                }
                return b.Name == Name && b.Year == Year;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public class TeamS<TMember>
    {
        public List<Team<TMember>> Teams { get; set; }

        public TeamS(params Team<TMember>[] teams)
        {
            Teams = new List<Team<TMember>>(teams);
        }

        public Team<TMember> this[int index]
        {
            get { return Teams[index]; }
            set { Teams[index] = value; }
        }

        override public string ToString()
        {
            string result = "";
            foreach (Team<TMember> team in Teams)
            {
                result += team;
            }
            return result;
        }

        public List<Team<TMember>> ContainsCharacters(string characters)
        {
            List<Team<TMember>> found = new List<Team<TMember>>();
            foreach (Team<TMember> team in Teams)
            {
                if (team.Name.Contains(characters))
                {
                    found.Add(team);
                }
            }
            return found;
        }

        public void Add(Team<TMember> team)
        {
            Teams.Add(team);
        }

        public void Remove(Team<TMember> team)
        {
            Teams.Remove(team);
        }

        public void ReadBooks(string fileName)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Team<TMember>>));
            using (TextReader textReader = new StreamReader(fileName))
            {
                Teams = (List<Team<TMember>>)deserializer.Deserialize(textReader);
            }
        }

        public void WriteBooks(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Team<TMember>>));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(textWriter, Teams);
            }
        }
    
        class CompareByTitle : IComparer<Team<TMember>>
        {
            public int Compare(Team<TMember> b1, Team<TMember> b2)
            {
                return string.Compare(b1.Name, b2.Name);
            }
        }

        class CompareByAuthorsCount : IComparer<Team<TMember>>
        {
            public int Compare(Team<TMember> b1, Team<TMember> b2)
            {
                return b1.Members.Count < b2.Members.Count ? -1 :
                       (b1.Members.Count == b2.Members.Count ? 0 : 1);
            }
        }

        public void SortByTitle()
        {
            Teams.Sort(new CompareByTitle());
        }

        public void SortByAuthorsCount()
        {
            Teams.Sort(new CompareByAuthorsCount());
        }

        public static TeamS<TMember> operator +(TeamS<TMember> teamS, Team<TMember> team)
        {
            TeamS<TMember> newShelf = new TeamS<TMember>() { Teams = teamS.Teams };
            newShelf.Add(team);
            return newShelf;
        }

        public static TeamS<TMember> operator -(TeamS<TMember> teamS, Team<TMember> team)
        {
            TeamS<TMember> newShelf = new TeamS<TMember>() { Teams = teamS.Teams };
            newShelf.Remove(team);
            return newShelf;
        }
    }

    public class NameTeams<TMember> : TeamS<TMember>
    {
        public string Name { get; set; }

        public NameTeams(string name, params Team<TMember>[] teams)
                  : base(teams)
        {
            Name = name;
        }

        override public string ToString()
        {
            return Name + "\n" + base.ToString();
        }

        public static NameTeams<TMember> operator +(NameTeams<TMember> titled, Team<TMember> team)
        {
            NameTeams<TMember> newShelf = new NameTeams<TMember>(titled.Name) 
            { 
                Teams = titled.Teams 
            };
            newShelf.Add(team);
            return newShelf;
        }

        public static NameTeams<TMember> operator -(NameTeams<TMember> titled, Team<TMember> team)
        {
            NameTeams<TMember> newShelf = new NameTeams<TMember>(titled.Name)
            { 
                Teams = titled.Teams 
            };
            newShelf.Remove(team);
            return newShelf;
        }
    }
}