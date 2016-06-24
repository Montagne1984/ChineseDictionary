import {Area} from "./area";
import {ToneType} from "./tonetype";

export class Tone {
    constructor(public id?: number, public value?: string, public area?: Area, public toneType?: ToneType) { }
}