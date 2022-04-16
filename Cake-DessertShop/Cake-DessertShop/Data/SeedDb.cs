using CakeDessertShop.Data.Entities;

namespace CakeDessertShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckStatesAsync();
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
                                new Neighborhood { Name = "Milan"},
                            }
                        },
                        new City { Name = "Itagüí",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Ditaires"},
                                new Neighborhood { Name = "Pilsen"},
                            }
                        },
                        new City { Name = "Sabaneta",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Santa Ana"},
                                new Neighborhood { Name = "Palenque"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Putumayo",
                    Cities = new List<City>()
                    {
                        new City { Name = "Mocoa",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Unión"},
                            }
                        }
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
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
                                new Neighborhood { Name = "Unión"},
                            }
                        }
                    }
                });
                _context.States.Add(new State
                {
                    Name = "Vichada",
                    Cities = new List<City>()
                    {
                        new City { Name = "Puerto Carreño",
                            Neighborhoods = new List<Neighborhood>()
                            {
                                new Neighborhood { Name = "Unión"},
                            }
                        }
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
