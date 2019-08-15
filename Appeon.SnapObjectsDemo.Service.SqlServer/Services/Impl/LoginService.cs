using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;
using SnapObjects.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
            String[] userNames = userName.Split('.');
            String firstName = userNames[0];
            String lastName = userNames[1];
            String pwd = password;

            return this._context.SqlModelMapper.Exists<Login>(firstName, lastName, pwd);
        }

        public bool UserIsExist(string userName)
        {
            //prepare parameter
            String[] userNames = userName.Split('.');
            String firstName = userNames[0];
            String lastName = userNames[1];

            //init sql query build
            SqlQueryBuilder sqlQueryBuilder = new SqlQueryBuilder();
            sqlQueryBuilder.Select("*")
                .From("Person.Person")
                .Where("FirstName", SqlBuilder.Parameter<string>("firstName"))
                .AndWhere("LastName", SqlBuilder.Parameter<string>("lastName"));

            String sql = sqlQueryBuilder.ToSqlString(this._context);

            //execute sql
            var dynamicModel = this._context.SqlExecutor.Select<DynamicModel>(sql, firstName, lastName);
            if (dynamicModel.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
