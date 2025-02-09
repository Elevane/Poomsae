namespace Poomsae.Server.Domain.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }   
        public string Password { get; set; }


        private static char[] CaracteresSpeciaux = {
            '!', '?', ',', ';', ':', '.', '…', '-', '—', '_', '\'', '\"',
            '[', ']', '(', ')', '{', '}', '&', '%', '$', '#', '@', '*',
            '+', '-', '=', '/', '\\', '<', '>', '|'
        };

        private User(string email, string password)
        {
            Email = email;
            Password = password;
            IsConfirmed = false;
        }
        public static bool isValid(string password)
        {
            return password.Length > 9 && HasCapitalLetter(password) && HasSpecialChar(password) && HasNumber(password);
        }
        public static User Create(string email, string password)
        {

            return new User(email, password);
        }

        private static bool HasCapitalLetter(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i])) count += 1;
            }
            return count > 0;
        }

        private static bool HasSpecialChar(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int y = 0; y < CaracteresSpeciaux.Length; y++)
                {
                    if ((char)str[i] == CaracteresSpeciaux[y]) count += 1;
                }

            }
            return count > 0;
        }

        private static bool HasNumber(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i])) count += 1;
            }
            return count > 0;
        }

        /*
         * User data cannot be bounded to any irl person
         */
        public void Anonymise()
        {
            Email = $"{Id}#############";
            Password = "#############";
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }
    }

}
