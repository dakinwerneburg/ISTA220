/*
 -- Author: Dakin Werneburg
 -- Date: 2/6/2021

This excercise demonstrates Classes, and 
object instantiation, and inheritance.

Creates an abstract Animal class with and 
creates different types of Animals found on a 
farm by inheriting methods from the Animal class,
implements each one, instatiates each object, then
calls each method.

Displays one unit test performed.  
*/

using System;


namespace cssbs_ex04_werneburg
{
    public class Program
    {
        static void Main(string[] args)
        {
            Animal mrEd = new Horse();
            mrEd.speak("Wilbur....");
            mrEd.eat("grass");
            Console.WriteLine();

            Animal glory = new Horse();
            glory.speak("neigh");
            glory.eat("apples");
            Console.WriteLine();

            Animal blaze = new Horse();
            blaze.speak("wiiiiiii");
            blaze.eat("hotdogs");
            Console.WriteLine();

            Animal wildFire = new Horse();
            wildFire.speak("Heee Hee");
            wildFire.eat("hay");
            Console.WriteLine();

            Animal porky = new Pig();
            porky.speak("Bleep Bleep That's All Folks");
            porky.eat("cabbage");
            Console.WriteLine();

            Animal wilbur = new Pig();
            wilbur.speak("Oink Oink");
            wilbur.eat("trash");
            Console.WriteLine();

            Animal missPiggy = new Pig();
            missPiggy.speak("I love Kermit");
            missPiggy.eat("caviar");
            Console.WriteLine();

            Animal napolean = new Pig();
            napolean.speak("We must unite");
            napolean.eat("flowers");
            Console.WriteLine();

            Animal snowflake = new Sheep();
            snowflake.speak("Baaaah");
            snowflake.eat("grain");
            Console.WriteLine();


            Animal dolly = new Sheep();
            dolly.speak("baaadddd");
            dolly.eat("grass");
            Console.WriteLine();

            Animal baaBaa = new Sheep();
            baaBaa.speak("BaaBaa");
            baaBaa.eat("Lettuce");
            Console.WriteLine();

            Animal shrek = new Sheep();
            shrek.speak("I am not an ogre");
            shrek.eat("Anything");
            Console.WriteLine();

            Animal bettsy = new Cow();
            bettsy.speak("Mooo");
            bettsy.eat("grass");
            Console.WriteLine();

            Animal bella = new Cow();
            bella.speak("mooove");
            bella.eat("hamburgers");
            Console.WriteLine();

            Animal daisy = new Cow();
            daisy.speak("Mooodddyy");
            daisy.eat("slop");
            Console.WriteLine();

            Animal milky = new Cow();
            milky.speak("mooove over");
            milky.eat("cake");

 

 

 

 


        }
    }

    public abstract class Animal
    {
        public abstract void speak(string sound);
        public abstract void eat(string food);
    }

 

    public class Sheep : Animal
    {
        private string _name;

        public Sheep() : this("Dolly"){}
        public Sheep(string name) {  _name = name; }
        public override void eat(string food)
        {
            Console.WriteLine($"num num num, The {food} tastes good");
        }
        public override void speak(string sound)
        {
            Console.WriteLine($"Hello, my name is {_name} and I am a sheep. I say {sound}");
        }
    }

    public class Pig : Animal
    {
        private string _name;
        public Pig() : this("Wilber"){}
        public Pig(string name){ _name = name; }
        public override void eat(string food)
        {
            Console.WriteLine($"num num num, The {food} tastes good");
        }
        public override void speak(string sound)
        {
            Console.WriteLine($"Hello, my name is {_name} and I am a pig. I say {sound}");
        }
    }

    public class Horse : Animal
    {
        private string _name;
        public Horse() : this("Mr.Ed"){}
        public Horse(string name){ _name = name;}
        public override void eat(string food)
        {
            Console.WriteLine($"num num num, The {food} tastes good");
        }
        public override void speak(string sound)
        {
            Console.WriteLine($"Hello, my name is {_name} and I am a horse. I say {sound}");
        }
    }

    public class Cow : Animal
    {
        private string _name;

        public Cow() : this("Bettsy") { }
        public Cow(string name) { _name = name; }
        public override void eat(string food)
        {
            Console.WriteLine($"num num num, The {food} tastes good");
        }
        public override void speak(string sound)
        {
            Console.WriteLine($"Hello, my name is {_name} and I am a cow. I say {sound}.");
        }
    }
}

 

 

-------------------------------------UNIT TESTS------------------------

 

using Microsoft.VisualStudio.TestTools.UnitTesting;
using cssbs_ex04_werneburg;
using System;

using System.IO;

namespace cssbs_ex04_werneburg.Tests
{
    [TestClass()]
    public class CowTests
    {
        Horse s = new Horse("Bettsy");

        [TestMethod()]
        public void eatTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            s.eat("SLOP");
            string actual = output.ToString();
            string expected = $"num num num, The SLOP tastes good\r\n";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void speakTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            s.speak("Baaaa");
            string actual = output.ToString();
            string expected = $"Hello, my name is Bettsy and I am a horse. I say Baaaa\r\n";

            Assert.AreEqual(expected, actual);
        }
    }
