using System;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch_E stopwatch = new Stopwatch_E();

        // Event Handlers
        stopwatch.OnStarted += message => Console.WriteLine(message);
        stopwatch.OnStopped += message => Console.WriteLine(message);
        stopwatch.OnReset += message => Console.WriteLine(message);

        bool running = true;

        Console.WriteLine("Console Stopwatch_E Application");
        Console.WriteLine("Commands: A = Start, B = Stop, C = Reset, X = Quit");

        while (running)
        {
            Console.Write("Enter Command: ");
            var input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (char.ToUpper(input))
            {
                case 'A':
                    stopwatch.Start();
                    break;
                case 'B':
                    stopwatch.Stop();
                    break;
                case 'C':
                    stopwatch.Reset();
                    break;
                case 'X':
                    running = false;
                    stopwatch.Stop();
                    Console.WriteLine("Exiting application...");
                    break;
                default:
                    Console.WriteLine("Invalid command. Please enter A, B, C, or X.");
                    break;
            }
        }
    }
}
