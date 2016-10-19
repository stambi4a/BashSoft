using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Exceptions;
using Executor.Network;
using Executor.Judge;
using Executor.Repository;

namespace Executor.IO.Commands
{
    using Executor.Attributes;
    using Executor.Interfaces;

    [Alias("downloadasync")]
    public class DownloadAsynchCommand : Command
    {
        private IDownloadManager downloadManager;
        public DownloadAsynchCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string url = this.Data[1];
            this.downloadManager.DownloadAsync(url);
        }
    }
}
