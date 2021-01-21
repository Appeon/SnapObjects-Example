using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;
using SnapObjects.Data;

namespace Appeon.SnapObjectsDemo.Services
{
    public class LoginService : ILoginService
    {
        private OrderContext _context;
        public LoginService(OrderContext context)

        {
            _context = context;
        }

        public bool Login(string userName, string password)
        {
            var userNames = userName.Split('.');
            var firstName = userNames[0];
            var lastName = userNames[1];
            var pwd = password;

            return _context.SqlModelMapper.Exists<Login>(firstName, lastName, pwd);
        }

        public bool UserIsExist(string userName)
        {
            //prepare parameter
            var userNames = userName.Split('.');
            var firstName = userNames[0];
            var lastName = userNames[1];

            //init sql query build
            var sqlQueryBuilder = new SqlQueryBuilder();
            sqlQueryBuilder.Select("*")
                .From("Person.Person")
                .Where("FirstName", SqlBuilder.Parameter<string>("firstName"))
                .AndWhere("LastName", SqlBuilder.Parameter<string>("lastName"));

            var sql = sqlQueryBuilder.ToSqlString(_context);

            //execute sql
            var dynamicModel = _context.SqlExecutor.Select<DynamicModel>(sql, firstName, lastName);
            if (dynamicModel.Count == 0)
            {
                return false;
            }

            return true;
        }

    }
}
