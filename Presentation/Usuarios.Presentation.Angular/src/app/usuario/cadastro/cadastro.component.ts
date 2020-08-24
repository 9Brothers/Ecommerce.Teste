declare let $: any;

import { Component, OnInit, Input } from '@angular/core';
import { Usuario } from 'src/domain/entities/usuario';
import { FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import axios from 'axios';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router) { }

  usuarioForm: FormGroup = null;

  @Input()
  nome: string = '';

  @Input()
  nascimento: string = '';

  @Input()
  email: string = '';

  @Input()
  senha: string = '';

  @Input()
  sexo: string = '';

  hoje: Date = null;
  maxDate: Date = null;
  oldDate: Date = null;

  titulo: string = '';
  mensagem: string = '';

  ngOnInit(): void {

    this.hoje = new Date(new Date().toISOString().substring(0, 10));
    this.maxDate = new Date(new Date().toISOString().substring(0, 10));
    this.nascimento = this.hoje.toISOString().substring(0, 10);
    this.sexo = "1";
  }

  salvar() {
    let usuario: Usuario = {
      nome: this.nome,
      email: this.email,
      nascimento: new Date(this.nascimento),
      senha: this.senha,
      sexoId: +this.sexo
    }
    
    axios.post(`${environment.apiUrl}/Usuario`, usuario)
      .then(() => {

        this.titulo = 'Cadastro efetuado';
        this.mensagem = 'Usuário cadastrado com sucesso';

        $('#modal-message').modal('show');
      });
  }

  validarData() {
    
    if (new Date(this.nascimento) > this.maxDate) {
      this.nascimento = this.oldDate.toISOString().substring(0, 10);
    }
    else {
      this.oldDate = new Date(this.nascimento);
    }
  }

  setData() {
    this.oldDate = new Date(this.nascimento);
  }

  closeModal(evt: string) {
    this.router.navigate(['/']);
  }

  voltar() {
    this.router.navigate(['/']);
  }
}