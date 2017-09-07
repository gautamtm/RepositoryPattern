using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Chat
{
    public class ChatService : IChatService
    {
        public string InsertMessage(string msg)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(msg))
                    return string.Empty;
                return "reached";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
