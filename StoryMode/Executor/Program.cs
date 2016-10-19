using System;

namespace Executor
{
    using Executor.Network;

    class Program
    {
        static void Main()
        {
            Tester tester = new Tester();
            DownloadManager downloadManager = new DownloadManager();
            IOManager inputOutputManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositioryFilter());
            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, downloadManager, inputOutputManager);
            InputReader reader = new InputReader(currentInterpreter);
            Console.WindowWidth = 150;
            reader.StartReadingCommands();       
                              
        }
    }
}