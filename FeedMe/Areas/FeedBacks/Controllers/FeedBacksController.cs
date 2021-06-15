using FeedMe.DataAccess.Data.Repository;
using FeedMe.DataAccess.Data.Repository.IRepository;
using FeedMe.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMe.Areas.FeedBacks.Controllers
{
    [Area("FeedBacks")]
    [Authorize]
 
    public class FeedBacksController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public FeedBacksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult SendFeed()
        {
            FeedBack feedBack = new FeedBack();
            return View(feedBack);
        }
        [HttpPost]
        public IActionResult SendFeed(FeedBack feedBack)
        {
            if (ModelState.IsValid) {
                _unitOfWork.FeedBack.Add(feedBack);
                _unitOfWork.Save();

                Task.Delay(2300).Wait();
                return View(nameof(Index));
            };
            return View(feedBack);
           
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
