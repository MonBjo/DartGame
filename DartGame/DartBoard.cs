using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame {
    class DartBoard {
        public int HitOnDartBoard() {
            Random rnd = new Random();
            int foo = rnd.Next(100);
            
            if(foo >= 60) {

            }

            return 4;
        }
    }
}
/* TODO Make a dart board
 * 
 *  60% träffar
 *  15% den innan
 *  15% den efter
 *  5% slumpad
 *  5% missar helt
 *  1% träffa bullseye
 *
 * 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5
 * 
 * Hantera resultat här?
 * 
 */