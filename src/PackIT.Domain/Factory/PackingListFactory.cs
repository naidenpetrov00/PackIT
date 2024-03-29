﻿namespace PackIT.Domain.Factory
{
	using PackIT.Domain.Entities;
	using PackIT.Domain.Enums;
	using PackIT.Domain.Policies;
	using PackIT.Domain.ValueObjects;
	using PackIT.Domain.ValueObjects.PackingLists;

	public sealed class PackingListFactory : IPackingListFactory
	{
		private readonly IEnumerable<IPackingItemsPolicy> policies;

		public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
			=> this.policies = policies;

		public PackingList CreatePackingList(PackingListId id, PackingListName name, Localization localization)
		{
			return new PackingList
			{
				Id = id,
				Name = name,
				Localization = localization
			};
		}

		public PackingList CreatePackingListWithDefaultItems(
			PackingListId id,
			PackingListName name,
			Localization localization,
			TravelDays days,
			Temperature temperature,
			Gender gender)
		{
			var data = new PolicyData(days, gender, temperature, localization);
			var applicablePolicies = this.policies.Where(policy => policy.IsApplicable(data));
			var items = applicablePolicies.SelectMany(policy => policy.GenerateItems(data));
			var packingList = this.CreatePackingList(id, name, localization);
			packingList.AddItems(items);

			return packingList;
		}
	}
}
