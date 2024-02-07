using Domain.Models.Animal;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public string Purr()
        {
            return "This animal purrs";
        }
    }
}
