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

    public void CreateHallType(HallTypeBlank hallTypeBlank)
    {
        HallTypeDB newHallType = HallTypeDB.Convert(hallTypeBlank);
        _repository.CreateHallType(newHallType);
    }

    public void UpdateHallType(int halltypeId, HallTypeBlank hallTypeBlank)
    {
        HallTypeDB updateHallType = HallTypeDB.Convert(halltypeId,hallTypeBlank);
        _repository.UpdateHallType(updateHallType);
    }

    public void DeleteHallType(int halltypeId)
    {
        _repository.DeleteHallType(halltypeId);
    }
}