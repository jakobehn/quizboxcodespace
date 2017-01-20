/// <reference path="../scripts/typings/jasmine/jasmine.d.ts"/>
/// <reference path="../../QBox.ClientJS/calculator.ts"/>

describe('calculator should', () => {
    it('add numbers', () => {
        var calc = new calculator();
        var result = calc.add(5, 4);

        expect(result).toBe(9);
    });

    it('subtract numbers', () => {
        var calc = new calculator();
        var result = calc.sub(5, 4);

        expect(result).toBe(1);
    });

    it('multiply numbers', () => {
        var calc = new calculator();
        var result = calc.multiply(5, 4);

        expect(result).toBe(20);
    });

    it('divide numbers', () => {
        var calc = new calculator();
        var result = calc.divide(12, 3);

        expect(result).toBe(4);
    });
});
