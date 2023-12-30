using Indiv.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indiv.Respository2
{
    internal class ClienteRepo2
    {
        Indiv2Context context = new Indiv2Context();

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
        public Cliente guardar(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return cliente;
        }
        public void eliminar(int id, Indiv2Context context)
        {
            //Colore colores = context.Colores.Find(id);
            Cliente clientes = new Cliente();
            clientes.Idcliente = id;
            context.Clientes.Remove(clientes);
            context.SaveChanges();
        }
        public void actualizar(int id, string nombre, string apellido, string identificacion, Indiv2Context context)
        {
            Cliente cl = context.Clientes.Find(id);
            cl.Nombres = nombre;
            cl.Apellidos = apellido;
            cl.Identificacion = identificacion;
            //context.Clientes.Update(cl);
            context.SaveChanges();
        }

        public void consultaID(int id, Indiv2Context context)
        {
            Cliente clientes = context.Clientes.Find(id);

            if (clientes != null)
                Console.WriteLine("El cliente buscado es: " + clientes.Apellidos+" "+clientes.Nombres+ "CI:" +clientes.Identificacion);
        }

        public ICollection<Cliente> consulta(Indiv2Context context)
        {
            ICollection<Cliente> clientes = context.Clientes.ToList();

            foreach (Cliente item in clientes)
            {
                Console.WriteLine($"ID: {item.Idcliente} Nombre: {item.Apellidos +item.Nombres} Identificacion: {item.Identificacion}");
            }

            return clientes;
        }
        public ICollection<Cliente> SQLNativo(SqlParameter identificacion, Indiv2Context context)
        {
            ;
            ICollection<Cliente> clientes = context.Clientes.FromSqlRaw($"Select * from Clientes where Identificacion = @Identificacion", identificacion).ToList();
            foreach (Cliente item in clientes)
            {
                Console.WriteLine($"ID: {item.Idcliente} Nombre: {item.Apellidos + item.Nombres} Identificacion: {item.Identificacion}");
            }
            return clientes;
        }
        public ICollection<Cliente> SQLSelect(string identificacion, Indiv2Context context)
        {
            Cliente cl = new Cliente();
            ICollection<Cliente> clientes = (from var in context.Clientes where var.Identificacion == identificacion select var).ToList();
            foreach (Cliente item in clientes)
            {
                Console.WriteLine($"ID: {item.Idcliente} Nombre: {item.Apellidos + item.Nombres} Identificacion: {item.Identificacion}");
            }
            return clientes;
        }

        public ICollection<Cliente> SqlSelecLamda(string identificacion, Indiv2Context context)
        {
            ICollection<Cliente> clientes = context.Clientes.Where(a => a.Identificacion.Equals(identificacion)).ToList();
            foreach (Cliente item in clientes)
            {
                Console.WriteLine($"ID: {item.Idcliente} Nombre: {item.Apellidos + item.Nombres} Identificacion: {item.Identificacion}");

            }
            return clientes;
        }

    }
}
