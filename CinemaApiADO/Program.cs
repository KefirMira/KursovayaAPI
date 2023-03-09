using CinemaApiAdo.Services.Cinemas;
using CinemaApiAdo.Services.Clients;
using CinemaApiAdo.Services.Companies;
using CinemaApiAdo.Services.FilmProductions;
using CinemaApiAdo.Services.Films;
using CinemaApiAdo.Services.Genres;
using CinemaApiAdo.Services.Halls;
using CinemaApiAdo.Services.HallTypes;
using CinemaApiAdo.Services.PaymentsMethods;
using CinemaApiAdo.Services.Rentals;
using CinemaApiAdo.Services.Roles;
using CinemaApiAdo.Services.Sessions;
using CinemaApiAdo.Services.SessionsTypes;
using CinemaApiAdo.Services.Tickets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IHallTypeService, HallTypeService>();
builder.Services.AddScoped<IFilmProductionService, FilmProductionService>();
builder.Services.AddScoped<ISessionTypeService, SessionTypeService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IHallService, HallService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();