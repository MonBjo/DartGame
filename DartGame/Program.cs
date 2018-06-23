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
        //      Start of the game, basicly the menu
        public void PlayGame() {
            while(true) {
                Console.Clear();
                Console.WriteLine("=== Welcome to the Dart Game ===\n" +
                                  "[S] Start game \n" +
                                  "[A] Add player \n" +
                                  "[Q] Quit game");
                ConsoleKeyInfo userInputMenu = Console.ReadKey(true);
                switch(userInputMenu.Key) {
                    //      Start the game
                    case ConsoleKey.S: {
                        if(!players.Any()) {
                            Console.Clear();
                            Console.WriteLine("Please add players");
                            break;
                        }
                        else {
                            DartGame();
                        }
                        break;
                    }
                    //      Add new player
                    case ConsoleKey.A: {
                        while(true) {
                            //===== START OF SUBMENU =====\\
                            Console.WriteLine("=== Add a player ===\n" +
                                              "Do you want to play agaist a\n" +
                                              "friend or the computer?\n" +
                                              "  [F] Friend\n" +
                                              "  [C] Computer\n" +
                                              "  [R] Return");
                            ConsoleKeyInfo userInputSubMenu = Console.ReadKey(true);
                            switch(userInputSubMenu.Key) {
                                //      Add a friend as player
                                case ConsoleKey.F: {
                                    AddPlayer();
                                    break;
                                }
                                //      Add a computer as player
                                case ConsoleKey.C: {
                                    /* The computer's name in  *\
                                    \* the game is "Computer". */
                                    AddPlayer("Computer");
                                    break;
                                }
                                //      Return to main menu
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
                            //===== END OF SUBMENU =====\\
                        }
                        break;
                    }
                    //      Quit game, close console.
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
        //      The actual game
        private void DartGame() {
            bool continueGame = true;
            while(true) {
                if(!continueGame) {
                    break; //   To break the while-loop when game is finished.
                }
                foreach(Player aPlayer in players) {
                    //      Defining data
                    int throwOne = 0;
                    int throwTwo = 0;
                    int throwThree = 0;
                    int highestPoint = 20;
                    int winningPoint = 301;

                    Console.Clear();
                    Console.WriteLine($"It's {aPlayer.Name}'s turn with a total score of {aPlayer.CalculatePoints()}!");

                    //      Computer's game
                    if(aPlayer.Name == "Computer") {
                        Random randomThrow = new Random();
                        throwOne = randomThrow.Next(0, highestPoint);
                        throwTwo = randomThrow.Next(0, highestPoint);
                        throwThree = randomThrow.Next(0, highestPoint);

                        Console.WriteLine($"First throw:  {throwOne}\n" +
                                          $"Second throw: {throwTwo}\n" +
                                          $"Third throw:  {throwThree}");
                    }

                    //      People's game
                    else {
                        Console.WriteLine($"Write an integer bewteen 0 and {highestPoint} to choose your hit\n");
                        
                        while(true) {
                            Console.Write("First throw:  ");
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
                        
                        while(true) {
                            Console.Write("Thrid throw:  ");
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

                    if(aPlayer.CalculatePoints() >= winningPoint && continueGame) {
                        Console.WriteLine($"Congratulations {aPlayer.Name}!\n" +
                                            $"You won with {aPlayer.CalculatePoints()}!");
                        continueGame = false;
                    }
                }
            }
        }
        //      Add a new player
        private void AddPlayer() {
            Console.Clear();
            // Defining data
            string newName = "";
            bool uniqueName = true;

            while(true) {
                Console.Write("Name of new player: ");
                try {
                    newName = Console.ReadLine();
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                }

                for(int i = 0; i < players.Count; i++) {
                    if(players[i].Name == newName) {
                        Console.WriteLine("Please choose a unique name");
                        uniqueName = false;
                        break;
                    }
                    else {
                        uniqueName = true;
                    }
                }

                if(String.IsNullOrWhiteSpace(newName)) {
                    Console.WriteLine("You never enterd a name, please try again");
                }
                else if(uniqueName) {
                    Player player = new Player(newName);
                    players.Add(player);
                    Console.WriteLine("The new player was added");
                    break; // Sucessful input
                }
            }
            Console.WriteLine("===========================\n" +
                  " Press any key to continue");
            Console.ReadKey(true);
        }
        //      Add the computer as a player
        private void AddPlayer(string name) {
            Console.Clear();
            bool isComputerInPlayerlist = false;


            for(int i = 0; i < players.Count; i++) {
                if(players[i].Name == "Computer") {
                    isComputerInPlayerlist = true;
                    break;
                }
            }
            if(isComputerInPlayerlist) {
                Console.WriteLine("The Computer is alredy in the playerlist");
            }
            else {
                Player player = new Player("Computer");
                players.Add(player);
                Console.WriteLine("The Computer was added as a player");
            }
            Console.WriteLine("===========================\n" +
                  " Press any key to continue");
            Console.ReadKey(true);
        }
    }

    class Player {
        //      Defining data
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
        public int PlayerScore {
            get { return playerScore; }
            set { playerScore = value; }
        }
        //      It makes more sense in the context to return the players name
        public override string ToString() {
            return Name;
        }
        //      Calculate the total points for the player
        public int CalculatePoints() {
            int totalPoints = 0;
            foreach(Turns oneTurn in allTurns) {
                totalPoints += oneTurn.GetScore;
            }
            return totalPoints;
        }
        //      Adds a turn for the player
        public void AddTurn(int one, int two, int three) {
            Turns turn = new Turns(one, two, three);
            allTurns.Add(turn);
        }
        //      Prints the last turn for the player
        public void PrintTurn() {
            Console.WriteLine(allTurns.Last());
        }
    }

    class Turns {
        //      Defining data
        private List<int> turn = new List<int>(3);
        private int arrowOne, arrowTwo, arrowThree;
        
        public Turns(int firstArrow, int secondArrow, int thirdArrow) {
            this.ArrowOne = firstArrow;
            this.ArrowTwo = secondArrow;
            this.ArrowThree = thirdArrow;
        }

        public int ArrowOne {
            get { return arrowOne; }
            set {
                arrowOne = value;
            }
        }
        public int ArrowTwo {
            get { return arrowTwo; }
            set {
                arrowTwo = value;
            }
        }
        public int ArrowThree {
            get { return arrowThree; }
            set {
                arrowThree = value;
            }
        }
        //      It makes more sense in the context to return this string
        public override string ToString() {
            string myString =$"Throws this turn: {ArrowOne}, {ArrowTwo} and {ArrowThree}";
            return myString;
        }
        //      Calculates the score for one turn
        public int GetScore {
            get { return ArrowOne + ArrowTwo + ArrowThree; }
        }
    }
}