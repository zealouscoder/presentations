using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
	public class Cart
	{
		[Required]
		public Guid UserId { get; set; }

		[Required]
		public List<CartItem> Items { get; set; }

		public string CartItemCountDisplay
		{
			get
			{
				return Items.Sum(i => i.Count).ToString() + " items";
			}
		}

		public string CartTotalDisplay
		{
			get
			{
				return Items.Sum(i => i.TotalPrice).ToString("C2");
			}
		}

		public Cart()
		{
			Items = new List<CartItem>();
		}
	}
}