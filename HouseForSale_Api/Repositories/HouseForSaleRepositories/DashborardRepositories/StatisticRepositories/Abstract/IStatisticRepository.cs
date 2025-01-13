namespace HouseForSale_Api.Repositories.HouseForSaleRepositories.DashborardRepositories.StatisticRepositories.Abstract
{
    public interface IStatisticRepository
    {
        int ProductCountByEmployeeId(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();
    }
}