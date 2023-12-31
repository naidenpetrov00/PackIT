﻿namespace PackIT.Domain.ValueObjects
{
	using PackIT.Domain.Exceptions;

	public record PackingListName
	{
		public PackingListName(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new EmptyPackingListNameException();
			}

			this.Value = value;
		}

		public string Value { get; }

		public static implicit operator string(PackingListName name) => name.Value;

		public static implicit operator PackingListName(string name) => new (name);

	}
}
