using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Common.Search
{
    public class NumberCriteria<T>
        where T : IComparable<T>
    {
        public T Value { get; set; } = default!;
        public T? Value2 { get; set; }
        public Operator Operator { get; set; }

        public NumberCriteria()
        {
            Operator = Operator.Equal;
        }

        /// <summary>
        /// Instanciate a lower than criteria
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static NumberCriteria<T> LowerStrict(T value)
        {
            return new NumberCriteria<T>()
            {
                Value = value,
                Operator = Operator.LowerStrict,
            };
        }

        /// <summary>
        /// Instanciate a lower or equal than criteria
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static NumberCriteria<T> LowerOrEqualThan(T value)
        {
            return new NumberCriteria<T>()
            {
                Value = value,
                Operator = Operator.LowerOrEqual,
            };
        }

        /// <summary>
        /// Instanciate an equal criteria
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static NumberCriteria<T> Equal(T value)
        {
            return new NumberCriteria<T>()
            {
                Value = value,
                Operator = Operator.Equal,
            };
        }

        /// <summary>
        /// Instanciate a greater than criteria
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static NumberCriteria<T> GreaterThan(T value)
        {
            return new NumberCriteria<T>()
            {
                Value = value,
                Operator = Operator.GreaterStrict,
            };
        }

        /// <summary>
        /// Instanciate a greater or equal than criteria
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static NumberCriteria<T> GreaterOrEqualThan(T value)
        {
            return new NumberCriteria<T>()
            {
                Value = value,
                Operator = Operator.GreaterOrEqual,
            };
        }

        /// <summary>
        /// Instanciate a greater or equal than criteria
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static NumberCriteria<T> Between(T value, T value2)
        {
            if (value.CompareTo(value2) > 0)
                throw new ArgumentException($"{value} is greater than {value2}");

            return new NumberCriteria<T>()
            {
                Value = value,
                Value2 = value2,
                Operator = Operator.Between,
            };
        }
    }

    /// <summary>
    /// Type of operator
    /// </summary>
    public enum Operator
    {
        LowerStrict,
        LowerOrEqual,
        Equal,
        GreaterStrict,
        GreaterOrEqual,
        Between,
    }
}
