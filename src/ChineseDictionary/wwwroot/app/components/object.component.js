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
var Observable_1 = require("rxjs/Observable");
require("rxjs/Rx");
var angular2localization_1 = require("angular2localization/angular2localization");
var object_service_1 = require("../services/object.service");
var ObjectComponent = (function (_super) {
    __extends(ObjectComponent, _super);
    function ObjectComponent(locale, localization, objectService) {
        _super.call(this, locale, localization);
        this.locale = locale;
        this.localization = localization;
        this.objectService = objectService;
        this.item = this.new();
        // Adds a new language (ISO 639 two-letter or three-letter code).
        this.locale.addLanguage("zh");
        // Add a new language here.
        // Required: default language, country (ISO 3166 two-letter, uppercase code) and expiry (No days). If the expiry is omitted, the cookie becomes a session cookie.
        this.locale.definePreferredLocale("zh", 'CN', 30);
        // Optional: default currency (ISO 4217 three-letter code).
        this.locale.definePreferredCurrency("CNY");
        this.localization.translationProvider("./resources/locale.");
        this.localization.updateTranslation(); // Need to update the translation.
        this.observableBatch = [objectService.get()];
    }
    ObjectComponent.prototype.ngOnInit = function () {
        var _this = this;
        Observable_1.Observable.forkJoin(this.observableBatch).subscribe(function (res) { return _this.loadItems(res); }, function (error) { return _this.errorMessage = error; });
    };
    ObjectComponent.prototype.showDialogToAdd = function () {
        this.newItem = true;
        this.item = this.new();
        this.displayDialog = true;
    };
    ObjectComponent.prototype.save = function () {
        var _this = this;
        if (this.newItem) {
            this.objectService.post(this.item)
                .subscribe(function (item) { return _this.items.push(item); }, function (error) { return _this.errorMessage = error; });
        }
        else {
            var item_1 = this.cloneItem(this.item);
            this.objectService.put(item_1)
                .subscribe(function () { return _this.items[_this.findSelectedItemIndex()] = _this.setItem(item_1); }, function (error) { return _this.errorMessage = error; });
        }
        this.item = null;
        this.displayDialog = false;
    };
    ObjectComponent.prototype.delete = function () {
        var _this = this;
        this.objectService.delete(this.item)
            .subscribe(function () {
            _this.items.splice(_this.findSelectedItemIndex(), 1);
            _this.item = null;
            _this.displayDialog = false;
        }, function (error) { return _this.errorMessage = error; });
    };
    ObjectComponent.prototype.onRowSelect = function (event) {
        this.newItem = false;
        this.item = this.cloneItem(event.data);
        this.displayDialog = true;
    };
    ObjectComponent.prototype.cloneItem = function (i) {
        var item = this.new();
        for (var prop in i) {
            item[prop] = i[prop];
        }
        return item;
    };
    ObjectComponent.prototype.findSelectedItemIndex = function () {
        return this.items.indexOf(this.selectedItem);
    };
    ObjectComponent.prototype.loadItems = function (res) {
        this.items = res[0];
    };
    ObjectComponent.prototype.setItem = function (item) {
        return item;
    };
    ObjectComponent = __decorate([
        core_1.Component({
            providers: [
                angular2localization_1.LocaleService,
                angular2localization_1.LocalizationService
            ],
            pipes: [angular2localization_1.TranslatePipe]
        }), 
        __metadata('design:paramtypes', [angular2localization_1.LocaleService, angular2localization_1.LocalizationService, object_service_1.ObjectService])
    ], ObjectComponent);
    return ObjectComponent;
}(angular2localization_1.Locale));
exports.ObjectComponent = ObjectComponent;
//# sourceMappingURL=object.component.js.map