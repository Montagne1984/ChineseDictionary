"use strict";
var Tone = (function () {
    function Tone(id, value, areaId, toneTypeId) {
        this.id = id;
        this.value = value;
        this.areaId = areaId;
        this.toneTypeId = toneTypeId;
    }
    Tone.prototype.extract = function (json) {
        this.id = json.Id;
        this.value = json.Value;
        this.areaId = json.AreaId;
        this.toneTypeId = json.ToneTypeId;
    };
    return Tone;
}());
exports.Tone = Tone;
//# sourceMappingURL=tone.js.map