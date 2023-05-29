using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.RequestResultDTO;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Response_Result_DTO;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Movies_Management_System_API.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase   
    {
        private readonly IMovieServices _MovieServices;

        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieServices movieServices, ILogger<MovieController> logger)
        {
            _MovieServices = movieServices;

            _logger = logger;
        }

        /// <summary>
        /// Fetching all information from Movie table 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Get_all_Movies")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetMovieDTO>>> GetAllMoviesAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all information from Movie table...");

                var result = await _MovieServices.GetAllEntityAsync();
                
                _logger.LogInformation("Everything is good! Operations is Succesfull!");

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {GetAllMoviesAsync().GetType().Name} method!");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Fetching the Movie with by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet, Route("Get_Movie_ID/{ID}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetMovieDTO>> GetMovieByIdAsync(Guid ID)
        {
            try
            {
                _logger.LogInformation($"Fetching the Employee with {ID} ID...");

                var result = await _MovieServices.GetEntityByIdAsync(ID);

                if (result is null) 
                {
                    _logger.LogInformation($"The Entity with {ID} ID was not found in table Movie!!!");
                    return StatusCode(StatusCodes.Status404NotFound); 
                }

                _logger.LogInformation("Everything is good! Operations is Succesfull!");

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {GetMovieByIdAsync(ID).GetType().Name} method!");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Inserting the Movie to the table
        /// </summary>
        /// <param name="Movie"></param>
        /// <returns></returns>
        [HttpPost, Route("Insert_Movies/Movie")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetMovieDTO>>> InsertMovieAsync([FromBody] InsertMovieDTO Movie)
        {
            try
            {
                _logger.LogInformation($"Inserting the Employee to the table...");
                var result = await _MovieServices.InsertEntityAsync(Movie);

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {InsertMovieAsync(Movie).GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Updating the Movie to the table
        /// </summary>
        /// <param name="Movie"></param>
        /// <returns></returns>
        [HttpPut, Route("Update_Movies/Movie")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetMovieDTO>>> UpdateMovieAsync([FromBody] UpdateMovieDTO Movie)
        {
            try
            {
                _logger.LogInformation($"Updating the Employee to the table...");

                var result = await _MovieServices.UpdateEntityAsync(Movie);

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {UpdateMovieAsync(Movie).GetType().Name} method!");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Deleting the Movie to the table
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete, Route("Delete_Movie/{ID}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetMovieDTO>>> DeleteMovieAsync(Guid ID)
        {
            try
            {
                _logger.LogInformation($"Deleting the Employee to the table...");
                var result = await _MovieServices.DeleteEntityByIdAsync(ID);

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {DeleteMovieAsync(ID).GetType().Name} method!");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
