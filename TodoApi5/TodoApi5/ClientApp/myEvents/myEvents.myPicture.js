var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Directive, Input } from '@angular/core';
import { MyeventsModel } from '../models/model.myEvents';
import { DomSanitizer } from '@angular/platform-browser';
var MyPicture = /** @class */ (function () {
    function MyPicture(sanitizer) {
        this.sanitizer = sanitizer;
    }
    MyPicture.prototype.ngOnInit = function () {
        this.imageData = 'data:image/' + this.condition1.Screen_format + ';base64,' + this.condition1.Picture;
        this.sanitizedImageData = this.sanitizer.bypassSecurityTrustUrl(this.imageData);
        console.log(this.imageData);
    };
    __decorate([
        Input('myPicture'),
        __metadata("design:type", MyeventsModel)
    ], MyPicture.prototype, "condition1", void 0);
    MyPicture = __decorate([
        Directive({
            selector: '[myPicture]',
            host: {
                '[src]': 'sanitizedImageData'
            }
        }),
        __metadata("design:paramtypes", [DomSanitizer])
    ], MyPicture);
    return MyPicture;
}());
export { MyPicture };
//# sourceMappingURL=myEvents.myPicture.js.map