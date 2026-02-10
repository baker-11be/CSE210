using System;

namespace EternalQuest
{
    // INHERITANCE: SimpleGoal inherits from Goal base class
    public class SimpleGoal : Goal
    {
        // Constructor
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points)
        {
            // INHERITANCE: Using base constructor
        }

        // Constructor for loading from file
        public SimpleGoal(string name, string description, int points, bool isComplete) 
            : base(name, description, points)
        {
            // INHERITANCE: Inherited _isComplete field
            if (isComplete)
            {
                SetComplete(true);
            }
        }

        // POLYMORPHISM: Override RecordEvent method
        public override int RecordEvent()
        {
            if (!IsComplete())
            {
                SetComplete(true);
                return GetPoints(); // INHERITANCE: Using inherited GetPoints()
            }
            return 0;
        }

        // POLYMORPHISM: Override GetStringRepresentation for saving
        public override string GetStringRepresentation()
        {
            // INHERITANCE: Using inherited getters
            return $"SimpleGoal:{GetShortName()},{GetDescription()},{GetPoints()},{IsComplete()}";
        }

        // POLYMORPHISM: Override GetDetailsString
        public override string GetDetailsString()
        {
            // INHERITANCE: Building on base class method
            string completionStatus = IsComplete() ? "[X]" : "[ ]";
            return $"{completionStatus} {GetShortName()} ({GetDescription()})";
        }
    }
}