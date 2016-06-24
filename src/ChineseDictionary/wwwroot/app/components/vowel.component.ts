import {Component} from "@angular/core";
import {Vowel} from "../domain/vowel";
import {ObjectComponent} from "./object.component";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText} from "primeng/primeng";
import {VowelService} from "../services/vowel.service"
import {LocaleService, LocalizationService, TranslatePipe} from 'angular2localization/angular2localization';

@Component({
    selector: "d-phoneme",
    templateUrl: "app/components/phoneme.html",
    directives: [Button, Dialog, DataTable, Column, Header, Footer, InputText],
    providers: [VowelService],
    pipes: [TranslatePipe]
})
export class VowelComponent extends ObjectComponent<Vowel> {
    title = "VOWEL";

    constructor(locale: LocaleService, localization: LocalizationService, objectService: VowelService) {
        super(locale, localization, objectService);
    }
    new(): Vowel {
        return new Vowel();
    }
}