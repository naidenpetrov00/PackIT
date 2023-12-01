﻿namespace PackIT.Application.Exceptions
{
	public class PackingListNotFoundException : Exception
	{
		public PackingListNotFoundException(Guid id) : base($"Packing list with ID '{id}' was not found.")
		{
		}
	}
}