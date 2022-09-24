import { CreateProductModel } from './product.model';
import { Validator } from 'fluentvalidation-ts';

export class CreateProductValidator extends Validator<CreateProductModel> {
  /**
   *
   */
  constructor() {
    super();
    this.ruleFor('amount')
      .notNull()
      .greaterThan(0)
      .withMessage('amount is required and must be greater than zero');

    this.ruleFor('name').notEmpty().withMessage('name is required');
    this.ruleFor('imageUrl').notEmpty().withMessage('image url is required');
    this.ruleFor('imageUrl').must((url) => this.isValidHttpUrl(url));
    this.ruleFor('description')
      .notEmpty()
      .minLength(10)
      .withMessage('description is required and with minimum length of 10');
    this.ruleFor('description')
      .maxLength(50)
      .withMessage('description must not exceeds maximum length of 50');
  }

  isValidHttpUrl(uri: string): boolean {
    let url;

    try {
      url = new URL(uri);
    } catch (_) {
      return false;
    }

    return url.protocol === 'http:' || url.protocol === 'https:';
  }
}
