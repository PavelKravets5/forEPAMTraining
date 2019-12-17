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
import { EmailsService } from './emails.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { EmailsModel } from '../models/model.emails';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
var EmailsComponent = /** @class */ (function () {
    function EmailsComponent(dataService, activateRoute, router) {
        var _this = this;
        this.dataService = dataService;
        this.activateRoute = activateRoute;
        this.editedEmail = null;
        this.email = new EmailsModel(); // изменяемый товар
        this.tableMode = true; // табличный режим
        this.querySubscription = activateRoute.queryParams.subscribe(function (queryParam) { _this.id = queryParam['Id']; });
        this.myRouter = router;
    }
    EmailsComponent.prototype.ngOnInit = function () {
        this.loadEmails(); // загрузка данных при старте компонента  
    };
    // получаем данные через сервис
    EmailsComponent.prototype.loadEmails = function () {
        var _this = this;
        this.dataService.getEmailsById(this.id)
            .subscribe(function (data) { return _this.emails = data; });
    };
    EmailsComponent.prototype.editEmail = function (email) {
        this.editedEmail = new EmailsModel(email.Id, email.OrganizerId, email.Email);
    };
    EmailsComponent.prototype.deleteEmail = function (Id) {
        var _this = this;
        this.dataService.deleteEmail(Id).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadEmails();
        });
    };
    // загружаем один из двух шаблонов
    EmailsComponent.prototype.loadTemplate = function (email) {
        if (this.editedEmail && this.editedEmail.Id == email.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    EmailsComponent.prototype.addEmail = function () {
        this.editedEmail = new EmailsModel(0, this.id, "");
        this.emails.push(this.editedEmail);
        this.isNewRecord = true;
    };
    // сохраняем пользователя
    EmailsComponent.prototype.saveEmail = function () {
        var _this = this;
        this.dataService.createEmail(this.editedEmail).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно добавлены',
                _this.loadEmails();
        });
        this.isNewRecord = false;
        this.editedEmail = null;
    };
    EmailsComponent.prototype.backwards = function () {
        this.myRouter.navigate(['org']);
    };
    // отмена редактирования
    EmailsComponent.prototype.cancel = function () {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.emails.pop();
            this.isNewRecord = false;
        }
        this.editedEmail = null;
    };
    __decorate([
        ViewChild('readOnlyTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], EmailsComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        ViewChild('editTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], EmailsComponent.prototype, "editTemplate", void 0);
    EmailsComponent = __decorate([
        Component({
            selector: 'emails-app',
            templateUrl: './emails.component.html',
            providers: [EmailsService]
        }),
        __metadata("design:paramtypes", [EmailsService, ActivatedRoute, Router])
    ], EmailsComponent);
    return EmailsComponent;
}());
export { EmailsComponent };
//# sourceMappingURL=emails.component.js.map