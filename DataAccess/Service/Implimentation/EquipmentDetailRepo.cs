using DataAccess.DbAccess;
using DataAccess.Service.Interface;
using Models;

namespace DataAccess.Service.Implimentation
{
    public class EquipmentDetailRepo(ApplicationDbContext context) : Repository<EquipmentDetail>(context), IEquipmentDetailRepo
    {
    }
}
