﻿using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlProductoRepo : IProductoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlProductoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Productos de la base de datos.
         */
        public IEnumerable<Producto> GetAll()
        {
            //Se retorna una lista de todos los Productos.
            return _context.Producto.ToList();
        }

        /*
         * Retorna un solo Producto por su id.
         */
        public Producto GetById(int id)
        {
            return _context.Producto.FirstOrDefault(p => p.idProducto == id);
        }

        /*
         * Retorna el Producto con el nombre indicado.
         */
        public Producto GetByNombre(string nombre)
        {
            //Se retorna el Producto especificado
            return _context.Producto.FirstOrDefault(p => p.nombre == nombre);
        }

        /*
         * Retorna el idProducto de un Producto especifico.
         */
        public int GetId(string nombre)
        {
            //Se obtiene el idProducto de un Producto especifico
            int idProducto = _context.Producto.FirstOrDefault(p => p.nombre == nombre).idProducto;

            //Se verifica que el Producto exista
            if (idProducto > 0)
            {
                //Si existe, se retorna el idProducto
                return idProducto;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        /*
         * Ingresa a la base de datos un nuevo Producto.
         */
        public void Create(Producto producto)
        {
            //Se verifica si el Producto existe
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            //Se crea el Producto en la base de datos por medio del context
            _context.Producto.Add(producto);
        }

        /*
         * Actualiza los datos de un Producto en la base de datos.
         */
        public void Update(Producto producto)
        {
            //De esto se encarga el DbContext
        }

        /*
         * Elimina los datos de un Producto en la base de datos.
         */
        public void Delete(Producto producto)
        {
            //Se verifica si el Producto existe
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            //Se elimina el Producot de la base de datos por medio del context
            _context.Producto.Remove(producto);
        }

        /*
         * Guarda los cambios en la Base de Datos de SQLServer.
         */
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
