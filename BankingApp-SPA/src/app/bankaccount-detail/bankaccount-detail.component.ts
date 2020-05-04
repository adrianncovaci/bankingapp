import { Component, OnInit } from '@angular/core';
import { Bankaccount } from '../_models/bankaccount';
import { BankaccountsService } from '../_services/bankaccounts.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TransferService } from '../_services/transfer.service';
import { Transaction } from '../_models/transaction';
import { error } from 'protractor';

@Component({
  selector: 'app-bankaccount-detail',
  templateUrl: './bankaccount-detail.component.html',
  styleUrls: ['./bankaccount-detail.component.css']
})

export class BankaccountDetailComponent implements OnInit {
  model: any;
  depositForm: FormGroup;
  withdrawForm: FormGroup;
  transferForm: FormGroup;
  bankAccount: Bankaccount;
  transactions: Transaction[];

  constructor(private bankAcc: BankaccountsService, private alertify: AlertifyService,
              private route: ActivatedRoute, private transferService: TransferService, 
              private fbDeposit: FormBuilder, private fbWithdraw: FormBuilder,
              private fbTransfer: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.loadBankAccount();
    this.getTransactionsByUser();
    this.depositForm = this.fbDeposit.group({
      amount: ['', [
        Validators.required,
        Validators.min(0),
        Validators.pattern("^[0-9]*$"),
        ]
      ]
    });
    this.withdrawForm = this.fbWithdraw.group({
      amount: ['', [
        Validators.required,
        Validators.min(0),
        Validators.pattern("^[0-9]*$"),
        ]
      ]
    });
    this.transferForm = this.fbTransfer.group({
      amount: ['', [
        Validators.required,
        Validators.min(0),
        Validators.pattern("^[0-9]*$"),
      ]
      ],
      receiver: ['', [
        Validators.required
      ]],
      message: ['', [
        Validators.maxLength(256)
      ]]
    });
  }
  
  get t() {
    return this.transferForm.controls;
  }
  
  get d() {
    return this.depositForm.controls;
  }
  
  get w() {
    return this.withdrawForm.controls;
  }
  
  loadBankAccount() {
    this.bankAcc.getBankAccount(+this.route.snapshot.params['id']).subscribe(acc => {
      this.bankAccount = acc;
    }, error => {
      this.alertify.error(error);
    }
    );
  }

  getTransactionsByUser() {
    this.transferService.getTransactionsByUser(+this.route.snapshot.params['id']).subscribe(transactions => {
      this.transactions = transactions; 
    }, 
    error => {
      this.alertify.error(error);
    })
  }
  
  // getTransactionReceiverUsers() {
  //   this.transactions.forEach(el => {
  //     if (el.receiverAccountId != null) {
  //       this.bankAccS
  //     }
  //   })
  // }

  deposit() {
    this.model = {
      senderAccountId: this.bankAccount.id,
      amount: this.depositForm.get('amount').value
    };
    
    this.transferService.deposit(this.model).subscribe(next => {
      this.alertify.success("Successfully deposited");
    },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['']);
      }
    )
  }

  withdraw() {
    this.model = {
      senderAccountId: this.bankAccount.id,
      amount: this.withdrawForm.get('amount').value
    };

    this.transferService.withdraw(this.model).subscribe(next => {
      this.alertify.success("Successfully withdrawn!");
    },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['']);
      }
    )
  }

  transfer() {
    this.model = {
      senderAccountId: this.bankAccount.id,
      amount: this.transferForm.get('amount').value,
      receiverAccountName: this.transferForm.get('receiver').value,
      message: this.transferForm.get('message').value 
    };

    this.transferService.transfer(this.model).subscribe(next => {
      this.alertify.success("Successfully transfered");
    }, error => {
      this.alertify.error(error);
    },
    () => {
      this.router.navigate([''])
    })
  }

}
