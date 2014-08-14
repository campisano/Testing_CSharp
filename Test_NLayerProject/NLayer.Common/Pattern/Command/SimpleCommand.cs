namespace NLayer.Common.Pattern.Command
{
    public class SimpleCommand : I_Command
    {
        private CommandDelegate _command;

        public delegate void CommandDelegate();

        #region Constructors

        public SimpleCommand(CommandDelegate command)
        {
            this._command = command;
        }

        #endregion

        #region Methods

        public void Execute()
        {
            _command();
        }

        #endregion
    }
}
