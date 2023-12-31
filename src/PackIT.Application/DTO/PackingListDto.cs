﻿namespace PackIT.Application.DTO
{
	using PackIT.Domain.ValueObjects;

	public class PackingListDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public LocalizationDto LocalizationDto { get; set; }

        public IEnumerable<PackingItemDto> Items { get; set; }
    }
}
