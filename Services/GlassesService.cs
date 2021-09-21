using SeeSharp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeeSharp.Services
{
    public static class GlassesService
    {
        static List<GlassesPair> Glasses { get; }
        static int nextId = 3;
        static GlassesService()
        {
            Glasses = new List<GlassesPair>
            {
                new GlassesPair { Id = 1, Name = "Rayban", IsBifocal = false },
                new GlassesPair { Id = 2, Name = "Oakley", IsBifocal = true }
            };
        }

        public static List<GlassesPair> GetAll() => Glasses;

        public static GlassesPair Get(int id) => Glasses.FirstOrDefault(p => p.Id == id);

        public static void Add(GlassesPair glassesPair)
        {
            glassesPair.Id = nextId++;
            Glasses.Add(glassesPair);
        }

        public static void Delete(int id)
        {
            var glassesPair = Get(id);
            if(glassesPair is null)
                return;

            Glasses.Remove(glassesPair);
        }

        public static void Update(GlassesPair glassesPair)
        {
            var index = Glasses.FindIndex(p => p.Id == glassesPair.Id);
            if(index == -1)
                return;

            Glasses[index] = glassesPair;
        }
    }
}