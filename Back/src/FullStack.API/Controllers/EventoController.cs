using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.API.Data;
using FullStack.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        //Fazer referencia do context do BD dentro da controller
        private readonly DataContext contexto;

        public EventoController(DataContext contexto)
        {
            this.contexto = contexto;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return contexto.Eventos;
        }
        /// <summary>
        /// Busca elementos por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return contexto.Eventos.FirstOrDefault(evento => evento.EventoId == id);

        }
        [HttpPost]
        public string Post()
        {
            return "Teste do Evento POST";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Teste do Evento Put {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Teste do Evento Delete {id}";
        }
    }
}
