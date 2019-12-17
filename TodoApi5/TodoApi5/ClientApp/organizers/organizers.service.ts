import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { OrganizersModel } from '../models/model.organizers';

@Injectable()
export class OrganizersService 
{

    private url = "/api/Organizer";

    constructor(private http: HttpClient) 
    {
    }

    getAllOrganizers() 
    {
        return this.http.get(this.url);
    }

    deleteOrganizer(id: number) 
    {
        return this.http.delete(this.url + '/' + id);
    }

    createOrganizer(organizer: OrganizersModel)
    {
        return this.http.post(this.url, organizer);
    }
}