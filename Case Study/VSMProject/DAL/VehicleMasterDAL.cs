using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VehicleMasterDAL : IVehicleMasterRepository<VehicleMaster>
    {
        public bool DeleteVehicle(VehicleMaster vehicleMaster)
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    var vehicle = dbContext.VehicleMasters.Where(x => x.CustId == vehicleMaster.CustId).FirstOrDefault();
                    dbContext.VehicleMasters.Remove(vehicle);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<VehicleMaster> GetAllVehicle()
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    var vehicles = dbContext.VehicleMasters.ToList();
                    return vehicles;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public VehicleMaster GetVehicleByCode(int code)
        {
            throw new NotImplementedException();
        }

        public bool SaveVehicle(VehicleMaster vehicleMaster)
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    dbContext.VehicleMasters.Add(vehicleMaster);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateVehicle(VehicleMaster vehicleMaster)
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    var oldVehicle = dbContext.VehicleMasters.Where(x => x.CustId == vehicleMaster.CustId).FirstOrDefault();
                    oldVehicle.ModalNo = vehicleMaster.ModalNo;
                    oldVehicle.ModalName = vehicleMaster.ModalName;
                    oldVehicle.ModalYear = vehicleMaster.ModalYear;
                    oldVehicle.VehicleType = vehicleMaster.VehicleType;
                    oldVehicle.SoldDate = vehicleMaster.SoldDate;
                    oldVehicle.ServiceSchedule = vehicleMaster.ServiceSchedule;
                    oldVehicle.CustId = vehicleMaster.CustId;
                    dbContext.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
