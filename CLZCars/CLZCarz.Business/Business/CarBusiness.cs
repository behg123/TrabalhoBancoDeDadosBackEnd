using CLZCarz.Business.Repository;
using Library.Shared.Design;
using Model.Shared.Car;
using Model.Shared.User;

namespace CLZCarz.Business.Business
{
    public class CarBusiness : Singleton<CarBusiness>
    {
        private CarRepository repository;

        protected override void Init()
        {

        }

        public CarBusiness()
        {
            this.repository = CarRepository.GetInstance();
        }
        public string CreateCar(CarModel car)
        {
            try
            {
                this.repository.Create(car);
                return ("Carro criado com sucesso");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public CarModel? GetCar(int id)
        {
            try
            {
                CarModel? car = new CarModel();
                if (id > 0)
                {
                    car.IdCar = id;
                    car = this.repository.Get(car);
                    if (car== null || string.IsNullOrEmpty(car.Plate))
                    {
                        throw new Exception(String.Format("Carro com o id {0} não localizado", id));
                    }
                    return car;
                }
                throw new Exception("Valor inválido");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<CarModel> GetAllCar()
        {
            try
            {
                List<CarModel>? carList = new List<CarModel>();
                carList = this.repository.List(carList);
                if (carList == null ||carList.Any() == false)
                {
                    throw new Exception("Nenhum carro registrado");
                }
                return carList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public string UpdateCar(CarModel car)
        {
            try
            {
                CarModel aux = new CarModel();
                aux = GetCar(car.IdCar);
                car.Created = aux.Created;
                this.repository.Update(car);
                return "Atualização bem sucedida";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteCar(int id)
        {
            try
            {
                if (id > 0)
                {
                    CarModel? car = new CarModel();
                    car.IdCar = id;
                    car = this.repository.Get(car);
                    if (car == null || string.IsNullOrEmpty(car.Plate))
                    {
                        throw new Exception("Carro não localizado");
                    }
                    this.repository.Delete(car);
                    return "Carro excluído com exito";
                }
                throw new Exception("Valor inválido");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
