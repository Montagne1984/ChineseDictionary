"use strict";
var ObjectService = (function () {
    function ObjectService() {
    }
    ObjectService.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    return ObjectService;
}());
exports.ObjectService = ObjectService;
//# sourceMappingURL=object.service.js.map