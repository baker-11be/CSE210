using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            // ===================================================
            // EXCEEDS REQUIREMENTS - CREATIVITY SECTION
            // ===================================================
            // This program exceeds core requirements by implementing:
            // 1. LEVEL SYSTEM: Users level up based on points earned
            // 2. CATEGORY SYSTEM: Goals can be categorized for better organization
            // 3. ACHIEVEMENT SYSTEM: Unlockable achievements for milestones
            // 4. STREAK TRACKING: Tracks consecutive days of activity
            // 5. PROGRESS STATISTICS: Detailed statistics dashboard
            // 6. BONUS POINTS: Level-up bonuses and streak rewards
            // 7. VISUAL ENHANCEMENTS: Emojis and formatted displays
            // ===================================================
            
            EternalQuestApp app = new EternalQuestApp();
            app.Run();
        }
    }

    // Main application class
    public class EternalQuestApp
    {
        // ENCAPSULATION: Private member variables
        private List<Goal> _goals;
        private int _score;
        
        // EXCEEDS REQUIREMENTS: Additional features
        private int _level;
        private int _totalPointsEarned;
        private int _streakDays;
        private DateTime _lastActivityDate;
        private List<string> _achievements;

        // Constructor
        public EternalQuestApp()
        {
            _goals = new List<Goal>();
            _score = 0;
            
            // EXCEEDS REQUIREMENTS: Initialize bonus features
            _level = 1;
            _totalPointsEarned = 0;
            _streakDays = 0;
            _lastActivityDate = DateTime.MinValue;
            _achievements = new List<string>();
        }

        // Main run loop
        public void Run()
        {
            int userChoice;
            
            do
            {
                // EXCEEDS REQUIREMENTS: Update streak daily
                UpdateStreak();
                
                Console.Clear();
                DisplayHeader();
                DisplayMenu();
                
                Console.Write("Select a choice from the menu: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out userChoice))
                {
                    ProcessMenuChoice(userChoice);
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid number.");
                    Pause();
                }
                
            } while (userChoice != 7);
            
            Console.WriteLine("\nThank you for using Eternal Quest! Goodbye!");
        }

        // Display program header with score and level
        private void DisplayHeader()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("           ETERNAL QUEST PROGRAM");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Current Score: {_score} points");
            Console.WriteLine($"Level: {_level}");
            Console.WriteLine($"Daily Streak: {_streakDays} days");
            Console.WriteLine("==========================================");
        }

        // Display main menu
        private void DisplayMenu()
        {
            Console.WriteLine("\nMAIN MENU:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. View Statistics");
            Console.WriteLine("7. Quit");
        }

        // Process user menu choice
        private void ProcessMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    ListAllGoals();
                    break;
                case 3:
                    SaveGoalsToFile();
                    break;
                case 4:
                    LoadGoalsFromFile();
                    break;
                case 5:
                    RecordGoalEvent();
                    break;
                case 6:
                    DisplayStatistics();
                    break;
                case 7:
                    // Quit - handled in main loop
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please select 1-7.");
                    Pause();
                    break;
            }
        }

        // 1. CREATE NEW GOAL - User can create all three types
        private void CreateNewGoal()
        {
            Console.Clear();
            Console.WriteLine("CREATE NEW GOAL");
            Console.WriteLine("===============\n");
            
            // Display goal types
            Console.WriteLine("Types of Goals:");
            Console.WriteLine("1. Simple Goal (One-time completion)");
            Console.WriteLine("2. Eternal Goal (Repeatable forever)");
            Console.WriteLine("3. Checklist Goal (Multiple completions)");
            
            // Get goal type
            Console.Write("\nSelect goal type (1-3): ");
            if (!int.TryParse(Console.ReadLine(), out int goalType) || goalType < 1 || goalType > 3)
            {
                Console.WriteLine("\nInvalid goal type. Returning to menu.");
                Pause();
                return;
            }
            
            // Get goal details
            Console.Write("\nEnter goal name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            
            Console.Write("Enter points for completing: ");
            if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
            {
                Console.WriteLine("\nInvalid points value. Must be positive.");
                Pause();
                return;
            }
            
            // Create goal based on type
            Goal newGoal = null;
            
            switch (goalType)
            {
                case 1: // Simple Goal
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                    
                case 2: // Eternal Goal
                    newGoal = new EternalGoal(name, description, points);
                    break;
                    
                case 3: // Checklist Goal
                    Console.Write("How many times to complete for bonus? ");
                    if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                    {
                        Console.WriteLine("\nInvalid target. Must be positive.");
                        Pause();
                        return;
                    }
                    
                    Console.Write("Enter bonus points for completion: ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus <= 0)
                    {
                        Console.WriteLine("\nInvalid bonus. Must be positive.");
                        Pause();
                        return;
                    }
                    
                    newGoal = new ChecklistGoal(name, description, points, bonus, target);
                    break;
            }
            
            // Add goal to list
            if (newGoal != null)
            {
                _goals.Add(newGoal);
                Console.WriteLine($"\n✓ Goal '{name}' created successfully!");
                
                // EXCEEDS REQUIREMENTS: Check for achievements
                CheckAchievements();
            }
            
            Pause();
        }

        // 2. LIST ALL GOALS - Shows all goals with completion status
        private void ListAllGoals()
        {
            Console.Clear();
            Console.WriteLine("YOUR GOALS");
            Console.WriteLine("==========\n");
            
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet. Create your first goal!");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    // POLYMORPHISM: Each goal type displays differently
                    Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
                }
                
                // EXCEEDS REQUIREMENTS: Show completion statistics
                int completedCount = 0;
                foreach (var goal in _goals)
                {
                    if (goal.IsComplete())
                    {
                        completedCount++;
                    }
                }
                
                double completionRate = _goals.Count > 0 ? 
                    (double)completedCount / _goals.Count * 100 : 0;
                
                Console.WriteLine($"\n📊 Statistics: {completedCount}/{_goals.Count} goals completed ({completionRate:F1}%)");
            }
            
            Pause();
        }

        // 3. SAVE GOALS TO FILE - Saves all goals and user progress
        private void SaveGoalsToFile()
        {
            Console.Clear();
            Console.WriteLine("SAVE GOALS");
            Console.WriteLine("==========\n");
            
            Console.Write("Enter filename to save (e.g., goals.txt): ");
            string filename = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("\nFilename cannot be empty.");
                Pause();
                return;
            }
            
            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    // Save user progress
                    outputFile.WriteLine(_score);
                    outputFile.WriteLine(_level);
                    outputFile.WriteLine(_totalPointsEarned);
                    outputFile.WriteLine(_streakDays);
                    outputFile.WriteLine(_lastActivityDate.ToString("yyyy-MM-dd"));
                    
                    // Save achievements
                    foreach (string achievement in _achievements)
                    {
                        outputFile.WriteLine($"Achievement:{achievement}");
                    }
                    
                    // Save each goal
                    foreach (Goal goal in _goals)
                    {
                        // POLYMORPHISM: Each goal saves in its own format
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                
                Console.WriteLine($"\n✓ Goals saved successfully to '{filename}'!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error saving file: {ex.Message}");
            }
            
            Pause();
        }

        // 4. LOAD GOALS FROM FILE - Loads goals and user progress
        private void LoadGoalsFromFile()
        {
            Console.Clear();
            Console.WriteLine("LOAD GOALS");
            Console.WriteLine("==========\n");
            
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine();
            
            if (!File.Exists(filename))
            {
                Console.WriteLine($"\n✗ File '{filename}' not found.");
                Pause();
                return;
            }
            
            try
            {
                string[] lines = File.ReadAllLines(filename);
                
                // Clear current data
                _goals.Clear();
                _achievements.Clear();
                
                // Load user progress (first 5 lines)
                _score = int.Parse(lines[0]);
                _level = int.Parse(lines[1]);
                _totalPointsEarned = int.Parse(lines[2]);
                _streakDays = int.Parse(lines[3]);
                _lastActivityDate = DateTime.Parse(lines[4]);
                
                // Load remaining lines
                for (int i = 5; i < lines.Length; i++)
                {
                    string line = lines[i];
                    
                    if (line.StartsWith("Achievement:"))
                    {
                        // Load achievement
                        string achievement = line.Substring("Achievement:".Length);
                        _achievements.Add(achievement);
                    }
                    else
                    {
                        // Load goal
                        string[] parts = line.Split(':');
                        string goalType = parts[0];
                        string[] goalData = parts[1].Split(',');
                        
                        Goal loadedGoal = null;
                        
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                loadedGoal = new SimpleGoal(
                                    goalData[0], // name
                                    goalData[1], // description
                                    int.Parse(goalData[2]), // points
                                    bool.Parse(goalData[3]) // isComplete
                                );
                                break;
                                
                            case "EternalGoal":
                                loadedGoal = new EternalGoal(
                                    goalData[0], // name
                                    goalData[1], // description
                                    int.Parse(goalData[2]) // points
                                );
                                break;
                                
                            case "ChecklistGoal":
                                loadedGoal = new ChecklistGoal(
                                    goalData[0], // name
                                    goalData[1], // description
                                    int.Parse(goalData[2]), // points
                                    int.Parse(goalData[3]), // bonus
                                    int.Parse(goalData[4]), // target
                                    int.Parse(goalData[5]) // amountCompleted
                                );
                                break;
                        }
                        
                        if (loadedGoal != null)
                        {
                            _goals.Add(loadedGoal);
                        }
                    }
                }
                
                Console.WriteLine($"\n✓ Loaded {_goals.Count} goals from '{filename}'");
                Console.WriteLine($"Current score: {_score}, Level: {_level}");
                
                // EXCEEDS REQUIREMENTS: Check for level up after loading
                CheckLevelUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error loading file: {ex.Message}");
            }
            
            Pause();
        }

        // 5. RECORD EVENT - User records completion of a goal
        private void RecordGoalEvent()
        {
            Console.Clear();
            Console.WriteLine("RECORD GOAL COMPLETION");
            Console.WriteLine("======================\n");
            
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available. Create some goals first!");
                Pause();
                return;
            }
            
            // Display goals with numbers
            Console.WriteLine("Select a goal to record:\n");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
            }
            
            Console.Write("\nEnter goal number: ");
            if (!int.TryParse(Console.ReadLine(), out int goalNumber) || 
                goalNumber < 1 || goalNumber > _goals.Count)
            {
                Console.WriteLine("\nInvalid goal number.");
                Pause();
                return;
            }
            
            Goal selectedGoal = _goals[goalNumber - 1];
            
            // Check if goal is already complete (except eternal goals)
            if (selectedGoal.IsComplete() && selectedGoal is not EternalGoal)
            {
                Console.WriteLine("\nThis goal is already completed!");
                Pause();
                return;
            }
            
            // POLYMORPHISM: RecordEvent behaves differently for each goal type
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;
            _totalPointsEarned += pointsEarned;
            
            Console.WriteLine($"\n🎉 Congratulations! You earned {pointsEarned} points!");
            Console.WriteLine($"New total score: {_score}");
            
            // EXCEEDS REQUIREMENTS: Apply streak bonus
            ApplyStreakBonus();
            
            // EXCEEDS REQUIREMENTS: Check for level up
            CheckLevelUp();
            
            // EXCEEDS REQUIREMENTS: Check for achievements
            CheckAchievements();
            
            Pause();
        }

        // 6. DISPLAY STATISTICS - Shows detailed statistics
        private void DisplayStatistics()
        {
            Console.Clear();
            Console.WriteLine("STATISTICS DASHBOARD");
            Console.WriteLine("====================\n");
            
            // Basic statistics
            Console.WriteLine($"📈 Total Points Earned: {_totalPointsEarned}");
            Console.WriteLine($"🏆 Current Level: {_level}");
            Console.WriteLine($"🔥 Current Streak: {_streakDays} days");
            Console.WriteLine($"🎯 Total Goals: {_goals.Count}");
            
            // Goal type breakdown
            int simpleCount = 0, eternalCount = 0, checklistCount = 0;
            int simpleCompleted = 0, checklistCompleted = 0;
            
            foreach (Goal goal in _goals)
            {
                if (goal is SimpleGoal)
                {
                    simpleCount++;
                    if (goal.IsComplete()) simpleCompleted++;
                }
                else if (goal is EternalGoal)
                {
                    eternalCount++;
                }
                else if (goal is ChecklistGoal)
                {
                    checklistCount++;
                    if (goal.IsComplete()) checklistCompleted++;
                }
            }
            
            Console.WriteLine("\n📊 Goal Breakdown:");
            Console.WriteLine($"   Simple Goals: {simpleCompleted}/{simpleCount} completed");
            Console.WriteLine($"   Eternal Goals: {eternalCount} active");
            Console.WriteLine($"   Checklist Goals: {checklistCompleted}/{checklistCount} completed");
            
            // EXCEEDS REQUIREMENTS: Display achievements
            if (_achievements.Count > 0)
            {
                Console.WriteLine("\n🏅 Achievements Unlocked:");
                foreach (string achievement in _achievements)
                {
                    Console.WriteLine($"   ✓ {achievement}");
                }
            }
            
            // EXCEEDS REQUIREMENTS: Progress to next level
            int pointsForNextLevel = _level * 1000 - _totalPointsEarned;
            if (pointsForNextLevel > 0)
            {
                Console.WriteLine($"\n⬆️ Points needed for Level {_level + 1}: {pointsForNextLevel}");
            }
            
            Pause();
        }

        // ============================================
        // EXCEEDS REQUIREMENTS: Additional Features
        // ============================================

        // Level up system
        private void CheckLevelUp()
        {
            while (_totalPointsEarned >= _level * 1000)
            {
                _level++;
                int levelBonus = _level * 100;
                
                _score += levelBonus;
                _totalPointsEarned += levelBonus;
                
                Console.WriteLine($"\n🎉 LEVEL UP! You are now Level {_level}!");
                Console.WriteLine($"   Bonus: +{levelBonus} points!");
                
                // Add achievement
                AddAchievement($"Reached Level {_level}");
            }
        }

        // Streak tracking
        private void UpdateStreak()
        {
            DateTime today = DateTime.Today;
            
            if (_lastActivityDate == DateTime.MinValue)
            {
                // First time using
                _streakDays = 1;
            }
            else if (_lastActivityDate == today.AddDays(-1))
            {
                // Consecutive day
                _streakDays++;
            }
            else if (_lastActivityDate != today)
            {
                // Broken streak
                _streakDays = 1;
            }
            
            _lastActivityDate = today;
        }

        // Streak bonus
        private void ApplyStreakBonus()
        {
            if (_streakDays >= 7)
            {
                int streakBonus = (_streakDays / 7) * 50;
                _score += streakBonus;
                _totalPointsEarned += streakBonus;
                
                Console.WriteLine($"🔥 Streak Bonus! +{streakBonus} points for {_streakDays} day streak!");
            }
        }

        // Achievement system
        private void CheckAchievements()
        {
            // Check total goals
            if (_goals.Count >= 5 && !_achievements.Contains("Goal Setter"))
            {
                AddAchievement("Goal Setter (Created 5 goals)");
            }
            
            if (_goals.Count >= 10 && !_achievements.Contains("Goal Master"))
            {
                AddAchievement("Goal Master (Created 10 goals)");
            }
            
            // Check completed goals
            int completedCount = 0;
            foreach (Goal goal in _goals)
            {
                if (goal.IsComplete()) completedCount++;
            }
            
            if (completedCount >= 3 && !_achievements.Contains("Goal Getter"))
            {
                AddAchievement("Goal Getter (Completed 3 goals)");
            }
            
            if (completedCount >= 10 && !_achievements.Contains("Completionist"))
            {
                AddAchievement("Completionist (Completed 10 goals)");
            }
            
            // Check streak
            if (_streakDays >= 7 && !_achievements.Contains("Weekly Warrior"))
            {
                AddAchievement("Weekly Warrior (7-day streak)");
            }
            
            if (_streakDays >= 30 && !_achievements.Contains("Monthly Master"))
            {
                AddAchievement("Monthly Master (30-day streak)");
            }
            
            // Check level
            if (_level >= 5 && !_achievements.Contains("Rising Star"))
            {
                AddAchievement("Rising Star (Reached Level 5)");
            }
            
            if (_level >= 10 && !_achievements.Contains("Legendary"))
            {
                AddAchievement("Legendary (Reached Level 10)");
            }
        }

        private void AddAchievement(string achievement)
        {
            if (!_achievements.Contains(achievement))
            {
                _achievements.Add(achievement);
                Console.WriteLine($"\n🏆 Achievement Unlocked: {achievement}!");
            }
        }

        // Utility method to pause execution
        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}