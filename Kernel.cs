using System;
using System.Threading;
using Sys = Cosmos.System;

namespace CalcOS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Welcome to CalcOS.");
            Console.WriteLine("Type \"help\" to get list of available commands.");
        }

        protected override void Run()
        {
            Console.Write("\nCalcOS> ");
            var input= Console.ReadLine().ToLower().Trim();

            switch(input)
            {
                case "help": HelpCmd(); break;
                case "version": VersionCmd(); break;
                case "about": AboutCmd(); break;
                case "clear": ClearCmd(); break;
                case "calc": CalcCmd(); break;
                case "beep": BeepCmd(); break;
                case "poweroff":
                case "shutdown": ShutDownCmd(); break;
                case "reboot":
                case "restart": RestartCmd(); break;
                case "": break;
                default: BadCommand(); break;
            }
        }

        public void HelpCmd() {
            Console.WriteLine("LIST OF AVAILABLE COMMANDS:\n");
            Console.WriteLine("1. help - To see a list of available commands.");
            Console.WriteLine("2. version - To get the version of the OS.");
            Console.WriteLine("3. about - To get info about the OS.");
            Console.WriteLine("4. clear - Clears the screen.");
            Console.WriteLine("5. calc - The calculator.");
            Console.WriteLine("6. beep - Beeps at a given frequency for a certain duration.");
            Console.WriteLine("7. shutdown (or) poweroff - Shuts down the OS.");
            Console.WriteLine("8. restart (or) reboot - Reboots the OS.");
        }
        public void VersionCmd() {
            Console.WriteLine("1.0");
        }
        public void AboutCmd() {
            Console.WriteLine("CalcOS 1.0 - The Calculator");
        }

        public void ClearCmd() { 
            Console.Clear();
        }
        public void CalcCmd() {
            try
            {
                Console.WriteLine("Welcome to Calculator.");
                Console.WriteLine("It should be of the form:- a <op> b. Use + for addition, - for subtraction, X for multiplication,");
                Console.WriteLine("/ for division, // for floor division, % for remainder and ^ for power.");
                Console.Write("Enter the problem: ");
                String[] input = Console.ReadLine().Split(' ');
                double val1 = Double.Parse(input[0]);
                double val2 = Double.Parse(input[2]);
                string op = input[1];
                double res;

                switch (op)
                {
                    case "+": res = val1 + val2; break;
                    case "-": res = val1 - val2; break;
                    case "X": res = val1 * val2; break;
                    case "/": res = val1 / val2; break;
                    case "//": res = (int)(val1 / val2); break;
                    case "%": res = val1 % val2; break;
                    case "^": res = Math.Pow(val1, val2); break;
                    default: throw new FormatException();
                }

                Console.WriteLine("\nThe value is " + res);
            }
            catch (FormatException)
            {
                Console.Beep(1000, 500);
                Console.WriteLine("Please enter the expression correctly.");
            }
            catch 
            {
                Console.Beep(1000, 500);
                Console.WriteLine("Exception Occurred."); 
            }
            
        }
        public void BeepCmd()
        {
            Console.Write("Enter the frequency: ");
            int freq = Int32.Parse(Console.ReadLine());
            Console.Write("Enter the duration: ");
            int duration = Int32.Parse(Console.ReadLine());
            Console.Beep(freq, duration);
        }
        public void ShutDownCmd() {
            Console.Write("Shutting down in ");
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i + " .. ");
                Thread.Sleep(1000);
            }
            Sys.Power.Shutdown();
            
        }
        public void RestartCmd() {
            Console.Write("Restarting in ");
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i + " .. ");
                Thread.Sleep(1000);
            }
            Sys.Power.Reboot();
        }
        public void BadCommand() {
            Console.WriteLine("This command does not exist.");
            Console.Beep(1000, 500);
        }
    }
}
