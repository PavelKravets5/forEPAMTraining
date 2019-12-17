import { TemplateRef, Directive, OnInit, Input, ViewContainerRef  } from '@angular/core';
import { Myeventsmodel } from './myeventsmodel';

@Directive({
    selector: '[myPicture]'
})
export class MyPicture {
    imageData: any;
    @Input('myPicture') condition1: Myeventsmodel;
    
    constructor(private tpl: TemplateRef < any >, private vc: ViewContainerRef) { }

    ngOnInit()
    {
        this.imageData = 'data:image/' + this.condition1.Screen_format+'; base64, ' + this.condition1.Picture;       
    }
}