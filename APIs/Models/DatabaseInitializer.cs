using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos;

namespace APIs.Models
{
    public class DatabaseInitializer:System.Data.Entity.CreateDatabaseIfNotExists<APIsContext>
    {
        protected override void Seed(APIsContext context) //funcion semilla para crear datos de muestra
        {
            context.Articles.Add(new articles { id = 1, name = "zapatos nike", description = "Zapatillas confortables para hombre", price = 250000, total_in_shelf = 20, total_in_vault = 400, store_id=1 });
            context.Articles.Add(new articles { id = 2, name = "zapatos adidas", description = "Zapatillas confortables unisex", price = 350000, total_in_shelf = 30, total_in_vault = 100, store_id = 2 });
            context.Articles.Add(new articles { id = 3, name = "zapatos reebook", description = "Botines confortables para hombre", price = 150000, total_in_shelf = 10, total_in_vault = 200, store_id = 2 });
            context.Articles.Add(new articles { id = 4, name = "zapatos vans", description = "Zapatillas confortables para mujer", price = 150000, total_in_shelf = 200, total_in_vault = 100, store_id = 3 });
            context.Articles.Add(new articles { id = 5, name = "zapatos kelme", description = "Zapatillas confortables unisex", price = 280000, total_in_shelf = 250, total_in_vault = 400, store_id = 1 });

            context.Stores.Add(new stores { id=1, name="Buenavista", address="Calle 98 Cra 53"});
            context.Stores.Add(new stores { id = 2, name = "Portal del Prado", address = "Calle 46 Cra 53" });
            context.Stores.Add(new stores { id = 3, name = "Viva", address = "Calle 90 Cra 51B" });
            base.Seed(context);
        }
    }
}