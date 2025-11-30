namespace Quiz;

public class Question
{
    public Question()
    {
        
    }


    public int Id { get; set; }
    public string Content { get; set; }
    public int Category { get; set; }
    public List<string> Answers { get; set; }

}
