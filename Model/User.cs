using System;

namespace Model
{
    public class User
    {

        public User()
        {
            id = 0;
        }
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public bool flgAtivo { get; set; }
        public string perfil { get; set; }

    }
}
