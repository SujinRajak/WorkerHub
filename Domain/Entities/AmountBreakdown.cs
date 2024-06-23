using System;
using System.ComponentModel.DataAnnotations;

namespace WorkerHub.Domain.Entities
{
	public class AmountBreakdown
	{
		[Key]
		public Guid Id { get; set; }
		public int OrderID { get; set; }
		public Order Order { get; set; }
		public string Label { get; set; }
		public int Amount { get; set; }
	}
}
