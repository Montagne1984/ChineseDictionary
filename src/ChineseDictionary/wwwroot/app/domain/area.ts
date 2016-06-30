import {IExtractable} from "./extractable"
import {Tone} from "./tone"

export class Area implements IExtractable {
    tones: Tone[] = [];
    constructor(public id?: number, public name?: string) { }
    static extract(json: any) {
        return new Area();
    }

    extract(json) {
        this.id = json.Id;
        this.name = json.Name;
    }
}