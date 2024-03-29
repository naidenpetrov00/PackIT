﻿namespace PackIT.Infrastructure.EF.Configurations
{
	using PackIT.Application.Common.DTO;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
	{
		public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
		{
			builder.ToTable("PackingLists", "packing");
			builder.HasKey(x => x.Id);
			builder
				.Property(pl => pl.Localization)
				.HasConversion(pl => pl.ToString(), pl => LocalizationReadModel.Create(pl));
			builder
				.HasMany(pl => pl.Items)
				.WithOne(pi => pi.PackingList);
		}

		public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
		{
			builder.ToTable("PackingItems");
		}
	}
}
