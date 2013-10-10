using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FormulasInformes
{
    public class CuentaContable
    {
        DiarioDataContext oDC = new DiarioDataContext();
      
        private string _NumCuenta;

        public string NumCuenta
        {
            get { return _NumCuenta; }
            set { _NumCuenta = value; }
        }

        private  decimal _Debe;

        public decimal Debe
        {
            get { return _Debe; }
            set { _Debe = value; }
        }

        private  decimal _Haber;

        public decimal Haber
        {
            get { return _Haber; }
            set { _Haber = value; }
        }

        public decimal[] SumTotalGrupo(DateTime pFechaDesde,DateTime pFechaHasta,string pCuenta)
        {
            decimal[] dAux = new decimal[2];
            decimal oResultadoDebe, oResultadoHaber;
            oResultadoDebe = oResultadoHaber = 0;
            try
            {
                try
                {
                     oResultadoDebe = (from p in oDC.Diario
                                              where p.NumCuenta.StartsWith(pCuenta) &&
                                              (p.Fecha >= pFechaDesde && p.Fecha <= pFechaHasta)
                                              select new { p.Debe }).Sum(p => p.Debe);
                                        

                     oResultadoHaber = (from p in oDC.Diario
                                               where p.NumCuenta.StartsWith(pCuenta) &&
                                               (p.Fecha >= pFechaDesde && p.Fecha <= pFechaHasta)
                                               select new { p.Haber }).Sum(p => p.Haber);

                    dAux[1] = oResultadoDebe;
                    dAux[0] = oResultadoHaber;
                }
                catch
                {
                    oResultadoDebe = oResultadoHaber = 0;
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
           

            return dAux;
        }

        public void lectorFormulas(string pFormula)
        {
            CompilerParameters CompilerParams = new CompilerParameters();
            string outputDirectory = Directory.GetCurrentDirectory();

            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";

            string[] references = { "System.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compilar = provider.CompileAssemblyFromSource(CompilerParams, pFormula);

            if (compilar.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError ce in compilar.Errors)
                {
                    text += "rn" + ce.ToString();
                }
                throw new Exception(text);
            }

            //ExploreAssembly(compile.CompiledAssembly);

            Module module = compilar.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;

            if (module != null)
            {
                mt = module.GetType("DynaCore.DynaCore");
            }

            if (mt != null)
            {
                methInfo = mt.GetMethod("Main");
            }

            if (methInfo != null)
            {
                Console.WriteLine(methInfo.Invoke(null, new object[] { "here in dyna code" }));
            }
        }

    }
}
