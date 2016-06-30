import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import {Consonant} from '../domain/consonant';
import {ObjectService} from './object.service';

@Injectable()
export class ConsonantService extends ObjectService<Consonant> {
    protected url = 'api/consonants/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    new(): Consonant {
        return new Consonant();
    }
}