using Microsoft.AspNetCore.Mvc;
using Revisao.Application.Interfaces;
using Revisao.Application.ViewModels;

namespace Revisao.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaController : ControllerBase
    {
        private readonly ICartaService _cartaService;

        public CartaController(ICartaService produtoService)
        {
            _cartaService = produtoService;
        }

        [HttpGet("ObterCarta")]
        public async Task<IActionResult> Get()
        {
            return Ok(_cartaService.ObterTodos());
        }

        [HttpPost("RegistrarCarta")]
        public IActionResult Post(NovaCartaViewModel novaCartaViewModel)
        {
            _cartaService.Adicionar(novaCartaViewModel);
            return Ok("Carta adicionada com sucesso!");
        }
    }
}
