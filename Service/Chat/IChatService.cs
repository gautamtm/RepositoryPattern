using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Chat
{
    interface IChatService
    {
        string InsertMessage(string msg);
    }
}
