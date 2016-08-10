using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorSeries.Logic
{
    public class TylorCalculator
    {
        /// <summary>
        /// Punkt innerhalb der Tylor-Reihe von ln(x+1).
        /// </summary>
        /// <remarks>
        /// Funktionsaufrufe sind langsam. Daher wird die Berechnung direkt im Code durcheführt.
        /// Ausserdem ist die Schritt-für-Schritt Berechnung auch langsam, daher wird eine
        /// schnellere Variante gewählt.
        /// </remarks>
        /// <see cref="http://www.math.tu-dresden.de/~ganter/inf2005/folien/Taylor2.pdf"/>
        /// <param name="x"></param>
        /// <param name="v">iterationsToPerform</param>
        /// <returns></returns>
        public float getTylorValueStepByStep(int x, int v) {

            if (v == 0) {
                throw new Exception("v can't be 0!");
            }

            var dividend = (float) Math.Pow((-1), v + 1); // (-1)^v+1 => a
            var divisor = (float) v; // / v => b
            var multiplier = (float)Math.Pow(x, v); // * x^v => c

            //  a / b * c = r
            return (dividend / divisor) * multiplier; // Punkt v innerhalb der Reihe für ln(x+1)
        }

        public double getTylorValue(int x, int v)
        {
            return (Math.Pow((-1), v + 1) / v) * Math.Exp(Math.Log(x) * v);
        }

        /// <summary>
        /// Tylor-Reihe von ln(x+1) = SUM[v=1 --> ∞] => ((-1)^v+1 / v) * x^v.
        /// Summiert die Tylor-Punkte.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="iterationsToPerform">v</param>
        /// <returns></returns>
        public double getTylorResult(int x, int iterationsToPerform) {
            double result = 0;

            for (int v = 1; v < iterationsToPerform + 1; v++)
            {
                result += (Math.Pow((-1), v + 1) / v) * Math.Exp(Math.Log(x) * v);
            }

            return result;
        }

        /// <summary>
        /// Tylor-Reihe von ln(x+1) = SUM[v=1 --> ∞] => ((-1)^v+1 / v) * x^v.
        /// Summiert die Tylor-Punkte.
        /// </summary>
        /// <remarks>
        /// Schneller, da vergleiche mit 0 schneller sind und ein check pro iteration weniger als im for loop nötig ist.
        /// </remarks>
        /// <param name="x"></param>
        /// <param name="v">Iterations to perform</param>
        /// <returns></returns>
        public double getTylorResultReverse(int x, int v)
        {
            double result = 0;

            v += 1; // decreasing operator!

            while (--v != 0)
            {
                result += (Math.Pow((-1), v + 1) / v) * Math.Exp(Math.Log(x) * v);
            }

            return result;
        }

        /// <summary>
        /// Tylor-Reihe von ln(x+1) = SUM[v=1 --> ∞] => ((-1)^v+1 / v) * x^v.
        /// Summiert die Tylor-Punkte.
        /// </summary>
        /// <remarks>
        /// Schneller, da vergleiche mit 0 schneller sind und ein check pro iteration weniger als im for loop nötig ist.
        /// </remarks>
        /// <param name="x"></param>
        /// <param name="v">Iterations to perform</param>
        /// <returns></returns>
        public double getTylorResultReverseDivideAndConquer(int x, int end, int v)
        {
            double result = 0;

            v += 1; // decreasing operator!

            while (--v != end)
            {
                result += (Math.Pow((-1), v + 1) / v) * Math.Exp(Math.Log(x) * v);
            }

            return result;
        }
    }
}
