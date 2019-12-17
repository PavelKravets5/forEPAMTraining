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
import { MyEventsService } from './myEvents.service';
import { MyeventsModel } from '../models/model.myEvents';
import { TemplateRef, ViewChild } from '@angular/core';
var MyEventsComponent = /** @class */ (function () {
    function MyEventsComponent(dataService) {
        this.dataService = dataService;
        this.editedMyEvent = null;
        this.myEvent = new MyeventsModel(); // изменяемый товар
        this.tableMode = true; // табличный режим
        this.base64textString = "";
    }
    MyEventsComponent.prototype.ngOnInit = function () {
        this.loadMyEvents(); // загрузка данных при старте компонента  
    };
    MyEventsComponent.prototype.addMyEvent = function () {
        this.editedMyEvent = new MyeventsModel(0, "", "", "", "", "", "", "", "");
        this.myEvents.push(this.editedMyEvent);
        this.isNewRecord = true;
    };
    // получаем данные через сервис
    MyEventsComponent.prototype.loadMyEvents = function () {
        var _this = this;
        this.dataService.getAllMyEvents()
            .subscribe(function (data) { return _this.myEvents = data; });
    };
    MyEventsComponent.prototype.editMyEvent = function (myEvent) {
        this.editedMyEvent = new MyeventsModel(myEvent.Id, myEvent.EventTitle, myEvent.EventDate, myEvent.Category, myEvent.Picture, myEvent.Screen_format, myEvent.EventVenue, myEvent.Discription, myEvent.Organizer);
    };
    MyEventsComponent.prototype.deleteMyEvent = function (myEvent) {
        var _this = this;
        this.dataService.deleteMyEvent(myEvent.Id).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadMyEvents();
        });
    };
    // загружаем один из двух шаблонов
    MyEventsComponent.prototype.loadTemplate = function (myEvent) {
        if (this.editedMyEvent && this.editedMyEvent.Id == myEvent.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    // сохраняем пользователя
    MyEventsComponent.prototype.saveMyEvent = function () {
        var _this = this;
        this.dataService.createMyEvent(this.editedMyEvent).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно добавлены',
                _this.loadMyEvents();
        });
        this.isNewRecord = false;
        this.editedMyEvent = null;
    };
    //onFileChanged(event) 
    //{
    //    this.editedPicture = event.target.files[0];
    //    this.editedMyEvent.Picture=
    //}
    MyEventsComponent.prototype.onFileChanged = function (event) {
        var files = event.target.files;
        var file = files[0];
        if (files && file) {
            this.editedMyEvent.Screen_format = (file.type).substring(6);
            console.log(this.editedMyEvent.Screen_format);
            var reader = new FileReader();
            reader.onload = this._handleReaderLoaded.bind(this);
            reader.readAsBinaryString(file);
        }
    };
    MyEventsComponent.prototype._handleReaderLoaded = function (readerEvt) {
        var binaryString = readerEvt.target.result;
        this.editedMyEvent.Picture = btoa(binaryString);
        //console.log(btoa(binaryString)); 
    };
    // отмена редактирования
    MyEventsComponent.prototype.cancel = function () {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.myEvents.pop();
            this.isNewRecord = false;
        }
        this.editedMyEvent = null;
    };
    __decorate([
        ViewChild('readOnlyTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], MyEventsComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        ViewChild('editTemplate', { static: false }),
        __metadata("design:type", TemplateRef)
    ], MyEventsComponent.prototype, "editTemplate", void 0);
    MyEventsComponent = __decorate([
        Component({
            selector: 'myEvent-app',
            templateUrl: './myEvents.component.html',
            providers: [MyEventsService]
        }),
        __metadata("design:paramtypes", [MyEventsService])
    ], MyEventsComponent);
    return MyEventsComponent;
}());
export { MyEventsComponent };
//# sourceMappingURL=myEvents.component.js.map