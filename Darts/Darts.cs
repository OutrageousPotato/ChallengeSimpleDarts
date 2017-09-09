using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Darts
    {
        public class Dart
        {
            public System.Random randomizer { get; private set; }

            public int baseScore { get; private set; }
            public bool doubleRingHit { get; private set; }
            public bool tripleRingHit { get; private set; }
            public int totalScore { get; private set; }

            public Dart(System.Random random)
            {
                this.randomizer = random;
            }

            public int Throw()
            {
                this.baseScore = randomizer.Next(0, 20);
                int multiplierCheck = randomizer.Next();
                this.doubleRingHit = (multiplierCheck % 20 == 0) ? true : false;
                this.tripleRingHit = (multiplierCheck % 20 == 1) ? true : false;
                return baseScore;        
            }
        }

    }
}
