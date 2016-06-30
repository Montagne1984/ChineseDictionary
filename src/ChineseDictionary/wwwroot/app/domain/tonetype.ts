import {IExtractable} from "./extractable"

export class ToneType implements IExtractable {
    constructor(public id?: number, public name?: string) { }

    extract(json) {
        this.id = json.Id;
        this.name = json.Name;
    }
}