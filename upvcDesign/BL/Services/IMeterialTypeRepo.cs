using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IMeterialTypeRepo
    {
        Task<MeterialType> GetMaterialTypeID(string ID);
        Task<MeterialType> GetMaterialTypeByName(string name);
        Task<IEnumerable<MeterialType>> GetMaterialType();

        Task<string> InserMaterialType(MeterialType _typ);
        Task<string> UpdateMaterialType(MeterialType _typ);
        Task<string> DeleteMaterialType(string id);

    }
}
