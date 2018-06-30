using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame {
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
        //      Calculates the score for one turn
        public int GetScore {
            get { return ArrowOne + ArrowTwo + ArrowThree; }
        }
        //      It makes more sense in the context to return this string
        public override string ToString() {
            string myString =$" {ArrowOne}, {ArrowTwo} and {ArrowThree} \n" +
                             $"Total: {GetScore}";
            return myString;
        }
    }
}
