public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // _studentName is accessible here because it is 'protected' in the base class
        return $"{_title} by {_studentName}";
    }
}