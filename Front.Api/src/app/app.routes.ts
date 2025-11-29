import { Routes } from '@angular/router';
import { ProductComponent } from './components/product/product.component';
import { UserComponent } from './components/user/user.component';

export const routes: Routes = [
  { path: '', redirectTo: 'user', pathMatch: 'full' },
  { path: 'product', component: ProductComponent },
  { path: 'user', component: UserComponent }
];