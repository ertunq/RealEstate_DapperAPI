using RealEstate_DapperAPI.Models.DapperContext;
using RealEstate_DapperAPI.Models.Dtos.CategoryDtos;
using Dapper;

namespace RealEstate_DapperAPI.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto createCategoryDto)
        {
            string sql = "INSERT INTO Category (CategoryName,CategoryStatus) VALUES (@CategoryName,@CategoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", createCategoryDto.CategoryName);
            parameters.Add("@CategoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
            }

        }

        public async void DeleteCategory(int id)
        {
            string sql = "DELETE FROM Category WHERE CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public  Task<GetByIdCategoryDto> GetCategory(int id)
        {
            string query = "Select * from Category where CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return values;
            } 
        }

        public void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string query = "UPDATE Category SET CategoryName = @CategoryName, CategoryStatus = @CategoryStatus WHERE CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", updateCategoryDto.CategoryID);
            parameters.Add("@CategoryName", updateCategoryDto.CategoryName);
            parameters.Add("@CategoryStatus", updateCategoryDto.CategoryStatus);
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
