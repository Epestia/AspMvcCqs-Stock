using Stock.Commands;
using Stock.Models;
using Stock.Repositories;

public class CreateUserCommandHandler
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(CreateUserCommand command)
    {
        var userModel = new UserModel
        {
            Nom = command.Nom,
            Prenom = command.Prenom,
            Mail = command.Mail,
            MotDePasse = command.MotDePasse
        };

        await _userRepository.AddUser(userModel);
    }
}
