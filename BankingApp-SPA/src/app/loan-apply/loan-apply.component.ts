import { Component, OnInit } from '@angular/core';
import { LoanService } from '../_services/loan.service';
import { AlertifyService } from '../_services/alertify.service';
import { LoanType } from '../_models/loan-type';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-loan-apply',
  templateUrl: './loan-apply.component.html',
  styleUrls: ['./loan-apply.component.css']
})
export class LoanApplyComponent implements OnInit {
  loanTypes: LoanType[];
  message: Boolean[] = [];
  applyForm: FormGroup;
  model: any;
  index: number;

  constructor(private loanService: LoanService, private alertify: AlertifyService, private fb: FormBuilder,
              private route: Router) { }

  ngOnInit(): void {
    this.getLoanTypes();
    this.applyForm = this.fb.group({
        comments: ['', [
          Validators.maxLength(256),
          Validators.required,
        ]
      ]
    });
  }

  get f() {
    return this.applyForm.controls;
  }

  apply() {
    this.model = {
      ...this.applyForm.value
    };
    for (var i = 0; i < this.message.length; i++)
      if (this.message[i] === true)
        this.model.loanId = this.loanTypes[i].id;
        
    this.loanService.requestLoan(this.model).subscribe( () => {
      this.alertify.success("Successfully requested");
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.route.navigate(['']);      
    })
  }

  getLoanTypes() {
    this.loanService.getLoanTypes().subscribe(loans => {
      this.loanTypes = loans;
      this.loanTypes.forEach(_ => {
        this.message.push(false);
      });
    }, error => {
      this.alertify.error(error);
    })
  }

  toggleMessage(id: number) {
    for(var i = 0; i < this.message.length; i++)
      this.message[i] = false;
    this.message[id] = true !== this.message[id];
  }
}
