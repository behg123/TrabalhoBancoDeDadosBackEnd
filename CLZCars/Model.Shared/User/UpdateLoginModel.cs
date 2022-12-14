using Model.Shared.Validation;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Shared.User
{
    public class UpdateLoginModel
    {
        [JsonIgnore]
        public virtual ObjectId? _id { get; set; } = null;
        
        public virtual int IdLogin { get; set; } 

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
