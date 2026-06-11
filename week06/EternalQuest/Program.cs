using System;

/*
========================================================================================
EXCEEDING THE CORE REQUIREMENTS (CREATIVITY & INNOVATION):
1. PERSISTENT DATA STORAGE:
   - Implemented a robust file I/O system to save and load goals, ensuring user progress 
     is retained across sessions. This includes error handling for file access issues and 
     data integrity checks to prevent corruption.
2. ADVANCED USER INTERFACE & STATE CHECKING:
   - Developed a dynamic console menu that adapts based on the user's current goals and 
     progress. This includes real-time updates to the menu options, visual indicators of 
     goal completion, and a more intuitive navigation system.

3. DYNAMIC LEVELING & TITLE SYSTEM:
   - Created a leveling system that calculates the user's level based on their total points, 
     with a title system that assigns thematic titles (e.g., "Novice Adventurer", "Master 
     Quest Seeker") at specific milestones. This adds an engaging layer of progression and 
     personalization to the user experience.
========================================================================================
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}