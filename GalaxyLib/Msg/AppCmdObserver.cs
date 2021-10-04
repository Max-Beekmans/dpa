using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Msg
{
    public class AppCmdObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            if (subject is ICommand)
            {
                ((ICommand) subject).Execute();
            }
        }
    }
}
