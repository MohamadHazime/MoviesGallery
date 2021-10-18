import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from '../components/home/home.component';
import { HomeResolver } from '../resolvers/home.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent, resolve: [HomeResolver] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutesModule {}