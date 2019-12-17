import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpRequest } from '@angular/common/http';

import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { OrganizersComponent } from '../organizers/organizers.component';
import { MyEventsComponent } from '../myEvents/myEvents.component';
import { MyPicture } from '../myEvents/myEvents.myPicture.component';
import { HomeComponent } from '../home/home.component';
import { CategoriesComponent } from '../categories/categories.component';
import { EmailsComponent } from '../emails/emails.component'
import { PhonesComponent } from '../phones/phones.component'

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'myevents', component: MyEventsComponent },
    { path: 'org', component: OrganizersComponent },
    { path: 'category', component: CategoriesComponent },
    { path: 'emails', component: EmailsComponent },
    { path: 'phones', component: PhonesComponent },
    { path: '**', redirectTo: '/' }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, PhonesComponent,MyPicture, OrganizersComponent, EmailsComponent,MyEventsComponent, HomeComponent, CategoriesComponent],
    bootstrap: [AppComponent]
})
export class AppModule {
}