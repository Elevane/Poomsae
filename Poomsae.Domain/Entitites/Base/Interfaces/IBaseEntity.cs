﻿namespace Poomsae.Server.Domain.Entitites.Base.Interfaces
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}