using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BL.BlToDalController;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			GenreController genresDb = new GenreController();
			GenreDTO genreAction = new GenreDTO() {GenreName = "Action", Description = "Dynamic action games with some logic puzzles"};
			GenreDTO genreSport = new GenreDTO() {GenreName = "Sprot Simulator", Description = "A sports game is a video game genre that simulates the practice of sports" };
			GenreDTO genreMMORPG = new GenreDTO() {GenreName = "MMORPG", Description = "Massively multiplayer online role-playing game" };
			
			//example of exeption on BL validtion
			GenreDTO badGenre = new GenreDTO() { GenreName = "MMORPG", Description = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaaaaaaaaaaaaaaaa" };

			genresDb.Create(genreAction);
			genresDb.Create(genreSport);
			genresDb.Create(genreMMORPG);

			List<GenreDTO> allGenresFormDB = genresDb.GetAll();
			foreach(GenreDTO genre in allGenresFormDB)
			{
				Console.WriteLine($"{genre.Id} -- {genre.GenreName} : {genre.Description}");
			}

			//example of updating
			genreMMORPG.Description = "Multiplayer game";

			genresDb.Update(genreMMORPG);

			allGenresFormDB = genresDb.GetAll();
			foreach (GenreDTO genre in allGenresFormDB)
			{
				Console.WriteLine($"{genre.Id} -- {genre.GenreName} : {genre.Description}");
			}
			

			//Example of Deleting 
			var genreToDelete = genresDb.GetById(6);

			genresDb.Delete(genreToDelete);

			allGenresFormDB = genresDb.GetAll();
			foreach (GenreDTO genre in allGenresFormDB)
			{
				Console.WriteLine($"{genre.Id} -- {genre.GenreName} : {genre.Description}");
			}

			Console.ReadKey();
		}
	}
}
