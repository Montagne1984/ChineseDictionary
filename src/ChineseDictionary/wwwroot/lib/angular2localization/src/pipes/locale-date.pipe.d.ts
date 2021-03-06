/**
 * ANGULAR 2 LOCALIZATION
 * An Angular 2 library to translate messages, dates and numbers.
 * Written by Roberto Simonetti.
 * MIT license.
 * https://github.com/robisim74/angular2localization
 */
import { PipeTransform } from '@angular/core';
/**
 * 'localedate' pipe function.
 */
export declare class LocaleDatePipe implements PipeTransform {
    static ALIASES: {
        [key: string]: String;
    };
    constructor();
    /**
     * LocaleDatePipe transform method.
     *
     * @param value The date to be localized
     * @param defaultLocale The default locale
     * @param pattern The format of the date
     * @return The locale date
     */
    transform(value: any, defaultLocale: string, pattern?: string): string;
    private supports(obj);
}
