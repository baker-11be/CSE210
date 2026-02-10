using System;

namespace EternalQuest
{
    // ABSTRACTION: This class defines the essential characteristics of a Goal
    public abstract class Goal
    {
        // ENCAPSULATION: All member variables are private
        private string _shortName;
        private string _description;
        private int _points;
        
        // Protected for derived class access (still encapsulated from external access)
        protected bool _isComplete;

        // Constructor
        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        // POLYMORPHISM: Abstract methods to be overridden by derived classes
        public abstract int RecordEvent();
        public abstract string GetStringRepresentation();
        
        // Virtual method that can be overridden (POLYMORPHISM)
        public virtual string GetDetailsString()
        {
            // INHERITANCE: Common behavior shared by all goals
            string completionStatus = _isComplete ? "[X]" : "[ ]";
            return $"{completionStatus} {_shortName} ({_description})";
        }

        // ENCAPSULATION: Getters for private data
        public string GetShortName()
        {
            return _shortName;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetPoints()
        {
            return _points;
        }

        public bool IsComplete()
        {
            return _isComplete;
        }

        // Setter for completion status (ENCAPSULATION)
        protected void SetComplete(bool complete)
        {
            _isComplete = complete;
        }
    }
}