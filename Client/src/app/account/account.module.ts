import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AccountRoutingModule } from "./account-routing.module";
import { SharedModule } from "../shared/shared.module";

import { ProfileComponent } from "./pages/profile/profile.component";

@NgModule({
	declarations: [ProfileComponent],
	imports: [CommonModule, SharedModule, AccountRoutingModule],
})
export class AccountModule {}
