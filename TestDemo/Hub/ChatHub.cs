using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Service.Chat;
//using Microsoft.AspNet.SignalR.Hubs;

namespace TestDemo
{
    //[HubName("Chat")]
    public class ChatHub : Hub
    {
        private ChatService _chatService;

        public ChatHub()
        {
            _chatService = new ChatService();
        }
        public void Hello()
        {
            Clients.All.hello();
        }

        public void send(string msg)
        {
            msg = _chatService.InsertMessage(msg);
            Clients.All.AddMessage(msg);
        }

        public void pushNotification(string from, string subject, string notice)
        {
            try
            {
                Clients.All.AddNotice(from, subject, notice);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}