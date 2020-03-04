using System;
using System.Collections.Generic;
using System.Text;

namespace LetterList
{
    class SeenItAll : MovieConsumer
    {
        
        Movies film = new Movies();
        public SeenItAll(string question) : base(question)
        {
        }

        public override string SuggestMovie(List<Movies> MovieList)
        {
            Random rnd = new Random();
            int randomnumber = rnd.Next(MovieList.Count);
            if (MovieList == null)
            {
                throw new NoFileException();
            }
            return "You should watch " + MovieList[randomnumber].Name + " again.";
        }
    }
}
