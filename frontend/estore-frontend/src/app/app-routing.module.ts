import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HomeLayoutComponent } from './layout/home-layout/home-layout.component';

const routes: Routes = [
  {
    path: '',
    component: HomeLayoutComponent,
    children: [{ path: '', component: HomeComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
