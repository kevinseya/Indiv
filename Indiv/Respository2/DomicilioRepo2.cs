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
    internal class DomicilioRepo2
    {
        Indiv2Context context = new Indiv2Context();

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
        public Domicilio guardar(Domicilio domicilio)
        {
            context.Domicilios.Add(domicilio);
            context.SaveChanges();
            return domicilio;
        }
        public void eliminar(int id, Indiv2Context context)
        {
            //Colore colores = context.Colores.Find(id);
            Domicilio domicilios = new Domicilio();
            domicilios.Iddomicilio = id;
            context.Domicilios.Remove(domicilios);
            context.SaveChanges();
        }
        public void actualizar(int id, string calle, string numerocasa, int idcliente, Indiv2Context context)
        {

            //Domicilio dom = new Domicilio();
            //dom.Iddomicilio = id;
            Domicilio dom = context.Domicilios.Find(id);
            dom.Calle = calle;
            dom.Numerocasa = numerocasa;
            dom.Clientesid = idcliente;
            //context.Domicilios.Update(dom);
            context.SaveChanges();
        }

        public void consultaID(int id, Indiv2Context context)
        {
            Domicilio domicilios = context.Domicilios.Find(id);

            if (domicilios != null)
                Console.WriteLine("El domicilio buscado es: " + domicilios.Numerocasa + " Ubicado en: " + domicilios.Calle);
        }

        public ICollection<Domicilio> consulta(Indiv2Context context)
        {
            ICollection<Domicilio> domicilios = context.Domicilios.ToList();

            foreach (Domicilio item in domicilios)
            {
                Console.WriteLine($"ID: {item.Iddomicilio} Número de casa: {item.Numerocasa} Calles: {item.Calle}");
            }

            return domicilios;
        }
        public ICollection<Domicilio> SQLNativo(SqlParameter numerocasa, Indiv2Context context)
        {
            ;
            ICollection<Domicilio> domicilios = context.Domicilios.FromSqlRaw($"Select * from Domicilio where NUMEROCASA = @Numerocasa", numerocasa).ToList();
            foreach (Domicilio item in domicilios)
            {
                Console.WriteLine($"ID: {item.Iddomicilio} Número de casa: {item.Numerocasa} Calles: {item.Calle}");
            }
            return domicilios;
        }
        public ICollection<Domicilio> SQLSelect(string numerocasa, Indiv2Context context)
        {
            Domicilio dom = new Domicilio();
            ICollection<Domicilio> domicilios = (from var in context.Domicilios where var.Numerocasa == numerocasa select var).ToList();
            foreach (Domicilio item in domicilios)
            {
                Console.WriteLine($"ID: {item.Iddomicilio} Número de casa: {item.Numerocasa} Calles: {item.Calle}");
            }
            return domicilios;
        }

        public ICollection<Domicilio> SqlSelecLamda(string numerocasa, Indiv2Context context)
        {
            ICollection<Domicilio> domicilios = context.Domicilios.Where(a => a.Numerocasa.Equals(numerocasa)).ToList();
            foreach (Domicilio item in domicilios)
            {
                Console.WriteLine($"ID: {item.Iddomicilio} Número de casa: {item.Numerocasa} Calles: {item.Calle}");

            }
            return domicilios;
        }
    }
}
