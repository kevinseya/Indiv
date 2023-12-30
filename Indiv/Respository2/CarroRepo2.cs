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
    internal class CarroRepo2
    {
        Indiv2Context context = new Indiv2Context();

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
        public Carro guardar(Carro carro)
        {
            context.Carros.Add(carro);
            context.SaveChanges();
            return carro;
        }
        public void eliminar(int id, Indiv2Context context)
        {
            //Colore colores = context.Colores.Find(id);
            Carro carros = new Carro();
            carros.Idcarro = id;
            context.Carros.Remove(carros);
            context.SaveChanges();
        }
        public void actualizar( int id, string modelo, int aniofabricacion, int idcolor, Indiv2Context context)
        {
            //Carro cr = new Carro();
            //cr.Idcarro = id;
            Carro cr = context.Carros.Find(id);
            cr.Modelo = modelo;
            cr.Aniofabricacion = aniofabricacion;
            cr.Colorid = idcolor;
            //context.Carros.Update(cr);
            context.SaveChanges();
        }

        public void consultaID(int id, Indiv2Context context)
        {
            Carro carros = context.Carros.Find(id);

            if (carros != null)
                Console.WriteLine("El carro buscado es: " + carros.Modelo+" "+ carros.Aniofabricacion );
        }

        public ICollection<Carro> consulta(Indiv2Context context)
        {
            ICollection<Carro> carros = context.Carros.ToList();

            foreach (Carro item in carros)
            {
                Console.WriteLine($"ID: {item.Colorid} Modelo: {item.Modelo} Año de fabricacion: {item.Aniofabricacion}");
            }

            return carros;
        }
        public ICollection<Carro> SQLNativo(SqlParameter modelo, Indiv2Context context)
        {
            ;
            ICollection<Carro> carros = context.Carros.FromSqlRaw($"Select * from Carros where Modelo = @Modelo", modelo).ToList();
            foreach (Carro item in carros)
            {
                Console.WriteLine($"ID: {item.Colorid} Modelo: {item.Modelo} Año de fabricacion: {item.Aniofabricacion}");
            }
            return carros;
        }
        public ICollection<Carro> SQLSelect(string modelo, Indiv2Context context)
        {
            Carro cr = new Carro();
            ICollection<Carro> carros = (from var in context.Carros where var.Modelo == modelo select var).ToList();
            foreach (Carro item in carros)
            {
                Console.WriteLine($"ID: {item.Colorid} Modelo: {item.Modelo} Año de fabricacion: {item.Aniofabricacion}");
            }
            return carros;
        }

        public ICollection<Carro> SqlSelecLamda(string modelo, Indiv2Context context)
        {
            ICollection<Carro> carros = context.Carros.Where(a => a.Modelo.Equals(modelo)).ToList();
            foreach (Carro item in carros)
            {
                Console.WriteLine($"ID: {item.Colorid} Modelo: {item.Modelo} Año de fabricacion: {item.Aniofabricacion}");

            }
            return carros;
        }


    }
}
