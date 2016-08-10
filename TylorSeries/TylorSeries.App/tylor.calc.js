/**
 * @author Thomas Erni
 * @version 1.0
 */
function TylorCalculator() {
    var self = this;
    
    /**
     * @description Tylor-Reihe von ln(x+1) = SUM[v=1 --> ∞] => ((-1)^v+1 / v) * x^v
     * @link http://www.math.tu-dresden.de/~ganter/inf2005/folien/Taylor2.pdf
     */
    self.getTylorValue = function (x, v) {
        var dividend =  Math.pow((-1), v + 1); // (-1)^v+1 => a
        var divisor = v; // / v => b
        var multiplier = Math.pow(x, v); // * x^v => c

        var result = (dividend / divisor) * multiplier; //  a / b * c = r

        return result; // Punkt v innerhalb der Reihe für ln(x+1)
    }

    /**
     * Führt n iterationen durch und berechnet für jeden Punkt den Wert der Tylor-Reihe ln(x+1).
     */
    self.getTylorResult = function (x, iterationsToPerform) {
        var result = 0; // Näherungslösung / Approximation
        var series = []; // kann genutzt werden um ein Chart darzustellen

        // Per definition v = 1
        for (var v = 1; v < iterationsToPerform + 1; v++) {
            var val = self.getTylorValue(x, v);

            result += val;

            series.push(val);
        }

        return result;
    }
}

/**
 * @author Thomas Erni
 * @version 1.0
 */
function TylorCalculatorPerf() {
    var self = this;

    // self.tylorCalculator.getTylorResult(1, 50);
    // self.tylorCalculator.getTylorResult(1, parseInt(self.iterationsToPerform()));
    self.getTylorResult = function (x, iterationsToPerform) {
        var result = 0;
        var itp = iterationsToPerform + 1;
        
        for (var v = 1; v < itp; v++) {
            result += (Math.pow((-1), v + 1) / v) * Math.exp(Math.log(x) * v);
        }

        // container-object
        return result;
    }
}

/**
 * @author Thomas Erni
 * @version 1.0
 */
function TylorCalculatorPerf_2() {
    var self = this;

    // self.tylorCalculator.getTylorResult(1, 50);
    // self.tylorCalculator.getTylorResult(1, parseInt(self.iterationsToPerform()));
    self.getTylorResult = function (x, itp) {
        var result = 0;
        itp += 1;

        while (--itp) {
            result += (Math.pow((-1), itp + 1) / itp) * Math.exp(Math.log(x) * itp);
        }

        // container-object
        return result;
    }
}