using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IVehicleMasterRepository<VehicleMaster>
    {
        IEnumerable<VehicleMaster> GetAllVehicle();
        VehicleMaster GetVehicleByCode(int code);
        bool SaveVehicle(VehicleMaster vehicleMaster);
        bool DeleteVehicle(VehicleMaster vehicleMaster);
        bool UpdateVehicle(VehicleMaster vehicleMaster);

    }
}
