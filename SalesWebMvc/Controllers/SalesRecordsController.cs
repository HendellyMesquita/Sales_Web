using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //CRUD IMCOMPLETO

        //public async Task<IActionResult> Create()
        //{
        //    var departments = await _departmentService.FindAllAsync();
        //    var viewModel = new SellerFormViewModel { Departments = departments };
        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Seller seller)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var departments = await _departmentService.FindAllAsync();
        //        var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
        //        return View(viewModel);
        //    }
        //    await _sellerService.InsertAsync(seller);
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = IdNotProvided });
        //    }

        //    var obj = await _sellerService.FindByIdAsync(id.Value);
        //    if (obj == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = IdNotFound });
        //    }

        //    return View(obj);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {

        //        await _sellerService.RemoveAsync(id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (IntegrityException e)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = e.Message });
        //    }
        //}

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = IdNotProvided });
        //    }

        //    var obj = await _sellerService.FindByIdAsync(id.Value);
        //    if (obj == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = IdNotFound });
        //    }

        //    return View(obj);
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = IdNotProvided });
        //    }

        //    var obj = await _sellerService.FindByIdAsync(id.Value);
        //    if (obj == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = IdNotFound });
        //    }

        //    List<Department> departments = await _departmentService.FindAllAsync();
        //    SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Seller seller)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var departments = await _departmentService.FindAllAsync();
        //        var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
        //        return View(viewModel);
        //    }
        //    if (id != seller.Id)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
        //    }
        //    try
        //    {
        //        await _sellerService.UpdateAsync(seller);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (ApplicationException e)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = e.Message });
        //    }
        //}

        //public IActionResult Error(string message)
        //{
        //    var viewModel = new ErrorViewModel
        //    {
        //        Message = message,
        //        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        //    };
        //    return View(viewModel);
        //}

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");


            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");


            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
