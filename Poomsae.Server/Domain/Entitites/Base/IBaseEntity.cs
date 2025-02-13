﻿namespace Poomsae.Server.Domain.Entitites.Base
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}