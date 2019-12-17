import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CategoriesModel } from '../models/model.categories';

@Injectable()
export class CategoriesService 
{

    private url = "/api/Category";

    constructor(private http: HttpClient) 
    {
    }

    getAllCategories() 
    {
        return this.http.get(this.url);
    }

    deleteCategory(id: number) 
    {
        return this.http.delete(this.url + '/' + id);
    }

    createCategory(category: CategoriesModel)
    {
        return this.http.post(this.url, category);
    }
}