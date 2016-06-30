import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import {IPAVowel} from '../domain/ipavowel';
import {ObjectService} from './object.service';

@Injectable()
export class IPAVowelService extends ObjectService<IPAVowel> {
    protected url = 'api/ipavowels/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    new(): IPAVowel {
        return new IPAVowel();
    }
}