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

    new(): IPAConsonant {
        return new IPAConsonant();
    }
}