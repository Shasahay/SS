import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../account/account.service';
import { BasketService } from '../basket/basket.service';
import { Observable, pipe } from 'rxjs';
import { IBasketTotals } from '../shared/models/basket';
import { IAddress } from '../model/Identity/address';
import { map, tap } from 'rxjs/operators';


@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  basketTotals$: Observable<IBasketTotals>;
  addressRes:IAddress;
  constructor(private fb: FormBuilder, private accountService: AccountService, private basketService: BasketService) { }

  ngOnInit(): void {
    this.createCheckoutForm();
    this.getAddressForm();
    //this.getDeliveryMethodValue();
    this.basketTotals$ = this.basketService.basketTotals$;
  }

  // Nested FormGroups
  createCheckoutForm() {
    this.checkoutForm = this.fb.group({
      addressForm: this.fb.group({
        addressId: [null],
        userId: [null],
        firstName: [null, Validators.required],
        lastName: [null, Validators.required],
        houseNumber: [null, Validators.required],
        apartment: [null, Validators.required],
        street: [null, Validators.required],
        city: [null, Validators.required],
        state: [null, Validators.required],
        pinCode: [null, Validators.required]
      }),
      deliveryForm: this.fb.group({
        deliveryMethod: [null, Validators.required]
      }),
      paymentForm: this.fb.group({
        nameOnCard: [null, Validators.required]
      })
    });
  }

  getAddressForm() {
    
    this.accountService.getUserAddress().subscribe((address: IAddress) => {
      if(address){
        this.checkoutForm.get('addressForm').patchValue(address);
      }
    })
  }

  getDeliveryMethodValue() {
    const basket = this.basketService.getCurrentBasketValue();
    if (basket.deliveryMethodId !== null) {
      this.checkoutForm.get('deliveryForm').get('deliveryMethod')
        .patchValue(basket.deliveryMethodId.toString());
    }
  }

}
