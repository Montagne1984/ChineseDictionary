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
var tone_1 = require("../domain/tone");
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
        this.areaService = areaService;
        this.toneTypeService = toneTypeService;
        this.title = "TONE";
    }
    ToneComponent.prototype.ngOnInit = function () {
        var _this = this;
        _super.prototype.ngOnInit.call(this);
        this.areas = [];
        this.areaService.get()
            .subscribe(function (areas) { return areas.forEach(function (area) { return _this.areas.push({ label: area.name, value: area.id }); }); }, function (error) { return _this.errorMessage = error; });
        this.toneTypes = [];
        this.toneTypeService.get()
            .subscribe(function (toneTypes) { return toneTypes.forEach(function (toneType) { return _this.toneTypes.push({ label: toneType.name, value: toneType.id }); }); }, function (error) { return _this.errorMessage = error; });
    };
    ToneComponent.prototype.new = function () {
        return new tone_1.Tone();
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