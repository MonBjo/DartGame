using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame {
    class Program {
        static void Main(string[] args) {
            Game myGame = new Game();
            myGame.PlayGame();
        }
    }

    class Game {
        private List<Player> players = new List<Player>();
        
        public void PlayGame() {
            while(true) {
                Console.Clear();
                Console.WriteLine("=== Welcome to the Dart Game ===\n" +
                                  "[S] Start game \n" +
                                  "[A] Add player \n" +
                                  "[Q] Quit game");
                ConsoleKeyInfo userInputMenu = Console.ReadKey(true);
                switch(userInputMenu.Key) {
                    // Start the game
                    case ConsoleKey.S: {
                        bool continueGame = true;
                        while(true) {
                            if(!players.Any()) {
                                Console.Clear();
                                Console.WriteLine("Please add players");
                                break;
                            }
                            else if(!continueGame) {
                                break;
                            }
                            foreach(Player aPlayer in players) {
                                // Defining data
                                int throwOne = 0;
                                int throwTwo = 0;
                                int throwThree = 0;
                                int highestPoint = 20;
                                int winningPoint = 301;

                                Console.Clear();
                                Console.WriteLine($"It's {aPlayer.Name}'s turn with a total score of {aPlayer.CalculatePoints()}!");
                                if(aPlayer.Name == "Computer") {
                                    Random randomThrow = new Random();
                                    throwOne = randomThrow.Next(0, highestPoint);
                                    throwTwo = randomThrow.Next(0, highestPoint);
                                    throwThree = randomThrow.Next(0, highestPoint);
                                    Console.WriteLine($"First throw: {throwOne}\n" +
                                                      $"First throw: {throwTwo}\n" +
                                                      $"First throw: {throwThree}");
                                }
                                else {
                                    Console.WriteLine($"Write an integer bewteen 0 and {highestPoint} to choose your hit");
                                    // first throw
                                    while(true) {
                                        Console.Write("First throw: ");
                                        try {
                                            throwOne = Convert.ToInt32(Console.ReadLine());
                                            if(throwOne < 0 || throwOne > highestPoint) {
                                                Console.WriteLine("Please write an integer between 0 and " + highestPoint);
                                            }
                                            else {
                                                break; // Successful input
                                            }
                                        }
                                        catch(FormatException) {
                                            Console.WriteLine("Please write an integer");
                                        }
                                        catch(Exception e) {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    // second throw
                                    while(true) {
                                    Console.Write("Second throw: ");
                                        try {
                                            throwTwo = Convert.ToInt32(Console.ReadLine());
                                            if(throwTwo < 0 || throwTwo > highestPoint) {
                                                Console.WriteLine("Please write an integer between 0 and " + highestPoint);
                                            }
                                            else {
                                                break; // Successful input
                                            }
                                        }
                                        catch(FormatException) {
                                            Console.WriteLine("Please write an integer");
                                        }
                                        catch(Exception e) {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    // third throw
                                    while(true) {
                                    Console.Write("Thrid throw: ");
                                        try {
                                            throwThree = Convert.ToInt32(Console.ReadLine());
                                            if(throwThree < 0 || throwThree > highestPoint) {
                                                Console.WriteLine("Please write an integer between 0 and " + highestPoint);
                                            }
                                            else {
                                                break; // Successful input
                                            }
                                        }
                                        catch(FormatException) {
                                            Console.WriteLine("Please write an integer");
                                        }
                                        catch(Exception e) {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                }
                                aPlayer.AddTurn(throwOne, throwTwo, throwThree);
                                aPlayer.PrintTurn();
                                Console.WriteLine("==============================\n" +
                                          " Press any key to continue...");
                                Console.ReadKey(true);

                                if(aPlayer.CalculatePoints() >= winningPoint && continueGame == true) {
                                    Console.WriteLine($"Congratulations {aPlayer.Name}!\n" +
                                                      $"You won with {aPlayer.CalculatePoints()}!");
                                    continueGame = false;
                                }
                            }
                        }
                        Console.WriteLine("==============================\n" +
                                          " Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    }
                    // Add new player
                    case ConsoleKey.A: {
                        while(true) {
                            Console.WriteLine("=== Add a player ===\n" +
                                              "Do you want to play agaist a\n" +
                                              "friend or the computer?\n" +
                                              "  [F] Friend\n" +
                                              "  [C] Computer\n" +
                                              "  [R] Return");
                            ConsoleKeyInfo userInputSubMenu = Console.ReadKey(true);
                            switch(userInputSubMenu.Key) {
                                // Add a friend as player
                                case ConsoleKey.F: {
                                    Console.Clear();
                                    string newName = "";
                                    while(true) {
                                        Console.Write("Name of new player: ");
                                        try {
                                            newName = Console.ReadLine();
                                        }
                                        catch(Exception e) {
                                            Console.WriteLine(e.Message);
                                        }

                                        if(String.IsNullOrWhiteSpace(newName)) {
                                            Console.WriteLine("You never enterd a name, please try again.");
                                        }
                                        else {
                                            AddPlayer(newName);
                                            Console.WriteLine("The new player was added");
                                            break; // Sucessful input
                                        }
                                    }
                                    Console.WriteLine("===========================\n" +
                                          " Press any key to continue");
                                    Console.ReadKey(true);
                                    break;
                                }
                                // Add a computer as player
                                case ConsoleKey.C: {
                                    Console.Clear();
                                    bool isComputerInPlayerlist = false;
                                    for(int i = 0; i < players.Count; i++) {
                                        if(players[i].Name == "Computer") {
                                            isComputerInPlayerlist = true;
                                            break;
                                        }
                                    }
                                    if(isComputerInPlayerlist == true) {
                                        Console.WriteLine("The Computer is alredy in the playerlist");
                                    }
                                    else {
                                        AddPlayer();
                                        Console.WriteLine("The Computer was added as a player");
                                    }
                                    Console.WriteLine("===========================\n" +
                                          " Press any key to continue");
                                    Console.ReadKey(true);
                                    break;
                                }
                                // Return to main menu
                                case ConsoleKey.R: {
                                    Console.WriteLine("Returns...");
                                    break;
                                }
                                default: {
                                    Console.WriteLine("Please choose something in the menu");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                    /*/ Debug info
                    case ConsoleKey.L: {
                        foreach(Player aPlayer in players) {
                            Console.WriteLine(aPlayer.Name);
                            
                        }
                        Console.ReadKey(true);
                        break;
                    }
                    //*/
                    // Quit game, close console.
                    case ConsoleKey.Q: {
                        Environment.Exit(0);
                        break;
                    }
                    default: {
                        Console.WriteLine("Please choose something in the menu.");
                        continue;
                    }
                }
            }
        }

        private void AddPlayer(string name) {
            Player player = new Player(name);
            players.Add(player);
        }
        private void AddPlayer() {
            Player player = new Player("Computer");
            players.Add(player);
        }
    }

    class Player {
        private List<Turns> allTurns = new List<Turns>();
        private string name = "no name";
        private int playerScore = 0;

        public Player(string _name) {
            this.Name = _name;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public override string ToString() {
            return Name;
        }

        public int PlayerScore {
            get { return playerScore; }
            set { playerScore = value; }
        }

        public int CalculatePoints() { // Todo: Calculate all throws to get total number points.
            int totalPoints = 0;
            //foreach(Turns oneTurn in allTurns) {
            //    totalPoints = GetScore + oneTurn.GetScore;
            //}
            foreach(Turns oneTurn in allTurns) {
                totalPoints += oneTurn.GetScore;
            }
            return totalPoints;
        }

        public void AddTurn(int one, int two, int three) { // Todo: Add a round until someone wins. Player will write 3 integers or a computer will randomize
            Turns turn = new Turns(one, two, three);
            allTurns.Add(turn);
            //Console.WriteLine("A turn migth have been added.");
            
        }

        public void PrintTurn() { // Todo: Print all the rounds for each player
            Console.WriteLine(allTurns.Last());
        }
    }

    class Turns {
        private List<int> turn = new List<int>(3);
        private int arrowOne, arrowTwo, arrowThree, score;
        //private int arrowOne = 0;
        //private int arrowTwo = 0;
        //private int arrowThree = 0;

        public Turns(int firstArrow, int secondArrow, int thirdArrow) {
            this.ArrowOne = firstArrow;
            this.ArrowTwo = secondArrow;
            this.ArrowThree = thirdArrow;
        }

        public int ArrowOne {
            get { return arrowOne /*+ turn[0]*/; }
            set { arrowOne = value;
                //turn.Add(arrowOne);
            }
        }
        public int ArrowTwo {
            get { return arrowTwo /*+ turn[1]*/; }
            set { arrowTwo = value;
                //turn.Add(arrowTwo);
            }
        }
        public int ArrowThree {
            get { return arrowThree /*+ turn[2];*/; }
            set { arrowThree = value;
                //turn.Add(arrowThree);
            }
        }

        public int GetScore {
            get { return ArrowOne + ArrowTwo + ArrowThree; }
        }

        public override string ToString() {
            string myString =$"Throws this turn: {ArrowOne}, {ArrowTwo} and {ArrowThree}";
            return myString;
        }
    }
}