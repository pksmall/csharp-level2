using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Student : IComparable<Student>, IEquatable<Student>, IEquatable<string>, ICloneable<Student>
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public List<int> Ratings { get; set; } = new List<int>();

        public double AvgRating
        {
            get
            {
                //return Ratings.Average();
                return Ratings.Sum() / (double)Ratings.Count;
            }
        }
/*        public double AvgRating
        {
            get
            {
                var ratings = Ratings;
                if (ratings == null)
                {
                    throw new InvalidOperationException("Average ratings can't calculated. Ratings hasn't values.");
                }
                if(ratings.Count == 0)
                {
                    return double.NaN;
                }

                var sum = 0;
                for (var i = 0; i < ratings.Count; i++)
                {
                    sum += ratings[i];
                }
                return sum / (double)ratings.Count;
            }
        }
*/
        public object Clone()
        {
            return new Student
            {
                FirstName = FirstName,
                Ratings = new List<int>(Ratings)
            };
        }

        public Student CloneObject()
        {
            return (Student)Clone();
        }

        public int CompareTo(Student other)
        {
            var current_avg_rating = AvgRating;
            var other_avg_rating = other.AvgRating;

            if(Math.Abs(current_avg_rating - other_avg_rating) < 0.001)
            {
                return 0;
            }
            if (current_avg_rating > other_avg_rating)
            {
                return +1;
            } else
            {
                return -1;
            }

        }

        public bool Equals(Student other)
        {
            return other?.FirstName == FirstName;
            //return (other == null ? null : other.Name) == Name;
            //if (other is null)
            //    return null;
            //else
            //    return other.Name == Name;
        }

        public bool Equals(string other)
        {
            return FirstName == other;
        }

        public override string ToString() => $"[{Id} {LastName} {FirstName} ({GroupId}): {AvgRating:0.##}";
    }
}
