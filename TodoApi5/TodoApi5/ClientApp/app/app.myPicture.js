var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { TemplateRef, Directive, Input, ViewContainerRef } from '@angular/core';
import { Myeventsmodel } from './myeventsmodel';
var MyPicture = /** @class */ (function () {
    function MyPicture(tpl, vc) {
        this.tpl = tpl;
        this.vc = vc;
    }
    MyPicture.prototype.ngOnInit = function () {
        this.imageData = 'data:image/' + this.condition1.Screen_format + '; base64, ' + this.condition1.Picture;
    };
    __decorate([
        Input('myPicture'),
        __metadata("design:type", Myeventsmodel)
    ], MyPicture.prototype, "condition1", void 0);
    MyPicture = __decorate([
        Directive({
            selector: '[myPicture]'
        }),
        __metadata("design:paramtypes", [TemplateRef, ViewContainerRef])
    ], MyPicture);
    return MyPicture;
}());
export { MyPicture };
//# sourceMappingURL=app.myPicture.js.map