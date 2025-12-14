using Quiz;

// Powołujemy do życia obiekt klasy Game - główna logika gry
Game game = new Game();

// Wyświetlamy ekran powitalny
game.DisplayWelcome();

// Tworzymy bazę pytań
game.CreateQuestionDatabase();

// Losuje z bazy jedno pytanie z aktualnej kategorii
game.DrawQuestionFromCurrentCategory();


// Wyświtlanie wylosowanego pytania 
game.CurrentQuestion.Display();


// Pobieranie opowiedzi gracza
var userAnswer = Console.ReadLine();



Console.ReadLine();
