import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import {ToneType} from '../domain/tonetype';
import {ObjectService} from './object.service';

@Injectable()
export class ToneTypeService extends ObjectService<ToneType> {
    protected url = 'api/tonetypes/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    new(): ToneType {
        return new ToneType();
    }
}