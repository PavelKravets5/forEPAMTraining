var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var MyEventsService = /** @class */ (function () {
    function MyEventsService(http) {
        this.http = http;
        this.url = "/api/MyEvent";
    }
    MyEventsService.prototype.getAllMyEvents = function () {
        return this.http.get(this.url);
    };
    MyEventsService.prototype.deleteMyEvent = function (id) {
        return this.http.delete(this.url + '/' + id);
    };
    MyEventsService.prototype.createMyEvent = function (myEvent) {
        return this.http.post(this.url, myEvent);
    };
    MyEventsService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], MyEventsService);
    return MyEventsService;
}());
export { MyEventsService };
//# sourceMappingURL=myEvents.service.js.map