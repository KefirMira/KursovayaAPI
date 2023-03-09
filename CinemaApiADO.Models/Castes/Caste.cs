using CinemaApiADO.Models.FilmProductions.DB;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Roles.DB;

namespace CinemaApiADO.Models.Castes;

public class Caste
{
    public int Id { get; set; }
    public FilmDB? Film { get; set; } = new FilmDB();
    public RoleDB? Role { get; set; } = new RoleDB();
    public FilmProductionDB? FilmProd { get; set; } = new FilmProductionDB();
    public int filmId { get; set; }
    public int roleId { get; set; }
    public int filmprodId { get; set; }
}