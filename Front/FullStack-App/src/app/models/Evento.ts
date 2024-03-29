import { Lote } from "./Lote";
import { Palestrante } from "./Palestrante";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
  id : number ;
  local : string ;
  dataEvento ?: Date ;
  tema : string ;
  qtdPessoas : number ;
  imagemUrl : string ;
  telefone : string ;
  email : string ;
  lote : Lote[] ;
  redessociais : RedeSocial[] ;
  palestranteseventos : Palestrante[] ;
}
