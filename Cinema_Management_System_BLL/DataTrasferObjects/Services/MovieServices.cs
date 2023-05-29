using AutoMapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.EntitiesRepositories.Interfaces;
using Dapper_Data_Access_Layer.GenericRepository_UnitOfWork.Interfaces;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.RequestResultDTO;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Response_Result_DTO;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.DataTrasferObjects.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public MovieServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMovieDTO>> DeleteEntityByIdAsync(Guid ID)
        {
            var result = await _unitOfWork.MovieRepository.DeleteEntityByIdAsync(ID);

            return _mapper.Map<IEnumerable<Movie>, IEnumerable<GetMovieDTO>>(result);
        }

        public async Task<IEnumerable<GetMovieDTO>> GetAllEntityAsync()
        {
            var result = await _unitOfWork.MovieRepository.GetAllEntityAsync();

            return _mapper.Map<IEnumerable<Movie>, IEnumerable<GetMovieDTO>>(result);
        }

        public async Task<GetMovieDTO> GetEntityByIdAsync(Guid ID)
        {
            var result = await _unitOfWork.MovieRepository.GetEntityByIdAsync(ID);

            return _mapper.Map<GetMovieDTO>(result);
        }

        public async Task<IEnumerable<GetMovieDTO>> InsertEntityAsync(InsertMovieDTO entity)
        {
            var result = await _unitOfWork.MovieRepository.InsertEntityAsync(_mapper.Map<Movie>(entity));

            return _mapper.Map<IEnumerable<Movie>, IEnumerable<GetMovieDTO>>(result);
        }

        public async Task<IEnumerable<GetMovieDTO>> UpdateEntityAsync(UpdateMovieDTO entity)
        {
            var result = await _unitOfWork.MovieRepository.UpdateEntityAsync(_mapper.Map<Movie>(entity));

            return _mapper.Map<IEnumerable<Movie>, IEnumerable<GetMovieDTO>>(result);
        }
    }
}
