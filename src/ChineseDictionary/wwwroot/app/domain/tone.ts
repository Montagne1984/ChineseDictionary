import {IExtractable} from "./extractable"
import {Area} from "./area";
import {ToneType} from "./tonetype";

export class Tone implements IExtractable {
    area: Area;
    toneType: ToneType;
    constructor(public id?: number, public value?: string, public areaId?: number, public toneTypeId?: number) { }

    extract(json) {
        this.id = json.Id;
        this.value = json.Value;
        this.areaId = json.AreaId;
        this.toneTypeId = json.ToneTypeId;
    }
}