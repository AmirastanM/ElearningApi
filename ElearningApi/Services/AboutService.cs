using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.About;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ElearningApi.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public AboutService(
            AppDbContext context,
            IWebHostEnvironment env,
            IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }


        public async Task CreateAsync(AboutCreateDto request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.UploadImage.FileName}";

            string path = Path.Combine(_env.WebRootPath, "img", fileName);


            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.UploadImage.CopyToAsync(stream);
            }


            var about = _mapper.Map<About>(request);
            about.Image = fileName;


            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existAbout = await _context.Abouts.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "img", existAbout.Image);

            if(File.Exists(path))
                File.Delete(path);

            _context.Abouts.Remove(existAbout);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, AboutEditDto request)
        {
            var existAbout = await _context.Abouts.FindAsync(id);
            if(request.UploadImage != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "img", existAbout?.Image);
                if(File.Exists(oldPath))
                    File.Delete($"{oldPath}");

                string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await request.UploadImage.CopyToAsync(stream);
                }

                request.Image = fileName;

            }

            _mapper.Map(existAbout, request);

            await _context.SaveChangesAsync();

        }

        public async Task<List<AboutDto>> GetAllAsync()
        {
            return _mapper.Map<List<AboutDto>>(await _context.Abouts.AsNoTracking().ToListAsync());
        }

        public async Task<AboutDto> GetByIdAsync(int id)
        {
            return _mapper.Map<AboutDto>(await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
