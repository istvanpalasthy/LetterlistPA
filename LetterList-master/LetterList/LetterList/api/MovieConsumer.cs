using System.Collections.Generic;

namespace LetterList
{
    abstract class MovieConsumer
    {

        public MovieConsumer(string question)
        {
            this.Question = question;
        }
        
        public bool? Answer { get; set; }
        public string Question { get; private set; }

        public abstract string SuggestMovie(List<Movies> MovieList);
   
    }
}
