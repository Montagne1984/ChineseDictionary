"use strict";
var Area = (function () {
    function Area(id, name) {
        this.id = id;
        this.name = name;
        this.tones = [];
    }
    Area.extract = function (json) {
        return new Area();
    };
    Area.prototype.extract = function (json) {
        this.id = json.Id;
        this.name = json.Name;
    };
    return Area;
}());
exports.Area = Area;
//# sourceMappingURL=area.js.map