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
var core_1 = require("@angular/core");
require("rxjs/Rx");
var tone_1 = require("../domain/tone");
var area_1 = require("../domain/area");
var tonetype_1 = require("../domain/tonetype");
var object_component_1 = require("./object.component");
var primeng_1 = require("primeng/primeng");
var tone_service_1 = require("../services/tone.service");
var area_service_1 = require("../services/area.service");
var tonetype_service_1 = require("../services/tonetype.service");
var angular2localization_1 = require('angular2localization/angular2localization');
var ToneComponent = (function (_super) {
    __extends(ToneComponent, _super);
    function ToneComponent(locale, localization, objectService, areaService, toneTypeService) {
        _super.call(this, locale, localization, objectService);
        this.title = "TONE";
        this.observableBatch.push(areaService.get());
        this.observableBatch.push(toneTypeService.get());
    }
    ToneComponent.prototype.new = function () {
        return new tone_1.Tone();
    };
    ToneComponent.prototype.loadItems = function (res) {
        var _this = this;
        _super.prototype.loadItems.call(this, res);
        var areas = res[1];
        this.areas = areas.map(function (area) { return ({ label: area.name, value: area.id }); });
        var toneTypes = res[2];
        this.toneTypes = toneTypes.map(function (toneType) { return ({ label: toneType.name, value: toneType.id }); });
        this.items.forEach(function (item) { return _this.setItem(item); });
    };
    ToneComponent.prototype.setItem = function (item) {
        item.area = this.getArea(item.areaId);
        item.toneType = this.getToneType(item.toneTypeId);
        return item;
    };
    ToneComponent.prototype.getArea = function (id) {
        return new area_1.Area(id, this.areas.filter(function (area) { return area.value === id; })[0].label);
    };
    ToneComponent.prototype.getToneType = function (id) {
        return new tonetype_1.ToneType(id, this.toneTypes.filter(function (toneType) { return toneType.value === id; })[0].label);
    };
    ToneComponent = __decorate([
        core_1.Component({
            selector: "d-tone",
            templateUrl: "app/components/tone.html",
            directives: [primeng_1.Button, primeng_1.Dialog, primeng_1.DataTable, primeng_1.Column, primeng_1.Header, primeng_1.Footer, primeng_1.InputText, primeng_1.Dropdown],
            providers: [tone_service_1.ToneService, area_service_1.AreaService, tonetype_service_1.ToneTypeService],
            pipes: [angular2localization_1.TranslatePipe]
        }), 
        __metadata('design:paramtypes', [angular2localization_1.LocaleService, angular2localization_1.LocalizationService, tone_service_1.ToneService, area_service_1.AreaService, tonetype_service_1.ToneTypeService])
    ], ToneComponent);
    return ToneComponent;
}(object_component_1.ObjectComponent));
exports.ToneComponent = ToneComponent;
//# sourceMappingURL=tone.component.js.map