"use strict";
var Observable_1 = require('rxjs/Observable');
var http_1 = require('@angular/http');
require('../rxjs-operators');
var ObjectService = (function () {
    function ObjectService(http) {
        this.http = http;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        this.options = new http_1.RequestOptions({ headers: this.headers });
    }
    ObjectService.prototype.get = function () {
        return this.http.get(this.url)
            .map(this.extractArray)
            .catch(this.handleError);
    };
    ObjectService.prototype.post = function (item) {
        var body = JSON.stringify(item);
        return this.http.post(this.url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    ObjectService.prototype.put = function (item) {
        var body = JSON.stringify(item);
        this.options.url = this.url + item["id"];
        return this.http.put(this.url + item["id"], body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    ObjectService.prototype.delete = function (item) {
        return this.http.delete(this.url + item["id"], this.options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    ObjectService.prototype.extractArray = function (res) {
        var _this = this;
        var items = [];
        res.json().forEach(function (item) { return items.push(_this.new().extract(item)); });
        return items;
    };
    ObjectService.prototype.extractData = function (res) {
        if (res.status === 204) {
            return null;
        }
        return this.new().extract(res.json());
    };
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