import { Injectable } from '@angular/core';
import {IPAConsonant} from '../domain/ipaconsonant';
import {IObjectService} from './object.service';

@Injectable()
export class IPAConsonantService implements IObjectService {
    get() {
        let i = new IPAConsonant();
        i.symbol = "b";
        return [i];
    }
}