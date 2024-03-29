﻿namespace PackIT.Application.Common.DTO
{
	public class PackingItemReadModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public uint Quantity { get; set; }
		public bool IsPacked { get; set; }

		public virtual PackingListReadModel PackingList { get; set; }
	}
}
