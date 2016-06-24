import {Component} from "@angular/core";
import {Tone} from "../domain/tone";
import {Area} from "../domain/area";
import {ToneType} from "../domain/tonetype";
import {ObjectComponent} from "./object.component";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText, Dropdown, SelectItem} from "primeng/primeng";
import {ToneService} from "../services/tone.service"
import {AreaService} from "../services/area.service"
import {ToneTypeService} from "../services/tonetype.service"
import {LocaleService, LocalizationService, TranslatePipe} from 'angular2localization/angular2localization';

@Component({
    selector: "d-tone",
    templateUrl: "app/components/tone.html",
    directives: [Button, Dialog, DataTable, Column, Header, Footer, InputText, Dropdown],
    providers: [ToneService, AreaService, ToneTypeService],
    pipes: [TranslatePipe]
})
export class ToneComponent extends ObjectComponent<Tone> {
    title = "TONE";
    areas: SelectItem[];
    toneTypes: SelectItem[];

    constructor(locale: LocaleService, localization: LocalizationService, objectService: ToneService, protected areaService: AreaService, protected toneTypeService: ToneTypeService) {
        super(locale, localization, objectService);
    }

    ngOnInit() {
        super.ngOnInit();
        this.areas = [];
        this.areaService.get()
            .subscribe(
                areas => areas.forEach(area => this.areas.push({ label: area.name, value: area.id })),
                error => this.errorMessage = error);
        this.toneTypes = [];
        this.toneTypeService.get()
            .subscribe(
                toneTypes => toneTypes.forEach(toneType => this.toneTypes.push({ label: toneType.name, value: toneType.id })),
                error => this.errorMessage = error);
    }

    new(): Tone {
        return new Tone();
    }
}