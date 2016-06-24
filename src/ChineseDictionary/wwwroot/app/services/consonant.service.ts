import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {Consonant} from '../domain/consonant';
import {ObjectService} from './object.service';

@Injectable()
export class ConsonantService extends ObjectService<Consonant> {
    protected url = 'api/consonants/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    protected extractArray(res: Response): Consonant[] {
        let items = [];
        res.json().forEach(item => items.push(new Consonant(item.Id, item.Symbol)));
        return items;
    }

    protected extractData(res: Response): Consonant {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new Consonant(item.Id, item.Symbol);
    }
}