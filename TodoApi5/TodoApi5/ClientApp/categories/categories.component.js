var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { CategoriesService } from './categories.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { CategoriesModel } from '../models/model.categories';
var CategoriesComponent = /** @class */ (function () {
    function CategoriesComponent(dataService) {
        this.dataService = dataService;
        this.editedCategory = null;
        this.category = new CategoriesModel(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    CategoriesComponent.prototype.ngOnInit = function () {
        this.loadCategories(); // загрузка данных при старте компонента  
    };
    CategoriesComponent.prototype.addCategory = function () {
        this.editedCategory = new CategoriesModel(0, "");
        this.categories.push(this.editedCategory);
        this.isNewRecord = true;
    };
    // получаем данные через сервис
    CategoriesComponent.prototype.loadCategories = function () {
        var _this = this;
        this.dataService.getAllCategories()
            .subscribe(function (data) { return _this.categories = data; });
    };
    CategoriesComponent.prototype.editCategory = function (category) {
        this.editedCategory = new CategoriesModel(category.Id, category.Category);
    };
    CategoriesComponent.prototype.deleteCategory = function (category) {
        var _this = this;
        this.dataService.deleteCategory(category.Id).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadCategories();
        });
    };
    // загружаем один из двух шаблонов
    CategoriesComponent.prototype.loadTemplate = function (category) {
        if (this.editedCategory && this.editedCategory.Id == category.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    // сохраняем пользователя
    CategoriesComponent.prototype.saveCategory = function () {
        var _this = this;
        this.dataService.createCategory(this.editedCategory).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно добавлены',
                _this.loadCategories();
        });
        this.isNewRecord = false;
        this.editedCategory = null;
    };
    // отмена редактирования
    CategoriesComponent.prototype.cancel = function () {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.categories.pop();
            this.isNewRecord = false;
        }
        this.editedCategory = null;
    };
    __decorate([
        ViewChild('readOnlyTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], CategoriesComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        ViewChild('editTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], CategoriesComponent.prototype, "editTemplate", void 0);
    CategoriesComponent = __decorate([
        Component({
            selector: 'category-app',
            templateUrl: './categories.component.html',
            providers: [CategoriesService]
        }),
        __metadata("design:paramtypes", [CategoriesService])
    ], CategoriesComponent);
    return CategoriesComponent;
}());
export { CategoriesComponent };
//# sourceMappingURL=categories.component.js.map