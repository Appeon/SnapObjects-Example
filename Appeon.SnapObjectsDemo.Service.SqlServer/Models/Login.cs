using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [SqlParameter("firstname", typeof(string))]
    [SqlParameter("lastname", typeof(string))]
    [SqlParameter("password", typeof(string))]
    [Table("Person", Schema = "Person")]
    [JoinTable("Password",Schema ="Person",JoinType =SqlJoinType.Left,OnRaw = "Person.BusinessEntityID = Password.BusinessEntityID")]
    [SqlWhere("Person.FirstName=:firstname and Person.LastName=:lastname")]
    [SqlAndWhere("Password.PasswordSalt=:password")]
    public class Login
    {
        public String Firstname { get; set; }

        public String Middlename { get; set; }

        public String Lastname { get; set; }

        public String Password { get; set; }
    }
}
