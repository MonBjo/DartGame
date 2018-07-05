using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame {
    class DartBoard {
        // Defining data
        private int[] dartBoardTargets = new int[] { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };

        public DartBoard(int arrowAim) {
            int arrowStrike = 0;
            int i = 0;
            foreach(int target in dartBoardTargets) {
                if(target == arrowAim) {
                    arrowStrike = StrikeOnDartBoard(arrowAim, i);
                    break;
                }
                ++i;
            }
            Console.WriteLine("Strikes: " + arrowStrike);
        }

        private int StrikeOnDartBoard(int arrowStrike, int index) {
            Random rnd = new Random();
            int chanceToStrike = rnd.Next(100);
            //Console.WriteLine("Chance of strike: " + chanceToStrike); // Debug data
            
            if(chanceToStrike > 60 && chanceToStrike <= 75) { // 15%
                if(index == (dartBoardTargets.Length - 1)) { 
                    arrowStrike = dartBoardTargets[0];
                    // Last element in array, jump to the first element
                }
                else {
                    arrowStrike = dartBoardTargets[++index];
                }
            }

            else if(chanceToStrike > 75 && chanceToStrike <= 90) { // 15%
                if(index == 0) { 
                    arrowStrike = dartBoardTargets[dartBoardTargets.Length - 1];
                    // First element in array, jump to the last element
                }
                else {
                    arrowStrike = dartBoardTargets[--index];
                }
            }

            else if(chanceToStrike > 90 && chanceToStrike <= 97) { // 7%
                arrowStrike = rnd.Next(20);
            }

            else if(chanceToStrike > 97 && chanceToStrike <= 100) { // 3%
                arrowStrike = 0;
            }
            // chanceToStrike <= 60 ... hits the target, nothing happens here.
            return arrowStrike;
        }
    }
}
/*  TODO: Remove comment
 *  60% träffar
 *  15% den innan
 *  15% den efter
 *  5% slumpad
 *  5% missar helt
 *
 * 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5
 * 
 * Hantera resultat här?
 * 
 */