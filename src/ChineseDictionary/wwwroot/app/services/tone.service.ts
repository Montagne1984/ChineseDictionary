import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {Tone} from '../domain/tone';
import {ObjectService} from './object.service';

@Injectable()
export class ToneService extends ObjectService<Tone> {
    protected url = 'api/tones/';  // URL to web api

    constructor(http: Http) {
        super(http);
    }

    new(): Tone {
        return new Tone();
    }
}