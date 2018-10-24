﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Avance.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SparesDSPEntities : DbContext
    {
        public SparesDSPEntities()
            : base("name=SparesDSPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<tipo_user> tipo_user { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<vistaProductos> vistaProductos { get; set; }
    
        public virtual ObjectResult<buscarProducto_Result> buscarProducto(string var)
        {
            var varParameter = var != null ?
                new ObjectParameter("var", var) :
                new ObjectParameter("var", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscarProducto_Result>("buscarProducto", varParameter);
        }
    
        public virtual ObjectResult<buscarUser_Result> buscarUser(string nomUser, string pass)
        {
            var nomUserParameter = nomUser != null ?
                new ObjectParameter("nomUser", nomUser) :
                new ObjectParameter("nomUser", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscarUser_Result>("buscarUser", nomUserParameter, passParameter);
        }
    
        public virtual int editarProductos(string nombre, string descripcion, string categoria, string marca, Nullable<int> cantidad, Nullable<decimal> precio, Nullable<int> id)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var categoriaParameter = categoria != null ?
                new ObjectParameter("categoria", categoria) :
                new ObjectParameter("categoria", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("marca", marca) :
                new ObjectParameter("marca", typeof(string));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("editarProductos", nombreParameter, descripcionParameter, categoriaParameter, marcaParameter, cantidadParameter, precioParameter, idParameter);
        }
    
        public virtual int editarUsuario(Nullable<int> dUI, string nomUsuario, string password, string nombre, string email, Nullable<int> telefono, string tipo, Nullable<int> id)
        {
            var dUIParameter = dUI.HasValue ?
                new ObjectParameter("DUI", dUI) :
                new ObjectParameter("DUI", typeof(int));
    
            var nomUsuarioParameter = nomUsuario != null ?
                new ObjectParameter("nomUsuario", nomUsuario) :
                new ObjectParameter("nomUsuario", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("editarUsuario", dUIParameter, nomUsuarioParameter, passwordParameter, nombreParameter, emailParameter, telefonoParameter, tipoParameter, idParameter);
        }
    
        public virtual int eliminarProducto(Nullable<int> idpro)
        {
            var idproParameter = idpro.HasValue ?
                new ObjectParameter("idpro", idpro) :
                new ObjectParameter("idpro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("eliminarProducto", idproParameter);
        }
    
        public virtual int eliminarUsuario(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("eliminarUsuario", idParameter);
        }
    
        public virtual int insertarProducto(string nombre, string descripcion, string categoria, string marca, Nullable<int> cantidad, Nullable<decimal> precio)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var categoriaParameter = categoria != null ?
                new ObjectParameter("categoria", categoria) :
                new ObjectParameter("categoria", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("marca", marca) :
                new ObjectParameter("marca", typeof(string));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertarProducto", nombreParameter, descripcionParameter, categoriaParameter, marcaParameter, cantidadParameter, precioParameter);
        }
    
        public virtual int insertarUsuario(Nullable<int> dUI, string nomUsuario, string password, string nombre, string email, Nullable<int> telefono, string tipo)
        {
            var dUIParameter = dUI.HasValue ?
                new ObjectParameter("DUI", dUI) :
                new ObjectParameter("DUI", typeof(int));
    
            var nomUsuarioParameter = nomUsuario != null ?
                new ObjectParameter("nomUsuario", nomUsuario) :
                new ObjectParameter("nomUsuario", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertarUsuario", dUIParameter, nomUsuarioParameter, passwordParameter, nombreParameter, emailParameter, telefonoParameter, tipoParameter);
        }
    
        public virtual ObjectResult<mostrarProducto_Result> mostrarProducto()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrarProducto_Result>("mostrarProducto");
        }
    
        public virtual ObjectResult<mostrarUsuarios_Result> mostrarUsuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostrarUsuarios_Result>("mostrarUsuarios");
        }
    }
}