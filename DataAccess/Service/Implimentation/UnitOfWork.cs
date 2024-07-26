using DataAccess.DbAccess;
using DataAccess.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Service.Implimentation
{
	public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
	{
		private readonly ApplicationDbContext _context = context;

		public IEquipmentDetailRepo EquipmentDeatilRepo { get; private set; } = new EquipmentDetailRepo(context);

		public IZirconMasterRepo ZirconMasterRepo { get; private set; } = new ZirconMasterRepo(context);

		public void Save()
		{
			_context.SaveChanges();
		}
		
	}
}
