using System;
using System.Globalization;
using System.Web.Helpers;
using System.Web.Mvc;
using App.Models;

namespace App.Controllers
{
	[RouteArea("Store")]
	[RoutePrefix("Cart")]
	[Route("{ action = GetCart }")]
	[RequireHttps]
	public class ShoppingCartController : Controller
	{
		[Route]
		public ViewResult Index()
		{
			return View("Cart", new Cart());
		}

		[Route("/{userId?}")]
		[Authorize]
		public ViewResult GetCart(Guid userId)
		{
			return View("Cart", CartRepository.Get(userId));
		}

		[HttpPost]
		[Route("Add", Name = "AddCartItem")]
		[Authorize(Roles = "Shopper")]
		public ActionResult AddCartItem(CartItem model)
		{
			if (!ModelState.IsValid)
			{
				// trigger a validation message and/or return something that will trigger a validation message
				ModelState.AddModelError("", "The product you selected is not a valid product.  Please select another item");
				return PartialView("CartItem", new CartItem());
			}

			return PartialView("CartItem", CartRepository.Update(model));
		}

		[HttpGet]
		[Route("Remove/{userId}/{productId?}", Name = "RemoveCartItem")]
		[Authorize(Roles = "Shopper")]
		public JsonResult RemoveCartItem(Guid userId, int? productId)
		{
			// call something that will 
			string[] result = new string[] { "true", "ProductName removed from cart." };
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}