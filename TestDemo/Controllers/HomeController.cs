using Service.Chat;
using Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestDemo.ViewModels;

namespace TestDemo.Controllers
{
    public class HomeController : Controller
    {
        private INotification _notificationService;
        
        private delegate string FirstDelegate(int x);
        public HomeController(IProductService productService, INotification notification)
        {
            _notificationService = notification;
            
        }
        // GET: Home
        public ActionResult Index()
        {
            var notice = _notificationService.GetNotification();
            ViewBag.Notification = notice;
            return View();
        }

        public PartialViewResult GetView(string typeScript)
        {
            return PartialView("_notification", new NotificationViewModel());
        }

        public PartialViewResult GetNotificatoinView()
        {
            return PartialView("_notification", new NotificationViewModel());
        }

        public ActionResult Algorithm()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GenerateReport()
        {
            try
            {
                var result = await ExecuteAlgorithm();
                var stringResult = await GetReport();
                Console.WriteLine("Int thread is {0}", result.GetType().ToString());
                Console.WriteLine("String thread is {0}", stringResult.GetType());
                return View("Algorithm");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Task<int> ExecuteAlgorithm()
        {
            return Task.FromResult(1);
        }

        private Task<string> GetReport() 
        {
            return Task.FromResult("hello");
        }

        public class DelegateSample 
        {
            public delegate void SecondDelegate(string name, int age);
        }
    }
}