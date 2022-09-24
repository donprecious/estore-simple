import {
  CreateProductModel,
  GetProductModel,
} from './../../services/product/product.model';
import { Component, Input, OnInit } from '@angular/core';
import UIkit from 'uikit';
import {
  UntypedFormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { OrderValidator } from 'src/app/services/order/order.validate';
import {
  CreateOrderModel,
  OrderItem,
} from 'src/app/services/order/order-model';
import { OrderService } from 'src/app/services/order/order.service';
import { CreateProductValidator } from 'src/app/services/product/product.validation';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  constructor(
    private orderService: OrderService,
    private productService: ProductService
  ) {}

  @Input()
  products: GetProductModel[] = [];
  ngOnInit(): void {}

  savedAddress = this.orderService.getShippingAddress();

  orderForm = new FormGroup({
    quantity: new FormControl(1, {
      nonNullable: true,
      validators: [Validators.min(1), Validators.required],
    }),
    email: new FormControl(this.savedAddress?.email, {
      nonNullable: true,
      validators: [Validators.email, Validators.required],
    }),
    street: new FormControl(this.savedAddress?.street, {
      nonNullable: true,
      validators: [Validators.required],
    }),
    state: new FormControl(this.savedAddress?.state, {
      nonNullable: true,
      validators: [Validators.required],
    }),
    city: new FormControl(this.savedAddress?.city, {
      nonNullable: true,
      validators: [Validators.required],
    }),
    country: new FormControl(this.savedAddress?.country, {
      nonNullable: true,
      validators: [Validators.required],
    }),
    zipCode: new FormControl(this.savedAddress?.zipCode, {}),
  });

  // name: string;
  // description: string;
  // amount: number;
  // imageUrl: string;

  productForm = new FormGroup({
    name: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
    description: new FormControl('', {
      nonNullable: true,
      validators: [Validators.min(10), Validators.required, Validators.max(50)],
    }),
    amount: new FormControl(1, {
      nonNullable: true,
      validators: [Validators.required, Validators.min(1)],
    }),
    imageUrl: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
  });

  formControls = this.orderForm.controls;
  productFormControl = this.productForm.controls;
  isLoading = false;
  currentProdutId = 0;

  order(productId: number) {
    this.currentProdutId = productId;
    UIkit.modal('#order-modal').show();
  }

  submitOrderForm() {
    const orderValidate = new OrderValidator();
    const formValue = this.orderForm.value;

    const orderData: CreateOrderModel = {
      customerEmail: formValue.email as string,
      orderItems: [
        {
          productId: this.currentProdutId,
          quantity: formValue.quantity as number,
        } as OrderItem,
      ],
      shippingAddress: {
        city: formValue.city as string,
        country: formValue.country as string,
        state: formValue.state as string,
        street: formValue.street as string,
        zipCode: formValue.zipCode as string,
      },
    };

    const result = orderValidate.validate(orderData);
    this.isLoading = true;
    console.log(this.formControls);
    const shippingAddress = orderData.shippingAddress;
    shippingAddress.email = orderData.customerEmail;

    this.orderService.persistShippingDetail(shippingAddress);
    this.orderService.createOrder(orderData).subscribe(
      (a) => {
        this.isLoading = false;
        UIkit.modal.alert('Order Placed Successfully');
      },
      (error) => {
        this.isLoading = false;
        UIkit.modal.alert('error occured when placing your order');
        console.error(error);
      }
    );
  }

  createProduct() {
    const productValidator = new CreateProductValidator();

    const data: CreateProductModel = {
      amount: this.productForm.value.amount as number,
      description: this.productForm.value.description as string,
      imageUrl: this.productForm.value.imageUrl as string,
      name: this.productForm.value.name as string,
      
    };
    const validateResult = productValidator.validate(data);
    this.isLoading = true;
    if (validateResult?.imageUrl) {
      UIkit.modal.alert('Image Url must be valid');
      return;
    }
    this.productService.createProduct(data).subscribe(
      (a) => {
        this.isLoading = false;
        UIkit.modal.alert(a.message);
      },
      (error) => {
        this.isLoading = false;
        UIkit.modal.alert('error occured when creating product');
        console.error(error);
      }
    );
  }
}
