namespace SuperGroup.Domain.IContractManagers
{
    public interface IRepository<in TId, TModel> where TModel : class
    {
        TModel GetAll();
    }
}