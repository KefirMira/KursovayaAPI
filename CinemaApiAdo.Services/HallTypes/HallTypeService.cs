using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.DB;
using CinemaApiADO.Models.HallsTypes.Domain;

namespace CinemaApiAdo.Services.HallTypes;

public class HallTypeService : IHallTypeService
{
    private readonly HallTypeRepository _repository;

    public HallTypeService()
    {
        _repository = new HallTypeRepository();
    }

    public IEnumerable<HallTypeDomain> GetAllHallType()
    {
        IEnumerable<HallTypeDB> allhalltypes = _repository.GetAllHallType();
        return HallTypeDomain.Convert(allhalltypes);
    }

    public bool CreateHallType(HallTypeBlank hallTypeBlank)
    {
        try
        {
            HallTypeDB newHallType = HallTypeDB.Convert(hallTypeBlank);
            _repository.CreateHallType(newHallType);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateHallType(int halltypeId, HallTypeBlank hallTypeBlank)
    {
        try
        {
            HallTypeDB updateHallType = HallTypeDB.Convert(halltypeId, hallTypeBlank);
            _repository.UpdateHallType(updateHallType);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteHallType(int halltypeId)
    {
        try
        {
            _repository.DeleteHallType(halltypeId);
            return true;
        }
        catch
        {
            return false;
        }
    }
}