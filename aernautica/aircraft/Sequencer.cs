namespace aernautica {
    public class Sequencer {
        
        private static Sequencer INSTANCE  = new Sequencer();

        private int counter = 0;
        
        private Sequencer() {
            
        }

        public static Sequencer GetInstance() {
            return INSTANCE;
        }

        public int IncrementAndGet() {
            return ++counter;
        }
        
    }
}