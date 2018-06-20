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
        List<Player> players = new List<Player>();
        
        private void AddPlayer(string name) { // Todo: method to add new players by their name
            players.Add(new Player(name));
            Console.WriteLine(players[players.Count() - 1]); // Debug info
        }

        public void PlayGame() { // Todo: Welcome user, menu, add players, start game, etc.  
            Console.WriteLine("=== Welcome to the awsome dart game ===\n" +
                              "");

            Console.Write("Name of new player: ");
            string newName = Console.ReadLine();
            AddPlayer(newName);
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

        int[] turns = new int[2];   // Array with three elements for three throws.

        private void CalculatePoints() { // Todo: Calculate all throws to get total number points.

        }

        private void AddTurn(int firstThrow, int secondThrwo, int thirdThrow) { // Todo: Add a round until someone wins. Player will write 3 integers or a computer will randomize

        }

        private string PrintTurns() { // Todo: Print the last round when finished.

            string foo = "noo";
            return foo;
        }
    }

    class Turns {
        int throwOne, throwTwo, throwThree;
        
        public int GetScore() { // Todo: Return all points for a player.

            int foo = 0;
            return foo;
        }
    }
}
