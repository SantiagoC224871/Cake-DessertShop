using CakeDessertShop.Data.Entities;
using CakeDessertShop.Enums;
using CakeDessertShop.Helpers;

namespace CakeDessertShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckStatesAsync();
            await CheckRolesAsync();
            await CheckCategoriesAsync();
            await CheckUserAsync("1010", "Santiago", "Carmona", "santiago@yopmail.com", "312 5289621", "Calle xxx", UserType.Admin);
            await CheckUserAsync("2020", "Juan", "Agudelo", "Juan@yopmail.com", "312 5289621", "Calle xxx", UserType.Admin);
            await CheckUserAsync("3030", "Juan", "Zuluaga", "zulu@yopmail.com", "312 5289621", "Calle xxx", UserType.User);
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Postres" });
                _context.Categories.Add(new Category { Name = "Bebidas" });
                _context.Categories.Add(new Category { Name = "Pasteles" });
                _context.Categories.Add(new Category { Name = "Helados" });
                _context.Categories.Add(new Category { Name = "Especialidades de la casa" });
                _context.Categories.Add(new Category { Name = "Cumpleaños" });
                _context.Categories.Add(new Category { Name = "Bodas" });
                _context.Categories.Add(new Category { Name = "Galletas" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    Neighborhood = _context.Neighborhoods.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckStatesAsync()
        {
            if (!_context.States.Any())
            {
                _context.States.Add(new State
                {
                    Name = "Amazonas",
                    Cities = new List<City>()
                    {
                        new City {
                            Name = "Leticia",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "IANE"},
                                new Neighborhood { Name = "Castañal"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Antiqouia",
                    Cities = new List<City>()
                    {
                        new City { Name = "Medellín",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Castilla"},
                                new Neighborhood { Name = "Aranjuez"},
                                new Neighborhood { Name = "Robledo"},
                                new Neighborhood { Name = "Villa Hermosa"},
                                new Neighborhood { Name = "San Antonia Prado"},
                                new Neighborhood { Name = "Guayabal"}
                            }
                        },
                        new City { Name = "Envigado",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "San Lucas"},
                                new Neighborhood { Name = "Milan"}
                            }
                        },
                        new City { Name = "Itagüí",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Ditaires"},
                                new Neighborhood { Name = "Pilsen"}
                            }
                        },
                        new City { Name = "Sabaneta",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Santa Ana"},
                                new Neighborhood { Name = "Palenque"}
                            }
                        }
                    }

                });
                _context.States.Add(new State
                {
                    Name = "Arauca",
                    Cities = new List<City>()
                    {
                        new City { Name = "Arauca",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Unión"},
                                new Neighborhood { Name = "El bosque"},
                                new Neighborhood { Name = "La chorrera"},
                                new Neighborhood { Name = "Bella Vista"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Atlántico",
                    Cities = new List<City>()
                    {
                        new City { Name = "Barranquilla",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Bellavista"},
                                new Neighborhood { Name = "Barranquillita"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Bolívar",
                    Cities = new List<City>()
                    {
                        new City { Name = "Cartagena",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "El Centro"},
                                new Neighborhood { Name = "Getsemaní"},
                                new Neighborhood { Name = "La Matuna"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Boyacá",
                    Cities = new List<City>()
                    {
                        new City { Name = "Tunja",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Santa Ana"},
                                new Neighborhood { Name = "Asis Boyacense"},
                                new Neighborhood { Name = "Santa Catalina"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Caldas",
                    Cities = new List<City>()
                    {
                        new City { Name = "Manizales",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Bella Montaña"},
                                new Neighborhood { Name = "Sacatin"},
                                new Neighborhood { Name = "Chipre"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Caquetá",
                    Cities = new List<City>()
                    {
                       new City { Name = "Florencia",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Malvinas"},
                                new Neighborhood { Name = "Buenos Aires Bajos"},
                                new Neighborhood { Name = "Puente Lopez"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Casanare",
                    Cities = new List<City>()
                    {
                        new City { Name = "Yopal",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Torres del Cubarro"},
                                new Neighborhood { Name = "El Cimarrón"},
                                new Neighborhood { Name = "Los Naranjos"},
                                new Neighborhood { Name = "	La Independencia"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Cauca",
                    Cities = new List<City>()
                    {
                        new City { Name = "Popayán",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Modelo"},
                                new Neighborhood { Name = "Loma Linda"},
                                new Neighborhood { Name = "Prados del Norte"},
                                new Neighborhood { Name = "La Cabaña"},
                                new Neighborhood { Name = "Santa Clara"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Cesar",
                    Cities = new List<City>()
                    {
                        new City { Name = "Valledupar",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Altagracia"},
                                new Neighborhood { Name = "La Garita"},
                                new Neighborhood { Name = "El Centro"},
                                new Neighborhood { Name = "El Cerezo"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Chocó",
                    Cities = new List<City>()
                    {
                       new City { Name = "Quibdó",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Alto Munguidó"},
                                new Neighborhood { Name = "Barranco"},
                                new Neighborhood { Name = "Bellaluz"},
                                new Neighborhood { Name = "Calahorra"},
                                new Neighborhood { Name = "Boca de Nemotá"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Córdoba",
                    Cities = new List<City>()
                    {
                        new City { Name = "Montería",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Nariño"},
                                new Neighborhood { Name = "Montería Moderno"},
                                new Neighborhood { Name = "El Centro"},
                                new Neighborhood { Name = "La Ceiba"},
                                new Neighborhood { Name = "Ospina Pérez"},
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Cundinamarca",
                    Cities = new List<City>()
                    {
                       new City { Name = "Bogotá",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Usaquén"},
                                new Neighborhood { Name = "Chapinero"},
                                new Neighborhood { Name = "Santa Fe"},
                                new Neighborhood { Name = "San Cristóbal"},
                                new Neighborhood { Name = "Usme"},
                                new Neighborhood { Name = "Tunjuelito"},
                                new Neighborhood { Name = "Bosa"},
                                new Neighborhood { Name = "Kennedy"},
                                new Neighborhood { Name = "Fontibón"},
                                new Neighborhood { Name = "Engativá"},
                                new Neighborhood { Name = "Suba"},
                                new Neighborhood { Name = "Barrios Unidos"},
                                new Neighborhood { Name = "Teusaquillo"},
                                new Neighborhood { Name = "Mártires"},
                                new Neighborhood { Name = "Antonio Nariño"},
                                new Neighborhood { Name = "Puente Aranda"},
                                new Neighborhood { Name = "La Candelaria"},
                                new Neighborhood { Name = "Rafael Uribe Uribe"},
                                new Neighborhood { Name = "Ciudad Bolívar"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Guainía",
                    Cities = new List<City>()
                    {
                        new City { Name = "Puerto Inírida",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Inírida"},
                                new Neighborhood { Name = "Barranco Minas"},
                                new Neighborhood { Name = "Mapiripana"},
                                new Neighborhood { Name = "Morichal Nuevo"},
                                new Neighborhood { Name = "Cacahual"},
                                new Neighborhood { Name = "Pana Pana"},
                                new Neighborhood { Name = "San Felipe"},
                                new Neighborhood { Name = "La Guadalupe"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Guaviare",
                    Cities = new List<City>()
                    {
                        new City { Name = "San José del Guaviare",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "San José del Guaviare"},
                                new Neighborhood { Name = "El Retorno"},
                                new Neighborhood { Name = "Calamar"},
                                new Neighborhood { Name = "Miraflores"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Huila",
                    Cities = new List<City>()
                    {
                        new City { Name = "Neiva",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Aipecito"},
                                new Neighborhood { Name = "Chapinero"},
                                new Neighborhood { Name = "San Luis"},
                                new Neighborhood { Name = "Guacirco"},
                                new Neighborhood { Name = "Fortalecillas"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "La Guajira",
                    Cities = new List<City>()
                    {
                        new City { Name = "Riohacha",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Obrero"},
                                new Neighborhood { Name = "20 de julio"},
                                new Neighborhood { Name = "San Francisco"},
                                new Neighborhood { Name = "Rojas Pinilla"},
                                new Neighborhood { Name = "La Loma"},
                                new Neighborhood { Name = "Calancala"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Magdalena",
                    Cities = new List<City>()
                    {
                        new City { Name = "Santa Marta",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "El Pueblito"},
                                new Neighborhood { Name = "El Territorial"},
                                new Neighborhood { Name = "La Esperanza"},
                                new Neighborhood { Name = "Santa Helena"},
                                new Neighborhood { Name = "Los Troncos"},
                                new Neighborhood { Name = "Perehuétano"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Meta",
                    Cities = new List<City>()
                    {
                        new City { Name = "Villavicencio",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "La Esperanza"},
                                new Neighborhood { Name = "Paraíso"},
                                new Neighborhood { Name = "Cooperativo"},
                                new Neighborhood { Name = "Jardín"},
                                new Neighborhood { Name = "Cambulos"},
                                new Neighborhood { Name = "Santa Marta"},
                                new Neighborhood { Name = "Los Centauros"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Nariño",
                    Cities = new List<City>()
                    {
                        new City { Name = "Pasto",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Unión"},
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Norte de Santander",
                    Cities = new List<City>()
                    {
                        new City { Name = "Cúcuta",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Ciudadela Atalaya"},
                                new Neighborhood { Name = "Ciudadela La Libertad"},
                                new Neighborhood { Name = "Comuna del centro"},
                                new Neighborhood { Name = "Aeropuerto"},
                                new Neighborhood { Name = "Aniversario Uno"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Putumayo",
                    Cities = new List<City>()
                    {
                        new City { Name = "Mocoa" }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Quindío",
                    Cities = new List<City>()
                    {
                        new City { Name = "Armenia",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Centenario"},
                                new Neighborhood { Name = "Rufino José Cuervo Sur"},
                                new Neighborhood { Name = "Alfonso López"},
                                new Neighborhood { Name = "Francisco de Paula Santander"},
                                new Neighborhood { Name = "El Bosque"},
                                new Neighborhood { Name = "San José"},
                                new Neighborhood { Name = "El Cafetero"},
                                new Neighborhood { Name = "Libertadores"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Risaralda",
                    Cities = new List<City>()
                    {
                        new City { Name = "Pereira",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Ferrocarril"},
                                new Neighborhood { Name = "Olímpica"},
                                new Neighborhood { Name = "San Joaquín"},
                                new Neighborhood { Name = "Cuba"},
                                new Neighborhood { Name = "Del Café"},
                                new Neighborhood { Name = "El Oso"},
                                new Neighborhood { Name = "Perla del Otún"},
                                new Neighborhood { Name = "Consotá"},
                                new Neighborhood { Name = "El Rocío"},
                                new Neighborhood { Name = "El Poblado"},
                                new Neighborhood { Name = "El Jardín"},
                                new Neighborhood { Name = "San Nicolás"},
                                new Neighborhood { Name = "Centro"},
                                new Neighborhood { Name = "Río Otún"},
                                new Neighborhood { Name = "Boston"},
                                new Neighborhood { Name = "Universidad"},
                                new Neighborhood { Name = "Villavicencio"},
                                new Neighborhood { Name = "Oriente"},
                                new Neighborhood { Name = "Villasantana"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "San Andrés y Providencia",
                    Cities = new List<City>()
                    {
                        new City { Name = "San Andrés",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Tablitas"},
                                new Neighborhood { Name = "Modelo"},
                                new Neighborhood { Name = "Natania"},
                                new Neighborhood { Name = "Back Road"},
                                new Neighborhood { Name = "Atlantico"},
                                new Neighborhood { Name = "Slave Hill"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Santander",
                    Cities = new List<City>()
                    {
                        new City { Name = "Bucaramanga",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Cabecera del Llano"},
                                new Neighborhood { Name = "Sotomayor"},
                                new Neighborhood { Name = "Antiguo Campestre"},
                                new Neighborhood { Name = "Bolarquí"},
                                new Neighborhood { Name = "Mercedes"},
                                new Neighborhood { Name = "Puerta del Sol"},
                                new Neighborhood { Name = "Conucos"},
                                new Neighborhood { Name = "El Jardín"},
                                new Neighborhood { Name = "Pan de Azúcar"},
                                new Neighborhood { Name = "Los Cedros"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Sucre",
                    Cities = new List<City>()
                    {
                        new City { Name = "Sincelejo",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Las Huertas"},
                                new Neighborhood { Name = "San Antonio"},
                                new Neighborhood { Name = "Buenavista"},
                                new Neighborhood { Name = "Buena vistica"},
                                new Neighborhood { Name = "Babilonia"},
                                new Neighborhood { Name = "San Jacinto"},
                                new Neighborhood { Name = "Cerro del Naranjo"},
                                new Neighborhood { Name = "San Martín"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Tolima",
                    Cities = new List<City>()
                    {
                        new City { Name = "Ibagué",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Centro"},
                                new Neighborhood { Name = "Calambeo"},
                                new Neighborhood { Name = "San Simón​"},
                                new Neighborhood { Name = "Piedrapintada"},
                                new Neighborhood { Name = "Jordán"},
                                new Neighborhood { Name = "Vergel"},
                                new Neighborhood { Name = "Salado"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Valle del Cauca	",
                    Cities = new List<City>()
                    {
                        new City { Name = "Cali",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "San Cayetano"},
                                new Neighborhood { Name = "Centenario"},
                                new Neighborhood { Name = "El Limonar"},
                                new Neighborhood { Name = "El Peñón"},
                                new Neighborhood { Name = "La Merced"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Vaupés",
                    Cities = new List<City>()
                    {
                        new City { Name = "Mitú",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Inaya"},
                                new Neighborhood { Name = "San José"},
                                new Neighborhood { Name = "Belarmino"},
                                new Neighborhood { Name = "La Floresta"}
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Vichada",
                    Cities = new List<City>()
                    {
                        new City { Name = "Puerto Carreño" }
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
