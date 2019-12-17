import { Component, OnInit } from '@angular/core';
import { MyEventsService } from './myEvents.service';
import { MyeventsModel } from '../models/model.myEvents';
import { TemplateRef, ViewChild } from '@angular/core';

@Component({
    selector: 'myEvent-app',
    templateUrl: './myEvents.component.html',
    providers: [MyEventsService]
})
export class MyEventsComponent implements OnInit {

    //типы шаблонов
    @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate', { static: false }) editTemplate: TemplateRef<any>;

    editedMyEvent: MyeventsModel = null;
    myEvent: MyeventsModel = new MyeventsModel();   // изменяемый товар
    myEvents: MyeventsModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
    statusMessage: string;
    isNewRecord: boolean;
    editedPicture: any;
    private base64textString: String = "";

    constructor(private dataService: MyEventsService) { }

    ngOnInit() {
        this.loadMyEvents();    // загрузка данных при старте компонента  
    }

    addMyEvent() {
        this.editedMyEvent = new MyeventsModel(0, "", "", "", "", "", "", "", "");
        this.myEvents.push(this.editedMyEvent);
        this.isNewRecord = true;
    }

    // получаем данные через сервис
    loadMyEvents() {
        this.dataService.getAllMyEvents()
            .subscribe((data: MyeventsModel[]) => this.myEvents = data);


    }

    editMyEvent(myEvent: MyeventsModel) {
        this.editedMyEvent = new MyeventsModel(myEvent.Id, myEvent.EventTitle, myEvent.EventDate,
            myEvent.Category, myEvent.Picture, myEvent.Screen_format, myEvent.EventVenue, myEvent.Discription, myEvent.Organizer);
    }

    deleteMyEvent(myEvent: MyeventsModel) {
        this.dataService.deleteMyEvent(myEvent.Id).subscribe(data => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadMyEvents();
        });
    }

    // загружаем один из двух шаблонов
    loadTemplate(myEvent: MyeventsModel) {
        if (this.editedMyEvent && this.editedMyEvent.Id == myEvent.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    }

    // сохраняем пользователя
    saveMyEvent() {
        this.dataService.createMyEvent(this.editedMyEvent).subscribe(data => {
            this.statusMessage = 'Данные успешно добавлены',
                this.loadMyEvents();
        });
        this.isNewRecord = false;
        this.editedMyEvent = null;
    }

    //onFileChanged(event) 
    //{
    //    this.editedPicture = event.target.files[0];
    //    this.editedMyEvent.Picture=
    //}
    onFileChanged(event: any) {
        var files = event.target.files;
        var file = files[0];
        if (files && file) {
            this.editedMyEvent.Screen_format = (file.type).substring(6);
            console.log(this.editedMyEvent.Screen_format);
            var reader = new FileReader();
            reader.onload = this._handleReaderLoaded.bind(this);
            reader.readAsBinaryString(file);
        }
    }

    _handleReaderLoaded(readerEvt: any) {
        var binaryString = readerEvt.target.result;
        this.editedMyEvent.Picture = btoa(binaryString);

        //console.log(btoa(binaryString)); 
    }

    // отмена редактирования
    cancel() {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.myEvents.pop();
            this.isNewRecord = false;
        }
        this.editedMyEvent = null;
    }
}