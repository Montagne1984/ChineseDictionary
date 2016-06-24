import {Component} from "@angular/core";
import {ToneType} from "../domain/tonetype";
import {ObjectComponent} from "./object.component";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText} from "primeng/primeng";
import {ToneTypeService} from "../services/tonetype.service"
import {LocaleService, LocalizationService, TranslatePipe} from 'angular2localization/angular2localization';

@Component({
    selector: "d-toneType",
    templateUrl: "app/components/tonetype.html",
    directives: [Button, Dialog, DataTable, Column, Header, Footer, InputText],
    providers: [ToneTypeService],
    pipes: [TranslatePipe]
})
export class ToneTypeComponent extends ObjectComponent<ToneType> {
    title = "TONETYPE";

    constructor(locale: LocaleService, localization: LocalizationService, objectService: ToneTypeService) {
        super(locale, localization, objectService);
    }
    new(): ToneType {
        return new ToneType();
    }
}