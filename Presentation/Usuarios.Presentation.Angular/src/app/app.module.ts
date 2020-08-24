import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { MessageDialogComponent } from './dialogs/message-dialog/message-dialog.component';
import { CadastroComponent } from './usuario/cadastro/cadastro.component';
import { ListaComponent } from './usuario/lista/lista.component';

@NgModule({
  declarations: [
    AppComponent,
    MessageDialogComponent,
    CadastroComponent,
    ListaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
