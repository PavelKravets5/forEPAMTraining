import { Component, OnInit } from '@angular/core';
import { CategoriesService } from './categories.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { CategoriesModel } from '../models/model.categories';


@Component({
    selector: 'category-app',
    templateUrl: './categories.component.html',
    providers: [CategoriesService]
})
export class CategoriesComponent implements OnInit
{
    //типы шаблонов
    @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate', { static: false }) editTemplate: TemplateRef<any>;

    editedCategory: CategoriesModel = null;
    category: CategoriesModel = new CategoriesModel();   // изменяемый товар
    categories: CategoriesModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
    statusMessage: string;
    isNewRecord: boolean;
    editedPicture: any;

    constructor(private dataService: CategoriesService) { }

    ngOnInit() {
        this.loadCategories();    // загрузка данных при старте компонента  
    }

    addCategory() {
        this.editedCategory = new CategoriesModel(0, "");
        this.categories.push(this.editedCategory);
        this.isNewRecord = true;
    }

    // получаем данные через сервис
    loadCategories() {
        this.dataService.getAllCategories()
            .subscribe((data: CategoriesModel[]) => this.categories = data);


    }

    editCategory(category: CategoriesModel) {
        this.editedCategory = new CategoriesModel(category.Id, category.Category);
    }

    deleteCategory(category: CategoriesModel) {
        this.dataService.deleteCategory(category.Id).subscribe(data => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadCategories();
        });
    }

    // загружаем один из двух шаблонов
    loadTemplate(category: CategoriesModel) {
        if (this.editedCategory && this.editedCategory.Id == category.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    }

    // сохраняем пользователя
    saveCategory() {
        this.dataService.createCategory(this.editedCategory).subscribe(data => {
            this.statusMessage = 'Данные успешно добавлены',
                this.loadCategories();
        });
        this.isNewRecord = false;
        this.editedCategory = null;
    }

    // отмена редактирования
    cancel() {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.categories.pop();
            this.isNewRecord = false;
        }
        this.editedCategory = null;
    }
}