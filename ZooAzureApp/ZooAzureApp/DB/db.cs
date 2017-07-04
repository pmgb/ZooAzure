using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarRentelWeb
{
    public static class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                //string cadenaConexion = @"Server=.\sqlexpress;
                //                          Database=carrental;
                //                          User Id=testuser;
                //                          Password=!Curso@2017;";

                // string cadenaConexion = @"Server=carmencgserver.database.windows.net;Database=PedroMGB2;User Id=testuser;Password=!Curso@2017;";
                //string cadenaConexion = ConfigurationManager.ConnectionStrings["Miconexion"].ConnectionString;

                // CONEXIÓN CON AZURE
                //string cadenaConexion = @"Server=carmencgserver.database.windows.net;
                //                          Database=PedroMGB2;
                //                          User Id=testuser;
                //                          Password=!Curso@2017;";
                string cadenaConexion = ConfigurationManager.ConnectionStrings["Miconexion"].ConnectionString;

                // CREO LA CONEXIÓN
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // TRATO DE ABRIR LA CONEXION
                conexion.Open();

                //// PREGUNTO POR EL ESTADO DE LA CONEXIÓN
                //if (conexion.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("Conexión abierta con éxito");
                //    // CIERRO LA CONEXIÓN
                //    conexion.Close();
                //}
            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            finally
            {
                // DESTRUYO LA CONEXIÓN
                //if (conexion != null)
                //{
                //    if (conexion.State != ConnectionState.Closed)
                //    {
                //        conexion.Close();
                //        Console.WriteLine("Conexión cerrada con éxito");
                //    }
                //    conexion.Dispose();
                //    conexion = null;
                //}
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        