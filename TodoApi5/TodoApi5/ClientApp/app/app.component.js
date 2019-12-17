var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
var AppComponent = /** @class */ (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        Component({
            selector: 'app',
            styles: [" \n        .nav{ clear: both;}\n        a {float: left;}\n        .active a { color: red;}\n    "],
            template: "\n                <script data-require=\"angular.js@1.2.x\" src=\"https://code.angularjs.org/1.2.28/angular.js\" data-semver=\"1.2.28\"></script>\n                <script data-require=\"angular-sanitize.js@*\" data-semver=\"1.2.0-rc.3\" src=\"https://code.angularjs.org/1.2.0-rc.3/angular-sanitize.js\"></script>\n\n                <div>\n                    <ul class=\"nav\">\n                        <li routerLinkActive=\"active\" [routerLinkActiveOptions]=\"{exact:true}\">\n                            <a routerLink=\"\">\u0413\u043B\u0430\u0432\u043D\u0430\u044F</a>\n                        </li>\n                        <li routerLinkActive=\"active\">\n                            <a routerLink=\"/myevents\">\u0421\u043E\u0431\u044B\u0442\u0438\u044F</a>\n                        </li>\n                        <li routerLinkActive=\"active\">\n                            <a routerLink=\"/org\">\u041E\u0440\u0433\u0430\u043D\u0438\u0437\u0430\u0446\u0438\u0438</a>\n                        </li>\n                        <li routerLinkActive=\"active\">\n                            <a routerLink=\"/category\">\u041A\u0430\u0442\u0435\u0433\u043E\u0440\u0438\u0438</a>\n                        </li>\n                    </ul>\n                    <router-outlet></router-outlet>\n               </div>"
        })
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map