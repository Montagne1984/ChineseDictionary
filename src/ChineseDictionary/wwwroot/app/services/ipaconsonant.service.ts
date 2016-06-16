import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import {IPAConsonant} from '../domain/ipaconsonant';
import {ObjectService} from './object.service';

@Injectable()
export class IPAConsonantService extends ObjectService<IPAConsonant> {
    private url = 'api/ipaconsonants';  // URL to web api
    constructor(private http: Http) {
        super();
    }

    get() {
        //let i = new IPAConsonant();
        //i.symbol = "b";
        //return [i];
        return this.http.get(this.url)
            .toPromise()
            .then(response => response.json().data)
            .catch(this.handleError);
    }
}