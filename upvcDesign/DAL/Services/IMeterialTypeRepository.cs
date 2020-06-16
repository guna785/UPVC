using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IMeterialTypeRepository
    {
        Task<MeterialType> GetMaterialTypeID(string ID);
        Task<MeterialType> GetMaterialTypeByName(string name);
        Task<IEnumerable<MeterialType>> GetMaterialType();

        Task<bool> InserMaterialType(MeterialType _typ);
        Task<bool> UpdateMaterialType(MeterialType _typ);
        Task<bool> DeleteMaterialType(string id);
    }
}
