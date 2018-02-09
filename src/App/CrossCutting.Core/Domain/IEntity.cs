using System;

namespace CrossCutting.Core.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }

    public interface IEntity : IEntity<Guid>
    {
        Guid Id { get; set; }
    }
}
