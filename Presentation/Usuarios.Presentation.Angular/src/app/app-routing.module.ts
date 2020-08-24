import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastroComponent } from './usuario/cadastro/cadastro.component';
import { ListaComponent } from './usuario/lista/lista.component';


const routes: Routes = [
  { path: '', component: ListaComponent },
  { path: 'Cadastro', component: CadastroComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }