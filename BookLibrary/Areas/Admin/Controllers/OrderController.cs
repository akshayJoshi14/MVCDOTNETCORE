
using BookLibrary.DataAccess.Repository.IRepository;
using BookLibrary.Models;
using BookLibrary.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOffWork)
        {
            _unitOfWork = unitOffWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region Apicalls

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> orderHeader;

            orderHeader = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            

            switch (status)
            {
                case "pending":
                    orderHeader = orderHeader.Where(or => or.PaymentStatus == SD.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    orderHeader = orderHeader.Where(or => or.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    orderHeader = orderHeader.Where(or => or.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    orderHeader = orderHeader.Where(or => or.OrderStatus == SD.StatusApproved);
                    break;
                default:
                    break;
            }
            return Json(new { data = orderHeader });
        }
        #endregion
    }
}
