using ElearningApi.DTOs.Sliders;
using ElearningApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ElearningApi.Services.Interfaces;
using ElearningApi.Data;
using ElearningApi.Helpers.Extensions;

namespace ElearningApi.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;


        public SliderService(
            AppDbContext context,
            IWebHostEnvironment env,
            IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }

        public async Task CreateAsync(SliderCreateDto request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.UploadImage.FileName}";

            string path = _env.GenerateFilePath("img", fileName);
            await request.UploadImage.SaveFileToLocalAsync(path);
            request.Image = fileName;

            await _context.Sliders.AddAsync(_mapper.Map<Slider>(request));

           

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Slider slider)
        {
            string imagePath = _env.GenerateFilePath("img", slider.Image);
            imagePath.DeleteFileFromLocal();

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Slider slider, SliderEditDto request)
        {
            if (request.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("img", slider.Image);

                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{request.NewImage.FileName}";

                string newPath = _env.GenerateFilePath("img", fileName);

                await request.NewImage.SaveFileToLocalAsync(newPath);

                request.Image = fileName;
            }

            _mapper.Map(request, slider);
            _context.Sliders.Update(slider);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string title)
        {
            return await _context.Sliders.AnyAsync(m => m.Title.Trim() == title.Trim());
        }

        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _context.Sliders.AsNoTracking().ToListAsync();
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            return await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
