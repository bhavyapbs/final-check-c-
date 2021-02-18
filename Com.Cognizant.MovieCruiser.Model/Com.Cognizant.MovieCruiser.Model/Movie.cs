using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.MovieCruiser.Model
{
    public class Movie
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        long boxoffice;
        public long BoxOffice
        {
            get { return boxoffice; }
            set { boxoffice = value; }
        }
        bool active;
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        string dateoflaunch;
        public string DateOfLaunch
        {
            get { return dateoflaunch; }
            set { dateoflaunch = value; }
        }
        string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        bool hasteaser;
        public bool HasTeaser
        {
            get { return hasteaser; }
            set { hasteaser = value; }
        }


        //DEFAULT CONSTRUCTOR
        public Movie() { }

        //MOVIE CONSTRUCTOR
        public Movie(int Id, string Title, long BoxOffice, bool Active, string DateOfLaunch, string Genre, bool HasTeaser)
        {
            this.Id = Id;
            this.Title = Title;
            this.BoxOffice = BoxOffice;
            this.Active = Active;
            this.DateOfLaunch = DateOfLaunch;
            this.Genre = Genre;
            this.HasTeaser = HasTeaser;
        }
    }
}