using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    /*
     * The language class is created to be able to save multiple languages with their own salary enhancement percentage.
     * The assignment's description said that only C# would get a 10% increase, but with this system any language could get an enhancementpercentage.
     */
    public sealed class Language
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

        //Used for checking if language exists when assigning a language to an employee.
        public static bool LanguageExists(string languageName)
        {
            if (GetLanguage(languageName) is not null)
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return $"{Name} | {EnhancementPercentage}% salary increase";
        }
    }
}
