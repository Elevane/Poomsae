using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Poomsae.Application.Models.Authentification;
using Poomsae.Application.Models.Errors;
using Poomsae.Application.Services.Authentification.Interfaces;
using Poomsae.Application.Services.External.Mails;
using Poomsae.Application.Services.Helpers;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Infrastructure.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Poomsae.Application.Services.Authentification
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly SecurityHelpers _securityHelpers;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMailSender _mailSender;
        private readonly ApplicationUser? _contextUser;

        public AuthService(IApplicationContext context, IMapper mapper, SecurityHelpers securityHelpers, IHttpContextAccessor contextAccessor, IMailSender mailSender)
        {
            _mailSender = mailSender;
            _contextAccessor = contextAccessor;
            _contextUser = (ApplicationUser?)_contextAccessor.HttpContext?.Items["User"];
            _securityHelpers = securityHelpers;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<RegisteredUser>> AuthenticateUserAsync(AuthenticateUserRequest toAuthenticate)
        {
            if (toAuthenticate.Password == null)
                return Result<RegisteredUser>.Failure("credentials", "la requête envoyé est dans un format incorect");
            string hashed = string.Empty;
            hashed = _securityHelpers.GetHash(toAuthenticate.Password);
            if (hashed == null && hashed == string.Empty)
                return Result<RegisteredUser>.Failure("credentials", "La connexion n'a pas fonctionné");
            User? exist = await _context.Users.Where(user => user.Email == toAuthenticate.Email && user.Password == hashed).FirstOrDefaultAsync();
            if (exist == null)
                return Result<RegisteredUser>.Failure("credentials", "Aucun utilisateur trouvé avec l'Email et/ou le mot de passse donné.");
            if (!exist.IsConfirmed)
                return Result<RegisteredUser>.Failure("credentials", "Account not confirmed");
            RegisteredUser authenticatedUser = _mapper.Map<RegisteredUser>(exist);
            string? token = _securityHelpers.generateJwtToken(exist.Email);
            if (token == null) return Result<RegisteredUser>.Failure("credentials", "Error while generating token for user");
            authenticatedUser.Token = token;
            return Result<RegisteredUser>.Success(authenticatedUser);
        }

        public async Task<Result> ConfirmAccount(string token)
        {
            JwtSecurityToken? userToken = _securityHelpers.ValidateToken(token);
            if (userToken == null)
                return Result.Failure("credentials", "Token given is not valid");
            Claim? userMail = userToken.Claims.FirstOrDefault(x => x.Type == "email");
            if (userMail == null || userMail.Value == null)
                return Result.Failure("credentials", "Token given is not valid");
            User exist = await _context.Users.FirstAsync(x => x.Email == userMail.Value);
            if (exist == null)
                return Result.Failure("credentials", "The user you're trying to confirm doesn't exist");
            if (exist.IsConfirmed)
                return Result.Failure("credentials", "The account is already confirmed");
            exist.Confirm();
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<RegisteredUser>> CreateUserAsync(RegisterUserRequest toRegister)
        {
            if (toRegister.Password == null || toRegister.Email == null || toRegister.ConfirmPassword == null)
                return Result<RegisteredUser>.Failure("confirmPassword", "La requête est dans un format incorrrect");
            if (toRegister.Password != toRegister.ConfirmPassword)
                return Result<RegisteredUser>.Failure("confirmPassword", "Les mots de passe ne sont pas identique");
            User? exist = await _context.Users.FirstOrDefaultAsync(user => user.Email == toRegister.Email);
            if (exist != null)
                return Result<RegisteredUser>.Failure("email", "Adresse email déjà utilisé");
            if (!User.isValid(toRegister.Password))
                return Result<RegisteredUser>.Failure("credentials", "Le format du mot de passe ou de l'email est incorrect");
            string hashed = string.Empty;
            hashed = _securityHelpers.GetHash(toRegister.Password);
            if (hashed == null || hashed == string.Empty)
                return Result<RegisteredUser>.Failure("credentials", "La création de compte n'a pas fonctionné");
            toRegister.Password = hashed;
            User toCreate = User.Create(toRegister.Email, toRegister.Password);
            string? token = _securityHelpers.generateJwtToken(toCreate.Email);
            if (token == null)
                return Result<RegisteredUser>.Failure("credentials", "La création de compte n'a pas fonctionné");
            _context.Users.Add(toCreate);

            await _context.SaveChangesAsync();
            string? confirmToken = _securityHelpers.generateConfirmToken(toCreate.Email);
            if (confirmToken == null)
                return Result<RegisteredUser>.Failure("Credentials", "Impossible générer l'utilisateur");
            await _mailSender.SendConfirmAsync(toCreate.Email, confirmToken);
            RegisteredUser registered = _mapper.Map<RegisteredUser>(toCreate);
            registered.Token = token;
            return Result<RegisteredUser>.Success(registered);
        }

        public async Task<Result> DeleteOrAnonymise(DeleteUserRequest request)
        {
            User? exist = await _context.Users.Where(user => user.Email == request.Email).FirstOrDefaultAsync();
            if (exist == null)
                return Result<RegisteredUser>.Failure("credentials", "Aucun utilisateur trouvé avec l'Email et/ou le mot de passse donné.");
            if (request.IsAnonimise)
                exist.Anonymise();
            else
            {
                _context.Users.Remove(exist);
            }

            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public Result<User> Get(string email)
        {
            User user = _context.Users.Include(u => u.Sports).First(user => user.Email == email);
            if (user == null)
                return Result<User>.Failure("credentials", "Impossible de trouver l'utilisateur");
            return Result<User>.Success(user);
        }
    }
}