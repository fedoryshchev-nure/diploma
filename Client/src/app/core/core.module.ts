import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";

import { SharedModule } from '../shared/shared.module';

import { environment } from 'src/environments/environment';

import { HeaderComponent } from './components/header/header.component';

export function tokenGetter() {
  return (JSON.parse(localStorage.getItem("currentUser")) || {}).token;
}

@NgModule({
  declarations: [HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: [environment.noSchemaApiUrlBase]
      }
    }),
    SharedModule
  ],
  exports: [HeaderComponent]
})
export class CoreModule { }
