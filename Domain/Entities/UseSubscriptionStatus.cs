using System;
using System.ComponentModel.DataAnnotations;

namespace WorkerHub.Domain.Entities
{
	public class UseSubscriptionStatus
	{
		[Key]
		public Guid Id { get; set; }
		public Guid ApplicationUserId { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsConsumed { get; set; }
	}
}
