using System.Security.Claims;
using TasksManager.Data;

namespace TasksManager.BLL
{
    public class UserBLL
    {
        private readonly ApplicationDbContext _contexto;

        public UserBLL(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        

        public string GetUserId(ClaimsPrincipal principal)
        {
           var user = _contexto.Users.FirstOrDefault(user => user.Id == principal.Identity.Name);
            return user.Id;
        }

        
    }
}
