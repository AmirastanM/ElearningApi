using ElearningApi.DTOs.Informations;
using ElearningApi.Models;

namespace ElearningApi.Services.Interfaces
{
    public interface IInformationService
    {
        Task CreateAsync(InformtationCreateDto request);
        Task EditAsync(Information information, InformationEditDto request);
        Task DeleteAsync(Information information);
        Task<IEnumerable<Information>> GetAllAsync();
        Task<Information> GetByIdAsync(int id);
        Task<bool> ExistAsync(string title);
    }
}
