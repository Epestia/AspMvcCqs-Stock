namespace Stock.Commands
{
    public class CreateUserCommand
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string MotDePasse { get; set; }

        public CreateUserCommand(string nom, string prenom, string mail, string motDePasse)
        {
            Nom = nom;
            Prenom = prenom;
            Mail = mail;
            MotDePasse = motDePasse;
        }
    }
}