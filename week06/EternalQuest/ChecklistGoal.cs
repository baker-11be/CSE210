using System;

namespace EternalQuest
{
    // INHERITANCE: ChecklistGoal inherits from Goal base class
    public class ChecklistGoal : Goal
    {
        // ENCAPSULATION: Private member variables
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        // Constructor
        public ChecklistGoal(string name, string description, int points, int bonus, int target) 
            : base(name, description, points)
        {
            // INHERITANCE: Using base constructor
            _bonus = bonus;
            _target = target;
            _amountCompleted = 0;
        }

        // Constructor for loading from file
        public ChecklistGoal(string name, string description, int points, int bonus, int target, int amountCompleted) 
            : base(name, description, points)
        {
            _bonus = bonus;
            _target = target;
            _amountCompleted = amountCompleted;
            
            // Set completion status if target reached
            if (_amountCompleted >= _target)
            {
                SetComplete(true);
            }
        }

        // ENCAPSULATION: Getter for private data
        public int GetAmountCompleted()
        {
            return _amountCompleted;
        }

        public int GetTarget()
        {
            return _target;
        }

        public int GetBonus()
        {
            return _bonus;
        }

        // POLYMORPHISM: Override RecordEvent method
        public override int RecordEvent()
        {
            if (!IsComplete())
            {
                _amountCompleted++;
                
                if (_amountCompleted >= _target)
                {
                    SetComplete(true);
                    return GetPoints() + _bonus; // Bonus when target reached
                }
                return GetPoints(); // Regular points for each completion
            }
            return 0;
        }

        // POLYMORPHISM: Override GetDetailsString
        public override string GetDetailsString()
        {
            // INHERITANCE: Building on base class method
            string completionStatus = IsComplete() ? "[X]" : "[ ]";
            return $"{completionStatus} {GetShortName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        // POLYMORPHISM: Override GetStringRepresentation for saving
        public override string GetStringRepresentation()
        {
            // INHERITANCE: Using inherited getters
            return $"ChecklistGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
        }
    }
}