using FeedMe.DataAccess.Data.Repository.IRepository;
using FeedMe.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using FeedMe.Models.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FeedMe.DataAccess.Settings;
using FeedMe.DataAccess.Settings.G_Captcha.Interface;

namespace FeedMe.Areas.Cooperation.Controllers
{
    [Area("Cooperation")]
    [Authorize]
    public class Cooperation : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICaptchaValidator _captchaValidator;

        public Cooperation(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, ICaptchaValidator captchaValidator)
        {
            _captchaValidator = captchaValidator;
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CooperationReq()
        {
            CooperationViewModel cooperationVM = new CooperationViewModel();

            return View(cooperationVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CooperationReq(CooperationViewModel cooperationVM,string captcha)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(captcha))
            {
                ModelState.AddModelError("captcha", "Captcha validation failed");
            }
            if (ModelState.IsValid)
            {

                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"Files\Resume");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStreams);
                }
                CooperationModel cooperation = new CooperationModel()
                {
                    Id = cooperationVM.Id,
                    Text = cooperationVM.Text,
                    Name = cooperationVM.Name,
                    UploadFile = @"\Files\Resume\" + fileName + extension


                };



                _unitOfWork.Cooperation.Add(cooperation);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cooperationVM);

        }
    }
}
