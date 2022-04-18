using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Teams
{
    public struct Member
    {
        
        [XmlAttribute()]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            Member member = (Member)obj;
            return member.Name == Name;
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

    public class Teamm<TMember>
    {
        [XmlAttribute()]
        public string Title { get; set; }

        [XmlAttribute()]
        public int Year { get; set; }

        public List<TMember> Member { get; set; }

        public Teamm()
        {
            Title = "";
            Member = new List<TMember>();
        }
    
        public Teamm(string title, int year, params TMember[] authors)
        {
            Title = title;
            Year = year;
            Member = new List<TMember>(authors);
        }

        override public string ToString()
        {
            string s = string.Format("Name: \"{0}\". Amount of Members: {1}", Title, Year);
            s += "\n" + "   Members:";
            for (int i = 0; i < Member.Count; i++)
            {
                s += string.Format("      {0}", Member[i]);
                if (i < Member.Count - 1)
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
            Teamm<TMember> b = obj as Teamm<TMember>;

            if (b != null)
            {
                if (b.Member.Count != Member.Count)
                {
                    return false;
                }
                for (int i = 0; i < Member.Count; i++)
                {
                    if (!b.Member[i].Equals(Member[i]))
                    {
                        return false;
                    }
                }
                return b.Title == Title && b.Year == Year;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public class Team<TMember>
    {
        public List<Teamm<TMember>> Teams { get; set; }

        public Team(params Teamm<TMember>[] books)
        {
            Teams = new List<Teamm<TMember>>(books);
        }

        public Teamm<TMember> this[int index]
        {
            get { return Teams[index]; }
            set { Teams[index] = value; }
        }

        override public string ToString()
        {
            string result = "";
            foreach (Teamm<TMember> book in Teams)
            {
                result += book;
            }
            return result;
        }

        public List<Teamm<TMember>> ContainsMember(string member)
        {
            List<Teamm<TMember>> found = new List<Teamm<TMember>>();
            foreach (Teamm<TMember> book in Teams)
            {
                if (book.Title.Contains(member))
                {
                    found.Add(book);
                }
            }
            return found;
        }

        public void Add(Teamm<TMember> teamm)
        {
            Teams.Add(teamm);
        }


        public void Remove(Teamm<TMember> teamm)
        {
            Teams.Remove(teamm);
        }
        public void ReadTeam(string fileName)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Teamm<TMember>>));
            using (TextReader textReader = new StreamReader(fileName))
            {
                Teams = (List<Teamm<TMember>>)deserializer.Deserialize(textReader);
            }
        }
        public void WriteTeams(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Teamm<TMember>>));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(textWriter, Teams);
            }
        }
        class CompareByName : IComparer<Teamm<TMember>>
        {
            public int Compare(Teamm<TMember> b1, Teamm<TMember> b2)
            {
                return string.Compare(b1.Title, b2.Title);
            }
        }
        class CompareByMembersCount : IComparer<Teamm<TMember>>
        {
            public int Compare(Teamm<TMember> b1, Teamm<TMember> b2)
            {
                return b1.Member.Count < b2.Member.Count ? -1 :
                       (b1.Member.Count == b2.Member.Count ? 0 : 1);
            }
        }
        public void SortByName()
        {
            Teams.Sort(new CompareByName());
        }
        public void SortByMembersCount()
        {
            Teams.Sort(new CompareByMembersCount());
        }
        public static Team<TMember> operator +(Team<TMember> team, Teamm<TMember> teams)
        {
            Team<TMember> newTeam = new Team<TMember>() { Teams = team.Teams };
            newTeam.Add(teams);
            return newTeam;
        }
        public static Team<TMember> operator -(Team<TMember> team, Teamm<TMember> teams)
        {
            Team<TMember> newShelf = new Team<TMember>() { Teams = team.Teams };
            newShelf.Remove(teams);
            return newShelf;
        }
    }
    public class TitledTeam<TMember> : Team<TMember>
    {
        public string Title { get; set; }
        public TitledTeam(string title, params Teamm<TMember>[] teams)
                  : base(teams)
        {
            Title = title;
        }
        override public string ToString()
        {
            return Title + "\n" + base.ToString();
        }

        public static TitledTeam<TMember> operator +(TitledTeam<TMember> titled, Teamm<TMember> teamm)
        {
            TitledTeam<TMember> newShelf = new TitledTeam<TMember>(titled.Title) 
            { 
                Teams = titled.Teams 
            };
            newShelf.Add(teamm);
            return newShelf;
        }

        public static TitledTeam<TMember> operator -(TitledTeam<TMember> titled, Teamm<TMember> team)
        {
            TitledTeam<TMember> newShelf = new TitledTeam<TMember>(titled.Title)
            { 
                Teams = titled.Teams 
            };
            newShelf.Remove(team);
            return newShelf;
        }
    }
}