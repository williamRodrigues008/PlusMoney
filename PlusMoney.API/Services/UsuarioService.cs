using Microsoft.EntityFrameworkCore;
using PlusMoney.API.Helpers;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;

namespace PlusMoney.API.Services
{
    public class UsuarioService : IUsuarioLeituraEscrita
    {
        private readonly DbContexto _contextoDb;
        private readonly AutenticarUsuario _autenticar;

        public UsuarioService(DbContexto contextoDb, AutenticarUsuario autenticar)
        {
            _contextoDb = contextoDb;
            _autenticar = autenticar;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> BuscarTodosUsuario()
        {
            var usuarios = await _contextoDb.Usuario.ToListAsync();

            var roleUser = await _contextoDb.UserRoles
                .Where(r => usuarios.Select(u => u.Id).Contains(r.UsuarioId)).ToListAsync();

            var roleId = roleUser.Select(ru => ru.RoleId).Distinct();

            var roles = await _contextoDb.Roles
                .Where(r => roleId.Contains(r.Id))
                .ToListAsync();


            foreach (var usuario in usuarios)
            {
                var userRoles = roleUser
                    .Where(ur => ur.UsuarioId == usuario.Id)
                    .Select(ur => roles.First(r => r.Id == ur.RoleId).Name)
                    .ToList();
                usuario.ListaRoles = userRoles;
            }
            
            return usuarios;
        }

        public Usuario BuscarUsuario(string nome)
        {
            return _contextoDb.Usuario.FirstOrDefault(x => x.NomeUsuario == nome)!;
        }

        public string CriarUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                _contextoDb.Add(usuario);
                if(_contextoDb.SaveChanges() >= 1 )
                    return "Sucesso ao adicionar nova movimentação!";
            }
            return "Ops, houve um erro na criação da nova movimentação";
        }
        public void RemoverUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
