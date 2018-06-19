using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame {
    class Program {
        static void Main(string[] args) {
        }
    }

    class Game {
        List<Player> players = new List<Player>();
        
        private void AddPlayer(string name) { // Todo: method to add new players by their name

        }

        public void PlayGame() { // Todo: Welcome user, menu, add players, start game, etc.  
            
        }
    }

    class Player {
        private string name = "no name";

        int[] turns = new int[2];   // three elements for three throws.

        private void CalculatePoints() { // Todo: Calculate all throws to get total number points.

        }

        private void AddTurn(int firstThrow, int secondThrwo, int thirdThrow) { // Todo: Add a round until someone wins. Player will write 3 integers or a computer will randomize

        }

        private string PrintTurns() { // Todo: Print the last round when finished.

            int foo = 0;
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
