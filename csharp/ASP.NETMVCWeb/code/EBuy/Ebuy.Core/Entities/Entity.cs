using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ebuy.Common.Entities
{
    public interface IEntity { 
        
    }
    public class Entity<TId>:IEntity,IEquatable<Entity<TId>>
    {
        private object _id;
        [Key]
        public virtual TId Id {
            get {
                if (_id == null && typeof(TId) == typeof(Guid)) {
                    _id = Guid.NewGuid();
                }
                return _id == null ? default(TId) : (TId)_id;
            }
            protected set { _id = value; }
        }
        private string _key;
        public virtual string Key {
            get { return _key = _key ?? GenerateKey(); }
            protected set { _key = value; }
        } 
        protected virtual string GenerateKey(){
            return KeyGenerator.Generate();
        }
        public bool Equals(Entity<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            if (default(TId).Equals(Id) || default(TId).Equals(other.Id)) {
                return Equals(other._key, _key);
            }
            return other.Id.Equals(Id);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Entity<TId>)) return false;
            return Equals((Entity<TId>)obj);
        }
        public override int GetHashCode()
        {
            unchecked {
                if (default(TId).Equals(Id)) {
                    return Key.GetHashCode() * 397;
                }
                return Id.GetHashCode();
            }
        }
        public override string ToString()
        {
            return Key;
        }
        public static bool operator ==(Entity<TId> left, Entity<TId> right) {
            return Equals(left, right);
        }
        public static bool operator !=(Entity<TId> left, Entity<TId> right) {
            return !Equals(left, right);
        }
    }

    public static class KeyGenerator {
        public static string Generate() {
            return Generate(Guid.NewGuid().ToString("D").Substring(24));
        }
        public static string Generate(string input) {
            Contract.Requires(!string.IsNullOrWhiteSpace(input));
            return HttpUtility.UrlEncode(input.Replace(" ", "_").Replace("-", "_").Replace("&", "and"));
        }
    }
}
