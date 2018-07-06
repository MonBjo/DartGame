using System;

namespace DartGame {
    class DartBoard {
        // Defining data
        private int[] dartBoardTargets = new int[] { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };
        private int arrowStrike;

        public int ArrowStrike {
            get { return arrowStrike; }
            set { arrowStrike = value; }
        }

        public DartBoard(int arrowAim) {
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

        /******************************\
        |* CALCULATING WHERE THE DART *|
        |* ACTUALLY HITS ON THE BOARD *|
        \******************************/
        private int StrikeOnDartBoard(int arrowStrike, int index) {
            Random rnd = new Random();
            int chanceToStrike = rnd.Next(100);
            
            if(chanceToStrike > 60 && chanceToStrike <= 75) { // 15% chance that it strikes the next one
                if(index == (dartBoardTargets.Length - 1)) { 
                    arrowStrike = dartBoardTargets[0];
                    // Last element in array, jump to the first element
                }
                else {
                    arrowStrike = dartBoardTargets[++index];
                }
            }

            else if(chanceToStrike > 75 && chanceToStrike <= 90) { // 15% chance that it strikes the previous one
                if(index == 0) { 
                    arrowStrike = dartBoardTargets[dartBoardTargets.Length - 1];
                    // First element in array, jump to the last element
                }
                else {
                    arrowStrike = dartBoardTargets[--index];
                }
            }

            else if(chanceToStrike > 90 && chanceToStrike <= 97) { // 7% chance that it strikes a random one
                arrowStrike = rnd.Next(20);
            }

            else if(chanceToStrike > 97 && chanceToStrike <= 100) { // 3% chanse to miss the boad
                arrowStrike = 0;
            }

            // 60% chance to strike the target, nothing happens here
            return arrowStrike;
        }
    }
}