using System.Collections.Generic;
using System.Linq;

namespace CanbulutHukuk.Infrastructure.Common
{
    public class LoggedInUser : ILoggedInUser
    {
        public LoggedInUser(long id, string username, string name,string email, decimal? tcKimlikNo, long islemYapanId, List<Permission> permissions)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            TcKimlikNo = tcKimlikNo;
            IslemYapanId = islemYapanId;
            Permissions = permissions;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public decimal? TcKimlikNo { get; private set; }
        public long IslemYapanId { get; private set; }
        public List<Permission> Permissions { get; private set; }
    }

    public interface ILoggedInUser
    {
        long Id { get; }
        string Name { get; }
        string Username { get; }
        string Email { get; }
        decimal? TcKimlikNo { get; }
        long IslemYapanId { get; }
        List<Permission> Permissions { get; }
    }

    public class Permission
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }
}