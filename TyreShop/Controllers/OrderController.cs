﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TyreShop.Models;

namespace TyreShop.Controllers
{
    public class OrderController: Controller
    {
        private readonly IOrderRepository _repository;
        private Cart _cart;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }

        [Authorize]
        public ViewResult List() =>
            View(_repository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = _repository.Orders
                .FirstOrDefault(o => o.OrderID == orderId);

            if (order != null)
            {
                order.Shipped = true;
                _repository.SaveOrder(order);
            }

            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() =>
            View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Koszyk jest pusty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repository.SaveOrder(order);

                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}
