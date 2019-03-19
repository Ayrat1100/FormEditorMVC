import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable()


export class HttpService{
  
    constructor(private http: HttpClient){ }
      
    getFactorial(route:string){
        return this.http.get('http://localhost:53662'+route,{responseType: 'json'});
    }
}