"use strict";
var Observable_1 = require('rxjs/Observable');
var http_1 = require('@angular/http');
var ObjectService = (function () {
    function ObjectService() {
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        this.options = new http_1.RequestOptions({ headers: this.headers });
    }
    ObjectService.prototype.handleError = function (error) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        var errMsg = (error.message) ? error.message :
            error.status ? error.status + " - " + error.statusText : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable_1.Observable.throw(errMsg);
    };
    return ObjectService;
}());
exports.ObjectService = ObjectService;
//# sourceMappingURL=object.service.js.map