using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

namespace Quiz;

public class Game
{
    // Kategorie pytań: 100, 200, 300, 400, 500, 750, 1000


    // Konstruktor
    public Game()
    {
        CurrentCategory = 100;
        CurrentCategoryIndex = 0;
    }

    // Właściwości
    public List<Question> QuestionDatabase { get; set; }
    public int CurrentCategory { get; set; }
    public Question CurrentQuestion { get; set; }
    public List<int> AllCategories { get; set; } = [100, 200, 300, 400, 500, 750, 1000];
    public int CurrentCategoryIndex { get; set; }

    private Random random = new Random();


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
        var path = $"{Directory.GetCurrentDirectory()}\\questions.json";
        var data = File.ReadAllText(path);
        QuestionDatabase = JsonConvert.DeserializeObject<List<Question>>(data);
    }

    public void DrawQuestionFromCurrentCategory()
    {
        // mamy 1144 pytania z kategorii: 100, 200, 300, 400, 500, 750, 1000
        // musimy wybrać z nich wszystkich tylko te których kategoria równa się CurrentCategory
        // tworzymy pustą listę pytań z aktualnej kategorii
        var questionsFromCurrentCategory = new List<Question>();
        foreach (var question in QuestionDatabase)
        {
            if (question.Category == CurrentCategory)
                questionsFromCurrentCategory.Add(question);
        }


        // teraz losujemy jedno pytanie z listy pytań z aktualnej kategorii: questionsFromCurrentCategory
        var index = random.Next(0, questionsFromCurrentCategory.Count);
        
        
        var randomedQuestion = questionsFromCurrentCategory[index];
        randomedQuestion.Answers = randomedQuestion.Answers.OrderBy(a => random.Next()).ToList();
        var counter = 1;
        foreach (var answer in randomedQuestion.Answers)
        {
            answer.Order = counter;
            counter++;
        }

        CurrentQuestion = randomedQuestion;
    }

    public bool CheckUserAnswer(string answerIdString)
    {
        var answerId = int.Parse(answerIdString);

        foreach (var answer in CurrentQuestion.Answers)
        {
            if (answer.Order == answerId)
            {
                return answer.IsCorrect;
            }
        }

        return false;
    }

    public void FailGameOver()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" Niestety, to była błędna odpowiedź.");
        Console.WriteLine(" Koniec gry.");
    }

    public void GoodAnswer()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Brawo, to jest poprawna odpowiedź. Wygrałeś/aś {CurrentQuestion.Category} pkt");
        Console.WriteLine(" Gratulacje !!!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" Wciśnij ENTER, aby zobaczyć następne pytanie ... ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
        Console.Clear();
    }

    public void Success()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Brawo, udało Ci się ukończyć cały Quiz!!!. Wygrałeś/aś {CurrentQuestion.Category} pkt");
        Console.WriteLine(" Gratulacje !!!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" KONIEC GRY");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
        Console.Clear();
    }

    public void IncreaseCategory()
    {
        if (CurrentCategoryIndex == 6)
            return;

        CurrentCategoryIndex++;
        CurrentCategory = AllCategories[CurrentCategoryIndex];
    }
}
