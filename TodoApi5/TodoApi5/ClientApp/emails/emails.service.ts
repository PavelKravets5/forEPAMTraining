import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpRequest } from '@angular/common/http';
import { EmailsModel } from '../models/model.emails';

@Injectable()
export class EmailsService 
{

    private url = "/api/Email";
    
    constructor(private http: HttpClient) 
    {
    }

    getEmailsById(id: number) 
    {
        return this.http.get(this.url+'/'+id);
    }

    deleteEmail(id: number) 
    {
        return this.http.delete(this.url + '/' + id);
    }

    createEmail(email: EmailsModel)
    {
        return this.http.post(this.url, email);
    }
}