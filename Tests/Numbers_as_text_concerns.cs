using System;
using System.Collections.Generic;
using System.Text;
using NumberRepresentation;
using NUnit;
using NUnit.Framework;

namespace Numbers_as_text_concerns
{

    public class Given_numbers_up_to_twentynine
    {
        private void AssertRangeOfNumbers(string prefix, uint offset)
        {
            var prefixWithSpace = prefix + " ";
            Assert.AreEqual(prefix.Trim(), Numbers.AsText(offset));
            Assert.AreEqual(prefixWithSpace + "one", Numbers.AsText(offset + 1));
            Assert.AreEqual(prefixWithSpace + "two", Numbers.AsText(offset + 2));
            Assert.AreEqual(prefixWithSpace + "three", Numbers.AsText(offset + 3));
            Assert.AreEqual(prefixWithSpace + "four", Numbers.AsText(offset + 4));
            Assert.AreEqual(prefixWithSpace + "five", Numbers.AsText(offset + 5));
            Assert.AreEqual(prefixWithSpace + "six", Numbers.AsText(offset + 6));
            Assert.AreEqual(prefixWithSpace + "seven", Numbers.AsText(offset + 7));
            Assert.AreEqual(prefixWithSpace + "eight", Numbers.AsText(offset + 8));
            Assert.AreEqual(prefixWithSpace + "nine", Numbers.AsText(offset + 9));
        }

        [Test]
        public void it_should_give_me_a_zero()
        {
            Assert.AreEqual("zero", Numbers.AsText(0));
        }

        [Test]
        public void it_should_give_me_numbers_one_to_nine()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("one", Numbers.AsText(1));
                Assert.AreEqual("two", Numbers.AsText(2));
                Assert.AreEqual("three", Numbers.AsText(3));
                Assert.AreEqual("four", Numbers.AsText(4));
                Assert.AreEqual("five", Numbers.AsText(5));
                Assert.AreEqual("six", Numbers.AsText(6));
                Assert.AreEqual("seven", Numbers.AsText(7));
                Assert.AreEqual("eight", Numbers.AsText(8));
                Assert.AreEqual("nine", Numbers.AsText(9));
            });
        }

        [Test]
        public void it_should_give_me_numbers_ten_to_nineteen()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("ten", Numbers.AsText(10));
                Assert.AreEqual("eleven", Numbers.AsText(11));
                Assert.AreEqual("twelve", Numbers.AsText(12));
                Assert.AreEqual("thirteen", Numbers.AsText(13));
                Assert.AreEqual("fourteen", Numbers.AsText(14));
                Assert.AreEqual("fifteen", Numbers.AsText(15));
                Assert.AreEqual("sixteen", Numbers.AsText(16));
                Assert.AreEqual("seventeen", Numbers.AsText(17));
                Assert.AreEqual("eighteen", Numbers.AsText(18));
                Assert.AreEqual("nineteen", Numbers.AsText(19));
            });
        }

        [Test]
        public void it_should_give_me_numbers_twenty_to_ninty_nine()
        {
            Assert.Multiple(() =>
            {
                AssertRangeOfNumbers("twenty", 20u);
                AssertRangeOfNumbers("thirty", 30u);
                AssertRangeOfNumbers("forty", 40u);
                AssertRangeOfNumbers("fifty", 50u);
                AssertRangeOfNumbers("sixty", 60u);
                AssertRangeOfNumbers("seventy", 70u);
                AssertRangeOfNumbers("eighty", 80u);
                AssertRangeOfNumbers("ninety", 90u);
            });
        }

        [Test]
        public void it_should_give_me_numbers_one_hundred_to_nine_hundred_and_ninty_nine()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("one hundred", Numbers.AsText(100));
                Assert.AreEqual("one hundred and one", Numbers.AsText(101));

                Assert.AreEqual("two hundred", Numbers.AsText(200));
                Assert.AreEqual("two hundred and one", Numbers.AsText(201));

                Assert.AreEqual("nine hundred and ninety nine", Numbers.AsText(999));
            });
        }

        [Test]
        public void it_should_give_me_one_thousand()
        {
            Assert.AreEqual("one thousand", Numbers.AsText(1000));
        }

        [Test]
        public void it_should_give_me_numbers_greater_than_one_thousand()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("one thousand and one", Numbers.AsText(1001));
                Assert.AreEqual("one thousand and nineteen", Numbers.AsText(1019));
                Assert.AreEqual("one thousand and fifty six", Numbers.AsText(1056));
                Assert.AreEqual("one thousand one hundred and one", Numbers.AsText(1101));
                Assert.AreEqual("one thousand one hundred and nineteen", Numbers.AsText(1119));
                Assert.AreEqual("nine thousand nine hundred and ninety nine", Numbers.AsText(9999));
            });
            
        }


        [Test]
        public void it_should_give_me_numbers_greater_than_9999()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("ten thousand", Numbers.AsText(10000));
                Assert.AreEqual("ninety nine thousand nine hundred and ninety nine", Numbers.AsText(99999));
                Assert.AreEqual("one hundred thousand", Numbers.AsText(100000));
                Assert.AreEqual("nine hundred and ninety nine thousand nine hundred and ninety nine", Numbers.AsText(999999));

                Assert.AreEqual("one million", Numbers.AsText((uint)1e6));
            });

        }
    }


}
