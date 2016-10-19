namespace Executor.Commands
{
    using System;

    using Executor.Exceptions;
    using Executor.Network;

    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentsRepository repository;
        private DownloadManager downloadManager;
        private IOManager inputOutputManager;


        protected Command(
            string input,
            string[] data,
            Tester judge,
            StudentsRepository repository,
            DownloadManager downloadManager,
            IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = inputOutputManager;
        }
        public string Input
        {
            get
            {
                return this.input;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get
            {
                return this.data;
            }

            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected StudentsRepository Repository
        {
            get
            {
                return this.repository;
            }
        }

        protected Tester Judge
        {
            get
            {
                return this.judge;
            }
        }

        protected IOManager InputOutputManager
        {
            get
            {
                return this.inputOutputManager;
            }
        }

        protected DownloadManager DownloadManager
        {
            get
            {
                return this.downloadManager;
            }
        }


        public abstract void Execute();
    }
}
