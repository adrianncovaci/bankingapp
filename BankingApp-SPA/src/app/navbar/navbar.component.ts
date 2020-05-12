import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit(): void {
  }

  isLoggedIn() {
      return this.authService.loggedIn();
  }

  logOut() {
      this.authService.logOut();
      this.alertify.message('You have been logged out.');
      this.router.navigate(['home']);
  }
}
