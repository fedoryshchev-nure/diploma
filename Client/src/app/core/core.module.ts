import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { JwtModule } from "@auth0/angular-jwt";
import { environment } from 'src/environments/environment';

export function tokenGetter() {
  return (JSON.parse(localStorage.getItem("currentUser")) || {}).token;
}

const pureApiUrl = environment.apiUrl.substring(0, environment.apiUrl.length - 4);

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: [pureApiUrl]
      }
    })
  ]
})
export class CoreModule { }
