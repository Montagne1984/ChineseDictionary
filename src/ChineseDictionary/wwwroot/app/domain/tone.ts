import {Area} from "./area";
import {ToneType} from "./tonetype";

export class Tone {
    area: Area;
    toneType: ToneType;
    constructor(public id?: number, public value?: string, public areaId?: number, public toneTypeId?: number) { }
}