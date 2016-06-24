import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {Vowel} from '../domain/vowel';
import {ObjectService} from './object.service';

@Injectable()
export class VowelService extends ObjectService<Vowel> {
    protected url = 'api/vowels/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    protected extractArray(res: Response): Vowel[] {
        let items = [];
        res.json().forEach(item => items.push(new Vowel(item.Id, item.Symbol)));
        return items;
    }

    protected extractData(res: Response): Vowel {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new Vowel(item.Id, item.Symbol);
    }
}