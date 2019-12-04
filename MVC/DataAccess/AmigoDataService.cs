using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVC.DataAccess
{
    public class AmigoDataService
    {
        private readonly SqlClient _client;

        public AmigoDataService(string connectionString)
        {
            _client = new SqlClient(connectionString);
        }

        public List<Amigo> GetAmigos()
        {
            var result = new List<Amigo>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "getamigos",
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var amigo = new Amigo
                        {
                            idamigo = Convert.ToInt32(dataReader["idamigo"].ToString()),
                            nombre = dataReader["nombre"].ToString(),
                            telefono = dataReader["telefono"].ToString(),
                            usuario = dataReader["usuario"].ToString(),
                            seguidores = dataReader["seguidores"].ToString(),
                            seguidos = dataReader["seguidos"].ToString(),
                            publicaciones = dataReader["publicaciones"].ToString(),
                            frase = dataReader["frase"].ToString(),
                            foto = dataReader["foto"].ToString()
                        };
                        result.Add(amigo);
                    }
                }
            }
            catch(Exception ex)
            {
                string a = ex.Message;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool AddAmigo(Amigo amigo)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "addamigo",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@telefono", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.telefono
                    };

                    var par2 = new SqlParameter("@nombre", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.nombre
                    };

                    var par3 = new SqlParameter("@usuario", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.usuario
                    };

                    var par4 = new SqlParameter("@contrasena", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.contrasena
                    };

                    var par5 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);
                    command.Parameters.Add(par5);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool DeleteSeguido(int idseguido)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "deleteseguido",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idseguido
                    };

                    var par5 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par5);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool RefreshAmigo(Amigo amigo)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "updateamigo",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par2 = new SqlParameter("@nombre", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.nombre
                    };


                    var par3 = new SqlParameter("@contrasena", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.contrasena
                    };

                    var par5 = new SqlParameter("@telefono", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.telefono
                    };

                    var par6 = new SqlParameter("@usuario", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.usuario
                    };

                    var par10 = new SqlParameter("@frase", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.frase
                    };

                    var par11 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par5);
                    command.Parameters.Add(par6);
                    command.Parameters.Add(par10);
                    command.Parameters.Add(par11);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public List<Seguir> GetSeguidor()
        {
            var result = new List<Seguir>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "getseguidor",
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var seguir = new Seguir
                        {
                            id = Convert.ToInt32(dataReader["id"].ToString()),
                            seguidor = dataReader["seguidor"].ToString(),
                            seguido = dataReader["seguido"].ToString()
                        };
                        result.Add(seguir);
                    }
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public List<Publicaciones> GetPubli()
        {
            var result = new List<Publicaciones>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "getpubli",
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var publi = new Publicaciones
                        {
                            id = Convert.ToInt32(dataReader["id"].ToString()),
                            descripcion = dataReader["descripcion"].ToString(),
                            likes = dataReader["likes"].ToString(),
                            idusuario = dataReader["idusuario"].ToString(),
                            foto = dataReader["foto"].ToString()
                        };
                        result.Add(publi);
                    }
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public List<Historia> GetHistoria()
        {
            var result = new List<Historia>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "gethistorias",
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var historia = new Historia
                        {
                            id = Convert.ToInt32(dataReader["id"].ToString()),
                            foto = dataReader["foto"].ToString(),
                            usuario = dataReader["usuario"].ToString()
                        };
                        result.Add(historia);
                    }
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

    }
}