namespace Task7
{
    public class Invoker
    {
        Command command;

        /// <summary>
        /// This method will set new command
        /// </summary>
        /// <param new command ="c"></param>
        public void SetCommand(Command c)
        {
            if (c == null)
            {
                throw new System.NullReferenceException();
            }
            command = c;
        }

        /// <summary>
        /// This method will run command
        /// </summary>
        public string Run()
        {
            return command.Execute();
        }
    }
}
