using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaisDinheiro.Data;
using MaisDinheiro.Enums;
using MaisDinheiro.Models;
using MaisDinheiro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaisDinheiro.Controllers
{
    [ApiController]
    [Route("v1")]
    public class DespesaController : ControllerBase
    {
        [HttpGet("despesas")]
        [Authorize]
        public async Task<IActionResult> Get([FromServices] AppDbContext context)
        {
            var despesas = await context
                .Despesas
                .AsNoTracking()
                .ToListAsync();

            return Ok(despesas);
        }

        [HttpGet("despesas/{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromServices] AppDbContext context, int id)
        {
            var despesa = await context
                .Despesas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(despesa);
        }

        [HttpPost("despesas")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CriarDespesaViewModel despesaViewModel,
            [FromServices] AppDbContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var despesa = new Despesa
            {
                Nome = despesaViewModel.Nome,
                Valor = despesaViewModel.Valor,
                Vencimento = despesaViewModel.Vencimento,
                Categoria = despesaViewModel.Categoria,
                Status = despesaViewModel.Status,
                IsRecorrente = despesaViewModel.IsRecorrente
            };

            try
            {
                await context.Despesas.AddAsync(despesa);
                await context.SaveChangesAsync();
                return Created($"v1/despesa/{despesa.Id}", despesa);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("despesas/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var todo = await context.Despesas.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Despesas.Remove(todo);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}