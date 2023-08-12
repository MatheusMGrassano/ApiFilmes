using ApiFilmes.Models;

namespace ApiFilmes.Services.FilmeService
{
    public interface IFilmeService
    {
        Task<ServiceResponse<List<Filme>>> GetAll();
        Task<ServiceResponse<Filme>> GetById(int id);
        Task<ServiceResponse<Filme>> Create(Filme filme);
        Task<ServiceResponse<Filme>> Update(Filme filme);
        Task<ServiceResponse<Filme>> Delete(Filme filme);

    }
}
