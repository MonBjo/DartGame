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
        
        private void AddPlayer(string name) {

        }

        public void PlayGame() {

        }
    }

    class Player {
        private string name = "no name";

        int[] turns = new int[2];   // three elements, three throws.

        private void CalculatePoints() {

        }

        private void AddTurn(int firstThrow, int secondThrwo, int thirdThrow) {

        }
    }

    class Turns {
        int throwOne, throwTwo, throwThree;
        
        public int GetScore() {

            int foo = 0;
            return foo;
        }
    }
}
