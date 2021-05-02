using ArquivoBaseBootcamp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using ArquivoBaseBootcamp.Models;

namespace ArquivoBaseBootcamp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteresseController : ControllerBase
    {
        private readonly IInteresseService _interesseService;

        public InteresseController(IInteresseService interesseService)
        {
            _interesseService = interesseService;
        }

        /// <summary>
        /// Este endpoint deve consultar as interessadas cadastradas
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as interessadas cadastradas
        /// </returns>

        [HttpGet]
        public IActionResult ConsultarTodosInteresses() 
        {

            var todasAsInteressadas = _interesseService.ConsultarTodos();
            
            return Ok(todasAsInteressadas);
        
        }

        /// <summary>
        /// Este endpoint deve consultar a interessada cadastrada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpGet]
        [Route("consultar/email")]

        public IActionResult ConsultarInteresse(string email)
        {   
            Interessada verificaSeConsulta = _interesseService.ConsultarPorEmail(email);

            if (verificaSeConsulta != null) // Se o email foi encontrado, o retorno do ConsultaPorEmail não vai ser vazio
            {
                return Ok(verificaSeConsulta); // então retorna os dados da interessada correspondente ao email
            }
            else
            {
                return NotFound("E-mail não cadastrado"); // se o retorno do ConsultaPorEmail for vazio, o email não foi encontrado
            }
        }

        /// <summary>
        ///  Este endpoint deve realizar o inclusao de uma interessada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpPost]
        [Route("incluir")]
        public IActionResult AdicionarInteresse(Interessada interessada)
        {
            Interessada verificaSeAdiciona = _interesseService.Incluir(interessada);   

            if(verificaSeAdiciona == interessada)
            {
                return Ok(interessada);
            }
            else
            {
                return BadRequest("E-mail ou nome inválidos ou repetidos. Tente novamente.");
            }

        }

        /// <summary>
        /// Este endpoint deve atualizar os dados da interessada cadastrada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpPut]
        [Route("atualizar/email")]
        public IActionResult AtualizarInteresse(string email, Interessada interessada)
        {
            var atualizaEmailInterssada = _interesseService.AtualizarEmail(email, interessada);
            if (atualizaEmailInterssada != null)
            {
                return Ok(interessada);
            }
            else
            {
                return NotFound("Cadastro não encontrado para ser atualizado");
            }
   
        }

        /// <summary>
        /// Este endpoint deve excluir a interessada cadastrada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpDelete]
        [Route("excluir/email")]
        public IActionResult ExcluirInteresse(string email)
        {

            var excluiInteressada = _interesseService.ExcluirPorEmail(email);

            if (excluiInteressada == true)
            {
                return Ok("E-mail excluido");
            }
            else
            {
                return NotFound("E-mail não encontrado");
            }
        }
    }
}
