var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { OrganizersComponent } from '../organizers/organizers.component';
import { MyEventsComponent } from '../myEvents/myEvents.component';
import { MyPicture } from '../myEvents/myEvents.myPicture.component';
import { HomeComponent } from '../home/home.component';
import { CategoriesComponent } from '../categories/categories.component';
import { EmailsComponent } from '../emails/emails.component';
import { PhonesComponent } from '../phones/phones.component';
var appRoutes = [
    { path: '', component: HomeComponent },
    { path: 'myevents', component: MyEventsComponent },
    { path: 'org', component: OrganizersComponent },
    { path: 'category', component: CategoriesComponent },
    { path: 'emails', component: EmailsComponent },
    { path: 'phones', component: PhonesComponent },
    { path: '**', redirectTo: '/' }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
            declarations: [AppComponent, PhonesComponent, MyPicture, OrganizersComponent, EmailsComponent, MyEventsComponent, HomeComponent, CategoriesComponent],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map