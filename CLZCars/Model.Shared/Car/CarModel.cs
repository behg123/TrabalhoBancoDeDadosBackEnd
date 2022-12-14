using FluentNHibernate.Mapping;
using Model.Shared.Target;
using Model.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Shared.Car
{

    public class CarModelMap : ClassMap<CarModel>
    {
        public CarModelMap()
        {
            Table("Car");
            Id(login => login.IdCar).Not.Nullable().UniqueKey("IdCar").GeneratedBy.Increment();
            Map(login => login.ModelCar).Not.Nullable().Length((int)DataTypeLenghtCar.ModelCar);
            Map(login => login.CarBrand).Not.Nullable().Length((int)DataTypeLenghtCar.CarBrand);
            Map(login => login.Plate).Not.Nullable().Length((int)DataTypeLenghtCar.Plate);
            Map(login => login.Updated).Nullable();
            Map(login => login.Created).Not.Nullable();
        }
    }
    public class CarModel : SQLServer
    {

        public virtual int IdCar { get; set; } = 0;
        public virtual string ModelCar { get; set; } = "";
        public virtual string CarBrand { get; set; } = "";
        public virtual string Plate { get; set; } = "";
        [JsonIgnore]
        public virtual DateTime? Updated { get; set; }
        [JsonIgnore]
        public virtual DateTime Created { get ; set ; }

        public virtual string Entity { get;} = "Car";
    }
}
