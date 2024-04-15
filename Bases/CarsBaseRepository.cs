
using CarModelManagement_CommonServices.Context.CarModelManagementModel;

namespace CarModelManagement_CommonServices.Repositories.Bases
{
    public class CarsBaseRepository
    {
         protected readonly CarsContext _context;

        public CarsBaseRepository(CarsContext context){
            _context = context;
        }
        
    }
}
