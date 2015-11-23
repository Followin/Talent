namespace Talent.DAL.Models
{
    public class Synonym
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual Interest Interest { get; set; }

        public static implicit operator Synonym(string s)
        {
            return new Synonym() {Text = s};
        }
    }
}
