using BLL.DTOs;
using DAL.Repos;

namespace BLL.Services
{
    public class AuthService
    {
        AuthRepo repo;

        public AuthService(AuthRepo repo)
        {
            this.repo = repo;
        }

        public string Login(LoginDTO dto)
        {
            var user = repo.Login(dto.Email, dto.Password);

            if (user == null)
            {
                return "";
            }

            return user.Name;
        }
    }
}