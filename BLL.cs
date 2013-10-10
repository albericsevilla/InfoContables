using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FormulasInformes;

namespace InformesContables
{
    public class BLL
    {

        DiarioDataContext oDC = new DiarioDataContext();

        

         //Cargo la tabla diario entera y la meto a un dataSet
        public DataSet lstDiario()
        {
            System.Data.DataTable oTabla = new DataTable("TablaDiario");
            DataSet oDS = new DataSet();
            DataColumn oColumna;
            DataRow oFila;
            try
            {

                oColumna = new DataColumn();
                oColumna.DataType = System.Type.GetType("System.Int32");
                oColumna.ColumnName = "Id";
                oColumna.ReadOnly = true;
                oTabla.Columns.Add(oColumna);


                oColumna = new DataColumn();
                oColumna.DataType = System.Type.GetType("System.Int32");
                oColumna.ColumnName = "numOperacion";
                oColumna.ReadOnly = true;
                oTabla.Columns.Add(oColumna);

                oColumna = new DataColumn();
                oColumna.DataType = System.Type.GetType("System.String");
                oColumna.ColumnName = "NumCuenta";
                oColumna.ReadOnly = true;
                oTabla.Columns.Add(oColumna);

                oColumna = new DataColumn();
                oColumna.DataType = System.Type.GetType("System.String");
                oColumna.ColumnName = "Descripcion";
                oColumna.ReadOnly = true;
                oTabla.Columns.Add(oColumna);

                oColumna = new DataColumn();
                oColumna.DataType = System.Type.GetType("System.Decimal");
                oColumna.ColumnName = "Debe";
                oColumna.ReadOnly = true;
                oTabla.Columns.Add(oColumna);

                oColumna = new DataColumn();
                oColumna.DataType = System.Type.GetType("System.Decimal");
                oColumna.ColumnName = "Haber";
                oColumna.ReadOnly = true;
                oTabla.Columns.Add(oColumna);

                oColumna = new DataColumn();
                oColumna.DataType = System.Type.GetType("System.DateTime");
                oColumna.ColumnName = "Fecha";
                oColumna.ReadOnly = true;
                oTabla.Columns.Add(oColumna);

                var oListaAsientos = (from x in oDC.Diario
                                      select new
                                      {
                                          x.Fecha,
                                          x.ID,
                                          x.numOperacion,
                                          x.NumCuenta,
                                          x.Descripcion,
                                          x.Debe,
                                          x.Haber
                                      });

                foreach (var oRegistro in oListaAsientos)
                {

                    oFila = oTabla.NewRow();
                    oFila["Id"] = oRegistro.ID;
                    oFila["numOperacion"] = oRegistro.numOperacion;
                    oFila["Fecha"] = oRegistro.Fecha.Date;
                    oFila["NumCuenta"] = oRegistro.NumCuenta;
                    oFila["Descripcion"] = oRegistro.Descripcion;
                    if (oRegistro.Haber != 0 || oRegistro.Haber != 0)
                    {
                        oFila["Haber"] = oRegistro.Haber;
                    }
                    if (oRegistro.Debe != 0 || oRegistro.Debe != 0)
                    {
                        oFila["Debe"] = oRegistro.Debe;
                    }
                    oTabla.Rows.Add(oFila);
                }
                oTabla.AcceptChanges();
                oDS.Tables.Add(oTabla);
                return oDS;
            }
            catch
            {
                oDS.Tables.Add(oTabla);
                return oDS;
            }
        }
       
    }
}