import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { ProductEntity } from '../interfaces/product/ProductEntity';
import { CreateProduct } from '../interfaces/product/CreateProduct';
import { UpdateProduct } from '../interfaces/product/UpdateProduct ';
import { DeleteProduct } from '../interfaces/product/DeleteProduct';

@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  private apiUrl = `${environment.apiUrl}/Product`;

  constructor(private http: HttpClient) { }

  getProduct(): Observable<ProductEntity[]> {
    return this.http.get<ProductEntity[]>(`${this.apiUrl}/GetProduct`);
  }

  getProductById(id: number): Observable<ProductEntity> {
    return this.http.get<ProductEntity>(`${this.apiUrl}/GetProductById/${id}`);
  }

  createProduct(createProduct: CreateProduct): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/CreateProduct`, createProduct);
  }

  updateProduct(updateProduct: UpdateProduct): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}/UpdateProduct`, updateProduct);
  }

  deleteProduct(deleteProduct: DeleteProduct): Observable<boolean> {
    return this.http.request<boolean>('delete', `${this.apiUrl}/DeleteProduct`, {
      body: deleteProduct,
    });
  }
}
