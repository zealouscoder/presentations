using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
	public static class CartRepository
	{
		public static Cart Get(Guid? userId)
		{
			if (userId.GetValueOrDefault().Equals(Guid.Empty))
				return new Cart { UserId = userId.GetValueOrDefault() };
			
			return new Cart();	// query db here
		}

		public static CartItem Update(CartItem item)
		{
			// db query to verify user can access product id, check count and such, and get the price
			return new CartItem { ProductId = item.ProductId, ProductPrice = item.ProductPrice, Count = item.Count, Note = item.Note };
		}

		public static bool Remove(Guid userId, int? productId)
		{
			return true;
		}
	}
}