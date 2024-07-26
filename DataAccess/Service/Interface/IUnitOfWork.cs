using Models;

namespace DataAccess.Service.Interface
{
	public interface IUnitOfWork
	{
		IEquipmentDetailRepo EquipmentDeatilRepo { get; }
		IZirconMasterRepo ZirconMasterRepo { get; }
		public void Save();

	}
}
