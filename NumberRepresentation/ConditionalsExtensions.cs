using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberRepresentation
{
    public static class ConditionalsExtensions
    {
        public static T2 InvokeOne<T1, T2>(this IEnumerable<Conditional<T1, T2>> sequence, T1 parameter)
        {
            try
            {
                var choice = sequence.First(x => x.Condition(parameter));
                return choice.Consequence.Invoke(parameter);
            }
            catch (InvalidOperationException)
            {
                return default(T2);
            }
        }
    }
}
