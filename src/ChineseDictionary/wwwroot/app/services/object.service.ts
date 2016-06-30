import { Observable } from 'rxjs/Observable';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import '../rxjs-operators';
import {IExtractable} from '../domain/extractable'

export abstract class ObjectService<T extends IExtractable> {
    headers: Headers = new Headers({ 'Content-Type': 'application/json' });
    options: RequestOptions = new RequestOptions({ headers: this.headers });
    protected url: string;  // URL to web api

    constructor(private http: Http) {
    }

    get() {
        return this.http.get(this.url)
            .map(this.extractArray)
            .catch(this.handleError);
    }

    post(item: T) {
        let body = JSON.stringify(item);

        return this.http.post(this.url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    put(item: T) {
        let body = JSON.stringify(item);
        this.options.url = this.url + item["id"];

        return this.http.put(this.url + item["id"], body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    delete(item: T) {
        return this.http.delete(this.url + item["id"], this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    protected extractArray(res: Response): T[] {
        let items = [];
        res.json().forEach(item => items.push(this.new().extract(item)));
        return items;
    }

    protected extractData(res: Response): T {
        if (res.status === 204) {
            return null;
        }
        return this.new().extract(res.json());
    }
    
    protected handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

    abstract new(): T;
}