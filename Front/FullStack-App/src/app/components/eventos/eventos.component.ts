import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  providers: [EventoService] // Segunda maeira de injetar o serviço no componente
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos: Evento[]=[];
  public eventosFiltrados: Evento[] = [];
  larguraImagem =320;
  public alturaImagem=200
  public margemImagem=2;
  public exibirImagem=false;
  private _filtroLista: string = "";

  constructor(private eventoService: EventoService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService) { }

  public get filtroLista(): string{
    return this._filtroLista;
  }
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public ngOnInit(): void {
    this.getEventos();
     /** spinner starts on init */
     this.spinner.show();
  }

  public alternarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public filtrarEventos(filtrarPor :string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor)!== -1
      )
    }
    public getEventos(): void{

      this.eventoService.getEventos().subscribe({
        next:(_eventos: Evento[]) => {
          this.eventos = _eventos;
          this.eventosFiltrados = this.eventos;
        },
        error:(error: any) => {console.log(error)},
        complete:() => {setTimeout(() => {
          //spinner ends after 5 miliseconds
          this.spinner.hide();
        }, 500); }
      });
    }
    public openModal(template: TemplateRef<any>): void {
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

    public confirm(): void {
      //this.message = 'Confirmed!';
      this.modalRef?.hide();
      this.toastr.success('O evento foi excluído com sucesso!', 'Confirmado');
    }

    public decline(): void {
      //this.message = 'Declined!';
      this.modalRef?.hide();
      this.toastr.success('Nenhum evento foi excluido!', 'Alerta');
    }

  }

