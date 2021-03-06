﻿import {Component} from "@angular/core";
import {IPAConsonant} from "../domain/ipaconsonant";
import {ObjectComponent} from "./object.component";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText} from "primeng/primeng";
import {IPAConsonantService} from "../services/ipaconsonant.service"
import {LocaleService, LocalizationService, TranslatePipe} from 'angular2localization/angular2localization';

@Component({
    selector: "d-ipaPhoneme",
    templateUrl: "app/components/ipaphoneme.html",
    directives: [Button, Dialog, DataTable, Column, Header, Footer, InputText],
    providers: [IPAConsonantService],
    pipes: [TranslatePipe]
})
export class IPAConsonantComponent extends ObjectComponent<IPAConsonant> {
    title = "IPACONSONANT";

    constructor(locale: LocaleService, localization: LocalizationService, objectService: IPAConsonantService) {
        super(locale, localization, objectService);
    }
    new(): IPAConsonant {
        return new IPAConsonant();
    }
}