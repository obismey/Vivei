using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Core.UndoRedo
{
    public class DefaultUndoRedoToken :  IUndoRedoToken
    {
        private string privateMessage;
        private Action<object> UndoAction;
        private Action<object> RedoAction;
        public DefaultUndoRedoToken(
            Action<object> UndoAction,
            Action<object> RedoAction, 
            string Message="Unnamed Action", 
            object Parameter=null)
        {
            this.UndoAction = UndoAction;
            this.RedoAction = RedoAction;
            this.privateMessage = Message;
            this.Parameter = Parameter;
        }

        public object Parameter { get; set; }
        public string Message { get { return this.privateMessage; } }

        void IUndoRedoToken.Undo()
        {
            UndoAction(Parameter);
        }

        void IUndoRedoToken.Redo()
        {
            RedoAction(Parameter);
        }

        string IUndoRedoToken.Message
        {
            get { return this.privateMessage; }
        }
    }
}
