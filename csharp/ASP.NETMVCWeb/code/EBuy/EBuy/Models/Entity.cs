using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IdentityModel;
using EBuy.Utils;
using System.Security.Cryptography;

namespace EBuy.Models
{
    public abstract class Entity<TId>:IEntity,IEquatable<Entity<TId>> where TId:struct
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

        [StringLength(50)]
        public virtual string Key {
            get { return _key ?? GenerateKey(); }
            set { _key = value; }
        }

        protected string GenerateKey() {
            string key, iv;
            KeyGenerator.CreateSymmetricAlgorithmKey<TripleDESCryptoServiceProvider>(out key, out iv, 128);
            return key;
        }



        public bool Equals(Entity<TId> other)
        {
            return this.Key == other.Key;
        }
    }
}