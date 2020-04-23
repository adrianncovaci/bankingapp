import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../_services/auth.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  model: any = {};

  constructor(private fb: FormBuilder, private authService: AuthService) { }

  ngOnInit(): void {
      this.registerForm = this.fb.group({
          firstName: ['', [
              Validators.required,
              Validators.maxLength(64)
          ]],
          lastName: ['', [
              Validators.required,
              Validators.maxLength(64)
          ]],
          cnp: ['', [
              Validators.required,
              Validators.minLength(13)
          ]],
          email: ['', [
              Validators.required,
              Validators.email
          ]],
          password: ['', [
              Validators.required,
          ]],
          city: ['', [
              Validators.required,
          ]],
          address: ['', [
              Validators.required,
          ]],
          zipcode: ['', [
              Validators.required,
          ]]
      });
  }

  get f() {
      return this.registerForm.controls;
  }

  register() {
      this.model = {
          ...this.registerForm.value
      };
      this.authService.register(this.model).subscribe(
          () => { console.log('done'); },
          error => {
              console.log(this.registerForm.value);
          }
      );
  }
}

// {
//     "firstName": "Jon",
//     "lastName": "Snow",
//     "cnp": "4204204204204",
//     "email": "vanea@zapada.com",
//     "password": "Drag0ns",
//     "city": "Los Santos",
//     "address": "Grove St.",
//     "zipcode": "4204"
// }
