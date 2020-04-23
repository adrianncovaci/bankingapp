import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  model: any = {};

  constructor(private fb: FormBuilder, private authService: AuthService) { }

  ngOnInit(): void {
      this.loginForm = this.fb.group({
          email: ['', [
              Validators.required,
              Validators.email
          ]],
          password: ['', [
              Validators.required
          ]],
      });

  }
    get email() {
        return this.loginForm.get('email');
    }
    get password() {
        return this.loginForm.get('password');
    }

    login() {
      this.model = {
          ...this.loginForm.value
      };

      this.authService.login(this.model).subscribe(next => {
          console.log('Logged In Successful');
      }, error => {
          console.log(this.model);
      });
    }
}
