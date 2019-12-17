import { Component } from '@angular/core';

@Component({
    selector: 'app',
    styles: [` 
        .nav{ clear: both;}
        a {float: left;}
        .active a { color: red;}
    `],
    template: `
                <script data-require="angular.js@1.2.x" src="https://code.angularjs.org/1.2.28/angular.js" data-semver="1.2.28"></script>
                <script data-require="angular-sanitize.js@*" data-semver="1.2.0-rc.3" src="https://code.angularjs.org/1.2.0-rc.3/angular-sanitize.js"></script>

                <div>
                    <ul class="nav">
                        <li routerLinkActive="active" [routerLinkActiveOptions]="{exact:true}">
                            <a routerLink="">Главная</a>
                        </li>
                        <li routerLinkActive="active">
                            <a routerLink="/myevents">События</a>
                        </li>
                        <li routerLinkActive="active">
                            <a routerLink="/org">Организации</a>
                        </li>
                        <li routerLinkActive="active">
                            <a routerLink="/category">Категории</a>
                        </li>
                    </ul>
                    <router-outlet></router-outlet>
               </div>`
})
export class AppComponent { }