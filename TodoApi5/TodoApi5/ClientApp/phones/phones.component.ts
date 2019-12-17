import { Component, OnInit } from '@angular/core';
import { PhonesService } from './phones.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { PhonesModel } from '../models/model.phones';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
    selector: 'phones-app',
    templateUrl: './phones.component.html',
    providers: [PhonesService]
})
export class PhonesComponent implements OnInit
{
    //типы шаблонов
    @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate', { static: false }) editTemplate: TemplateRef<any>;

    editedPhone: PhonesModel = null;
    phone: PhonesModel = new PhonesModel();   // изменяемый товар
    phones: PhonesModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
    statusMessage: string;
    isNewRecord: boolean;
    id: number;
    private querySubscription: Subscription;
    myRouter: any;

    constructor(private dataService: PhonesService, private activateRoute: ActivatedRoute, router: Router) {
        this.querySubscription = activateRoute.queryParams.subscribe(
            (queryParam: any) => { this.id = queryParam['Id']; });
        this.myRouter = router;
    }

    ngOnInit() {
        this.loadPhones();    // загрузка данных при старте компонента  
    }

    // получаем данные через сервис
    loadPhones() {
        this.dataService.getPhonesById(this.id)
            .subscribe((data: PhonesModel[]) => this.phones = data);
    }

    editPhone(phone: PhonesModel) {
        this.editedPhone = new PhonesModel(phone.Id,phone.OrganizerId, phone.Phone)
    }

    deletePhone(id:number) {
        this.dataService.deletePhone(id).subscribe(data => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadPhones();
        });
    }

    // загружаем один из двух шаблонов
    loadTemplate(phone: PhonesModel) {
        if (this.editedPhone && this.editedPhone.Id == phone.Id)
        {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    }

    // сохраняем пользователя
    savePhone() {
        this.dataService.createPhone(this.editedPhone).subscribe(data => {
            this.statusMessage = 'Данные успешно добавлены',
                this.loadPhones();
        });
        this.isNewRecord = false;
        this.editedPhone = null;
    }

    backwards() {
        this.myRouter.navigate(['org']);
    }

    addPhone() {
        this.editedPhone = new PhonesModel(0, this.id, "");
        this.phones.push(this.editedPhone);
        this.isNewRecord = true;
    }

    // отмена редактирования
    cancel() {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.phones.pop();
            this.isNewRecord = false;
        }
        this.editedPhone = null;
    }
}