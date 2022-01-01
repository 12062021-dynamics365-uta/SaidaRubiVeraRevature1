using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";
        private string eyeColor;
        private int age;
        private int weight;


        public int Weight {
            get
            {
                return weight;
            }
            set
            {
                if (weight > 0 && weight < 900)
                    weight = value;
                else
                    weight = 0;
            }
        }

        public Human2()
        {

        }

        public Human2(string fName, string lName, string eyecolor, int a)
        {
            firstName = fName;
            lastName = lName;
            eyeColor = eyecolor;
            age = a;
        }

        public Human2(string fName, string lName, string eyecolor)
        {
            firstName=fName;
            lastName=lName;
            eyeColor=eyecolor;
        }
        public Human2(string fName,string lName, int a)
        {
            firstName=fName;
            lastName=lName;
            age=a;
        }


        public string AboutMe(string firstName, string lastName, string eyeColor, int age)
        {
            string baseLayer = $"My name is {firstName} {lastName}.";

            if (age != 0)
                baseLayer += $" My age is {age}.";
            if (eyeColor != null)
                baseLayer += $" My eye color is {eyeColor}.";
            return baseLayer;
        }


    }//eofc
}//eofn