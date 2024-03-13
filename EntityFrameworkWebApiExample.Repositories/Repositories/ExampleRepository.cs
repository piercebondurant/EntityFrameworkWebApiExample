using EntityFrameworkWebApiExample.Repositories.Context;
using EntityFrameworkWebApiExample.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWebApiExample.Repositories.Repositories
{
    public class ExampleRepository
    {
        private readonly ExampleDbContext _context;
        public ExampleRepository(ExampleDbContext context) 
        {
            _context = context;
        }

        public async Task<ExampleModel> Create(ExampleModel exampleModel)
        {
            await _context.AddAsync(exampleModel);
            
            await _context.SaveChangesAsync();

            return exampleModel;
        }

        public async Task<List<ExampleModel>> GetAll()
        {
            var exampleModels = await _context.Examples.ToListAsync();

            return exampleModels;
        }

        public async Task<ExampleModel> GetByID(int exampleModelID)
        {
            var foundExampleModel = await _context.Examples.FindAsync(exampleModelID);

            return foundExampleModel;
        }


        public async Task<ExampleModel> Update(ExampleModel exampleModel)
        {
            _context.Update(exampleModel);

            await _context.SaveChangesAsync();

            return exampleModel;
        }
        public async Task<bool> Delete(int exampleModelID)
        {
            var foundExampleModel = await _context.Examples.FindAsync(exampleModelID);

            if (foundExampleModel is null)
                throw new Exception("ID not found.");

            _context.Examples.Remove(foundExampleModel);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
