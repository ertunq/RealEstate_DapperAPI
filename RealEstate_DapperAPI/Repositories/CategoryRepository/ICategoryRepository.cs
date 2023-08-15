using RealEstate_DapperAPI.Models.Dtos.CategoryDtos;

namespace RealEstate_DapperAPI.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto createCategoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<GetByIdCategoryDto> GetCategory(int id);
    }
}
