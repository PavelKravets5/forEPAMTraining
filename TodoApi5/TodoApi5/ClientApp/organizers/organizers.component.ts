import { Component, OnInit } from '@angular/core';
import { OrganizersService } from './organizers.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { OrganizersModel } from '../models/model.organizers';
import { Router } from '@angular/router';
@Component({
    selector: 'org-app',
    templateUrl: './organizers.component.html',
    providers: [OrganizersService]
})
export class OrganizersComponent implements OnInit
{
    //типы шаблонов
    @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate', { static: false }) editTemplate: TemplateRef<any>;

    editedOrganizer: OrganizersModel = null;
    organizer: OrganizersModel = new OrganizersModel();   // изменяемый товар
    organizers: OrganizersModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
    statusMessage: string;
    isNewRecord: boolean;
    editedPicture: any;
    myRouter: any;

    constructor(private dataService: OrganizersService, router: Router) {
        this.myRouter = router;
    }

    ngOnInit() {
        this.loadOrganizers();    // загрузка данных при старте компонента  
    }

    // получаем данные через сервис
    loadOrganizers() {
        this.dataService.getAllOrganizers()
            .subscribe((data: OrganizersModel[]) => this.organizers = data);
    }

    showPhones(Id: number) {
        this.myRouter.navigate(['phones'],{queryParams: {'Id': Id }});
    }

    showEmails(Id: number) {
        this.myRouter.navigate(['emails'], { queryParams: { 'Id': Id } });
    }

    editOrganizer(organizer: OrganizersModel) {
        this.editedOrganizer = new OrganizersModel(organizer.Id, organizer.Organizer, organizer.Adress);
    }

    deleteOrganizer(organizer: OrganizersModel) {
        this.dataService.deleteOrganizer(organizer.Id).subscribe(data => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadOrganizers();
        });
    }

    // загружаем один из двух шаблонов
    loadTemplate(organizer: OrganizersModel) {
        if (this.editedOrganizer && this.editedOrganizer.Id == organizer.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    }

    // сохраняем пользователя
    saveOrganizer() {
        this.dataService.createOrganizer(this.editedOrganizer).subscribe(data => {
            this.statusMessage = 'Данные успешно добавлены',
                this.loadOrganizers();
        });
        this.isNewRecord = false;
        this.editedOrganizer = null;
    }

    addOrganizer() {
        this.editedOrganizer = new OrganizersModel(0, "", "");
        this.organizers.push(this.editedOrganizer);
        this.isNewRecord = true;
    }

    // отмена редактирования
    cancel() {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.organizers.pop();
            this.isNewRecord = false;
        }
        this.editedOrganizer = null;
    }
}