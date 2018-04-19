﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.EstadoCuenta;
using InmobiliariaDataLayer.Connection;

namespace InmobiliariaDataLayer.Pagos
{
    public class DBPagos: ISelectForId
    {
        private PostConnection db;

        public DBPagos()
        {
            this.db = new PostConnection();
        }

        public object FindForId(int id)
        {
            var listaMoras = new List<PagosSelectViewModels>();
            string query = "SELECT saldo_anterior, saldo_actual, monto, fecha_a_pagar, fecha_cancelada " +
                        "FROM pagos WHERE venta_id = @id";

            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaMoras.Add(new PagosSelectViewModels()
                                {
                                    saldo_anterior = Convert.ToDouble(reader["saldo_anterior"]),
                                    saldo_actual = Convert.ToDouble(reader["saldo_actual"]),
                                    monto = Convert.ToDouble(reader["monto"]),
                                    fecha_pagar = Convert.ToDateTime(reader["fecha_a_pagar"]),
                                    fecha_cancelada = Convert.ToDateTime(reader["fecha_cancelada"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaMoras;
        }
    }
}