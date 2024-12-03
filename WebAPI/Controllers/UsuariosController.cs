
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;
using WebApi;

namespace Libreria.WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        IObtenerLogin<UsuarioAltaDto> _obtener;
        public UsuariosController(
         IObtenerLogin<UsuarioAltaDto> obtener)
        {
            _obtener = obtener;
        }


        [HttpPost]
        public IActionResult ObtenerToken(LoginDto login)
        {

            try
            {
                UsuarioAltaDto unU = _obtener.Ejecutar(login.Email, login.Password);
                if (unU == null)
                {
                    return Unauthorized("Credenciales inválidas. Reintente");

                }
                var token = ManejadorJwt.GenerarToken(unU);
                return Ok(token);
            }
            catch (Exception)
            {

                return Unauthorized("Credenciales inválidas. Reintente");
            }
            
        }

    }
}
