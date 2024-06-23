using System;
using System.ComponentModel.DataAnnotations;

namespace WorkerHub.Domain.Entities
{
	public class Transaction
	{
		[Key]
		public Guid Id { get; set; }
		public int OrderID { get; set; }
		public Order Order { get; set; }
		public string KhaltiToken { get; set; }
		public int Amount { get; set; }
		public string Status { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
