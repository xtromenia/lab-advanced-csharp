using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    public class Language
    {
        public static List<Language> languages = new List<Language>();
        public string Name { get; set; }
        public int EnhancementPercentage { get; set; }

        public Language(string name)
        {
            this.Name = name;
            languages.Add(this);
        }
        public Language(string name, int enhancementPercentage)
        {
            this.Name = name;
            this.EnhancementPercentage = enhancementPercentage;
            languages.Add(this);
        }
        public static Language GetLanguage(string name)
        {
            return languages.Find(m => m.Name.Equals(name));
        }
        public override string ToString()
        {
            return $"{Name} | {EnhancementPercentage}% salary increase";
        }
    }
}
