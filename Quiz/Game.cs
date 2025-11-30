using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz;

public class Game
{
    public List<Question> QuestionDatabase { get; set; }


    public void DisplayWelcome()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Witamy w grze Quiz");
        Console.WriteLine(" Spróbuj odpowiedzieć na 7 pytań");
        Console.WriteLine(" Powodzenia !!!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" Wciśnij ENTER, aby zobaczyć pierwsze pytanie ... ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
        Console.Clear();
    }

    public void CreateQuestionDatabase()
    {
        // Tworzymy pustą liste pytań
        QuestionDatabase = new List<Question>();
        // Dodajemy 2 pytania do bazy (jedno za 100 punktów, drugie za 200 punktów)
        var p1 = new Question();
        p1.Id = 1;
        p1.Category = 100;
        p1.Content = "Jakiego koloru jest niebo?";
        p1.Answers = new List<string>();
        p1.Answers.Add("niebieskie");
        p1.Answers.Add("zielone");
        p1.Answers.Add("czerwone");
        p1.Answers.Add("żółte");
        QuestionDatabase.Add(p1);


        var p2 = new Question();
        p2.Id = 2;
        p2.Category = 200;
        p2.Content = "Jak miana imię Einstein?";
        p2.Answers = new List<string>();
        p2.Answers.Add("Albert");
        p2.Answers.Add("Zenek");
        p2.Answers.Add("Jasiek");
        p2.Answers.Add("Marek");
        QuestionDatabase.Add(p2);
    }
}
