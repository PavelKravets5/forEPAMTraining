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
import { PhonesService } from './phones.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { PhonesModel } from '../models/model.phones';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
var PhonesComponent = /** @class */ (function () {
    function PhonesComponent(dataService, activateRoute, router) {
        var _this = this;
        this.dataService = dataService;
        this.activateRoute = activateRoute;
        this.editedPhone = null;
        this.phone = new PhonesModel(); // изменяемый товар
        this.tableMode = true; // табличный режим
        this.querySubscription = activateRoute.queryParams.subscribe(function (queryParam) { _this.id = queryParam['Id']; });
        this.myRouter = router;
    }
    PhonesComponent.prototype.ngOnInit = function () {
        this.loadPhones(); // загрузка данных при старте компонента  
    };
    // получаем данные через сервис
    PhonesComponent.prototype.loadPhones = function () {
        var _this = this;
        this.dataService.getPhonesById(this.id)
            .subscribe(function (data) { return _this.phones = data; });
    };
    PhonesComponent.prototype.editPhone = function (phone) {
        this.editedPhone = new PhonesModel(phone.Id, phone.OrganizerId, phone.Phone);
    };
    PhonesComponent.prototype.deletePhone = function (id) {
        var _this = this;
        this.dataService.deletePhone(id).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadPhones();
        });
    };
    // загружаем один из двух шаблонов
    PhonesComponent.prototype.loadTemplate = function (phone) {
        if (this.editedPhone && this.editedPhone.Id == phone.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    // сохраняем пользователя
    PhonesComponent.prototype.savePhone = function () {
        var _this = this;
        this.dataService.createPhone(this.editedPhone).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно добавлены',
                _this.loadPhones();
        });
        this.isNewRecord = false;
        this.editedPhone = null;
    };
    PhonesComponent.prototype.backwards = function () {
        this.myRouter.navigate(['org']);
    };
    PhonesComponent.prototype.addPhone = function () {
        this.editedPhone = new PhonesModel(0, this.id, "");
        this.phones.push(this.editedPhone);
        this.isNewRecord = true;
    };
    // отмена редактирования
    PhonesComponent.prototype.cancel = function () {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.phones.pop();
            this.isNewRecord = false;
        }
        this.editedPhone = null;
    };
    __decorate([
        ViewChild('readOnlyTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], PhonesComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        ViewChild('editTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], PhonesComponent.prototype, "editTemplate", void 0);
    PhonesComponent = __decorate([
        Component({
            selector: 'phones-app',
            templateUrl: './phones.component.html',
            providers: [PhonesService]
        }),
        __metadata("design:paramtypes", [PhonesService, ActivatedRoute, Router])
    ], PhonesComponent);
    return PhonesComponent;
}());
export { PhonesComponent };
//# sourceMappingURL=phones.component.js.map