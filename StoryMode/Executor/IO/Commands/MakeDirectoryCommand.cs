﻿namespace Executor.IO.Commands
{
    using Executor.Attributes;
    using Executor.Exceptions;
    using Executor.Interfaces;

    [Alias("mkdir")]
    public class MakeDirectoryCommand : Command
    {
        [Inject]
        private IDirectoryManager ioManager;
        public MakeDirectoryCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string folderName = this.Data[1];
            this.ioManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}
