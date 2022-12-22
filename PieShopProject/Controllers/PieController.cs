using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PieShopProject.DataAccess.Data;
using PieShopProject.DataAccess.Repository;
using PieShopProject.DataAccess.Repository.IRepository;
using PieShopProject.Models.Models;

namespace PieShopProject.Controllers
{
    public class PieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PieShopDBContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        

        public PieController(IUnitOfWork unitOfWork, PieShopDBContext db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _db = db;

        }
        public IActionResult Index()
        {
            var Pies = _unitOfWork.Pie.GetAll();
            return View(Pies);
        }
        //[HttpGet]
        //public async Task<ActionResult> Index(string Empsearch)                  //for search
        //{
        //    var Pies = _unitOfWork.Pie.GetAll();
        //    ViewData["GetPieDetails"] = Empsearch;
        //    var empquery = from x in _db.Pies select x;
        //    if (!string.IsNullOrEmpty(Empsearch))
        //    {
        //        empquery = empquery.Where(x => x.Name.Contains(Empsearch));
        //    }
        //    return View(empquery.ToString());
        //}


        //  [HttpGet]
        public IActionResult Create()
        {
            

            return View();
        }

        //Create- Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pie catObj,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string path = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    // string fileName = Guid.NewGuid().ToString();
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    //var uploads = Path.Combine(path, @"Images");
                    //var extentions = Path.GetExtension(file.FileName);
                    catObj.Image = @"/Images/" + ImageName;
                }
                _unitOfWork.Pie.Add(catObj);

                _unitOfWork.Save();
                
                TempData["Success"] = "Pie details added successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                

                return View(catObj);
            }


        }

        public IActionResult Menu()
        {


            var Pies = _unitOfWork.Pie.GetAll();
            return View(Pies);
            
        }
        public IActionResult PieDetails(int id)
        {


            var pies = _unitOfWork.Pie.GetFirstOrDefault(c => c.Id == id); // new after adding unit



            return View(pies);

        }


    }
}
