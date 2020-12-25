using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientForm3b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		ClassData classData = new ClassData();
		public void TampilData()
		{
			var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
			var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

			dataGridView1.DataSource = data;

		}

		public void SearchData()
		{
			var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
			var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
			string nim = textBoxNIM.Text;
			if (nim == null || nim == "")
			{
				dataGridView1.DataSource = data;
			}
			else
			{
				var item = data.Where(x => x.nim == textBoxNIM.Text).ToList();

				dataGridView1.DataSource = item;
			}
		}

		public class Mahasiswa
		{
			private string _nama, _nim, _prodi, _angkatan;
			public string nama
			{
				get { return _nama; }
				set { _nama = value; }
			}

			public string nim
			{
				get { return _nim; }
				set { _nim = value; }
			}

			public string prodi
			{
				get { return _prodi; }
				set { _prodi = value; }
			}

			public string angkatan
			{
				get { return _angkatan; }
				set { _angkatan = value; }
			}
		}

		string baseurl = "http://localhost:1908/";
		private void btUpdate_Click(object sender, EventArgs e)
        {
			if (textBoxNIM.Text != "" &&
				textBoxNama.Text != "" &&
				textBoxProdi.Text != "" &&
				textBoxAngkatan.Text != "")
			{
				if (textBoxNIM.Text.Length <= 12 &&
				textBoxAngkatan.Text.Length <= 4 &&
				textBoxProdi.Text.Length <= 30 &&
				textBoxNama.Text.Length <= 20)
				{
					try
					{
						Mahasiswa mhs = new Mahasiswa();
						mhs.nim = textBoxNIM.Text;
						mhs.nama = textBoxNama.Text;
						mhs.prodi = textBoxProdi.Text;
						mhs.angkatan = textBoxAngkatan.Text;

						ClassData classData = new ClassData();
						classData.updateDatabase(mhs);
						MessageBox.Show("Data successfuly updated");

						dataGridView1.DataSource = classData.getAllData();
					}
					catch
					{
						
						MessageBox.Show("Server Error");
					}
				}
				else
				{
					MessageBox.Show("Please check your data");
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}

        private void btDelete_Click(object sender, EventArgs e)
        {
			if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					ClassData classData = new ClassData();
					classData.deleteMahasiswa(textBoxNIM.Text);
					dataGridView1.DataSource = classData.getAllData();
					MessageBox.Show("Data successfuly deleted");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error");
				}
			}
		}

        private void buttonJumlah_Click(object sender, EventArgs e)
        {
			var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
			var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
			int length = data.Count();
			labelTotal.Text = Convert.ToString(length);
		}

        
    }
}
