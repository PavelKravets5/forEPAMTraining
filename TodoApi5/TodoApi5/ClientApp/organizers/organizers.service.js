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
var OrganizersService = /** @class */ (function () {
    function OrganizersService(http) {
        this.http = http;
        this.url = "/api/Organizer";
    }
    OrganizersService.prototype.getAllOrganizers = function () {
        return this.http.get(this.url);
    };
    OrganizersService.prototype.deleteOrganizer = function (id) {
        return this.http.delete(this.url + '/' + id);
    };
    OrganizersService.prototype.createOrganizer = function (organizer) {
        return this.http.post(this.url, organizer);
    };
    OrganizersService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], OrganizersService);
    return OrganizersService;
}());
export { OrganizersService };
//# sourceMappingURL=organizers.service.js.map