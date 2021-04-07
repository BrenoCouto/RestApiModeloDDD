using Microsoft.AspNetCore.Mvc;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace RestApiModeloDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IApplicationServiceCliente applicationServiceCliente;

        public ClienteController(IApplicationServiceCliente applicationServiceCliente)
        {
            this.applicationServiceCliente = applicationServiceCliente;
        }

        //GET api/valores
        [HttpGet]
        public ActionResult<IEnumerable<String>> Get()
        {
            return Ok(applicationServiceCliente.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceCliente.GetById(id));
        }

        // POST api/valores

        [HttpPost]
        public ActionResult Post([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                    return NotFound();
                applicationServiceCliente.Add(clienteDto);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Put([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                    return NotFound();
                applicationServiceCliente.Update(clienteDto);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                    return NotFound();
                applicationServiceCliente.Remove(clienteDto);
                return Ok("Cliente removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
