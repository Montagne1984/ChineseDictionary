"use strict";
var IPAPhoneme = (function () {
    function IPAPhoneme(id, symbol) {
        this.id = id;
        this.symbol = symbol;
    }
    IPAPhoneme.prototype.extract = function (json) {
        this.id = json.Id;
        this.symbol = json.Symbol;
    };
    return IPAPhoneme;
}());
exports.IPAPhoneme = IPAPhoneme;
//# sourceMappingURL=ipaphoneme.js.map