using System;
using System.Collections.Generic;


namespace LecturePractice
{
    public class studentlist
    {
        public string name
        {
        get; set;
        }
        public int age
    {
        get;
        set;
    }
        public int Math
    {
        get;
        set;
    }
        public int Science
    {
        get;
        set;
    }
        public int SocialStudies
    {
        get;
        set;
    }
        public int English
    {
        get;
        set;
    }
        public int Art
    {
        get;
        set;
    }

    } //EofC


    class Program
    {
        static void Main(string[] args)
        {
            studentlist s1 = new studentlist()
            {
                name = "Amber",
                age = 19,
                Math = 60,
                Science = 95,
                SocialStudies = 100,
                English = 85,
                Art = 100,
            };
            studentlist s2 = new studentlist()
            {
                name = "Esmerald",
                age = 18,
                Math = 86,
                Science = 75,
                SocialStudies = 97,
                English = 100,
                Art = 100,
            };
            studentlist s3 = new studentlist()
            {
                name = "Texas",
                age = 17,
                Math = 100,
                Science = 67,
                SocialStudies = 99,
                English = 85,
                Art = 100,
            };
            studentlist s4 = new studentlist()
            {
                name = "Contessa",
                age = 18,
                Math = 68,
                Science = 80,
                SocialStudies = 90,
                English = 0,
                Art = 100,
            };
            studentlist s5 = new studentlist()
            {
                name = "Logan",
                age = 18,
                Math = 90,
                Science = 86,
                SocialStudies = 67,
                English = 80,
                Art = 100,
            };

            List<studentlist> students = new List<studentlist>();
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);

            Console.WriteLine("Students");
            Console.WriteLine($"Name = {s1.name}\nAge = {s1.age}\nMath = {s1.Math}\nScience = {s1.Science}\nSocial Studies = {s1.SocialStudies}\nArt = {s1.Art}\n");
            Console.WriteLine($"Name = {s2.name}\nAge = {s2.age}\nMath = {s2.Math}\nScience = {s2.Science}\nSocial Studies = {s2.SocialStudies}\nArt = {s2.Art}\n");
            Console.WriteLine($"Name = {s3.name}\nAge = {s3.age}\nMath = {s3.Math}\nScience = {s3.Science}\nSocial Studies = {s3.SocialStudies}\nArt = {s3.Art}\n");
            Console.WriteLine($"Name = {s4.name}\nAge = {s4.age}\nMath = {s4.Math}\nScience = {s4.Science}\nSocial Studies = {s4.SocialStudies}\nArt = {s4.Art}\n");
            Console.WriteLine($"Name = {s5.name}\nAge = {s5.age}\nMath = {s5.Math}\nScience = {s5.Science}\nSocial Studies = {s5.SocialStudies}\nArt = {s5.Art}\n");

        }



     }//EofC

}//EofNS

