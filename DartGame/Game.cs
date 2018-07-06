using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame {
    class Game {
        //      Defining data
        private List<Player> players = new List<Player>();
        internal static string computerAsPlayer = "Computer";
        // NOTE: If you change the string of computerAsPlayer, do not let it start with "A", "R" or "Q" as they're already used in the menu.
        
        /*************\
        |* GAME MENU *| 
        \*************/
        public void PlayGame() {
            while(true) {
                Console.Clear();
                Console.WriteLine("=== Welcome to the Simplified Dart Game ===\n" +
                                  "[S] Start game \n" +
                                  "[A] Add player \n" +
                                  "[R] Rules \n" +
                                  "[Q] Quit game");
                ConsoleKeyInfo userInputMenu = Console.ReadKey(true);
                switch(userInputMenu.Key) {
                    //      Start the game
                    case ConsoleKey.S: {
                        if(!players.Any()) {
                            Console.Clear();
                            Console.WriteLine("Please add players");
                            Console.WriteLine("==============================\n" +
                                              " Press any key to continue...");
                            Console.ReadKey(true);
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
                                             $"friend or the {computerAsPlayer}?\n" +
                                              "  [A] Add player\n" +
                                             $"  [{computerAsPlayer[0]}] {computerAsPlayer}\n" +
                                              "  [R] Return");
                            ConsoleKeyInfo userInputSubMenu = Console.ReadKey(true);
                            switch(userInputSubMenu.Key) {
                                //      Add a friend as player
                                case ConsoleKey.A: {
                                    AddPlayer();
                                    break;
                                }
                                //      Add a computer as player
                                case ConsoleKey.C: {
                                    //      The computer's name in the game
                                    AddPlayer(computerAsPlayer);
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
                    //      Show the rules
                    case ConsoleKey.R: {
                        Console.WriteLine("====== Rules ====== \n" +
                                          "  When playing dart, you start with 301 points.    \n" +
                                          "  Your goal is to get rid of them as fast as       \n" +
                                          "  possible, or at least faster than your opponent. \n" +
                                          "   \n" +
                                          "  When you throw a dart, you will be able to aim   \n" +
                                          "  for 1 to 20 points, end with [ENTER]. If you get \n" +
                                          "  0 points you have missed the dartboard completly,\n" +
                                          "  or you didn't throw at all.                      \n" +
                                          "  To throw randomly, do not write anything and just\n" +
                                          "  press [ENTER]. \n" +
                                          "  \n" +
                                          "  If your score gets under zero it's called to get \n" +
                                          "  bust. If you get bust you'll lose your last round.");

                        Console.WriteLine(" ==============================\n" +
                                          "  Press any key to continue...");
                        Console.ReadKey(true);
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
        /*******************************\
        |* HERE STARTS THE ACTUAL GAME *|
        \*******************************/
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
                    //int highestPoint = 20; // TODO: same as the magic number in player.cs
                    int pointsToWin = 301;

                    Console.Clear();
                    aPlayer.CalculatePoints(); // Calculate points for each turn
                    Console.WriteLine($"It's {aPlayer.Name}'s turn with {(pointsToWin - aPlayer.PlayerScore)} points left!");

                    //      Computer's game
                    if(aPlayer.Name == computerAsPlayer) {
                        Random rnd = new Random();
                        throwOne = rnd.Next(Player.highestPoint);
                        throwTwo = rnd.Next(Player.highestPoint);
                        throwThree = rnd.Next(Player.highestPoint);
                        Console.WriteLine($"First strike:  {throwOne}\n" +
                                          $"Second strike: {throwTwo}\n" +
                                          $"Third strike:  {throwThree}");
                    }
                    //      People's game
                    else {
                        Console.WriteLine($"Write an integer bewteen 0 and {Player.highestPoint} to choose your hit\n");
                            throwOne = aPlayer.AddThrow("First throw:");
                            throwTwo = aPlayer.AddThrow("Second throw:");
                            throwThree = aPlayer.AddThrow("Third throw:");
                    }
                    aPlayer.AddTurn(throwOne, throwTwo, throwThree);

                    Console.Write("Strikes on this turn: ");
                    aPlayer.PrintLastTurn();
                    aPlayer.CalculatePoints(); // So the if statements get the corret numbers to work with

                    if(aPlayer.PlayerScore > pointsToWin && continueGame) {
                        Console.WriteLine("Your score got bust");
                        aPlayer.ClearLastTurn(); 
                    }

                    else if(aPlayer.PlayerScore == pointsToWin && continueGame) {
                        Console.Clear();
                        Console.WriteLine($"Congratulations {aPlayer.Name}! You won!");
                        continueGame = false;
                    }

                    Console.WriteLine("==============================\n" +
                                      " Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
            if(!continueGame) {
                foreach(Player aPlayer in players) {
                    Console.Clear();
                    Console.WriteLine("All {0}'s turns", aPlayer.Name);
                    aPlayer.PrintAllTurns();
                    aPlayer.ClearTurns();
                    Console.WriteLine("==============================\n" +
                                      " Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }
        //      Add a new player // TODO: Make bigger
        private void AddPlayer() {
            Console.Clear();
            // Defining data
            string newName = "";

            while(true) {
                Console.Write("Name of new player: ");
                try {
                    newName = Console.ReadLine();
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                }

                if(AddPlayer(newName)) {
                    break; // Successful input
                }
                else if(!AddPlayer(newName)) {
                    continue; // Unsuccessful input
                }
            }
        }
        //      Conditions for a player name
        private bool AddPlayer(string _name) {
            Console.Clear();

            for(int i = 0; i < players.Count; i++) {
                if(players[i].Name == _name) {
                    if(computerAsPlayer != _name) {
                        Console.WriteLine("Please choose a unique name");
                        return false;
                    }
                    else {
                        Console.WriteLine($"The {computerAsPlayer} is already a player\n" +
                                           "===========================\n" +
                                           " Press any key to continue");
                        Console.ReadKey(true);
                        return false;
                    }
                }
            }

            if(String.IsNullOrWhiteSpace(_name)) {
                Console.WriteLine("You never enterd a name, please try again");
                return false;
            }
            else {
                Player player = new Player(_name);
                players.Add(player);
                Console.WriteLine(_name + " was added as a player");
                Console.WriteLine("===========================\n" +
                  " Press any key to continue");
                Console.ReadKey(true);
                return true;
            }
        }
    }
}
