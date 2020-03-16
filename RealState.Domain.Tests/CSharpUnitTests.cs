using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealState.Model.Sale;
using System.Collections.Generic;
using System.Linq;

namespace RealState.Domain.Tests
{
    [TestClass]
    public class CSharpUnitTests
    {
        #region Properties
        public bool MetIfCondition { get; set; }
        #endregion Properties

        #region Tests

        #region Null Conditional
        [TestMethod]
        public void CSharpNullConditionalFalseEqual()
        {
            List<int> primes = null;

            if (primes?.Count == 0)
                MetIfCondition = true;

            Assert.IsFalse(MetIfCondition);
        }

        [TestMethod]
        public void CSharpNullConditionalFalseGreaterThan()
        {
            List<int> primes = null;

            if (primes?.Count > 0)
                MetIfCondition = true;

            Assert.IsFalse(MetIfCondition);
        }

        [TestMethod]
        public void CSharpNullConditionalTrueNonEmpty()
        {
            var primes = GetPrimeNumbers(13);

            if (primes?.Count > 0)
                MetIfCondition = true;

            Assert.IsTrue(MetIfCondition);
        }

        [TestMethod]
        public void CSharpNullConditionalTrueEmpty()
        {
            var primes = GetPrimeNumbers(0);

            if (primes?.Count > 0)
                MetIfCondition = true;

            Assert.IsFalse(MetIfCondition);
        }


        [TestMethod]
        public void CSharpNullCondition()
        {
            bool? condition = null;

            if (condition.Value)
                MetIfCondition = true;

            Assert.IsFalse(MetIfCondition);
        }
        #endregion Null Conditional

        #region Null Coalescing
        [TestMethod]
        public void CSharpNullCoalescing()
        {
            const string unknown = "[unknown]";
            var dude = new Customer("Pipe", null);
            var surname = dude.FirstSurname ?? unknown;

            Assert.AreEqual(surname, unknown);
        }
        #endregion Null Coalescing

        #region Nullable Bool
        [TestMethod]
        public void CSharpNullableBoolConditionTrue()
        {
            bool? condition = true;

            if (condition ?? false)
                MetIfCondition = true;

            Assert.IsTrue(MetIfCondition);
        }

        [TestMethod]
        public void CSharpNullableBoolConditionNull()
        {
            bool? condition = null;

            if (condition ?? false)
                MetIfCondition = true;

            Assert.IsFalse(MetIfCondition);
        }
        #endregion Nullable Bool

        #region Ternary Operator
        [TestMethod]
        public void CSharpTernaryOperatorSimple()
        {
            var value1 = true ? "hello world" : "0";
            var value2 = false ? "1" : "hello world";

            Assert.AreEqual(value1, value2);
        }

        [TestMethod]
        public void CSharpTernaryOperatorRightEvaluation()
        {
            var a = true;
            var b = 2;
            var c = true;
            var d = 4;
            var e = 5;

            var result1 = a ? b : c ? d : e;
            var result2 = a ? b : (c ? d : e); //It's evaluated from right to left

            Assert.AreEqual(result1, result2);
        }
        #endregion Ternary Operator

        #endregion Tests

        #region Private Members
        private void Initialize()
        {
            MetIfCondition = false;
        }

        private List<int> GetPrimeNumbers(int howMany)
        {
            var primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 };
            return primes.Take(howMany).ToList();
        }
        #endregion Private Members
    }
}
