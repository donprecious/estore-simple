import { CreateOrderModel, ShippingAddress, OrderItem } from './order-model';
import { Validator } from 'fluentvalidation-ts';

export class OrderValidator extends Validator<CreateOrderModel> {
  /**
   *
   */
  constructor() {
    super();
    this.ruleFor('customerEmail').notEmpty().withMessage('email is required');
    this.ruleFor('shippingAddress')
      .notNull()
      .setValidator(() => new ShippingAddressValidator());

    this.ruleForEach('orderItems').setValidator(() => new OrderItemValidator());
  }
}

export class ShippingAddressValidator extends Validator<ShippingAddress> {
  /**
   *
   */
  constructor() {
    super();
    this.ruleFor('city').notEmpty().withMessage('city is required');
    this.ruleFor('country').notEmpty().withMessage('country is required');
    this.ruleFor('state').notEmpty().withMessage('state is required');
    this.ruleFor('street').notEmpty().withMessage('street is required');
  }
}

export class OrderItemValidator extends Validator<OrderItem> {
  /**
   *
   */
  constructor() {
    super();

    this.ruleFor('productId')
      .notNull()
      .greaterThan(0)
      .withMessage('productId is required');
    this.ruleFor('quantity')
      .notNull()
      .greaterThan(0)
      .withMessage('unit is required and must be above 0');
  }
}
