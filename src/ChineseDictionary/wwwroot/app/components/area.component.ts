import {Component} from "@angular/core";
import {Area} from "../domain/area";
import {ObjectComponent} from "./object.component";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText} from "primeng/primeng";
import {AreaService} from "../services/area.service"
import {LocaleService, LocalizationService, TranslatePipe} from 'angular2localization/angular2localization';

@Component({
    selector: "d-area",
    templateUrl: "app/components/area.html",
    directives: [Button, Dialog, DataTable, Column, Header, Footer, InputText],
    providers: [AreaService],
    pipes: [TranslatePipe]
})
export class AreaComponent extends ObjectComponent<Area> {
    title = "AREA";

    constructor(locale: LocaleService, localization: LocalizationService, objectService: AreaService) {
        super(locale, localization, objectService);
    }
    new(): Area {
        return new Area();
    }
}