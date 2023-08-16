using ApiFilmes.Data;
using ApiFilmes.Models;
using ApiFilmes.Services.FilmeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace ApiFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        //[HttpGet]
        //public async Task<ActionResult<ServiceResponse<List<Filme>>>> GetAll()
        //{
        //    return Ok(await _filmeService.GetAll());
        //}

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Filme>>>> Get([FromQuery] int offset, int limit = 10)
        {
            return Ok(await _filmeService.Get(offset, limit));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetById(int id)
        {
            return Ok(await _filmeService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Create(Filme filme)
        {
            return Ok(await _filmeService.Create(filme));
        }

        [HttpPut]
        public async Task<ActionResult<Filme>> Update(Filme filme)
        {
            return Ok(await _filmeService.Update(filme));
        }

        [HttpDelete]
        public async Task<ActionResult<Filme>> Delete(Filme filme)
        {
            return Ok(await _filmeService.Delete(filme));
        }
    }
}
