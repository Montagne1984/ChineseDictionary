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
var ipavowel_1 = require("../domain/ipavowel");
var object_component_1 = require("./object.component");
var primeng_1 = require("primeng/primeng");
var ipavowel_service_1 = require("../services/ipavowel.service");
var angular2localization_1 = require('angular2localization/angular2localization');
var IPAVowelComponent = (function (_super) {
    __extends(IPAVowelComponent, _super);
    function IPAVowelComponent(locale, localization, objectService) {
        _super.call(this, locale, localization, objectService);
        this.title = "IPAVOWEL";
    }
    IPAVowelComponent.prototype.new = function () {
        return new ipavowel_1.IPAVowel();
    };
    IPAVowelComponent = __decorate([
        core_1.Component({
            selector: "d-ipaPhoneme",
            templateUrl: "app/components/ipaphoneme.html",
            directives: [primeng_1.Button, primeng_1.Dialog, primeng_1.DataTable, primeng_1.Column, primeng_1.Header, primeng_1.Footer, primeng_1.InputText],
            providers: [ipavowel_service_1.IPAVowelService],
            pipes: [angular2localization_1.TranslatePipe]
        }), 
        __metadata('design:paramtypes', [angular2localization_1.LocaleService, angular2localization_1.LocalizationService, ipavowel_service_1.IPAVowelService])
    ], IPAVowelComponent);
    return IPAVowelComponent;
}(object_component_1.ObjectComponent));
exports.IPAVowelComponent = IPAVowelComponent;
//# sourceMappingURL=ipavowel.component.js.map