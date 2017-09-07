using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Chat
{
    public class Notification: INotification
    {
        public string GetNotification()
        {
            return "Checking Notification";
        }

    }
}
