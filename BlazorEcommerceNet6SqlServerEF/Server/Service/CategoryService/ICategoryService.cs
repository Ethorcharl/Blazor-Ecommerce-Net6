namespace BlazorEcommerceNet6SqlServerEF.Server.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategories();
    }
}
