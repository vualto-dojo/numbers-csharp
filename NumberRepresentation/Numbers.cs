using System;

namespace NumberRepresentation
{
    public class Numbers
    {
        private static readonly Func<uint, string> Ones = number =>
        {
            var words = new[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            return words[number];
        };

        private static readonly Func<uint, string> Teens = number =>
        {
            var words = new[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            return words[number-10];
        };

        private static readonly Func<uint, string> Tens = number =>
        {
            var words = new[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            return words[Math.Max((number / 10) - 2, 0)];
        };

        private static readonly Func<uint, string> Hundred = number =>
        {
            return Ones(number / 100) + " hundred";
        };

        private static readonly Func<uint, string> Thousand = number =>
        {
            return AsText(number / 1000) + " thousand";
        };

        private static readonly Func<uint, string> Million = number =>
        {
            return AsText(number / (uint)1e6) + " million";
        };

        private static Func<uint, string> Remainder(uint scale, Func<uint, string> fn)
        {
            return x => fn(x % scale);
        }

        private static Func<uint, string> Compound(Func<uint, string> fn1, string join, Func<uint, string> fn2)
        {
            return x => fn1(x) + join + fn2(x);
        }

        private static readonly Conditional<uint, string>[] Rules = new []
        {
            new Conditional<uint, string> { Condition = x => x == 0, Consequence = x => "zero" },
            new Conditional<uint, string> { Condition = x => x <= 9, Consequence = Ones },
            new Conditional<uint, string> { Condition = x => x <= 19, Consequence = Teens },
            new Conditional<uint, string> { Condition = x => x <= 99, Consequence = Compound(Tens, " ", Remainder(10, Ones)) },
            new Conditional<uint, string> { Condition = x => x < 1000 && x % 100 == 0, Consequence = Hundred },
            new Conditional<uint, string> { Condition = x => x <= 999, Consequence = Compound(Hundred, " and ", Remainder(100, AsText)) },
            new Conditional<uint, string> { Condition = x => x < 1e6 && x % 1000 == 0, Consequence = Thousand },
            new Conditional<uint, string> { Condition = x => x < 1e6 && x % 1000 < 99, Consequence = Compound(Thousand, " and ", Remainder(1000, AsText)) },
            new Conditional<uint, string> { Condition = x => x <= 999999, Consequence = Compound(Thousand, " ", Remainder(1000, AsText)) },
            new Conditional<uint, string> { Condition = x => x < 1e7 && x % 1e6 == 0, Consequence = Million },
            new Conditional<uint, string> { Condition = x => true, Consequence = x => string.Empty }
        };

        public static string AsText(uint n)
        {
            return Rules.InvokeOne(n).Trim();
        }
    }
}
