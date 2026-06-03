// This means "BreathingActivity inherits from Activity"
public class BreathingActivity : Activity
{
    // This calls the Parent (Activity) constructor to set the name and description
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax...")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();  // Inherited from Parent
        
        // Put your specific breathing logic here (loops, breath in/out)
        ShowCountDown(5);  // Inherited from Parent - Example of using the countdown for breathing in
        ShowCountDown(5);  // Inherited from Parent - Example of using the countdown for breathing out
            
        DisplayEndingMessage();   // Inherited from Parent
    }
}