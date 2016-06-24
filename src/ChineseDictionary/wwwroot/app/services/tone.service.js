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
var tone_1 = require('../domain/tone');
var object_service_1 = require('./object.service');
var ToneService = (function (_super) {
    __extends(ToneService, _super);
    function ToneService(http) {
        _super.call(this, http);
        this.url = 'api/tones/'; // URL to web api
    }
    ToneService.prototype.extractArray = function (res) {
        var items = [];
        res.json().forEach(function (item) { return items.push(new tone_1.Tone(item.Id, item.Value, item.Area, item.ToneType)); });
        return items;
    };
    ToneService.prototype.extractData = function (res) {
        if (res.status === 204) {
            return null;
        }
        var item = res.json();
        return new tone_1.Tone(item.Id, item.Value);
    };
    ToneService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], ToneService);
    return ToneService;
}(object_service_1.ObjectService));
exports.ToneService = ToneService;
//# sourceMappingURL=tone.service.js.map