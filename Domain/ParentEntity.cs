using System;

namespace Domain
{
    public class ParentEntity
    {
        public long? CreatedBy { get; protected set; }
        public DateTime? CreationTime { get; protected set; }
        public long? UpdatedBy { get; protected set; }
        public DateTime? UpdateTime { get; protected set; }
        public long? DeletedBy { get; protected set; }
        public DateTime? DeletedTime { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
