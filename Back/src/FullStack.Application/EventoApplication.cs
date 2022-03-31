using System;
using System.Threading.Tasks;
using FullStack.Application.Interfaces;
using FullStack.Domain.Entities;
using FullStack.Repository.Interfaces;

namespace FullStack.Application
{
    public class EventoApplication : IEventoApplication
    {
        private readonly IBaseFullRepository _base;
        private readonly IEventoRepository _evento;

        public EventoApplication(IBaseFullRepository baseRepository, IEventoRepository eventoRepository)
        {
            _evento = eventoRepository;
            _base = baseRepository;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _base.Add<Evento>(model);
                if( await _base.SaveChangesAsync()) {
                    return await _evento.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _evento.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;
                model.Id = evento.Id;
                _base.Update<Evento>(model);
                if (await _base.SaveChangesAsync()){
                    return await _evento.GetEventoByIdAsync(model.Id , false);
                }
                return null;               
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _evento.GetEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception($"Atenção! Não foi encontrado o evento número {eventoId} para ser excluído! ");
                _base.Delete<Evento>(evento);
                return await _base.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
 
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _evento.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) throw new Exception($"Não foram encontrados eventos!");
                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
 
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _evento.GetEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) throw new Exception($"Atenção! Não foram encontrados evento para a pesquisa '{tema}'!");
                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
 
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _evento.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) throw new Exception($"Atenção! Não foi encontrado evento para o identificador '{eventoId}'!");
                return eventos;
            }    
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
 
        }
    }
}