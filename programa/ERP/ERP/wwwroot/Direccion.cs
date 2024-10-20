namespace ERP.wwwroot
{
    //Esta clase va a contener las listas con todas las provincias, cantones y distritos
    public class Direccion
    {
        public List<string> provincias { get; set; }

        public List<string> cantonesSanJose { get; set; }
        public List<string> cantonesAlajuela { get; set; }
        public List<string> cantonesCartago { get; set; }
        public List<string> cantonesHeredia { get; set; }
        public List<string> cantonesGuanacaste { get; set; }
        public List<string> cantonesPuntarenas { get; set; }
        public List<string> cantonesLimon { get; set; }

        // Distritos de San José
        public List<string> distritosGoicoechea { get; set; }
        public List<string> distritosSanJose { get; set; }
        public List<string> distritosEscazu { get; set; }
        public List<string> distritosDesamparados { get; set; }
        public List<string> distritosTarrazu { get; set; }
        public List<string> distritosAserri { get; set; }
        public List<string> distritosMora { get; set; }

        public List<string> distritosMontesDeOca { get; set; }

        public List<string> distritosPuriscal { get; set; }
        public List<string> distritosTibas { get; set; }
        public List<string> distritosMoravia { get; set; }
        public List<string> distritosSantaAna { get; set; }
        public List<string> distritosAlajuelita { get; set; }
        public List<string> distritosVazquezDeCoronado { get; set; }
        public List<string> distritosAcosta { get; set; }
        public List<string> distritosTurrubares { get; set; }
        public List<string> distritosDota { get; set; }
        public List<string> distritosCurridabat { get; set; }
        public List<string> distritosPerezZeledon { get; set; }

        public List<string> distritosLeonCortesCastro { get; set; }


        // Distritos de Alajuela
        public List<string> distritosAlajuela { get; set; }
        public List<string> distritosSanRamon { get; set; }
        public List<string> distritosGrecia { get; set; }
        public List<string> distritosSanMateo { get; set; }
        public List<string> distritosAtenas { get; set; }
        public List<string> distritosNaranjo { get; set; }
        public List<string> distritosPalmares { get; set; }
        public List<string> distritosPoas { get; set; }
        public List<string> distritosOrotina { get; set; }
        public List<string> distritosSanCarlos { get; set; }
        public List<string> distritosZarcero { get; set; }

        public List<string> distritosSarchí { get; set; }
        public List<string> distritosUpala { get; set; }
        public List<string> distritosLosChiles { get; set; }
        public List<string> distritosGuatuso { get; set; }
        public List<string> distritosRioCuarto { get; set; }

        // Distritos de Cartago
        public List<string> distritosCartago { get; set; }
        public List<string> distritosParaíso { get; set; }
        public List<string> distritosLaUnion { get; set; }
        public List<string> distritosJimenez { get; set; }
        public List<string> distritosTurrialba { get; set; }
        public List<string> distritosAlvarado { get; set; }
        public List<string> distritosOreamuno { get; set; }
        public List<string> distritosElGuarco { get; set; }


        // Distritos de Heredia
        public List<string> distritosHeredia { get; set; }
        public List<string> distritosBarva { get; set; }
        public List<string> distritosSantoDomingo { get; set; }
        public List<string> distritosSantaBarbara { get; set; }
        public List<string> distritosSanRafael { get; set; }
        public List<string> distritosSanIsidro { get; set; }
        public List<string> distritosBelen { get; set; }
        public List<string> distritosFlores { get; set; }
        public List<string> distritosSanPablo { get; set; }
        public List<string> distritosSarapiqui { get; set; }

        // Distritos de Guanacaste
        public List<string> distritosLiberia;
        public List<string> distritosNicoya;
        public List<string> distritosSantaCruz;
        public List<string> distritosBagaces;
        public List<string> distritosCarrillo;
        public List<string> distritosCañas;
        public List<string> distritosAbangares;
        public List<string> distritosTilarán;
        public List<string> distritosNandayure;
        public List<string> distritosLaCruz;
        public List<string> distritosHojancha;

        //Distritos de Puntarenas
        public List<string> distritosPuntarenas;
        public List<string> distritosEsparza;
        public List<string> distritosBuenosAires;
        public List<string> distritosMontesDeOro;
        public List<string> distritosOsa;
        public List<string> distritosQuepos;
        public List<string> distritosGolfito;
        public List<string> distritosCotoBrus;
        public List<string> distritosParrita;
        public List<string> distritosCorredores;
        public List<string> distritosGarabito;

        //Distritos de Limón
        public List<string> distritosLimón;
        public List<string> distritosPococí;
        public List<string> distritosSiquirres;
        public List<string> distritosTalamanca;
        public List<string> distritosMatina;
        public List<string> distritosGuácimo;

        public Direccion()
        {
            //Lista de provincias
            provincias = new List<string>();
            provincias.Add("San José");
            provincias.Add("Alajuela");
            provincias.Add("Cartago");
            provincias.Add("Heredia");
            provincias.Add("Guanacaste");
            provincias.Add("Puntarenas");
            provincias.Add("Limón");

            //Cantones de San José
            cantonesSanJose = new List<string>
        {
            "San José", "Escazú", "Desamparados", "Puriscal","Tarrazú", "Aserrí", "Mora", "Goicoechea", "Santa Ana", "Alajuelita", "Vázquez de Coronado",
    "Acosta", "Tibás", "Moravia", "Montes de Oca", "Turrubares", "Dota", "Curridabat", "Pérez Zeledón", "León Cortés Castro"
        };


            //Cantones de Alajuela
            cantonesAlajuela = new List<string>
        {
            "Alajuela", "San Ramón", "Grecia", "San Mateo", "Atenas", "Naranjo", "Palmares",
             "Poás", "Orotina", "San Carlos", "Zarcero", "Sarchí","Upala", "Los Chiles", "Guatuso", "Río Cuarto"
        };

            //Cantones de Cartago
            cantonesCartago = new List<string>
        {
            "Cartago", "Paraíso", "La Unión", "Jiménez", "Turrialba", "Alvarado",
            "Oreamuno", "El Guarco"
        };

            // Cantones de Heredia
            cantonesHeredia = new List<string>
        {
             "Heredia", "Barva", "Santo Domingo", "Santa Bárbara","San Rafael",
            "San Isidro", "Belén", "Flores", "San Pablo", "Sarapiquí"
        };

            // Cantones de Guanacaste
            cantonesGuanacaste = new List<string>
        {
            "Liberia", "Nicoya", "Santa Cruz", "Bagaces", "Carrillo", "Cañas",
            "Abangares", "Tilarán", "Nandayure", "La Cruz", "Hojancha"
        };

            // Cantones de Puntarenas
            cantonesPuntarenas = new List<string>
        {
            "Puntarenas", "Esparza", "Buenos Aires", "Montes de Oro", "Osa",
            "Quepos", "Golfito", "Coto Brus", "Parrita", "Corredores", "Garabito"
        };

            // Cantones de Limón
            cantonesLimon = new List<string>
        {
            "Limón", "Pococí", "Siquirres", "Talamanca", "Matina", "Guácimo"
        };

            // Distritos de cada cantón en la provincia de San José
            // Listas de distritos por cantón
            distritosSanJose = new List<string>
         {
                "Carmen", "Merced", "Hospital", "Catedral", "Zapote",
                "San Francisco de Dos Ríos", "La Uruca", "Mata Redonda",
                "Pavas", "Hatillo", "San Sebastián"
        };

            distritosEscazu = new List<string>
        {
                "Escazú", "San Antonio", "San Rafael"
        };

             distritosDesamparados = new List<string>
        {
                "Desamparados", "San Miguel", "San Juan de Dios",
                "San Rafael Arriba", "San Antonio", "Frailes",
                "Patarrá", "San Cristóbal", "Rosario", "Damas",
                "San Rafael Abajo", "Gravilias", "Los Guido"
        };

            distritosPuriscal = new List<string>
        {
                "Santiago", "Mercedes Sur", "Barbacoas",
                "Grifo Alto", "San Rafael", "Candelarita",
                "Desamparaditos", "San Antonio", "Chires"
        };

             distritosTarrazu = new List<string>
        {
                "San Marcos", "San Lorenzo", "San Carlos"
        };

             distritosAserri = new List<string>
        {
                "Aserrí", "Tarbaca", "Vuelta de Jorco",
                "San Gabriel", "Legua", "Monterrey", "Salitrillos"
        };

             distritosMora = new List<string>
        {
               "Colón", "Guayabo", "Tabarcia",
                "Piedras Negras", "Picagres", "Jaris", "Quitirrisí"
        };

            distritosGoicoechea = new List<string>
        {
                "Guadalupe", "San Francisco", "Calle Blancos",
                "Mata de Plátano", "Ipís", "Rancho Redondo", "Purral"
        };

             distritosSantaAna = new List<string>
        {
                "Santa Ana", "Salitral", "Pozos",
                "Uruca", "Piedades", "Brasil"
        };

             distritosAlajuelita = new List<string>
        {
                "Alajuelita", "San Josecito", "San Antonio",
                "Concepción", "San Felipe"
        };

            distritosVazquezDeCoronado = new List<string>
        {
            "San Isidro", "San Rafael",
                "Dulce Nombre de Jesús", "Patalillo", "Cascajal"
        };

             distritosAcosta = new List<string>
        {
                "San Ignacio", "Guaitil", "Palmichal",
                "Cangrejal", "Sabanillas"
        };

             distritosTibas = new List<string>
        {
                "San Juan", "Cinco Esquinas",
                "Anselmo Llorente", "León XIII", "Colima"
        };

            distritosMoravia = new List<string>
        {
                "San Vicente", "San Jerónimo", "La Trinidad"
        };

             distritosMontesDeOca = new List<string>
        {
                "San Pedro", "Sabanilla", "Mercedes", "San Rafael"
        };

             distritosTurrubares = new List<string>
        {
                "San Pablo", "San Pedro", "San Juan de Mata",
                "San Luis", "Carara"
        };

            distritosDota = new List<string>
        {
                "Santa María", "Jardín", "Copey"
        };

            distritosCurridabat = new List<string>
        {
                "Curridabat", "Granadilla", "Sánchez", "Tirrases"
        };

             distritosPerezZeledon = new List<string>
        {
                "San Isidro de El General", "El General",
                "Daniel Flores", "Rivas", "San Pedro",
                "Platanares", "Pejibaye", "Cajón",
                "Barú", "Río Nuevo", "Páramo", "La Amistad"
        };

             distritosLeonCortesCastro = new List<string>
        {
                "San Pablo", "San Andrés", "Llano Bonito",
                "San Isidro", "Santa Cruz", "San Antonio"
        };

            //Distritos de cada cantón en Alajuela
            distritosAlajuela = new List<string> { "Alajuela", "San José", "Carrizal", "San Antonio", "Guácima", "San Isidro", "Sabanilla", "San Rafael", "Río Segundo"
                , "Desamparados", "Turrúcares", "Tambor", "La Garita", "Sarapiquí" };
            distritosSanRamon = new List<string> { "San Ramón", "Santiago", "San Juan", "Piedades Norte", "Piedades Sur", "San Rafael", "San Isidro", "Ángeles", "Alfaro", "Volio",
                "Concepción", "Zapotal", "Peñas Blancas", "San Lorenzo" };
            distritosGrecia = new List<string> { "Grecia", "San Isidro", "San José", "San Roque", "Tacares", "Puente de Piedra", "Bolívar" };
            distritosSanMateo = new List<string> { "San Mateo", "Desmonte", "Jesús María", "Labrador" };
            distritosAtenas = new List<string> { "Atenas", "Jesús", "Mercedes", "San Isidro", "Concepción", "San José", "Santa Eulalia", "Escobal" };
            distritosNaranjo = new List<string> { "Naranjo", "San Miguel", "San José", "Cirrí Sur", "San Jerónimo", "San Juan", "El Rosario", "Palmitos" };
            distritosPalmares = new List<string> { "Palmares", "Zaragoza", "Buenos Aires", "Santiago", "Candelaria", "Esquipulas", "La Granja" };
            distritosPoas = new List<string> { "San Pedro", "San Juan", "San Rafael", "Carrillos", "Sabana Redonda" };
            distritosOrotina = new List<string> { "Orotina", "El Mastate", "Hacienda Vieja", "Coyolar", "La Ceiba" };
            distritosSanCarlos = new List<string> { "Quesada", "Florencia", "Buenavista", "Aguas Zarcas", "Venecia", "Pital", "La Fortuna",
                "La Tigra", "La Palmera", "Venado", "Cutris", "Monterrey", "Pocosol" };
            distritosZarcero = new List<string> { "Zarcero", "Laguna", "Tapesco", "Palmira", "Guadalupe", "Zapote", "Brisas" };
            distritosSarchí = new List<string> { "Sarchí Norte", "Sarchí Sur", "Toro Amarillo", "San Pedro", "Rodríguez" };
            distritosUpala = new List<string> { "Upala", "Aguas Claras", "San José", "Bijagua", "Delicias", "Dos Ríos", "Yolillal", "Canalete" };
            distritosLosChiles = new List<string> { "Los Chiles", "Caño Negro", "El Amparo", "San Jorge" };
            distritosGuatuso = new List<string> { "San Rafael", "Buenavista", "Cote", "Katira" };
            distritosRioCuarto = new List<string> { "Río Cuarto", "Santa Isabel", "Santa Rita" };

            // Distritos de cada cantón en la provincia de Cartago
            distritosCartago = new List<string> { "Oriental", "Occidental", "Carmen", "San Nicolás",
            "Aguacaliente", "Guadalupe", "Corralillo", "Tierra Blanca",
            "Dulce Nombre", "Llano Grande", "Quebradilla"};
            distritosParaíso = new List<string> { "Paraíso", "Santiago", "Orosi", "Cachí", "Llanos de Santa Lucía", "Birrisito" };
            distritosLaUnion = new List<string> { "Tres Ríos", "San Diego", "San Juan", "San Rafael", "Concepción", "Dulce Nombre", "San Ramón", "Río Azul" };
            distritosJimenez = new List<string> { "Juan Viñas", "Tucurrique", "Pejibaye", "La Victoria" };
            distritosTurrialba = new List<string> { "Turrialba", "La Suiza", "Peralta", "Santa Cruz", "Santa Teresita", "Pavones", "Tuis", "Tayutic",
                "Santa Rosa", "Tres Equis", "La Isabel", "Chirripó"};
            distritosAlvarado = new List<string> { "Pacayas", "Cervantes", "Capellades" };
            distritosOreamuno = new List<string> { "San Rafael", "Cot", "Potrero Cerrado", "Cipreses", "Santa Rosa" };
            distritosElGuarco = new List<string> { "El Tejar", "San Isidro", "Tobosi", "Patio de Agua" };

            // Distritos de cada cantón en la provincia de Heredia
            distritosHeredia = new List<string>
        {
            "Heredia", "Mercedes", "San Francisco", "Ulloa", "Varablanca"
        };

            distritosBarva = new List<string>
        {
            "Barva", "San Pedro", "San Pablo", "San Roque", "Santa Lucía", "San José de la Montaña"
        };

            distritosSantoDomingo = new List<string>
        {
            "Santo Domingo", "San Vicente", "San Miguel", "Paracito",
            "Santo Tomás", "Santa Rosa", "Tures", "Pará"
        };

            distritosSanRafael = new List<string>
        {
            "San Rafael", "San Josecito", "Santiago", "Ángeles", "Concepción"
        };

            distritosSanIsidro = new List<string>
        {
            "San Isidro", "San José", "Concepción", "San Francisco"
        };

            distritosBelen = new List<string>
        {
            "San Antonio", "La Ribera", "La Asunción"
        };

            distritosFlores = new List<string>
        {
            "San Joaquín", "Barrantes", "Llorente"
        };

            distritosSanPablo = new List<string>
        {
            "San Pablo", "Rincón de Sabanilla"
        };

            distritosSarapiqui = new List<string>
        {
            "Puerto Viejo", "La Virgen", "Horquetas", "Llanuras del Gaspar", "Cureña"
        };

            distritosSantaBarbara = new List<string>
        {
                "Santa Bárbara", "San Pedro", "San Juan", "Jesús", "Santo Domingo", "Purabá"
        };



            //Distritos de Guanacaste
            distritosLiberia = new List<string>();
            distritosNicoya = new List<string>();
            distritosSantaCruz = new List<string>();
            distritosBagaces = new List<string>();
            distritosCarrillo = new List<string>();
            distritosCañas = new List<string>();
            distritosAbangares = new List<string>();
            distritosTilarán = new List<string>();
            distritosNandayure = new List<string>();
            distritosLaCruz = new List<string>();
            distritosHojancha = new List<string>();

            distritosLiberia.Add("Liberia");
            distritosLiberia.Add("Cañas Dulces");
            distritosLiberia.Add("Mayorga");
            distritosLiberia.Add("Nacascolo");
            distritosLiberia.Add("Curubandé");

            // Inicializar distritos de Nicoya
            distritosNicoya.Add("Nicoya");
            distritosNicoya.Add("Mansión");
            distritosNicoya.Add("San Antonio");
            distritosNicoya.Add("Quebrada Honda");
            distritosNicoya.Add("Sámara");
            distritosNicoya.Add("Nosara");
            distritosNicoya.Add("Belén de Nosarita");

            // Inicializar distritos de Santa Cruz
            distritosSantaCruz.Add("Santa Cruz");
            distritosSantaCruz.Add("Bolsón");
            distritosSantaCruz.Add("Veintisiete de Abril");
            distritosSantaCruz.Add("Tempate");
            distritosSantaCruz.Add("Cartagena");
            distritosSantaCruz.Add("Cuajiniquil");
            distritosSantaCruz.Add("Diriá");
            distritosSantaCruz.Add("Cabo Velas");
            distritosSantaCruz.Add("Tamarindo");

            // Inicializar distritos de Bagaces
            distritosBagaces.Add("Bagaces");
            distritosBagaces.Add("La Fortuna");
            distritosBagaces.Add("Mogote");
            distritosBagaces.Add("Río Naranjo");

            // Inicializar distritos de Carrillo
            distritosCarrillo.Add("Filadelfia");
            distritosCarrillo.Add("Palmira");
            distritosCarrillo.Add("Sardinal");
            distritosCarrillo.Add("Belén");

            // Inicializar distritos de Cañas
            distritosCañas.Add("Cañas");
            distritosCañas.Add("Palmira");
            distritosCañas.Add("San Miguel");
            distritosCañas.Add("Bebedero");
            distritosCañas.Add("Porozal");

            // Inicializar distritos de Abangares
            distritosAbangares.Add("Las Juntas");
            distritosAbangares.Add("Sierra");
            distritosAbangares.Add("San Juan");
            distritosAbangares.Add("Colorado");

            // Inicializar distritos de Tilarán
            distritosTilarán.Add("Tilarán");
            distritosTilarán.Add("Quebrada Grande");
            distritosTilarán.Add("Tronadora");
            distritosTilarán.Add("Santa Rosa");
            distritosTilarán.Add("Líbano");
            distritosTilarán.Add("Tierras Morenas");
            distritosTilarán.Add("Arenal");
            distritosTilarán.Add("Cabeceras");

            // Inicializar distritos de Nandayure
            distritosNandayure.Add("Carmona");
            distritosNandayure.Add("Santa Rita");
            distritosNandayure.Add("Zapotal");
            distritosNandayure.Add("San Pablo");
            distritosNandayure.Add("Porvenir");
            distritosNandayure.Add("Bejuco");

            // Inicializar distritos de La Cruz
            distritosLaCruz.Add("La Cruz");
            distritosLaCruz.Add("Santa Cecilia");
            distritosLaCruz.Add("La Garita");
            distritosLaCruz.Add("Santa Elena");

            // Inicializar distritos de Hojancha
            distritosHojancha.Add("Hojancha");
            distritosHojancha.Add("Monte Romo");
            distritosHojancha.Add("Puerto Carrillo");
            distritosHojancha.Add("Huacas");
            distritosHojancha.Add("Matambú");

            //Distritos de Puntarenas
            distritosPuntarenas = new List<string>();
            distritosEsparza = new List<string>();
            distritosBuenosAires = new List<string>();
            distritosMontesDeOro = new List<string>();
            distritosOsa = new List<string>();
            distritosQuepos = new List<string>();
            distritosGolfito = new List<string>();
            distritosCotoBrus = new List<string>();
            distritosParrita = new List<string>();
            distritosCorredores = new List<string>();
            distritosGarabito = new List<string>();

            // Inicializar distritos de Puntarenas
            distritosPuntarenas.Add("Puntarenas");
            distritosPuntarenas.Add("Pitahaya");
            distritosPuntarenas.Add("Chomes");
            distritosPuntarenas.Add("Lepanto");
            distritosPuntarenas.Add("Paquera");
            distritosPuntarenas.Add("Manzanillo");
            distritosPuntarenas.Add("Guacimal");
            distritosPuntarenas.Add("Barranca");
            distritosPuntarenas.Add("Isla del Coco");
            distritosPuntarenas.Add("Cóbano");
            distritosPuntarenas.Add("Chacarita");
            distritosPuntarenas.Add("Chira");
            distritosPuntarenas.Add("Acapulco");
            distritosPuntarenas.Add("El Roble");
            distritosPuntarenas.Add("Arancibia");

            // Inicializar distritos de Esparza
            distritosEsparza.Add("Espíritu Santo");
            distritosEsparza.Add("San Juan Grande");
            distritosEsparza.Add("Macacona");
            distritosEsparza.Add("San Rafael");
            distritosEsparza.Add("San Jerónimo");
            distritosEsparza.Add("Caldera");

            // Inicializar distritos de Buenos Aires
            distritosBuenosAires.Add("Buenos Aires");
            distritosBuenosAires.Add("Volcán");
            distritosBuenosAires.Add("Potrero Grande");
            distritosBuenosAires.Add("Boruca");
            distritosBuenosAires.Add("Pilas");
            distritosBuenosAires.Add("Colinas");
            distritosBuenosAires.Add("Chánguena");
            distritosBuenosAires.Add("Biolley");
            distritosBuenosAires.Add("Brunka");

            // Inicializar distritos de Montes de Oro
            distritosMontesDeOro.Add("Miramar");
            distritosMontesDeOro.Add("La Unión");
            distritosMontesDeOro.Add("San Isidro");

            // Inicializar distritos de Osa
            distritosOsa.Add("Puerto Cortés");
            distritosOsa.Add("Palmar");
            distritosOsa.Add("Sierpe");
            distritosOsa.Add("Bahía Ballena");
            distritosOsa.Add("Piedras Blancas");
            distritosOsa.Add("Bahía Drake");

            // Inicializar distritos de Quepos
            distritosQuepos.Add("Quepos");
            distritosQuepos.Add("Savegre");
            distritosQuepos.Add("Naranjito");

            // Inicializar distritos de Golfito
            distritosGolfito.Add("Golfito");
            distritosGolfito.Add("Guaycará");
            distritosGolfito.Add("Pavón");

            // Inicializar distritos de Coto Brus
            distritosCotoBrus.Add("San Vito");
            distritosCotoBrus.Add("Sabalito");
            distritosCotoBrus.Add("Aguabuena");
            distritosCotoBrus.Add("Limoncito");
            distritosCotoBrus.Add("Pittier");
            distritosCotoBrus.Add("Gutiérrez Braun");

            // Inicializar distritos de Parrita
            distritosParrita.Add("Parrita");

            // Inicializar distritos de Corredores
            distritosCorredores.Add("Corredor");
            distritosCorredores.Add("La Cuesta");
            distritosCorredores.Add("Canoas");
            distritosCorredores.Add("Laurel");

            // Inicializar distritos de Garabito
            distritosGarabito.Add("Jacó");
            distritosGarabito.Add("Tárcoles");
            distritosGarabito.Add("Lagunillas");
            distritosGarabito.Add("Monteverde");
            distritosGarabito.Add("Puerto Jiménez");

            //Distritos de Limón
            distritosLimón = new List<string>();
            distritosPococí = new List<string>();
            distritosSiquirres = new List<string>();
            distritosTalamanca = new List<string>();
            distritosMatina = new List<string>();
            distritosGuácimo = new List<string>();

            // Inicializar distritos de Limón
            distritosLimón.Add("Limón");
            distritosLimón.Add("Valle La Estrella");
            distritosLimón.Add("Río Blanco");
            distritosLimón.Add("Matama");

            // Inicializar distritos de Pococí
            distritosPococí.Add("Guápiles");
            distritosPococí.Add("Jiménez");
            distritosPococí.Add("La Rita");
            distritosPococí.Add("Roxana");
            distritosPococí.Add("Cariari");
            distritosPococí.Add("Colorado");
            distritosPococí.Add("La Colonia");

            // Inicializar distritos de Siquirres
            distritosSiquirres.Add("Siquirres");
            distritosSiquirres.Add("Pacuarito");
            distritosSiquirres.Add("Florida");
            distritosSiquirres.Add("Germania");
            distritosSiquirres.Add("El Cairo");
            distritosSiquirres.Add("Alegría");
            distritosSiquirres.Add("Reventazón");

            // Inicializar distritos de Talamanca
            distritosTalamanca.Add("Bratsi");
            distritosTalamanca.Add("Sixaola");
            distritosTalamanca.Add("Cahuita");
            distritosTalamanca.Add("Telire");

            // Inicializar distritos de Matina
            distritosMatina.Add("Matina");
            distritosMatina.Add("Batán");
            distritosMatina.Add("Carrandi");

            // Inicializar distritos de Guácimo
            distritosGuácimo.Add("Guácimo");
            distritosGuácimo.Add("Mercedes");
            distritosGuácimo.Add("Pocora");
            distritosGuácimo.Add("Río Jiménez");
            distritosGuácimo.Add("Duacarí");
        
        }
    }
}
