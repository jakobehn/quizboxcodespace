/// <reference path="scripts/typings/jasmine/jasmine.d.ts"/>
/// <reference path="../QBox.ClientJS/calculator.ts"/>
describe('calculator tests', function () {
    it('adds numbers', function () {
        var calc = new calculator();
        var result = calc.add(5, 4);
        expect(result).toBe(9);
    });
});
//# sourceMappingURL=calculatortests.js.map