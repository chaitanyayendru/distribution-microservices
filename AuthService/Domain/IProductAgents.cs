namespace AuthService.Domain
{
    public interface IProductAgents
    {
        void Add(ProductAgent agent);

        ProductAgent FindByLogin(string login);
    }
}