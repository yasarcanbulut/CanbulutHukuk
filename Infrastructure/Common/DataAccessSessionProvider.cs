using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CanbulutHukuk.Infrastructure.Common
{
    public class DataAccessSessionProvider : IDataAccessSessionProvider
    {
        private const string USER_SESSION_NAME = "LoggedInUser";
        ILoggedInUser _user;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public DataAccessSessionProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ILoggedInUser LoggedInUser
        {
            get { _user = _user ?? JsonConvert.DeserializeObject<LoggedInUser>(_session.GetString(USER_SESSION_NAME)); return _user; }
        }
    }

    public interface IDataAccessSessionProvider
    {
        ILoggedInUser LoggedInUser { get; }
    }
}
