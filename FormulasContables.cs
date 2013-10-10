using InformesContables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulasInformes
{
    public class FormulasContables
    {
        CuentaContable oCuenta = new CuentaContable();

        //Otras operaciones con socios o propietarios
        public decimal otrasOpSociosPropietarios(DateTime pDesde,DateTime pHasta)
        {
            decimal res = 0;
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasOpSociosPropietariosVar1)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasOpSociosPropietariosVar1)[1];
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasOpSociosPropietariosVar2)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasOpSociosPropietariosVar2)[1];
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasOpSociosPropietariosVar3)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasOpSociosPropietariosVar3)[1];

            return res;  
        }

        //Otras variaciones del patrimonio neto
        public decimal otrasVariacionesPN(DateTime pDesde, DateTime pHasta)
        {
            decimal res = 0;
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar1)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar1)[1];
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar2)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar2)[1];
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar3)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar3)[1];
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar4)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar4)[1];
            res += oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar5)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.otrasVariacionesPNVar5)[1];
            return res;
        }

        //Rdo Ejercicio
        public decimal rdoEjercicio(DateTime pDesde, DateTime pHasta)
        {
            return (oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.rdoEjercicio)[0] - oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.rdoEjercicio)[1]);
        }

        //Subvenciones donaciones y legados
        public decimal subvDonacionesLegados(DateTime pDesde, DateTime pHasta)
        {
            return oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.subvDonacionesLegadosVar1)[0];
        }

        //Ingresos Fiscales a distribuir
        public decimal ingreFiscalesDistribuir(DateTime pDesde, DateTime pHasta)
        {
            return oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.ingreFiscalesDistribuirVar1)[0];
        }

        //Aumentos del capital
        public decimal aumentoCapital(DateTime pDesde, DateTime pHasta)
        {
            return oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.aumentoDisminucionCapitalVar1)[0];
        }
       
        //Disminucion del capital
        public decimal disminucionCapital(DateTime pDesde, DateTime pHasta)
        {
            return oCuenta.SumTotalGrupo(pDesde, pHasta, RecursosCuentas.aumentoDisminucionCapitalVar1)[1];
        }

    }
}
