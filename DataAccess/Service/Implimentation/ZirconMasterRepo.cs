using DataAccess.DbAccess;
using DataAccess.Service.Interface;
using Models;

namespace DataAccess.Service.Implimentation
{
    public class ZirconMasterRepo(ApplicationDbContext context) : Repository<ZirconMaster>(context), IZirconMasterRepo
    {
    }
}
