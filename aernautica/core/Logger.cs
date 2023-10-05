using System;
using System.Text;

namespace aernautica {
    public class Logger {
        private static Logger INSTANCE = new Logger();

        public static bool LOG_TO_CONSOLE = true;

        private Logger() {
        }

        public static Logger GetInstance() {
            return INSTANCE;
        }

        public void Info(string message) {
            if (LOG_TO_CONSOLE) {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(DateTime.Now);
                stringBuilder.Append("\t");
                stringBuilder.Append(EMessageType.INFO);
                stringBuilder.Append("\t");
                stringBuilder.Append(message);

                Console.WriteLine(stringBuilder.ToString());
            }
        }

        public void Warn(string message) {
            if (LOG_TO_CONSOLE) {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(DateTime.Now);
                stringBuilder.Append("\t");
                stringBuilder.Append(EMessageType.WARN);
                stringBuilder.Append("\t");
                stringBuilder.Append(message);

                Console.WriteLine(stringBuilder.ToString());
            }
        }
    }
}