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
import { OrganizersService } from './organizers.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { OrganizersModel } from '../models/model.organizers';
import { Router } from '@angular/router';
var OrganizersComponent = /** @class */ (function () {
    function OrganizersComponent(dataService, router) {
        this.dataService = dataService;
        this.editedOrganizer = null;
        this.organizer = new OrganizersModel(); // изменяемый товар
        this.tableMode = true; // табличный режим
        this.myRouter = router;
    }
    OrganizersComponent.prototype.ngOnInit = function () {
        this.loadOrganizers(); // загрузка данных при старте компонента  
    };
    // получаем данные через сервис
    OrganizersComponent.prototype.loadOrganizers = function () {
        var _this = this;
        this.dataService.getAllOrganizers()
            .subscribe(function (data) { return _this.organizers = data; });
    };
    OrganizersComponent.prototype.showPhones = function (Id) {
        this.myRouter.navigate(['phones'], { queryParams: { 'Id': Id } });
    };
    OrganizersComponent.prototype.showEmails = function (Id) {
        this.myRouter.navigate(['emails'], { queryParams: { 'Id': Id } });
    };
    OrganizersComponent.prototype.editOrganizer = function (organizer) {
        this.editedOrganizer = new OrganizersModel(organizer.Id, organizer.Organizer, organizer.Adress);
    };
    OrganizersComponent.prototype.deleteOrganizer = function (organizer) {
        var _this = this;
        this.dataService.deleteOrganizer(organizer.Id).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadOrganizers();
        });
    };
    // загружаем один из двух шаблонов
    OrganizersComponent.prototype.loadTemplate = function (organizer) {
        if (this.editedOrganizer && this.editedOrganizer.Id == organizer.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    // сохраняем пользователя
    OrganizersComponent.prototype.saveOrganizer = function () {
        var _this = this;
        this.dataService.createOrganizer(this.editedOrganizer).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно добавлены',
                _this.loadOrganizers();
        });
        this.isNewRecord = false;
        this.editedOrganizer = null;
    };
    OrganizersComponent.prototype.addOrganizer = function () {
        this.editedOrganizer = new OrganizersModel(0, "", "");
        this.organizers.push(this.editedOrganizer);
        this.isNewRecord = true;
    };
    // отмена редактирования
    OrganizersComponent.prototype.cancel = function () {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.organizers.pop();
            this.isNewRecord = false;
        }
        this.editedOrganizer = null;
    };
    __decorate([
        ViewChild('readOnlyTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], OrganizersComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        ViewChild('editTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], OrganizersComponent.prototype, "editTemplate", void 0);
    OrganizersComponent = __decorate([
        Component({
            selector: 'org-app',
            templateUrl: './organizers.component.html',
            providers: [OrganizersService]
        }),
        __metadata("design:paramtypes", [OrganizersService, Router])
    ], OrganizersComponent);
    return OrganizersComponent;
}());
export { OrganizersComponent };
//# sourceMappingURL=organizers.component.js.map