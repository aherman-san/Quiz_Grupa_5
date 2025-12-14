using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Quiz;

public class Game
{
    // Konstruktor
    public Game()
    {
        CurrentCategory = 100;
    }

    // Właściwości
    public List<Question> QuestionDatabase { get; set; }
    public int CurrentCategory { get; set; }
    public Question CurrentQuestion { get; set; }

    // Metody (funkcje)
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

        var a1 = new Answer();
        a1.Id = 1;
        a1.Content = "niebieskie";
        a1.IsCorrect = true;
        p1.Answers.Add(a1);

        var a2 = new Answer();
        a2.Id = 2;
        a2.Content = "zielone";
        p1.Answers.Add(a2);

        var a3 = new Answer();
        a3.Id = 3;
        a3.Content = "czerwone";
        p1.Answers.Add(a3);

        var a4 = new Answer();
        a4.Id = 4;
        a4.Content = "żółte";
        p1.Answers.Add(a4);

        QuestionDatabase.Add(p1);
    }

    public void DrawQuestionFromCurrentCategory()
    {
        // niby losujemy pytanie
        CurrentQuestion = QuestionDatabase[0];
    }
}
