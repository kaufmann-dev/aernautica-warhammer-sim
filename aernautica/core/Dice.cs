using System;
using System.Collections.Generic;

namespace aernautica {
    public class Dice {
        private static Dice INSTANCE = new Dice();

        private Random _random = new Random();
        
        private Dice() {
            
        }

        public static Dice GetInstance() {
            return INSTANCE;
        }

        public int Roll() {
            return _random.Next(1, 7);
        }

        public Stack<int> RollDices(int amount) {
            Stack<int> results = new Stack<int>();

            for (int i = 0; i < amount; i++) {
                results.Push(Roll());
            }
            
            return results;
        }
        
    }
}