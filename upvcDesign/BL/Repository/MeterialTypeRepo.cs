using BL.Services;
using DAL.Madals;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class MeterialTypeRepo : IMeterialTypeRepo
    {
        IMeterialTypeRepository _repo;
        public MeterialTypeRepo(IMeterialTypeRepository repo)
        {
            _repo = repo;
        }
        public async Task<string> DeleteMaterialType(string id)
        {
            var clt = await _repo.GetMaterialTypeByName(id);
            if (clt != null)
            {
                var res = await _repo.DeleteMaterialType(clt.Id);
                if (res)
                {
                    return "Material Type data Deletion successfull";
                }
                else
                {
                    return "Material Type data Deletion Fails";
                }

            }
            else
            {
                return "Material Type does Not exists";
            }
        }

        public async Task<IEnumerable<MeterialType>> GetMaterialType()
        {
            return await _repo.GetMaterialType();
        }

        public async Task<MeterialType> GetMaterialTypeByName(string name)
        {
            return await _repo.GetMaterialTypeByName(name);
        }

        public async Task<MeterialType> GetMaterialTypeID(string ID)
        {
            return await _repo.GetMaterialTypeID(ID);
        }

        public async Task<string> InserMaterialType(MeterialType _typ)
        {
            var adm = await _repo.GetMaterialTypeByName(_typ.name);
            if (adm == null)
            {
                var res = await _repo.InserMaterialType(_typ);
                if (res)
                {
                    return "Material Type data insertion successfull";
                }
                else
                {
                    return "Material Type data insertion Fails";
                }

            }
            else
            {
                return "Material Type Name already exists";
            }
        }

        public async Task<string> UpdateMaterialType(MeterialType _typ)
        {
            var adm = await _repo.GetMaterialTypeByName(_typ.name);
            if (adm != null)
            {
                _typ.Id = adm.Id;
                var res = await _repo.UpdateMaterialType(_typ);
                if (res)
                {
                    return "Material Type data Updation successfull";
                }
                else
                {
                    return "Material Type data Updation Fails";
                }

            }
            else
            {
                return "Material Type Name Not exists";
            }
        }
    }
}
