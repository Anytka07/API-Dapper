using AutoMapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.RequestResultDTO;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Response_Result_DTO;

namespace Movies_Management_System_API.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            this.MoviesMapper();
        }

        private void MoviesMapper()
        {
            CreateMap<Movie, GetMovieDTO>().ReverseMap();
            CreateMap<InsertMovieDTO, Movie>();
            CreateMap<UpdateMovieDTO, Movie>();
        }
            
    }
}
