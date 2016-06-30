import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import {Area} from '../domain/area';
import {ObjectService} from './object.service';

@Injectable()
export class AreaService extends ObjectService<Area> {
    protected url = 'api/areas/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    new(): Area {
        return new Area();
    }
}