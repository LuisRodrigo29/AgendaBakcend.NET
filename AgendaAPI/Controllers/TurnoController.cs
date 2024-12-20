using AgendaAPI.ModelEntry;
using DTO;
using Entities;
using Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly IGuardar _IGuardar;
        private readonly IActualizar _IActualizar;
        private readonly IConsultar _IConsultar;

        public TurnoController(IGuardar iGuardar, IActualizar iActualizar, IConsultar iConsultar)
        {
            _IGuardar = iGuardar;
            _IActualizar = iActualizar;
            _IConsultar = iConsultar;
        }

        /// <summary>
        /// Metodo para obtener todos los turnos
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult ObtenerTurnos()
        {
            try
            {
                DataTable tblResult = _IConsultar.ObtenerTurnos();

                Entities.Resultado<DTOTurnoResultado> resultado = new Entities.Resultado<DTOTurnoResultado>();

                DTOTurnoResultado dto = new DTOTurnoResultado();
                List<DTOTurnoResultado> lsResult = new List<DTOTurnoResultado>();
                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow row in tblResult.Rows)
                    {
                        dto.nombre = row["nombre"].ToString();
                        dto.cedula = row["cedula"].ToString();
                        dto.fechaTurno = row["fechaTurno"].ToString();
                        dto.fechaCorta = row["fechaCorta"].ToString();
                        dto.descripcion = row["descripcion"].ToString();
                        dto.sucursal = row["sucursal"].ToString();
                        dto.turno = row["turno"].ToString();
                        dto.idTurno = row["idTurno"].ToString();
                        lsResult.Add(new DTOTurnoResultado(dto.nombre, dto.cedula, dto.fechaTurno, dto.fechaCorta, dto.descripcion, dto.sucursal, dto.turno, dto.idTurno) { });

                    }
                }
                resultado.resultadoLista = lsResult;

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                Entities.Resultado<DTOErrores> errores = new Entities.Resultado<DTOErrores>();

                DTOErrores dtoErrors = new DTOErrores(ex.Message, ex.StackTrace, Convert.ToString(ex.InnerException));

                errores.resultado = dtoErrors;

                return BadRequest(errores);
            }
        }

        /// <summary>
        /// Metodo para guardar el turno
        /// </summary>
        /// <param name="tur"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize]
        public IActionResult GuardarTurno([FromBody] TurnoEntry tur)
        {
            try
            {
                Entities.Resultado<DTOResultado> resultado = new Entities.Resultado<DTOResultado>();

                DataTable tblResult = _IGuardar.GuardarTurno(tur.operacion, tur.cedula, tur.nombre, tur.fecha_turno, tur.id_sucursal, tur.descripcion, tur.idTurno);

                DTOResultado dto = new DTOResultado();

                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow row in tblResult.Rows)
                    {
                        dto.resultado = row["result"].ToString();

                    }
                    resultado.resultado = dto;
                }

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                Entities.Resultado<DTOErrores> errores = new Entities.Resultado<DTOErrores>();

                DTOErrores dtoErrors = new DTOErrores(ex.Message, ex.StackTrace, Convert.ToString(ex.InnerException));

                errores.resultado = dtoErrors;

                return BadRequest(errores);
            }
        }

        /// <summary>
        /// Metodo para actualizar el turno
        /// </summary>
        /// <param name="idTurno"></param>
        /// <param name="tur"></param>
        [HttpPut("[action]")]
        [Authorize]
        public IActionResult ActualizarTurno(int idTurno, [FromBody] TurnoEntry tur)
        {
            try
            {
                Entities.Resultado<DTOResultado> resultado = new Entities.Resultado<DTOResultado>();

                tur.idTurno = Convert.ToString(idTurno);

                DataTable tblResult = _IActualizar.ActualizarTurno(tur.operacion, tur.cedula, tur.nombre, tur.fecha_turno, tur.id_sucursal, tur.descripcion, tur.idTurno);

                DTOResultado dto = new DTOResultado();

                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow row in tblResult.Rows)
                    {
                        dto.resultado = row["result"].ToString();

                    }
                    resultado.resultado = dto;
                }

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                Entities.Resultado<DTOErrores> errores = new Entities.Resultado<DTOErrores>();

                DTOErrores dtoErrors = new DTOErrores(ex.Message, ex.StackTrace, Convert.ToString(ex.InnerException));

                errores.resultado = dtoErrors;

                return BadRequest(errores);
            }
        }
        /// <summary>
        /// Metodo para obtener turno vigente por cedula
        /// </summary>
        /// <param name="tur"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize]
        public IActionResult ObtenerTurnoXCedula([FromBody] TurnoEntry tur)
        {
            try
            {
                DataTable tblResult = _IConsultar.ObtenerTurnoXCedula(tur.operacion, tur.cedula, tur.nombre, tur.fecha_turno, tur.id_sucursal, tur.descripcion, tur.idTurno);

                Entities.Resultado<DTOTurnoResultado> resultado = new Entities.Resultado<DTOTurnoResultado>();

                DTOTurnoResultado dto = new DTOTurnoResultado();
                List<DTOTurnoResultado> lsResult = new List<DTOTurnoResultado>();

                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow row in tblResult.Rows)
                    {
                        dto.nombre = row["nombre"].ToString();
                        dto.cedula = row["cedula"].ToString();
                        dto.fechaTurno = row["fechaTurno"].ToString();
                        dto.fechaCorta = row["fechaCorta"].ToString();
                        dto.descripcion = row["descripcion"].ToString();
                        dto.sucursal = row["sucursal"].ToString();
                        dto.turno = row["turno"].ToString();
                        dto.idTurno = row["idTurno"].ToString();
                        lsResult.Add(new DTOTurnoResultado(dto.nombre, dto.cedula, dto.fechaTurno, dto.fechaCorta, dto.descripcion, dto.sucursal, dto.turno, dto.idTurno) { });

                    }
                }
                resultado.resultadoLista = lsResult;
                return Ok(resultado);

            }
            catch (Exception ex)
            {
                Entities.Resultado<DTOErrores> errores = new Entities.Resultado<DTOErrores>();

                DTOErrores dtoErrors = new DTOErrores(ex.Message, ex.StackTrace, Convert.ToString(ex.InnerException));

                errores.resultado = dtoErrors;

                return BadRequest(errores);
            }
        }

        /// <summary>
        /// Metodo para obtener las sucursales
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult ObtenerSucursales()
        {
            try
            {
                Entities.Resultado<DTOSucursales> resultado = new Resultado<DTOSucursales>();

                DataTable tblResult = _IConsultar.ObtenerSucursales();

                DTOSucursales dto = new DTOSucursales();

                List<DTOSucursales> listResult = new List<DTOSucursales>();

                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow fila in tblResult.Rows)
                    {
                        dto.id = fila["id"].ToString();
                        dto.nombre = fila["nombre"].ToString();
                        listResult.Add(new DTOSucursales(dto.id, dto.nombre) { });
                    }
                }

                resultado.resultadoLista = listResult;

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                Entities.Resultado<DTOErrores> errores = new Entities.Resultado<DTOErrores>();

                DTOErrores dtoErrors = new DTOErrores(ex.Message, ex.StackTrace, Convert.ToString(ex.InnerException));

                errores.resultado = dtoErrors;

                return BadRequest(errores);
            }
        }

        /// <summary>
        /// Metodo para actualizar los turnos que son mayores a 15 minutos
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult ActualizarVigencia()
        {
            try
            {
                Entities.Resultado<DTOResultado> resultado = new Entities.Resultado<DTOResultado>();

                DataTable tblResult = _IActualizar.ActualizarVigenciaTurnos();

                DTOResultado dto = new DTOResultado();

                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow row in tblResult.Rows)
                    {
                        dto.resultado = row["result"].ToString();

                    }
                    resultado.resultado = dto;
                }

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                Entities.Resultado<DTOErrores> errores = new Entities.Resultado<DTOErrores>();

                DTOErrores dtoErrors = new DTOErrores(ex.Message, ex.StackTrace, Convert.ToString(ex.InnerException));

                errores.resultado = dtoErrors;

                return BadRequest(errores);
            }
        }
    }
}
