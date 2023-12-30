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
    internal class ColoreRepo2
    {
        Indiv2Context context = new Indiv2Context();

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
        public Colore guardar(Colore color)
        {
            context.Colores.Add(color);
            context.SaveChanges();
            return color;
        }

        public void eliminar(int id, Indiv2Context context)
        {
            //Colore colores = context.Colores.Find(id);
            Colore colores = new Colore();
            colores.Idcolor = id;
            context.Colores.Remove(colores);
            context.SaveChanges();
        }
        public void actualizar(int id, string color, Indiv2Context context)
        {
            //Colore c = new Colore();
            Colore c = context.Colores.Find(id);
            //c.Idcolor = id;
            c.Color = color;
            //context.Colores.Update(c);
            context.SaveChanges();
        }
        public void consultaID(int id, Indiv2Context context)
        {
            Colore colores = context.Colores.Find(id);

            if (colores != null)
                Console.WriteLine("El color buscado es: " + colores.Color);
        }
        public ICollection<Colore> consulta(Indiv2Context context)
        {
            ICollection<Colore> colores = context.Colores.ToList();

            foreach (Colore item in colores)
            {
                Console.WriteLine($"ID: {item.Idcolor} Color: {item.Color}");
            }

            return colores;
        }
        public ICollection<Colore> SQLNativo(SqlParameter color, Indiv2Context context)
        {
            
            ICollection<Colore> colores = context.Colores.FromSqlRaw("Select * from Colores where COLOR = @color", color).ToList();
            foreach (Colore item in colores)
            {
                Console.WriteLine($"ID: {item.Idcolor} Color: {item.Color}");
            }
            return colores;
        }

        public ICollection<Colore> SQLSelect(string colorBuscado, Indiv2Context context)
        {
            Colore c = new Colore();
            ICollection<Colore> colores = (from var in context.Colores where var.Color == colorBuscado select var).ToList();
            foreach (Colore item in colores)
            {
                Console.WriteLine($"ID: {item.Idcolor} Color: {item.Color}");
            }
            return colores;
        }
        public ICollection<Colore> SqlSelecLamda(string colorBuscado, Indiv2Context context)
        {
            ICollection<Colore> colores = context.Colores.Where(a => a.Color.Equals(colorBuscado)).ToList();
            foreach (Colore item in colores)
            {
                Console.WriteLine($"ID: {item.Idcolor} Color: {item.Color}");

            }
            return colores;
        }

    }
}

