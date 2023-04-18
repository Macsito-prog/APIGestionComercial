using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionComercial.DAL.DBContext;
using GestionComercial.DAL.Repositorios.Contrato;
using GestionComercial.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GestionComercial.DAL.Repositorios
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {

        private readonly DbGestionComercialContext _dbContext;

        public VentaRepository(DbGestionComercialContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

             using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalleVenta dv in  modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    NumeroDocumento correlativo = _dbContext.NumeroDocumentos.First();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistroDocumento = DateTime.Now;

                    _dbContext.NumeroDocumentos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();


                    //generar formato de número de documento de venta

                    int cantDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", cantDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    //formato 0001

                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantDigitos, cantDigitos);

                    modelo.NumeroDocumento = numeroVenta;

                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = modelo;

                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            }

        }
    }
}
