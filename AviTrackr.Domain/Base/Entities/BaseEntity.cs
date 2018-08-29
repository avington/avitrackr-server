using System;

namespace AviTrackr.Domain.Base.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public Guid Identifier { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public byte[] RowVersion { get; set; }
    }
}