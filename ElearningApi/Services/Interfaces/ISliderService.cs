using ElearningApi.DTOs.Sliders;
using ElearningApi.Models;


namespace ElearningApi.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderCreateDto request);
        Task EditAsync(Slider slider, SliderEditDto request);
        Task DeleteAsync(Slider slider);
        Task<IEnumerable<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int id);
        Task<bool> ExistAsync(string title);
    }
}
