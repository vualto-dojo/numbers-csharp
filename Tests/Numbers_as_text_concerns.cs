using System;
using System.Collections.Generic;
using System.Text;
using NumberRepresentation;
using NUnit;
using NUnit.Framework;

namespace Numbers_as_text_concerns
{

    public class Given_numbers_up_to_nine
    {
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
    }

    
}
