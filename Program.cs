using System;
using System.Collections.Generic;

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
            Bug bug1 = new Bug("Francine", "spider", new List<string>(){"cats", "Cara", "Sophie"}, new List<string>(){"flies", "plants", "other spiders"});
            Bug bug2 = new Bug("Harold", "grasshopper", new List<string>(){"dogs", "snakes", "birds"}, new List<string>(){"flies", "grass", "tomatoes"});
            Bug bug3 = new Bug("Arthur", "ladybug", new List<string>(){"cars", "doorways", "car doors"}, new List<string>(){"dirt", "leaves", "asphalt"});
            
            Console.WriteLine($"Bug #1 is {bug1.Name}. She is a {bug1.Species}. Her predators are {bug1.PredatorList()}. Her prey are {bug1.PreyList()}.");
            Console.WriteLine($"Bug #2 is {bug2.Name}. He is a {bug2.Species}. His predators are {bug2.PredatorList()}. His prey are {bug2.PreyList()}.");
            Console.WriteLine($"Bug #3 is {bug3.Name}. He is a {bug3.Species}. His predators are {bug3.PredatorList()}. His prey are {bug3.PreyList()}.");
        
            Console.WriteLine($"{bug1.FormalName} is afraid of {bug1.PredatorList()}. She enjoys eating {bug1.PreyList()}.");
            Console.WriteLine($"Would Arthur eat leaves? {bug3.Eat("leaves")}");
            Console.WriteLine($"Would Harold eat pizza? {bug2.Eat("pizza")}");
        }
    }
}

// Copy the code below into your Program.cs and convert all of the class methods to an expression-bodied 
// function member.
// Create some instances of your class in the Main method and invoke their methods.

public class Bug
{
    /*
        You can declare a typed public property, make it read-only,
        and initialize it with a default value all on the same
        line of code in C#. Readonly properties can be set in the
        class' constructors, but not by external code.
    */
    public string Name { get; } = "";
    public string Species { get; } = "";
    public ICollection<string> Predators { get; } = new List<string>();
    public ICollection<string> Prey { get; } = new List<string>();

    // Convert this readonly property to an expression member
    public string FormalName => $"{this.Name} the {this.Species}";
    // {
    //     get
    //     {
    //         return $"{this.Name} the {this.Species}";
    //     }
    // }

    // Class constructor
    public Bug(string name, string species, List<string> predators, List<string> prey)
    {
        this.Name = name;
        this.Species = species;
        this.Predators = predators;
        this.Prey = prey;
    }

    // Convert this method to an expression member
    public string PreyList() => string.Join(",", this.Prey);

    // Convert this method to an expression member
    public string PredatorList() => string.Join(",", this.Predators);

    // Convert this to expression method (hint: use a C# ternary)
    public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
    // {
    //     if (this.Prey.Contains(food))
    //     {
    //         return $"{this.Name} ate the {food}.";
    //     } else {
    //         return $"{this.Name} is still hungry.";
    //     }
    // }
}
