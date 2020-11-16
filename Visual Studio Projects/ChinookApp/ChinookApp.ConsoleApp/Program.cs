using ChinookApp.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ChinookApp.ConsoleApp
{
    class Program
    {
        static DbContextOptions<ChinookContext> s_dbContextOptions;
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            //optionsBuilder.LogTo(Console.WriteLine);
            s_dbContextOptions = optionsBuilder.Options;

            Display5Tracks();

            
            //EditTrack("#1 zero", "memes");

            Display5Tracks();

            /*
            InsertNewTrack("#3 memes");

            Display5Tracks();
            */ 
        }

        static void Display5Tracks()
        {
            using var context = new ChinookContext(s_dbContextOptions);

            IQueryable<Track> track = context.Tracks.OrderBy(t => t.Name).Take(5);

            foreach (var x in track)
            {
                Console.WriteLine(x.Name);
            }

        }

        static string GetConnectionString()
        {
            string path = "../../../SuperSecretConnectionString.json";
            string json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (IOException)
            {
                Console.WriteLine("Diddly done goofed");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;
        }

        static void EditTrack(string oldName, string newName)
        {
            using var context = new ChinookContext(s_dbContextOptions);

            var tracks = context.Tracks.Where(t => t.Name == oldName).First();

            tracks.Name = newName;

            context.SaveChanges();
        }
        static void InsertNewTrack(string newName)
        {
            using var context = new ChinookContext(s_dbContextOptions);

            var newTrack = new Track();
            newTrack.Name = newName;
            newTrack.MediaTypeId = 1;

            context.Tracks.Add(newTrack);

            context.SaveChanges();

        }
        static void DeleteTrack(string name)
        {
            using var context = new ChinookContext(s_dbContextOptions);

            var track = context.Tracks.Where(t => t.Name == name).First();

            context.Remove(track);

            context.SaveChanges();
        }
    }
}
