import {Component} from "@angular/core";
import {IPAVowel} from "../domain/ipavowel";
import {ObjectComponent} from "./object.component";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText} from "primeng/primeng";
import {IPAVowelService} from "../services/ipavowel.service"
import {LocaleService, LocalizationService, TranslatePipe} from 'angular2localization/angular2localization';

@Component({
    selector: "d-ipaPhoneme",
    templateUrl: "app/components/ipaphoneme.html",
    directives: [Button, Dialog, DataTable, Column, Header, Footer, InputText],
    providers: [IPAVowelService],
    pipes: [TranslatePipe]
})
export class IPAVowelComponent extends ObjectComponent<IPAVowel> {
    title = "IPAVOWEL";

    constructor(locale: LocaleService, localization: LocalizationService, objectService: IPAVowelService) {
        super(locale, localization, objectService);
    }
    new(): IPAVowel {
        return new IPAVowel();
    }
}