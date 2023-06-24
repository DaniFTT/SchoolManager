using SchoolManager.SharedKernel.Extesions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolManager.SharedKernel
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; set; }

        public Entity() { }

        #region Equality Methods

        public static bool operator ==(Entity left, Entity right)
        {
            return left is not null && right is not null && left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public bool Equals(Entity? obj)
        {
            if (obj is null) return false;

            if (obj.GetType() != GetType()) return false;

            return Id == obj.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;

            if (obj.GetType() != GetType()) return false;

            if (obj is not Entity entity) return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        #endregion
    }
}