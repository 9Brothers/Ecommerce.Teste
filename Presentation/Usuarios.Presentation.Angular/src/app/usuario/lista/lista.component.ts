import axios from "axios";
import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/domain/entities/usuario';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit {

  nome: string;
  ativo: boolean = true;

  usuarios: Usuario[] = [];

  digitando: boolean = false;
  timerTyping: any;

  constructor() { }

  ngOnInit(): void {
    this.getAllUsuarios();
  }

  filter() {

    if (!this.nome)
      this.nome = '';
    
    if (this.nome && this.nome.length < 3) {

      clearTimeout(this.timerTyping);

      return;
    }

    if (this.timerTyping)
      clearTimeout(this.timerTyping);

    this.timerTyping = setTimeout(() => {

      axios.get(`${environment.apiUrl}/Usuario/Filter?pagina=0&ativo=${this.ativo}&nome=${this.nome}`)
        .then((response) => this.formatUsuario(response));

    }, 500);
  }

  private onTyping() {


  }

  private getAllUsuarios() {
    axios.get(`${environment.apiUrl}/Usuario/Filter?pagina=0&ativo=true`)
      .then((response) => this.formatUsuario(response));
  }

  private formatUsuario(response) {
    let usuarios = response.data as Usuario[];

    usuarios.forEach((u) => {
      u.nascimento = new Date(u.nascimento);
    });

    this.usuarios = usuarios;
  }


}
