import {Component} from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/Rx";
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

    constructor(locale: LocaleService, localization: LocalizationService, objectService: ToneService, areaService: AreaService, toneTypeService: ToneTypeService) {
        super(locale, localization, objectService);
        this.observableBatch.push(areaService.get());
        this.observableBatch.push(toneTypeService.get());
    }

    new(): Tone {
        return new Tone();
    }

    loadItems(res) {
        super.loadItems(res);
        let areas = res[1];
        this.areas = areas.map(area => ({ label: area.name, value: area.id }));
        let toneTypes = res[2];
        this.toneTypes = toneTypes.map(toneType => ({ label: toneType.name, value: toneType.id }));
        this.items.forEach(item => this.setItem(item));
    }

    setItem(item): Tone {
        item.area = this.getArea(item.areaId);
        item.toneType = this.getToneType(item.toneTypeId);
        return item;
    }

    private getArea(id: number): Area {
        return new Area(id, this.areas.filter(area => { return area.value === id; })[0].label);
    }

    private getToneType(id: number): ToneType {
        return new ToneType(id, this.toneTypes.filter(toneType => { return toneType.value === id })[0].label);
    }
}