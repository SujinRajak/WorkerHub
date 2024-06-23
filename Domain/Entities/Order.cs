using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace WorkerHub.Domain.Entities
{
	public class Order
	{
		[Key]
		public Guid Id { get; set; }
		public string PurchaseOrderID { get; set; }
		public string PurchaseOrderName { get; set; }
		public Guid ApplicationUserId { get; set; }
		public int Amount { get; set; }
		public string ReturnUrl { get; set; }
		public string WebsiteUrl { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public ICollection<Transaction> Transactions { get; set; }
		public ICollection<AmountBreakdown> AmountBreakdowns { get; set; }
	}
}
