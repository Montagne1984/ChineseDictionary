import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import {Vowel} from '../domain/vowel';
import {ObjectService} from './object.service';

@Injectable()
export class VowelService extends ObjectService<Vowel> {
    protected url = 'api/vowels/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    new(): Vowel {
        return new Vowel();
    }
}