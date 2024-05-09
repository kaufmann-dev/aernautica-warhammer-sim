using System;
using System.Collections.Generic;
using System.Text;
using aernautica.aircraft;
using aernautica.command;

namespace aernautica.core {
    public class GameEngine {
        
        private static GameEngine INSTANCE = new GameEngine();
        
        private readonly Point _dimension = new Point(10,10,5);

        private readonly Stack<ICommand> _commandStack = new Stack<ICommand>();
        
        private readonly Dictionary<Point, AAircraft> _fleets = new Dictionary<Point, AAircraft>();

        public AAircraft this[Point p] {
            get => _fleets[p];
            set => _fleets[p] = value;
        }


        public Dictionary<Point, AAircraft> Fleets => _fleets;

        private GameEngine() {
            
        }

        public void ExecuteCommand(ICommand command) {
            command.Execute();
            _commandStack.Push(command);
        }

        public static GameEngine GetInstance() {
            return INSTANCE;
        }
        
        public void DisplayPlayfield() {
            
            for (int y = 0; y < _dimension.Y; y++) {
                StringBuilder str = new StringBuilder();

                for (int z = 0; z < _dimension.Z; z++) {
                    for (int x = 0; x < _dimension.X; x++) {
                        Point key = new Point(x,y,z);
                        
                        str.Append( _fleets.ContainsKey(key) ? _fleets[key].FieldOutput(): "*");
                    }
                    str.Append(" ");
                }

                Console.WriteLine(str.ToString());
            }
        }

        public bool IsMoveLegal(Point destination) {
            return destination.X < _dimension.X  &&
                   destination.Y < _dimension.Y && 
                   destination.Z < _dimension.Z &&
                   !_fleets.ContainsKey(destination);
        }
        
        
    }
}