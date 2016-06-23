import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions  } from '@angular/http';
import {IPAVowel} from '../domain/ipavowel';
import {ObjectService} from './object.service';

@Injectable()
export class IPAVowelService extends ObjectService<IPAVowel> {
    protected url = 'api/ipavowels/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    protected extractArray(res: Response): IPAVowel[] {
        let items = [];
        res.json().forEach(item => items.push(new IPAVowel(item.Id, item.Symbol)));
        return items;
    }

    protected extractData(res: Response): IPAVowel {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new IPAVowel(item.Id, item.Symbol);
    }
}