using System;
using System.Linq;
using System.Threading.Tasks;

namespace Executor.IO
{
    using Executor.Interfaces;

    public class InputReader : IInputReader
    {
        private const string endCommand = "quit";

        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();

            while (input != endCommand)
            {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
            }

            if (SessionData.taskPool.Count != 0)
            {
                Task.WaitAll(SessionData.taskPool.ToArray());
            }
        }
    }
}
