import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {ToneType} from '../domain/tonetype';
import {ObjectService} from './object.service';

@Injectable()
export class ToneTypeService extends ObjectService<ToneType> {
    protected url = 'api/tonetypes/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    protected extractArray(res: Response): ToneType[] {
        let items = [];
        res.json().forEach(item => items.push(new ToneType(item.Id, item.Name)));
        return items;
    }

    protected extractData(res: Response): ToneType {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new ToneType(item.Id, item.Name);
    }
}