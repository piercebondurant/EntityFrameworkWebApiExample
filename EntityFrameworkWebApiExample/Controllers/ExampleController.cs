using EntityFrameworkWebApiExample.Examples;
using EntityFrameworkWebApiExample.Examples.Commands;
using EntityFrameworkWebApiExample.Repositories.Models;
using EntityFrameworkWebApiExample.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkWebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ExampleRepository _exampleRepository;
        public ExampleController(ExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        [HttpPost]
        public async Task<ExampleViewModel> Create([FromBody] CreateExampleCommand request)
        {
            var exampleModel = new ExampleModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };

            var result = await _exampleRepository.Create(exampleModel);

            var createExampleResponseViewModel = new ExampleViewModel
            {
                ExampleID = result.ExampleID,
                FirstName = result.FirstName,
                LastName = result.LastName
            };

            return createExampleResponseViewModel;
        }

        [HttpGet]
        public async Task<List<ExampleModel>> GetAll()
        {
            var result = await _exampleRepository.GetAll();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ExampleModel> GetByID([FromRoute] int id)
        {
            var result = await _exampleRepository.GetByID(id);

            return result;
        }

        [HttpPut]
        public async Task<ExampleModel> Update([FromBody] ExampleModel exampleModel)
        {
            var result = await _exampleRepository.Update(exampleModel);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete([FromRoute] int id)
        {
            var result = await _exampleRepository.Delete(id);
            
            return result;
        }

    }
}
