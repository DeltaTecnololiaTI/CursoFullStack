import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable({
  providedIn: 'root' // Primeira maneira de injetar o serviço no componente
})
export class EventoService {

  baseURL = 'https://localhost:5001/api/eventos';

 //foi injetado no componente as funções do HttpClient
 //para isso tem que injetar no app.module.ts o HttpClientModule
 constructor(private http: HttpClient) { }

 public getEventos(): Observable<Evento[]>{
   return this.http.get<Evento[]>(this.baseURL);
 }
 public getEventosByTema(tema: string): Observable<Evento[]>{
  return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
}
public getEventoById(id: number): Observable<Evento[]>{
  return this.http.get<Evento[]>(`${this.baseURL}/${id}`);
}

}


