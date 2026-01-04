using Quiz;

// Powołujemy do życia obiekt klasy Game - główna logika gry
Game game = new Game();

// Wyświetlamy ekran powitalny
game.DisplayWelcome();

// Tworzymy bazę pytań
game.CreateQuestionDatabase();

while(true)
{
    // Losuje z bazy jedno pytanie z aktualnej kategorii
    game.DrawQuestionFromCurrentCategory();

    // Wyświtlanie wylosowanego pytania 
    game.CurrentQuestion.Display();

    // Pobieranie opowiedzi gracza
    // Robimy tak, aby gracz mógł wpisać tylko 1, 2, 3 lub 4
    var accceptedKeys = new List<string>() { "1", "2", "3", "4" };
    var userAnswerAsString = Console.ReadLine();
    while (!accceptedKeys.Contains(userAnswerAsString))
    {
        Console.Clear();
        game.CurrentQuestion.Display();
        userAnswerAsString = Console.ReadLine();
    }


    // Sprawdzanie czy odpowiedź jest prawidłowa
    var isCorrect = game.CheckUserAnswer(userAnswerAsString);


    if (isCorrect)
    {
        // Dobra odpowiedź
        game.GoodAnswer();
        // Sprawdzamy czy to było ostatnie pytanie
        // Jeżeli kategoria zadanego pytania to 1000, to oznacza, że to było ostatnie pytanie
        if (game.CurrentQuestion.Category == 1000)
        {
            // ostatnie pytanie => KONIEC GRY - WYGRANA
            game.Success();
            break;
        }
        else
        {
            // Podnosimy kategorię o jedną wyżej.
            game.IncreaseCategory();
        }
    }
    else
    {
        // Zła odpowiedź => KONIEC GRY
        game.FailGameOver();
        break;
    }
}




Console.ReadLine();


