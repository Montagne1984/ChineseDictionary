import {IExtractable} from "./extractable"

export class IPAPhoneme implements IExtractable {
    constructor(public id?: number, public symbol?: string) { }

    extract(json) {
        this.id = json.Id;
        this.symbol = json.Symbol;
    }
}