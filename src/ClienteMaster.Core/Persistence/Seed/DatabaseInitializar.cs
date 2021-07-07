using ClientMaster.Core.Models;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ClientMaster.Core.Persistence.Seed
{
    public static class DatabaseInitializar
    {
        private static readonly string PROVINCES_RESOURCE_NAME =
            "ClientMaster.Core.Persistence.Seed.Location.provinces.json";
        private static readonly string MUNICIPALITIES_RESOURCE_NAME =
            "ClientMaster.Core.Persistence.Seed.Location.municipality.json";
        private static readonly string SECTORS_RESOURCE_NAME =
            "ClientMaster.Core.Persistence.Seed.Location.sector.json";
        private static ClientMasterContext _context;

        public static void EnsureDatabaseIsSeeded(this IApplicationBuilder app, ClientMasterContext context)
        {
            _context = context;

            SeedProvinces();
            SeedMunicipalities();
            SeedSectors();

            _context.SaveChanges();
            _context = null;
        }

        private static void SeedProvinces()
        {
            if (_context.Provinces.Any()) return;
            var provincesJson = GetEmbeddedResourceAsString(PROVINCES_RESOURCE_NAME);

            ICollection<Province> provinces = JsonConvert.DeserializeObject<ICollection<Province>>(provincesJson);

            provinces = provinces.Select(upper => new Province
            {
                Id = upper.Id,
                Name = upper.Name.ToUpper()
            }).ToList();

            _context.Provinces.AddRange(provinces);
        }

        private static void SeedMunicipalities()
        {
            if (_context.Municipalities.Any()) return;
            var municipalitiesJson = GetEmbeddedResourceAsString(MUNICIPALITIES_RESOURCE_NAME);

            ICollection<Municipality> municipalities =
                JsonConvert.DeserializeObject<ICollection<Municipality>>(municipalitiesJson);

            municipalities = municipalities.Select(upper => new Municipality
            {
                MunicipalityId = upper.MunicipalityId,
                Name = upper.Name.ToUpper(),
                ProvinceId = upper.ProvinceId
            }).ToList();

            _context.Municipalities.AddRange(municipalities);
        }

        private static void SeedSectors()
        {
            if (!_context.Sectors.Any())
            {
                var sectorsJson = GetEmbeddedResourceAsString(SECTORS_RESOURCE_NAME);

                ICollection<Sector> sectors = JsonConvert.DeserializeObject<ICollection<Sector>>(sectorsJson);

                int increment = 1;
                foreach (var sector in sectors)
                {
                    sector.Name = sector.Name.ToUpper();
                    sector.SectorId = increment;
                    increment++;
                }
                _context.Sectors.AddRange(sectors);
            }
        }

        private static string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new(stream, Encoding.Default, false))
                result = reader.ReadToEnd();

            return result;
        }
    }
}
