import { Component, OnInit } from "@angular/core";

import { AuthService } from "../../services/auth.service";
import { UserService } from "../../services/user.service";

@Component({
	selector: "app-header",
	templateUrl: "./header.component.html",
	styleUrls: ["./header.component.scss"],
})
export class HeaderComponent implements OnInit {
	constructor(public authService: AuthService, public userService: UserService) {}

	ngOnInit(): void {}
}
