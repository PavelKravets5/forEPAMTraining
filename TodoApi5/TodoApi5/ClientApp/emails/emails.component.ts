import { Component, OnInit } from '@angular/core';
import { EmailsService } from './emails.service';
import { TemplateRef, ViewChild } from '@angular/core';
import { EmailsModel } from '../models/model.emails';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
    selector: 'emails-app',
    templateUrl: './emails.component.html',
    providers: [EmailsService]
})
export class EmailsComponent implements OnInit {
    //типы шаблонов
    @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate', { static: false }) editTemplate: TemplateRef<any>;

    editedEmail: EmailsModel = null;
    email: EmailsModel = new EmailsModel();   // изменяемый товар
    emails: EmailsModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
    statusMessage: string;
    isNewRecord: boolean;
    id: number;
    private querySubscription: Subscription;
    myRouter: any;

    constructor(private dataService: EmailsService, private activateRoute: ActivatedRoute, router: Router) {
        this.querySubscription = activateRoute.queryParams.subscribe(
            (queryParam: any) => { this.id = queryParam['Id']; });
        this.myRouter = router;
    }

    ngOnInit() {
        this.loadEmails();    // загрузка данных при старте компонента  
    }

    // получаем данные через сервис
    loadEmails() {
        this.dataService.getEmailsById(this.id)
            .subscribe((data: EmailsModel[]) => this.emails = data);
    }

    editEmail(email: EmailsModel) {
        this.editedEmail = new EmailsModel(email.Id, email.OrganizerId, email.Email)
    }

    deleteEmail(Id: number) {
        this.dataService.deleteEmail(Id).subscribe(data => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadEmails();
        });
    }

    // загружаем один из двух шаблонов
    loadTemplate(email: EmailsModel) {
        if (this.editedEmail && this.editedEmail.Id == email.Id)
        {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    }
    addEmail() {
        this.editedEmail = new EmailsModel(0, this.id, "");
        this.emails.push(this.editedEmail);
        this.isNewRecord = true;
    }

    // сохраняем пользователя
    saveEmail() {
        this.dataService.createEmail(this.editedEmail).subscribe(data => {
            this.statusMessage = 'Данные успешно добавлены',
                this.loadEmails();
        });
        this.isNewRecord = false;
        this.editedEmail = null;
    }

    backwards() {
        this.myRouter.navigate(['org']);
    }

    // отмена редактирования
    cancel() {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.emails.pop();
            this.isNewRecord = false;
        }
        this.editedEmail = null;
    }
}
