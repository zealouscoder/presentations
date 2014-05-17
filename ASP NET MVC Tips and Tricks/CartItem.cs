using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Models
{
	public class CartItem
	{
		[Required]
		[Remote("CheckProduct", "Product")]
		public int ProductId { get; set; }

		public string ProductName { get; set; }

		[Required]
		public int Count { get; set; }

		[MaxLength(100)]
		public string Note { get; set; }

		public decimal ProductPrice { get; set; }

		public string DisplayProductPrice
		{
			get
			{
				return ProductPrice.ToString("C2");
			}
			set
			{
				ProductPrice = Convert.ToDecimal(value);
			}
		}

		public decimal TotalPrice
		{
			get
			{
				return Count * ProductPrice;
			}
		}

		public string DisplayTotalPrice
		{
			get
			{
				return TotalPrice.ToString("C2");
			}
		}
	}
}