import {Component} from "@angular/core";
import {Consonant} from "../domain/consonant";
import {ObjectComponent} from "./object.component";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText} from "primeng/primeng";
import {ConsonantService} from "../services/consonant.service"
import {LocaleService, LocalizationService, TranslatePipe} from 'angular2localization/angular2localization';

@Component({
    selector: "d-phoneme",
    templateUrl: "app/components/phoneme.html",
    directives: [Button, Dialog, DataTable, Column, Header, Footer, InputText],
    providers: [ConsonantService],
    pipes: [TranslatePipe]
})
export class ConsonantComponent extends ObjectComponent<Consonant> {
    title = "CONSONANT";

    constructor(locale: LocaleService, localization: LocalizationService, objectService: ConsonantService) {
        super(locale, localization, objectService);
    }
    new(): Consonant {
        return new Consonant();
    }
}