using LetterList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cmd
{
    public class Menu
    {


        Movies movie;
        internal Menu(Movies movieka)
        {
            movie = movieka;
        }
        private void showMenu(string[] menupoints)
        {
            Console.WriteLine("Letter List! It's like LetterBox, but not yet.");
            Console.WriteLine();
            foreach (string point in menupoints)
            {
                Console.WriteLine(point);
            }
        }
        string[] menupoints = new string[]
            {
                "(1) List movies",
                "(2) Add a movie",
                "(3) Remove a movie by name",
                "(4) Change a movies name",
                "(5) Recommend me a movie",
                "(6) Make a favorite list",
                "(7) Search by Directors",
                "(8) Save current movie list",
                "(0) End Program"
            };
        private string director;

        public void StartMenu()
        {
            while (true)
            {
                showMenu(menupoints);
                Console.WriteLine();
                Console.Write("Type in your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {

                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "1":
                        { 
                            movie.ListMovies();
                            break;
                        }
                    case "2":
                        {
                            try
                            {
                                Console.WriteLine("Please enter the name of the movie: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter the director of the movie: ");
                                string director = Console.ReadLine();
                                Console.WriteLine("Please enter the release date of the movie: ");
                                int releaseyear = int.Parse(Console.ReadLine());
                                if (releaseyear > 2020 || releaseyear < 1888)
                                {
                                    Console.WriteLine("Not Possible");
                                }
                                else {
                                    movie.AddMovies(name, director, releaseyear);
                                }
                                
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong input");
                            }
                            break;
                        }
                    case "3":
                        {
                            try
                            {
                                Console.WriteLine("Enter the name of the movie you wish to delete: ");
                                string deletename = Console.ReadLine();
                                movie.RemoveMovies(deletename);
                                
                            }
                            catch (WrongInputException)
                            {
                                Console.WriteLine("There is no data with that movie");
                            }
                            break;
                        }
                    case "4":
                        {
                            try
                            {
                                Console.WriteLine("Enter the name of the movie you wish to update: ");
                                string updatename = Console.ReadLine();
                                Console.WriteLine("Enter the new name of the movie: ");
                                string newname = Console.ReadLine();
                                movie.UpdateMovie(updatename,newname);
                            }
                            catch (WrongInputException)
                            {
                                Console.WriteLine("There is no data with that name.") ;
                            }
                            break;
                        }
                    case "5":
                        {

                            try
                            {
                                Console.WriteLine("If you feel any of the above statement is true, just type yes, and the magic will do it's job!\n");
                                Movies movie = new Movies();
                                movie.LoadCSV("movies.csv");
                                List<MovieConsumer> allMovieConsumers = new List<MovieConsumer> {
                                 new OldMovieConsumer("I can't see colors."),
                                 new SeenItAll("I'm a big italian-korean-balinase movie buff guy."),
                                 new OnlyNewMovies("Explosions? SU-PER-HER-OOOES? COUNT ME IN!"),
                                 };
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine(allMovieConsumers[0].Question);
                                        string stringanswer = Console.ReadLine();
                                        if (stringanswer.ToLower().Equals("true") || stringanswer.ToLower().Equals("yes"))
                                        {
                                            allMovieConsumers[0].Answer = true;
                                            break;
                                        }
                                        else if (stringanswer.ToLower().Equals("false") || stringanswer.ToLower().Equals("no"))
                                        {
                                            allMovieConsumers[0].Answer = false;
                                            break;
                                        }
                                        else
                                        {
                                            throw new FormatException();
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Wrong Input");
                                    }
                                }
                                if (allMovieConsumers[0].Answer.Equals(true))
                                {
                                    Console.WriteLine(allMovieConsumers[0].SuggestMovie(movie.MovieList));
                                }
                                else if (allMovieConsumers[0].Answer.Equals(false))
                                {

                                    while (true)
                                    {
                                        try
                                        {
                                            Console.WriteLine(allMovieConsumers[1].Question);
                                            string stringanswer2 = Console.ReadLine();
                                            if (stringanswer2.ToLower().Equals("true") || stringanswer2.ToLower().Equals("yes"))
                                            {
                                                allMovieConsumers[1].Answer = true;
                                                break;
                                            }
                                            else if (stringanswer2.ToLower().Equals("false") || stringanswer2.ToLower().Equals("no"))
                                            {
                                                allMovieConsumers[1].Answer = false;
                                                break;
                                            }
                                            else
                                            {
                                                throw new FormatException();
                                            }
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Wrong Input");
                                        }
                                    }
                                    if (allMovieConsumers[1].Answer.Equals(true) || allMovieConsumers[1].Answer.Equals("yes"))
                                    {
                                        Console.WriteLine(allMovieConsumers[1].SuggestMovie(movie.MovieList));
                                    }
                                    else if (allMovieConsumers[1].Answer.Equals(false))
                                    {
                                        while (true)
                                        {
                                            try
                                            {

                                                Console.WriteLine(allMovieConsumers[2].Question);
                                                string stringanswer3 = Console.ReadLine();
                                                if (stringanswer3.ToLower().Equals("true") || stringanswer3.ToLower().Equals("yes"))
                                                {
                                                    allMovieConsumers[2].Answer = true;
                                                    break;
                                                }
                                                else if (stringanswer3.ToLower().Equals("false") || stringanswer3.ToLower().Equals("no"))
                                                {
                                                    allMovieConsumers[2].Answer = false;
                                                    break;
                                                }
                                                else
                                                {
                                                    throw new FormatException();
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Wrong input");
                                            }

                                        }
                                        if (allMovieConsumers[2].Answer.Equals(true))
                                        {
                                            Console.WriteLine(allMovieConsumers[2].SuggestMovie(movie.MovieList));
                                        }
                                        else
                                        {
                                            Console.WriteLine("You should read a book.");
                                        }
                                    }
                                }
                            }
                            catch (NoFileException)
                            {
                                Console.WriteLine("I have no data.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("An error ocuured");
                            }
                            
                            break;
                        }
                    case "6":
                        {
                            try
                            {
                                Console.WriteLine("Enter the name of the movie:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter the name of the director:");
                                string director = Console.ReadLine();
                                Console.WriteLine("Enter the release year: ");
                                int releaseyear = int.Parse(Console.ReadLine());
                                movie.MakeCustomList(name, director, releaseyear, "FavoriteList.csv");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong Input");
                            }
                                break;
                        }
                    case "7":
                        {

                            try
                            {
                                Console.WriteLine("Please Enter the Name of The Director: ");
                                director = Console.ReadLine();
                                List<Movies> listafilm = movie.SearchByDirector(director);
                                foreach (var item in listafilm)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong Input");
                            }
                            break;
                        }
                    case "8":
                        {
                            try
                            {
                                movie.SaveCurrentListToCsv();
                            }
                            catch (NoFileException)
                            {
                                Console.WriteLine("I dont have the file");
                            }
                            break;
                        }
                }
            }
        }
    }
}
