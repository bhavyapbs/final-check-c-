using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.Dao
{
    abstract public class User
    {
        abstract public List<Movie> GetMovieList();
        public List<Movie> movieList = new List<Movie>()
        {
            new Movie(1, "Avatar", 2787965087, true, "15/03/2017", "Science Fiction", true),
            new Movie(2, "The Avengers", 1518812988, true, "23/12/2017", "Superhero", false),
            new Movie(3, "Titanic", 2187463944, true, "21/08/2017", "Romance", false),
            new Movie(4, "Jurassic World", 1671713089, false, "02/07/2017", "Science Fiction", true),
            new Movie(5, "Avengers:End Game", 2750760348, false, "02/11/2022", "Superhero", true)
        };
    }
    public class Admin : User
    {
        string adminName;
        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }
        string adminPassword;
        public string AdminPassword
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }
        //MOVIE LIST ADMIN
        public override List<Movie> GetMovieList()
        {
            return movieList;
        }

        public void DisplayMovieListByAdmin()
        {
            movieList = GetMovieList();
            string active = string.Empty;
            string hasteaser = string.Empty;
            Console.WriteLine(" Id   Title              Box office($) Active     Date of launch      Genre       Hasteaser");
            foreach (Movie movie in movieList)
            {
                if (movie.Active)
                {
                    active = "yes";
                }
                else
                {
                    active = "No";
                }
                if (movie.HasTeaser == true)
                {
                    hasteaser = "yes";
                }
                else
                {
                    hasteaser = "No";
                }
                Console.WriteLine("{0,3}   {1,-18} {2,-6}    {3,-11} {4}    {5,-15}   {6}", movie.Id, movie.Title, movie.BoxOffice, movie.Active, movie.DateOfLaunch, movie.Genre, movie.HasTeaser);
            }
        }

        //EDIT MOVIE
        public void EditMovie(string title)
        {
            movieList = GetMovieList();
            foreach (Movie movie in movieList)
            {
                if (title == movie.Title)
                {
                    Console.WriteLine("Enter the Title:");
                    movie.Title = Console.ReadLine();

                    Console.WriteLine("Enter the Box Office Collection in $:");
                    movie.BoxOffice = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Enter Active status:");
                    movie.Active = Convert.ToBoolean(Console.ReadLine());

                    Console.WriteLine("Enter the Date of Launch in dd/mm/yyyy format:");
                    movie.DateOfLaunch = Console.ReadLine();

                    Console.WriteLine("Enter the Genre:");
                    movie.Genre = Console.ReadLine();

                    Console.WriteLine("Enter teaser status:");
                    movie.HasTeaser = Convert.ToBoolean(Console.ReadLine());

                    Console.WriteLine("Movie details edited successfully");
                    break;
                }
            }
        }
    }

    public class Customer : User
    {
        int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public Customer() { }
        public Customer(int customerId, string customerName)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
        }

        public List<Movie> favoritesMovieList = new List<Movie>()
    {
        new Movie(1, "Avatar", 2787965087, true, "15/03/2017", "Science Fiction", true),
        new Movie(2, "The Avengers", 1518812988, true, "23/12/2017", "Superhero", false),
        new Movie(3, "Titanic", 2187463944, true, "21/08/2017", "Romance", false),
    };
        public override List<Movie> GetMovieList()
        {
            return movieList;
        }
        public void DisplayMovieListByCustomer()
        {
            movieList = GetMovieList();
            string teaser = "";
            Console.WriteLine("Id    Title               Box office($)   Genre              Has teaser");
            for (int i = 0; i < movieList.Count() - 2; i++)
            {
                if (movieList[i].HasTeaser == true)
                {
                    teaser = "yes";
                }
                else
                {
                    teaser = "no";
                }
                Console.WriteLine("{0}     {1,-18}  {2,-13}   {3,-15}    {4}", movieList[i].Id, movieList[i].Title, movieList[i].BoxOffice, movieList[i].Genre, teaser);
            }
        }

        public List<Movie> GetFavoritesMovieList()
        {
            return favoritesMovieList;
        }


        //ADD TO FAVORITES
        public void AddToFavorites(int Id, List<Movie> favorites)
        {
            movieList = GetMovieList();
            favoritesMovieList = GetFavoritesMovieList();
            int i = Id - 1;
            favorites.Add(movieList[i]);
            Console.WriteLine("movie added to favorites successfully");
        }
        //view favorites
        public void viewfavorites(List<Movie> favorites)
        {
            Console.WriteLine("Favorites:");
            Console.WriteLine("ID title              Box office($)     genre");
            for (int i = 0; i < favorites.Count(); i++)
            {
                Console.WriteLine("{0} {1,-18}  {2,-13}   {3}", i + 1, favorites[i].Title, favorites[i].BoxOffice, favorites[i].Genre);
            }
            Console.WriteLine("no of favorites:" + favorites.Count());
        }
        //REMOVE FAVORITES
        public void RemoveFavorites(int Id)
        {
            favoritesMovieList = GetFavoritesMovieList();
            int i = Id - 1;
            favoritesMovieList.Remove(favoritesMovieList[i]);
            Console.WriteLine("movie removed from favorites successfully");
        }
    }
}