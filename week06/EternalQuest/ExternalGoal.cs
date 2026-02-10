using System;

namespace EternalQuest
{
    // INHERITANCE: EternalGoal inherits from Goal base class
    public class EternalGoal : Goal
    {
        // Constructor
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points)
        {
            // INHERITANCE: Using base constructor
        }

        // POLYMORPHISM: Override RecordEvent method
        public override int RecordEvent()
        {
            // Eternal goals are never complete - always return points
            return GetPoints(); // INHERITANCE: Using inherited GetPoints()
        }

        // POLYMORPHISM: Override GetStringRepresentation for saving
        public override string GetStringRepresentation()
        {
            // INHERITANCE: Using inherited getters
            return $"EternalGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
        }

        // POLYMORPHISM: Override GetDetailsString
        public override string GetDetailsString()
        {
            // INHERITANCE: Building on base class concept
            return $"[ ] {GetShortName()} ({GetDescription()})";
        }
    }
}