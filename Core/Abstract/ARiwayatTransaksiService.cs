using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SpareLog.Core.Model;

namespace Project_SpareLog.Core.Abstract
{
    public abstract class ARiwayatTransaksiService
    {
        public abstract List<M_RiwayatTransaksi> GetAllRiwayatPelanggan();
        public abstract List<M_RiwayatTransaksi> GetRiwayatByNamaPelanggan(string namaPelanggan);
        public abstract List<M_RiwayatTransaksi> GetRiwayatPelangganByTanggal(DateTime tanggal);

        public abstract List<M_RiwayatTransaksi> GetAllRiwayatToko();
        public abstract List<M_RiwayatTransaksi> GetRiwayatByNamaToko(string namaToko);
        public abstract List<M_RiwayatTransaksi> GetRiwayatTokoByTanggal(DateTime tanggal);
    }
}
