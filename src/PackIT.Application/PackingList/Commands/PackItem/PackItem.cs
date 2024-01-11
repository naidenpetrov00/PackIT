﻿namespace PackIT.Application.PackingList.Commands.PackItem
{
	using PackIT.Application.Common.Exceptions;

	using PackIT.Domain.Repositories;

	using System.Threading;
	using MediatR;
	using Ardalis.GuardClauses;

	public record PackItem(Guid PackingListId, string Name) : IRequest;

	internal sealed class PackItemHandler : IRequestHandler<PackItem>
	{
		private readonly IPackingListRepository repository;

		public PackItemHandler(IPackingListRepository repository)
			=> this.repository = repository;

		public async Task Handle(PackItem request, CancellationToken cancellationToken)
		{
			var packingList = await this.repository.GetAsync(request.PackingListId);

			Guard.Against.NotFound(request.PackingListId, packingList);

			packingList.PackItem(request.Name);

			await this.repository.UpdateAsync(packingList);
		}
	}
}
