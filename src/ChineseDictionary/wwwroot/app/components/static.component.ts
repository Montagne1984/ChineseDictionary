import {Component, OnInit} from "@angular/core";
import {InputText} from 'primeng/primeng';
import {Locale, LocaleService, LocalizationService, TranslatePipe} from "angular2localization/angular2localization";

@Component({
    selector: "static",
    directives: [InputText],
    templateUrl: "app/components/static.html",
    providers: [
        LocaleService,
        LocalizationService
    ],
    pipes: [TranslatePipe]
})
export class StaticComponent extends Locale {
    constructor(public locale: LocaleService, public localization: LocalizationService) {
        super(locale, localization);

        // Adds a new language (ISO 639 two-letter or three-letter code).
        this.locale.addLanguage("zh");
        // Add a new language here.

        // Required: default language, country (ISO 3166 two-letter, uppercase code) and expiry (No days). If the expiry is omitted, the cookie becomes a session cookie.
        this.locale.definePreferredLocale("zh", 'CN', 30);

        // Optional: default currency (ISO 4217 three-letter code).
        this.locale.definePreferredCurrency("CNY");

        this.localization.translationProvider("./resources/locale.");
        this.localization.updateTranslation(); // Need to update the translation.
    }
}