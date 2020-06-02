import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";

import { environment } from 'src/environments/environment';

import { SharedModule } from '../shared/shared.module';
import { HeaderComponent } from './components/header/header.component';

export function tokenGetter() {
  return (JSON.parse(localStorage.getItem("currentUser")) || {}).token;
}

const pureApiUrl = environment.apiUrl.substring(0, environment.apiUrl.length - 4);

@NgModule({
  declarations: [HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: [pureApiUrl]
      }
    }),
    SharedModule
  ],
  exports: [HeaderComponent]
})
export class CoreModule { }
