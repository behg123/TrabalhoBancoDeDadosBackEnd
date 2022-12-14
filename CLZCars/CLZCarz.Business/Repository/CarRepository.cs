using Database.Service.Repository;
using Model.Shared.Car;
using Model.Shared.User;

namespace CLZCarz.Business.Repository
{
    public class CarRepository : DatabaseRepository<CarRepository, CarModel>
    {
        protected override void Init()
        {

        }
        public bool Create(CarModel car)
        {
            try
            {
                this.DatabaseConnector.Open();

                try
                {
                    return this.DatabaseConnector.Create(car);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            finally
            {
                this.DatabaseConnector.Close();
            }
        }

        public CarModel? Get(CarModel car)
        {
            try
            {
                this.DatabaseConnector.Open();

                try
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    dictionary.Add("IdCar", car.IdCar);

                    return this.DatabaseConnector.Get<CarModel>(dictionary, car);
                }
                catch (Exception e)
                {
                    if (e.Message == "Sequence contains no elements")
                        return car;
                    throw new Exception(e.Message);
                }
            }
            finally
            {
                this.DatabaseConnector.Close();
            }
        }


        public List<CarModel>? List(List<CarModel>? CarList)
        {
            try
            {
                this.DatabaseConnector.Open();

                try
                {
                    CarModel car = new CarModel();
                    return this.DatabaseConnector.List<CarModel>(car);
                }
                catch (Exception e)
                {
                    if (e.Message == "Sequence contains no elements")
                        return CarList;
                    throw new Exception(e.Message);
                }
            }
            finally
            {
                this.DatabaseConnector.Close();
            }
        }


        public CarModel? Getplate(CarModel car)
        {
            try
            {
                this.DatabaseConnector.Open();

                try
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    dictionary.Add("plate", car.Plate);

                    return this.DatabaseConnector.Get<CarModel>(dictionary, car);
                }
                catch (Exception e)
                {
                    return null;
                    throw new Exception(e.Message);
                }
            }
            finally
            {
                this.DatabaseConnector.Close();
            }
        }


        public bool Update(CarModel car)
        {
            try
            {
                this.DatabaseConnector.Open();
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                dictionary.Add("IdCar", car.IdCar);

                return this.DatabaseConnector.Update<CarModel>(dictionary,car);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                this.DatabaseConnector.Close();
            }
        }


        public bool? Delete(CarModel car)
        {
            try
            {
                this.DatabaseConnector.Open();
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                dictionary.Add("IdCar", car.IdCar);

                return this.DatabaseConnector.Delete(dictionary, car);
            }
            catch (Exception e)
            {
                if (e.Message == "Sequence contains no elements")
                {
                    return null;
                }
                throw new Exception(e.Message);
            }
            finally
            {
                this.DatabaseConnector.Close();
            }
        }
    }
}
