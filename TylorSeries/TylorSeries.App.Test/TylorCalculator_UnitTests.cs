using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TylorSeries.Logic;

namespace TylorSeries.App.Test
{
    [TestClass]
    public class TylorCalculator_UnitTests
    {
        private TylorCalculator calculator;

        [TestInitialize]
        public void TearUp() {
            this.calculator = new TylorCalculator();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TylorValueStepByStep_ShouldThrowException_WhenGivenVIsZero()
        {
            this.calculator.getTylorValueStepByStep(1, 0);
        }

        /// <summary>
        /// No iterations should be performed!
        /// </summary>
        [TestMethod]
        public void TylorResult_ShouldReturnZero_WhenGivenVIsZero()
        {
            var result = this.calculator.getTylorResult(0, 0);

            Assert.AreEqual(0f, result);
        }

        /// <summary>
        /// Da die Werte in einer anderen Reihenfolge gerundet werden, sind die Teilsummen unterschiedlich was ein
        /// anderes gerundetes Endresultat zur Folge hat!
        /// </summary>
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TylorResultReverse_ShouldNotBeTheSame_WhenTylorResultIsUsed()
        {
            var ra = this.calculator.getTylorResult(1, 100);
            var rb = this.calculator.getTylorResultReverse(1, 100);

            Assert.AreNotEqual(ra, rb);
        }
    }
}
