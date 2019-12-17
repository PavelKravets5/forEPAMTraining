import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PhonesModel } from '../models/model.phones';

@Injectable()
export class PhonesService 
{

    private url = "/api/Phone";

    constructor(private http: HttpClient) 
    {
    }

    getPhonesById(id: number) 
    {
        return this.http.get(this.url+'/'+id);
    }

    deletePhone(id:number) 
    {
        return this.http.delete(this.url + '/' + id);
    }

    createPhone(phone: PhonesModel)
    {
        return this.http.post(this.url, phone);
    }
}