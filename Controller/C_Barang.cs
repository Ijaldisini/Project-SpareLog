using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SpareLog.App.Core;
using Project_SpareLog.Model;

namespace Project_SpareLog.Controller
{
    public class C_Barang
    {
        private DatabaseWrapper db;

        public C_Barang()
        {
            db = new DatabaseWrapper();
        }
        public DataTable GetAllBarang()
        {
            string query = "SELECT * FROM barang";
            return db.queryExecutor(query);
        }

        public int GetNextIdBarang()
        {
            string query = "SELECT MAX(id_barang) AS max_id FROM barang";
            DataTable dt = db.queryExecutor(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["max_id"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["max_id"]) + 1;
            }
            return 1;
        }

        public int? GetIdBarangByNama(string nama)
        {
            string query = $"SELECT id_barang FROM barang WHERE nama_barang = '{nama}'";
            DataTable dt = db.queryExecutor(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["id_barang"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["id_barang"]);
            }
            return null;
        }


        public DataTable GetSuppliers()
        {
            return db.queryExecutor("SELECT id_supplier, nama_supplier FROM supplier");
        }

        public bool SimpanBarang(M_Barang barang)
        {
            string query = $"INSERT INTO barang (id_barang, nama_barang, stok_barang, harga_barang, hpp, supplier_id_supplier) " +
                           $"VALUES ('{barang.id_barang}', '{barang.nama_barang}', '{barang.stok_barang}', '{barang.harga_barang}', '{barang.hpp}', '{barang.supplier_id_supplier}')";
            return db.ExecuteNonQuery(query) > 0;
        }
    }
}
