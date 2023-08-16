using ApiFilmes.Data;
using ApiFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFilmes.Services.FilmeService
{
    public class FilmeService : IFilmeService
    {
        private readonly AppDbContext _context;
        public FilmeService(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<ServiceResponse<List<Filme>>> GetAll()
        //{
        //    ServiceResponse<List<Filme>> response = new();

        //    response.Data = await _context.Filmes.ToListAsync();

        //    return response;
        //}

        public async Task<ServiceResponse<List<Filme>>> Get(int offset, int limit)
        {
            ServiceResponse<List<Filme>> response = new();

            response.Data = await _context.Filmes.Skip(offset).Take(limit).ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<Filme>> GetById(int id)
        {
            ServiceResponse<Filme> response = new();

            response.Data = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);
            if (response.Data == null)
                response.Message = $"Nenhum registro encontrado para o ID: {id}";

            return response;
        }

        public async Task<ServiceResponse<Filme>> Create(Filme filme)
        {
            ServiceResponse<Filme> response = new();

            try
            {
                await _context.AddAsync(filme);
                await _context.SaveChangesAsync();

                response.Data = _context.Filmes.FirstOrDefault(x => x.Id == filme.Id);
                response.Message = "Objeto adicionado com sucesso";
            }
            catch (Exception ex) 
            {
                response.Message = $"Ocorreu um erro ao adicionar o objeto!\nErro: {ex}";
            }

            return response;
        }

        public async Task<ServiceResponse<Filme>> Update(Filme filme)
        {
            ServiceResponse<Filme> response = new();
            response.Data = await _context.Filmes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == filme.Id);

            if (response.Data == null)
            {
                response.Message = $"Objeto com ID: {filme.Id} não encontrado! Não houve alteração.";
                return response;
            }

            try
            {
                _context.Update(filme);
                await _context.SaveChangesAsync();

                response.Data = filme;
                response.Message = "Objeto alterado com sucesso";
            }
            catch (Exception ex)
            {
                response.Message = $"Ocorreu um erro ao alterar o objeto! Erro: {ex}";
            }

            return response;
        }

        public async Task<ServiceResponse<Filme>> Delete(Filme filme)
        {
            ServiceResponse<Filme> response = new();
            response.Data = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == filme.Id);

            if (response.Data == null)
            {
                response.Message = $"Objeto com ID: {filme.Id} não encontrado! Não houve alteração.";
                return response;
            }

            try
            {
                _context.Remove(response.Data);
                await _context.SaveChangesAsync();

                response.Data = null;
                response.Message = "Objeto removido com sucesso";
            }
            catch (Exception ex)
            {
                response.Message = $"Ocorreu um erro ao remover o objeto! Erro: {ex}";
            }

            return response;
        }
    }
}
