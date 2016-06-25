import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {Tone} from '../domain/tone';
import {ObjectService} from './object.service';

@Injectable()
export class ToneService extends ObjectService<Tone> {
    protected url = 'api/tones/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    protected extractArray(res: Response): Tone[] {
        let items = [];
        res.json().forEach(item => items.push(new Tone(item.Id, item.Value, item.AreaId, item.ToneTypeId)));
        return items;
    }

    protected extractData(res: Response): Tone {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new Tone(item.Id, item.Value, item.AreaId, item.ToneTypeId);
    }
}