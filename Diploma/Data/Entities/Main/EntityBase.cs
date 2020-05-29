using System;

namespace Diploma.Data.Entities.Main
{
	public abstract class EntityBase : IEntity
	{
		public Guid Id { get; set; }
	}
}
