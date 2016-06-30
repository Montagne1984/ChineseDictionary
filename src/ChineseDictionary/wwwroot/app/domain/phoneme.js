"use strict";
var Phoneme = (function () {
    function Phoneme(id, symbol) {
        this.id = id;
        this.symbol = symbol;
    }
    Phoneme.prototype.extract = function (json) {
        this.id = json.Id;
        this.symbol = json.Symbol;
    };
    return Phoneme;
}());
exports.Phoneme = Phoneme;
//# sourceMappingURL=phoneme.js.map