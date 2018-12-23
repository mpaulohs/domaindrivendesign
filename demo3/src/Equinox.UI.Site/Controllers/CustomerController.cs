using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.UI.Site.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }

               
        public IActionResult Index()
        {
            return View(_customerAppService.GetAll());
        }

        [HttpGet]        
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpGet]        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel c)
        {
            var g = Guid.NewGuid();
            if (!ModelState.IsValid) return View(c);
            var cu = new Customer(g, c.Name, c.Email, c.BirthDate);
            _customerAppService.Register(cu);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Registered!";

            return View(c);
        }

        [HttpGet]       
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);

            _customerAppService.Update(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(customerViewModel);
        }

        [HttpGet]        
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]        
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _customerAppService.Remove(id);

            if (!IsValidOperation()) return View(_customerAppService.GetById(id));

            ViewBag.Sucesso = "Customer Removed!";
            return RedirectToAction("Index");
        }
        
        public JsonResult History(Guid id)
        {
            var customerHistoryData = _customerAppService.GetAllHistory(id);
            return Json(customerHistoryData);
        }
    }
}