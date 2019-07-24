using System;

namespace NumberRepresentation
{
    public struct Conditional<T1, T2>
    {
        public Func<T1, bool> Condition { get; set; }

        public Func<T1, T2> Consequence { get; set; }
    }
}
