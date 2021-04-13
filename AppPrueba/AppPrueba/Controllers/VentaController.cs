using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrueba.Models;
using AppPrueba.Response;
using AppPrueba.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly Context _miBd;
        public VentaController(Context miBd)
        {
            _miBd = miBd;

        }

        [HttpGet]

        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var Lista = _miBd.Ventas.Include("Cliente").ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = Lista;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult Add(VentaViewModel oVenta)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                Venta venta = new Venta();
                venta.CodigoVenta = oVenta.CodigoVenta;
                venta.ClienteId = oVenta.ClienteId;
                _miBd.Ventas.Add(venta);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]

        public IActionResult Update(VentaViewModel oVenta)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var venta = _miBd.Ventas.Find(oVenta.Id);
                venta.CodigoVenta = oVenta.CodigoVenta;
                venta.ClienteId = oVenta.ClienteId;
                _miBd.Ventas.Update(venta);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var venta = _miBd.Ventas.Find(Id);
                _miBd.Ventas.Remove(venta);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;

            }
            return Ok(oRespuesta);
        }
    }

    
}