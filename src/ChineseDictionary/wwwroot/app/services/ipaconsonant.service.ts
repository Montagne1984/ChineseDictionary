import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions  } from '@angular/http';
import {IPAConsonant} from '../domain/ipaconsonant';
import {ObjectService} from './object.service';
import '../rxjs-operators';

@Injectable()
export class IPAConsonantService extends ObjectService<IPAConsonant> {
    private url = 'api/ipaconsonants/';  // URL to web api
    constructor(private http: Http) {
        super();
    }

    get() {
        return this.http.get(this.url)
            .map(this.extractArray)
            .catch(this.handleError);
    }

    post(item: IPAConsonant) {
        let body = JSON.stringify(item);

        return this.http.post(this.url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    put(item: IPAConsonant) {
        let body = JSON.stringify(item);
        this.options.url = this.url + item.id;

        return this.http.put(this.url + item.id, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    delete(item: IPAConsonant) {
        return this.http.delete(this.url + item.id, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractArray(res: Response): IPAConsonant[] {
        let items = [];
        res.json().forEach(item => items.push(new IPAConsonant(item.Id, item.Symbol)));
        return items;
    }

    private extractData(res: Response): IPAConsonant {
        if (res.status === 204) {
            return null;
        }
        let item = res.json();
        return new IPAConsonant(item.Id, item.Symbol);
    }
}