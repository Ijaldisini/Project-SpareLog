using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SpareLog.Core.Model;

namespace Project_SpareLog.Core.Abstract
{
    public abstract class ALaporanService
    {
        public abstract List<M_Laporan> GetLaporanPenjualan();
        public abstract List<M_Laporan> GetLaporanPenjualanByTanggal(DateTime tanggal);

        public abstract List<M_Laporan> GetLaporanPembelian();
        public abstract List<M_Laporan> GetLaporanPembelianByTanggal(DateTime tanggal);
    }
}
