using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories;

namespace Usuarios.Infrastructure.CQRS
{
    public class UsuarioCQRSRepository : CQRSRepository<Usuario>, IUsuarioCQRSRepository
    {
        private readonly IUsuarioSqlServerRepository _usuarioSqlServerRepository;
        private readonly IRedisRepository<Usuario> _redisRepository;

        public UsuarioCQRSRepository(IUsuarioSqlServerRepository usuarioSqlServerRepository, IRedisRepository<Usuario> redisRepository) : base(usuarioSqlServerRepository, redisRepository)
        {
            _usuarioSqlServerRepository = usuarioSqlServerRepository;
            _redisRepository = redisRepository;
        }

        public async Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 1)
        {
            var result = await _redisRepository.GetAll($"Usuarios_Nome_{usuario.Nome}_Ativo_{usuario.Ativo}_Pagina_{pagina}");

            if (result.Count() == 0)
            {
                result = await _usuarioSqlServerRepository.Filter(usuario, pagina);

                if (result != null)
                    await _redisRepository.Set($"Usuarios_Nome_{usuario.Nome}_Ativo_{usuario.Ativo}_Pagina_{pagina}", result);
            }

            return result;
        }

        public async Task<Usuario> Get(int id)
        {
            var result = await _redisRepository.Get($"Usuario_Id_${id}");

            if (result == null)
            {
                result = await _usuarioSqlServerRepository.Get(id);

                if (result != null)
                    await _redisRepository.Set($"Usuario_Id_${id}", result);
            }

            return result;
        }

        public async Task<Usuario> Get(Guid usuarioGuid)
        {
            var result = await _redisRepository.Get($"Usuario_Guid_${usuarioGuid.ToString()}");

            if (result == null)
            {
                result = await _usuarioSqlServerRepository.Get(usuarioGuid);

                if (result != null)
                    await _redisRepository.Set($"Usuario_Guid_${usuarioGuid.ToString()}", result);
            }

            return result;
        }

        public async Task<IEnumerable<Usuario>> GetAll(int pagina = 1)
        {
            var result = await _redisRepository.GetAll($"Usuarios_Pagina_${pagina}");

            if (result.Count() == 0)
            {
                result = await _usuarioSqlServerRepository.GetAll(pagina);

                if (result != null)
                    await _redisRepository.Set($"Usuarios_Pagina_${pagina}", result);
            }

            return result;
        }
    }
}