using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Executor.Network
{
    using Executor.Exceptions;

    public class DownloadManager
    {
        private WebClient webClient;

        public DownloadManager()
        {
            this.webClient = new WebClient();
        }

        public void Download(string fileURL)
        {
            try
            {
                OutputWriter.WriteMessageOnNewLine("Started downloading: ");

                string nameOfFile = ExtractNameOfFile(fileURL);
                string pathToDownload = SessionData.currentPath + "/" + nameOfFile;

                webClient.DownloadFile(fileURL, pathToDownload);

                OutputWriter.WriteMessageOnNewLine("Download complete");
            }
            catch (WebException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        public void DownloadAsync(string fileURL)
        {
            Task currentTask = Task.Run(() => Download(fileURL));
            SessionData.taskPool.Add(currentTask);
        }

        private string ExtractNameOfFile(string fileURL)
        {
            int indexOfLastBackSlash = fileURL.LastIndexOf("/");

            if (indexOfLastBackSlash != -1)
            {
                return fileURL.Substring(indexOfLastBackSlash + 1);
            }
            else
            {
                throw new InvalidPathException();
            }
        }
    }
}
