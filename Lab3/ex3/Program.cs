using System;
using System.Xml.Serialization;
using System.IO;   

namespace ex3
{
    public class AcademicGroup
    {
        public string Group { get; set; }
        public string[] Student { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AcademicGroup academicgroup = new AcademicGroup()
            {
                Group = "КН-421с",
                Student = new string[] {"Stud 1", "Oleh Pakhomov", "Stud 3"}
            };
            XmlSerializer serializer = new XmlSerializer(typeof(AcademicGroup));
            using (TextWriter textWriter = new StreamWriter("Академічна група.xml"))
            {
                serializer.Serialize(textWriter, academicgroup);
            }
            XmlSerializer deserializer = new XmlSerializer(typeof(AcademicGroup));
            using (TextReader textReader = new StreamReader("Академічна група.xml"))
            {
                academicgroup = (AcademicGroup)deserializer.Deserialize(textReader);
            }
            Console.WriteLine("File created");
        }
    }
}