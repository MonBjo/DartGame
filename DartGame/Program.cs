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
        private List<Turns> playerTurns = new List<Turns>();
        
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
                        Console.Write("Start the game!\n");
                        foreach(Player playerRound in players) {
                            Console.WriteLine($"This round is for {playerRound.Name}!\n" +
                                               "Good luck!");
                            Console.Write("Throw number 1: ");
                            int first = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Throw number 2: ");
                            int second = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Throw number 3: ");
                            int third = Convert.ToInt32(Console.ReadLine());

                            playerRound.AddTurn(first, second, third);
                            
                            
                            Console.Clear();
                        }
                        Console.WriteLine("==============================" +
                                          " Press any key to continue...");
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
                        Console.WriteLine("===========================\n" +
                                          " Press any key to continue");
                        Console.ReadKey(true);
                        break;
                    }
                    // List all current players. Debug info
                    case ConsoleKey.L: {
                        foreach(Player player in players) {
                            Console.WriteLine(player.Name);
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey(true);
                        break;
                    }
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
        private string name = "no name";

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
        
        public void CalculatePoints() { // Todo: Calculate all throws to get total number points.

        }

        public void AddTurn(int newThrowOne, int newThrowTwo, int newThrowThree) { // Todo: Add a round until someone wins. Player will write 3 integers or a computer will randomize
            Turns playerTurn = new Turns(newThrowOne, newThrowTwo, newThrowThree);
            
            Console.WriteLine("The new turn where added");
        }

        public string PrintTurns() { // Todo: Print all the rounds for each player
            string resultOfTurns = "foo";
            return resultOfTurns;
        }
    }

    class Turns {
        private int throwOne, throwTwo, throwThree;

        public Turns(int firstThrow, int secondThrow, int thirdThrow) {
            this.throwOne = firstThrow;
            this.throwTwo = secondThrow;
            this.throwThree = thirdThrow;
        }

        public int ThrowOne {
            get { return throwOne; }
            set { throwOne = value; }
        }
        public int ThrowTwo {
            get { return throwTwo; }
            set { throwTwo = value; }
        }
        public int ThrowThree {
            get { return throwThree; }
            set { throwThree = value; }
        }

        public void GetScore() { // Todo: Return all points/throws for the last round.
            Console.WriteLine("You fucking did it. At last. Go treat yourself!");
            return;
        }
    }
}

/*
 
    Player: Name
            Turns: turn one: throws 123
                   turn tow: throws 123
                   etc
            Name
            Turns: turn one: throws 123
                   turn tow: throws 123
                   etc

     */
