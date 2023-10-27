import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { CarrosService } from 'src/app/carros.service';
import { Carro } from 'src/app/Carro';
import { ModelosService } from 'src/app/modelos.service';
import { Modelo } from 'src/app/Modelo';

@Component({
  selector: 'app-carros',
  templateUrl: './carros.component.html',
  styleUrls: ['./carros.component.css']
})
export class CarrosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  modelos: Array<Modelo> | undefined;

  constructor(private carrosService : CarrosService, private modelosService : ModelosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Carro';

    this.modelosService.listar().subscribe(modelos => {
      this.modelos = modelos;
      if (this.modelos && this.modelos.length > 0) {
        this.formulario.get('modeloId')?.setValue(this.modelos[0].id);
      }
    });

    this.formulario = new FormGroup({
      placa: new FormControl(null),
      modeloId: new FormControl(null),
      descricao: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const carro: Carro = this.formulario.value;
    const observer: Observer<Carro> = {
      next(_result): void {
        alert('Carro salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    /*
    if (????) {
      this.carrosService.alterar(carro).subscribe(observer);
    } else {
    */
      this.carrosService.cadastrar(carro).subscribe(observer);
  }
}
