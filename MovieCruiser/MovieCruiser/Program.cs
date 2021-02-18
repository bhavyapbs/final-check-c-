using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;
using Com.Cognizant.MovieCruiser.Dao;

namespace Com.Cognizant.MovieCruiser.Main
{
    class Program

    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 2);
            List<Movie> favorites = new List<Movie>();
            List<Movie> favoritesMovieList = new List<Movie>();

            new Movie(1, "Avatar", 2787965087, true, "15/03/2017", "Science Fiction", true);
            new Movie(2, "The Avengers", 1518812988, true, "23/12/2017", "Superhero", true);
            new Movie(3, "Titanic", 2187463944, true, "21/11/2017", "Romance", false);
            Admin admin = new Admin();
            Customer customer = new Customer();
            Dictionary<int, Customer> customerlist = new Dictionary<int, Customer>()
            {
                {1,new Customer(1,"priyanka") },
                {2,new Customer(2,"keerthi") },
                {3,new Customer(3,"akhila") },
                {4,new Customer(4,"sahitya") },
                {5,new Customer(5,"balu") }
            };
            Console.WriteLine("Welcome to Movie Cruiser \n\nEnter 1 to login as admin else Enter 2 for customer");
            int userType = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (userType == 1)
                {
                    Console.WriteLine("Enter username");
                    admin.AdminName = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    admin.AdminPassword = Console.ReadLine();
                    if ((admin.AdminName == "bhavya") && (admin.AdminPassword == "sreesree"))
                    {
                        int flag = 1;
                        Console.WriteLine("Logged in successfully as Admin");
                        while (flag == 1)
                        {
                            Console.WriteLine("Enter 1 to View MovieList \n enter 2 To Edit Movie \nenter 0 to exit");
                            int adminChoice = Convert.ToInt32(Console.ReadLine());
                            if (adminChoice == 1)
                            {
                                admin.DisplayMovieListByAdmin();
                            }
                            else if (adminChoice == 2)
                            {
                                admin.DisplayMovieListByAdmin();
                                Console.WriteLine("Enter the movie that you want to edit");
                                string title = Console.ReadLine();
                                admin.EditMovie(title);
                                Console.WriteLine("Movie record updated successfully");
                            }
                            else if (adminChoice == 0)
                            {
                                flag = 0;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Credentials");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Credentials");
            }
            if (userType == 2)
            {
                Console.WriteLine("Enter userid");
                customer.CustomerId = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Enter password");
                customer.CustomerName = Console.ReadLine();
                if (customer.CustomerId == customerlist[customer.CustomerId].CustomerId && customer.CustomerName == customerlist[customer.CustomerId].CustomerName)
                {
                    Console.WriteLine("Logged In as Customer");
                    int flag1 = 1;
                    while (flag1 == 1)
                    {
                        Console.WriteLine("Enter 1 to view movie list \nEnter 2 to add movie to favorites\nEnter 3 to view favorites \nEnter 4 to remove item from favorites \nEnter 0 to exit");
                        int customerChoice = Convert.ToInt32(Console.ReadLine());
                        if (customerChoice == 1)
                        {
                            Console.WriteLine("MovieList: \n ");
                            customer.DisplayMovieListByCustomer();
                        }
                        else if (customerChoice == 2)
                        {
                            customer.DisplayMovieListByCustomer();
                            Console.WriteLine("Enter the movieid you want to add to favorites");
                            int FavoriteId = Convert.ToInt32(Console.ReadLine());
                            customer.AddToFavorites(FavoriteId, favorites);
                        }
                        else if (customerChoice == 3)
                        {
                            customer.viewfavorites(favorites);
                        }
                        else if (customerChoice == 4)
                        {
                            customer.viewfavorites(favorites);
                            Console.WriteLine("Enter movieid you want to remove from favorites");
                            int FavoriteId = Convert.ToInt32(Console.ReadLine());
                            customer.RemoveFavorites(FavoriteId);
                        }
                        else if (customerChoice == 0)
                        {
                            flag1 = 0;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Credentials");
                        }

                    }
                }
            }
        }
    }
}