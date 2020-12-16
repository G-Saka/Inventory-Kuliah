﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory.view
{
    /// <summary>
    /// Interaction logic for KategoriBarang.xaml
    /// </summary>
    public partial class KategoriBarang : Window
    {
        private string proses;
        private Boolean hasil;
        private controller.KategoriController controller;
        public KategoriBarang()
        {
            InitializeComponent();
            controller = new controller.KategoriController(this);
            tampilData();
        }

        private void btnBeranda_Click(object sender, RoutedEventArgs e)
        {
            view.MenuUtama menu = new view.MenuUtama();
            menu.Show();
            this.Close();
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            proses = "INSERT";
            txtIdKategori.Text = "TIDAK BISA DIEDIT";
            txtIdKategori.IsReadOnly = true;
            aturButton(false);
        }
        public void aturButton(Boolean status)
        {
            btnTambah.IsEnabled = status;
            btnEdit.IsEnabled = status;
            btnHapus.IsEnabled = status;
            btnSave.IsEnabled = !status;
            btnBatal.IsEnabled = !status;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (proses == "INSERT")
            {

                if (!checkNull()) hasil = controller.insertKategori();
                clearAll();
            }
            else if (proses == "UPDATE")
            {
                if (!checkNull()) hasil = controller.updateKategori();
                clearAll();

            }
            else if (proses == "DELETE")
            {
                hasil = controller.deleteKategori();
                clearAll();

            }
            if (hasil == true)
            {
                MessageBox.Show("Berhasil!");
            }
            else
            {
                MessageBox.Show("Gagal Menyimpan");
            }
            tampilData();
        }
        private Boolean checkNull()
        {
            bool kosong;
            kosong = false;
            if (txtIdKategori.Text == "" || txtNamaKategori.Text == "")
            {
                MessageBox.Show("ANDA HARUS MENGISI SEMUA FIELD!", "ERROR!");
                kosong = true;
            }
            return kosong;
        }
        private void clearAll()
        {
            txtIdKategori.IsReadOnly = false;
            txtIdKategori.Text = "";
            txtNamaKategori.IsReadOnly = false;
            txtNamaKategori.Text = "";
        }
        public void tampilData()
        {
            controller.selectKategori();
            aturButton(true);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window1 loginPage = new Window1();
            loginPage.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdKategori.Text == "" || txtIdKategori.Text == "ID")
            {
                MessageBox.Show("MOHON ISI ID KATEGORI", "ERROR!");
            }
            else
            {
                proses = "UPDATE";
                aturButton(false);
                List<string> dataKategori = new List<string>();
                dataKategori = controller.GetDataUpdateById();
                txtIdKategori.Text = dataKategori[0];
                txtIdKategori.IsReadOnly = true;
                txtNamaKategori.Text = dataKategori[1];
            }
        }

        private void btnHapus1_Click(object sender, RoutedEventArgs e)
        {
            txtNamaKategori.Text = "TIDAK BISA DIEDIT";
            txtNamaKategori.IsReadOnly = true;
            txtIdKategori.Text = "";
            txtIdKategori.Focus();
            proses = "DELETE";
            aturButton(false);
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
            aturButton(true);
        }

        private void btnBarang1_Click(object sender, RoutedEventArgs e)
        {
            DataBarang data = new DataBarang();
            data.Show();
            this.Close();
        }

        private void btnDataBarang1_Click(object sender, RoutedEventArgs e)
        {
            DataBarang data = new DataBarang();
            data.Show();
            this.Close();
        }
    }
}
