import { Injectable } from '@angular/core';
import { HttpClient,HttpParams } from '@angular/common/http';
import { Myeventsmodel } from './myeventsmodel';

@Injectable()
export class DataService 
{

    private url = "/api/MyEvent";

    constructor(private http: HttpClient) 
    {
    }

    getAllMyEvents() 
    {
        return this.http.get(this.url);
    }

    deleteMyEvent(id: number) 
    {
        return this.http.delete(this.url + '/' + id);
    }

    createMyEvent(myEvent: Myeventsmodel)
    {
        return this.http.post(this.url, myEvent);
    }
}