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
var consonant_1 = require('../domain/consonant');
var object_service_1 = require('./object.service');
var ConsonantService = (function (_super) {
    __extends(ConsonantService, _super);
    function ConsonantService(http) {
        _super.call(this, http);
        this.url = 'api/consonants/'; // URL to web api
    }
    ConsonantService.prototype.extractArray = function (res) {
        var items = [];
        res.json().forEach(function (item) { return items.push(new consonant_1.Consonant(item.Id, item.Symbol)); });
        return items;
    };
    ConsonantService.prototype.extractData = function (res) {
        if (res.status === 204) {
            return null;
        }
        var item = res.json();
        return new consonant_1.Consonant(item.Id, item.Symbol);
    };
    ConsonantService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], ConsonantService);
    return ConsonantService;
}(object_service_1.ObjectService));
exports.ConsonantService = ConsonantService;
//# sourceMappingURL=consonant.service.js.map