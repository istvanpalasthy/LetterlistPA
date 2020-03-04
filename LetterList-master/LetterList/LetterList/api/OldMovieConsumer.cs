using System;
using System.Collections.Generic;
using System.Text;
using LetterList;

namespace LetterList
{
    class OldMovieConsumer : MovieConsumer
    {
        Movies film = new Movies();
        public OldMovieConsumer(string question) : base(question)
        {
        }


        public override string SuggestMovie(List<Movies> MovieList)
        {
            Random rnd = new Random();
            
            var returnlist = new List<Movies>();
            foreach (var item in MovieList)
            {
                if(item.Releaseyear < 1950)
                {
                    returnlist.Add(item);
                } 
            }
            if(MovieList == null)
            {
                throw new NoFileException();
            }
            int randomnumber = rnd.Next(returnlist.Count);
            return "You should probably see " + returnlist[randomnumber].Name;
        }

    }
}
