using NPoco;

namespace CanbulutHukuk.Infrastructure.DataAccess.Factories
{
    public interface IDbFactory
    {
        IDatabase Init();
    }
}
