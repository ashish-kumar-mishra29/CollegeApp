using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Dto;

namespace CollegeApp.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<studentDto, Student>().ReverseMap();
        //If the name field is different in the dto and the model class at that time we need to map
        // for that we need to use formember.
        //CreateMap<studentDto, Student>().ForMember(n => n.StudentName,opt => opt.MapFrom(x =>x.Name)).ReverseMap();
        
        //configuration for ignoring the field
        //CreateMap<studentDto, Student>().ReverseMap().ForMember( n=>n.StudentName,opt=>opt.Ignore());
        
        //Transforming the field if it is null 
        /*CreateMap<studentDto, Student>().ReverseMap().ForMember(n => n.Address,
            opt => opt.MapFrom(n => string.IsNullOrEmpty(n.Address) ? "No data found" : n.Address));
            */

    }
}