import {IExtractable} from "./extractable"
import {IPAPhoneme} from "./ipaphoneme"

export class Phoneme<T extends IPAPhoneme> implements IExtractable  {
    constructor(public id?: number, public symbol?: string) { }

    extract(json) {
        this.id = json.Id;
        this.symbol = json.Symbol;
    }
}