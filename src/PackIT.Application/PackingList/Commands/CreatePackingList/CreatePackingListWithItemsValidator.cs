﻿namespace PackIT.Application.PackingList.Commands.CreatePackingList
{
	using PackIT.Application.Services;

	using FluentValidation;

	public class CreatePackingListWithItemsValidator : AbstractValidator<CreatePackingListWithItems>
	{
		private readonly IPackingListReadService packingListReadService;

		public CreatePackingListWithItemsValidator(IPackingListReadService packingListReadService)
		{
			this.packingListReadService = packingListReadService;

			RuleFor(pl => pl.Name)
				.NotEmpty()
				.MustAsync(NotExistsByName)
				.WithMessage("Packing list '{PropertyValue}' already exists")
				.WithErrorCode("InvalidOperation");
		}

		public async Task<bool> NotExistsByName(string name, CancellationToken cancellationToken)
		{
			return !await packingListReadService.ExistsByNameAsync(name);
		}

	}
}
