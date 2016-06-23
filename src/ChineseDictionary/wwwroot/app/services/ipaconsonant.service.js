"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
var ipaconsonant_1 = require('../domain/ipaconsonant');
var object_service_1 = require('./object.service');
require('../rxjs-operators');
var IPAConsonantService = (function (_super) {
    __extends(IPAConsonantService, _super);
    function IPAConsonantService(http) {
        _super.call(this);
        this.http = http;
        this.url = 'api/ipaconsonants/'; // URL to web api
    }
    IPAConsonantService.prototype.get = function () {
        return this.http.get(this.url)
            .map(this.extractArray)
            .catch(this.handleError);
    };
    IPAConsonantService.prototype.post = function (item) {
        var body = JSON.stringify(item);
        return this.http.post(this.url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    IPAConsonantService.prototype.put = function (item) {
        var body = JSON.stringify(item);
        this.options.url = this.url + item.id;
        return this.http.put(this.url + item.id, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    IPAConsonantService.prototype.delete = function (item) {
        return this.http.delete(this.url + item.id, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    IPAConsonantService.prototype.extractArray = function (res) {
        var items = [];
        res.json().forEach(function (item) { return items.push(new ipaconsonant_1.IPAConsonant(item.Id, item.Symbol)); });
        return items;
    };
    IPAConsonantService.prototype.extractData = function (res) {
        if (res.status === 204) {
            return null;
        }
        var item = res.json();
        return new ipaconsonant_1.IPAConsonant(item.Id, item.Symbol);
    };
    IPAConsonantService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], IPAConsonantService);
    return IPAConsonantService;
}(object_service_1.ObjectService));
exports.IPAConsonantService = IPAConsonantService;
//# sourceMappingURL=ipaconsonant.service.js.map