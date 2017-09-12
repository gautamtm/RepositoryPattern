using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDemo.ViewModels
{
    public class NotificationViewModel
    {
        public string NotificationSubject { get; set; }
        public string NotificationMessage { get; set; }
        public string Sender { get; set; }
        public DateTime SendDate { get; set; }
    }
}