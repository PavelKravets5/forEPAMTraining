import { Directive, OnInit, Input } from '@angular/core';
import { MyeventsModel } from '../models/model.myEvents';
import { DomSanitizer } from '@angular/platform-browser';

@Directive({
    selector: '[myPicture]',
    host: {
        '[src]': 'sanitizedImageData'
    }
})
export class MyPicture implements OnInit {
    imageData: any;
    @Input('myPicture') condition1: MyeventsModel;
    sanitizedImageData: any;

    constructor(private sanitizer: DomSanitizer) { }

    ngOnInit()
    {
        this.imageData = 'data:image/' + this.condition1.Screen_format + ';base64,' + this.condition1.Picture;
        this.sanitizedImageData = this.sanitizer.bypassSecurityTrustUrl(this.imageData);
        console.log(this.imageData);
    }
}