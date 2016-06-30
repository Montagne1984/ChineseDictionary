import {Component, OnInit} from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/Rx";
import {Button, Dialog, DataTable, Column, Header, Footer, InputText} from "primeng/primeng";
import {Locale, LocaleService, LocalizationService, TranslatePipe} from "angular2localization/angular2localization";
import {ObjectService} from "../services/object.service"
import {IExtractable} from "../domain/extractable"

@Component({
    providers: [
        LocaleService,
        LocalizationService
    ],
    pipes: [TranslatePipe]
})

export abstract class ObjectComponent<T extends IExtractable> extends Locale implements OnInit {

    displayDialog: boolean;

    item = this.new();

    selectedItem: T;

    newItem: boolean;

    items: T[];

    errorMessage: string;

    title: string;

    observableBatch: Observable<any>[];

    constructor(public locale: LocaleService, public localization: LocalizationService, protected objectService: ObjectService<T>) {
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

        this.observableBatch = [objectService.get()];
    }

    ngOnInit() {
        Observable.forkJoin(this.observableBatch).subscribe(res => this.loadItems(res), error => this.errorMessage = error);
    }

    showDialogToAdd() {
        this.newItem = true;
        this.item = this.new();
        this.displayDialog = true;
    }

    save() {
        if (this.newItem) {
            this.objectService.post(this.item)
                .subscribe(item => this.items.push(item), error => this.errorMessage = error);

        } else {
            let item = this.cloneItem(this.item);
            this.objectService.put(item)
                .subscribe(() => this.items[this.findSelectedItemIndex()] = this.setItem(item), error => this.errorMessage = error);
        }

        this.item = null;
        this.displayDialog = false;
    }

    delete() {
        this.objectService.delete(this.item)
            .subscribe(() => {
                this.items.splice(this.findSelectedItemIndex(), 1);
                this.item = null;
                this.displayDialog = false;
            }, error => this.errorMessage = error);
    }

    onRowSelect(event) {
        this.newItem = false;
        this.item = this.cloneItem(event.data);
        this.displayDialog = true;
    }

    cloneItem(i: T): T {
        let item = this.new();
        for (let prop in i) {
            item[prop] = i[prop];
        }
        return item;
    }

    abstract new(): T;

    findSelectedItemIndex(): number {
        return this.items.indexOf(this.selectedItem);
    }

    loadItems(res) {
        this.items = res[0];
    }

    setItem(item: T): T {
        return item;
    }
}