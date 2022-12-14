using Model.Shared.Validation;
using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Shared.Target;
using System.ComponentModel;
using FluentNHibernate.Mapping;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Model.Shared.User
{
    public class LoginModelMap : ClassMap<LoginModel>
    {
        public LoginModelMap()
        {
            Table("Login");
            Id(login => login.IdLogin).Not.Nullable().UniqueKey("IdLogin").GeneratedBy.Increment();
            Map(login => login.Name).Not.Nullable().Length((int)DataTypeLenght.Name);
            Map(login => login.Email).Not.Nullable().Length((int)DataTypeLenght.Email);
            Map(login => login.Password).Not.Nullable().Length((int)DataTypeLenght.Description);
            Map(login => login.Updated).Nullable();
            Map(login => login.Created).Not.Nullable();
        }
    }

    public class LoginModel : SQLServer
    {
        [JsonIgnore]
        public virtual ObjectId? _id { get; set; } = null;
        
        [JsonIgnore]
        public virtual int IdLogin { get; set; } = 0;

        [nameValidation]
        public virtual string Name { get; set; } = "";
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public virtual string Email { get; set; } = "";
        [passwordValidation]
        public virtual string Password { get; set; } = "";
        [JsonIgnore]
        public virtual DateTime? Updated { get; set; }
        [JsonIgnore]
        public virtual DateTime Created { get; set; }
        public virtual string Entity { get; } = "Login";


    }

}
