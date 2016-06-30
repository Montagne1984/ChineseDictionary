"use strict";
var ToneType = (function () {
    function ToneType(id, name) {
        this.id = id;
        this.name = name;
    }
    ToneType.prototype.extract = function (json) {
        this.id = json.Id;
        this.name = json.Name;
    };
    return ToneType;
}());
exports.ToneType = ToneType;
//# sourceMappingURL=tonetype.js.map