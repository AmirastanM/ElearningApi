using AutoMapper;
using ElearningApi.DTOs.About;
using ElearningApi.DTOs.Categories;
using ElearningApi.DTOs.Courses;
using ElearningApi.DTOs.Informations;
using ElearningApi.DTOs.Instructors;
using ElearningApi.DTOs.Sliders;
using ElearningApi.Models;


namespace ElearningApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<About, AboutDto>();
            CreateMap<AboutCreateDto, About>();
            CreateMap<AboutEditDto, About>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is not null)));

            CreateMap<Slider, SliderDto>();
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<SliderEditDto, Slider>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is not null)));

            CreateMap<Information, InformationDto>();
            CreateMap<InformtationCreateDto, Information>();
            CreateMap<InformationEditDto, Information>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is not null)));

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryEditDto, Category>();

            CreateMap<Course, CourseDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(d => d.Instructor, opt => opt.MapFrom(s => s.Instructor.FullName))
                .ForMember(d => d.Images, opt => opt.MapFrom(s => s.CourseImages.Select(i => new CourseImageDto
                {
                    Name = i.Name,
                    IsMain = i.IsMain
                }).ToList()));
            CreateMap<Course, CourseImageDto>();
            CreateMap<Course, DeleteAndMainDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseEditDto, Course>();

            CreateMap<Instructor, InstructorDto>();
            CreateMap<InstructorCreateDto, Instructor>();
            CreateMap<InstructorEditDto, Instructor>();
        }
    
    }
}
