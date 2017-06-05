using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Entities
{
    [ComplexType]
    public class CurrencyCode {
        private readonly string _value;
        public CurrencyCode() { 
            
        }
        public CurrencyCode(string value) : this() {
            _value = value;
        }
        //user-defined conversion from string to CurrencyCode
        public static implicit operator CurrencyCode(string code) {
            return new CurrencyCode(code);
        }
        //user-defined conversion from CurrencyCode to string
        public static implicit operator string(CurrencyCode code) {
            return code == null ? null : code._value;
        }
    }
    public class Currency:IEquatable<Currency>
    {
        public IDictionary<char, string> CurrencyCodesBySymbol = new Dictionary<Char, string>
        {
            {'€',"EUR"},{'￡',"GBP"},{'￥',"GPY"},{'$',"USD"}
        };
        public string Code { get; private set; }
        public virtual double Value { get;private set; }

        public Currency(CurrencyCode code, double value) {
            Code = code;
            Value = value;
        }
        public Currency() { 
        
        }
        public Currency(string currency) { 
            Contract.Requires(!string.IsNullOrWhiteSpace(currency));
            Contract.Requires(currency.Length > 1);
            Code = CurrencyCodesBySymbol[currency[0]];
            Value = double.Parse(currency.Substring(1));
        }

        public  bool Equals(Currency other)
       {
           if (ReferenceEquals(null, other)) return false;
          if (ReferenceEquals(this, other)) return true;
          return Equals(other.Code, Code) && other.Value == Value;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Currency)) return false;
            return Equals((Currency)obj);
        }
        /// <summary>
        /// 操作 +
        /// </summary>
        /// <param name="x"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Currency operator +(Currency x, double amount) {
            Contract.Requires(x != null);
            return new Currency(x.Code, x.Value + amount);
        }
        /// <summary>
        /// 操作 -
        /// </summary>
        /// <param name="x"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Currency operator -(Currency x, double amount) {
            Contract.Requires(x != null);
            return new Currency(x.Code, x.Value - amount);
        }
        /// <summary>
        /// 操作 ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Currency left, Currency right) {
            return Equals(left, right);
        }
        /// <summary>
        /// 操作 !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Currency left, Currency right) {
            return !Equals(left, right);
        }
        /// <summary>
        /// 操作： 隐式转换,string to Currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static implicit operator Currency(string currency) {
            return new Currency(currency);
        }
        /// <summary>
        /// 操作：隐式转换,Currency to string
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static implicit operator string(Currency currency) {
            return currency.ToString();
        }
        public override string ToString()
        {
            var symbol = CurrencyCodesBySymbol.Single(x => x.Value == Code).Key;
            return string.Format("{0}{1:N2}", symbol, Value);
        }
        public override int GetHashCode()
        {
            unchecked {
                return ((Code != null ? Code.GetHashCode() : 0) * 397) ^ Value.GetHashCode();
            }

        }
       
    }
}
