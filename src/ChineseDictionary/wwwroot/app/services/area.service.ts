import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {Area} from '../domain/area';
import {ObjectService} from './object.service';

@Injectable()
export class AreaService extends ObjectService<Area> {
    protected url = 'api/areas/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    protected extractArray(res: Response): Area[] {
        let items = [];
        res.json().forEach(item => items.push(new Area(item.Id, item.Name)));
        return items;
    }

    protected extractData(res: Response): Area {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new Area(item.Id, item.Name);
    }
}