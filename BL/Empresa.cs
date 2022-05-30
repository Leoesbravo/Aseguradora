using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static ML.Result Add(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.EmpresaAdd(empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb, empresa.Logo);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.EmpresaDelete(empresa.IdEmpresa);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.EmpresaUpdate(empresa.IdEmpresa, empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb, empresa.Logo);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el update";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var empresas = context.EmpresaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (empresas != null)
                    {
                        foreach (var obj in empresas)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = obj.IdEmpresa;
                            empresa.Nombre = obj.Nombre;
                            empresa.Telefono = obj.Telefono;
                            empresa.Email = obj.Email;
                            empresa.DireccionWeb = obj.DireccionWeb;
                            empresa.Logo = obj.Logo;

                            result.Objects.Add(empresa);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByID(int IdEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var obj = context.EmpresaGetById(IdEmpresa).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();
                        empresa.IdEmpresa = obj.IdEmpresa;
                        empresa.Nombre = obj.Nombre;
                        empresa.Telefono = obj.Telefono;
                        empresa.Email = obj.Email;
                        empresa.DireccionWeb = obj.DireccionWeb;
                        empresa.Logo = obj.Logo;

                        result.Object = empresa;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
