import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {IPAConsonant} from '../domain/ipaconsonant';
import {ObjectService} from './object.service';

@Injectable()
export class IPAConsonantService extends ObjectService<IPAConsonant> {
    protected url = 'api/ipaconsonants/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    protected extractArray(res: Response): IPAConsonant[] {
        let items = [];
        res.json().forEach(item => items.push(new IPAConsonant(item.Id, item.Symbol)));
        return items;
    }

    protected extractData(res: Response): IPAConsonant {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new IPAConsonant(item.Id, item.Symbol);
    }
}