import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { Constants } from '../../shared/constants';
import { ProductoService } from '../../services/producto.service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-producto',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  providers: [ProductoService],
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss',
})
export class ProductComponent {
  products: any[] = [];
  productForm!: FormGroup;
  edit: boolean = false;
  productEditId: number | null = null;

  constructor(
    private productoService: ProductoService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.productForm = this.fb.group({
      id: [null],
      name: [''],
      price: [''],
    });
    this.GetProduct();
  }

  GetProduct() {
    this.productoService.getProduct().subscribe((data) => {
      this.products = data;
    });
  }

  SaveProduct() {
    if (this.edit && this.productEditId !== null) {
      this.productoService
        .updateProduct(this.productForm.value)
        .subscribe(() => {
          this.GetProduct();
          this.CancelEdition();
        });
    } else {
      this.productoService
        .createProduct(this.productForm.value)
        .subscribe(() => {
          this.GetProduct();
          this.productForm.reset();
        });
    }
  }

  editProduct(producto: any) {
    this.edit = true;
    this.productEditId = producto.id;
    this.productForm.patchValue({
      id: producto.id,
      name: producto.name,
      price: producto.price,
    });
  }

  CancelEdition() {
    this.edit = false;
    this.productEditId = null;
    this.productForm.reset();
  }

  DeleteProduct(producto: any) {
    Swal.fire({
      title: Constants.Delete.DELETE_TITLE,
      text: Constants.Delete.DELETE_TEXT,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: Constants.Buttons.DELETE_OK,
      cancelButtonText: Constants.Buttons.DELETE_CANCEL,
    }).then((result) => {
      if (result.isConfirmed) {
        this.productoService.deleteProduct(producto).subscribe(() => {
          this.GetProduct();
          this.CancelEdition();
        });
      }
    });
  }
}
