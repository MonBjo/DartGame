using System;
using System.Collections.Generic;
using System.Linq;

namespace DartGame {
    class Player {
        //      Defining data
        private List<Turns> allTurns = new List<Turns>();
        private string name = "no name";
        private int playerScore = 0;
        internal static int highestPoint = 20;

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
        //      Calculate the current total points for the player
        public int CalculatePoints() {
            int _score = 0;
            foreach(Turns oneTurn in allTurns) {
                _score += oneTurn.GetScore;
            }
            PlayerScore = _score;
            return _score;
            
        }

        public int AddThrow(string instructionString) {
            int arrowInt;
            while(true) {
                Console.Write(instructionString + " ");

                string userInput = Console.ReadLine();
                if(userInput.Length == 0) {
                    Random randomThrow = new Random();
                    arrowInt = randomThrow.Next(highestPoint);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine( $"{instructionString} {arrowInt} (random throw) {new string(' ', instructionString.Length)}" );
                    break;
                }
                else {
                    try {
                        arrowInt = Convert.ToInt32(userInput);
                        if(arrowInt < 0 || arrowInt > highestPoint) {
                            Console.WriteLine("Please write an integer between 0 and " + highestPoint);
                        }
                        else if(arrowInt == 0) {
                            Console.WriteLine("Didn't throw");
                            break; // Successful input
                        }
                        else {
                            DartBoard playerDartBoard = new DartBoard(arrowInt);
                            arrowInt = playerDartBoard.ArrowStrike;
                            break; // Also successful input
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
            return arrowInt;
        }

        public void AddTurn(int arrowOne, int arrowTwo, int arrowThree) {
            Turns turn = new Turns(arrowOne, arrowTwo, arrowThree);
            allTurns.Add(turn);
        }

        public void ClearTurns() {
            allTurns.Clear();
        }
        public void ClearLastTurn() {
            allTurns.RemoveAt((allTurns.Count - 1));
        }

        public void PrintLastTurn() {
            Console.WriteLine(allTurns.Last());
        }

        public void PrintAllTurns() {
            int i = 0;
            foreach(Turns oneTurn in allTurns) {
                Console.WriteLine("Turn {0}: {1} \n", i, oneTurn);
                i++;
            }
        }
        //      It makes more sense in the context to return the players name
        public override string ToString() {
            return Name;
        }
    }
}
