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

		public void TampilData()
		{
			var json = new WebClient().DownloadString("http://localhost:1115/Mahasiswa");
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
			var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
			var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

			string nim = textBoxNIM.Text;
			var item = data.Where(x => x.nim == textBoxNIM.Text).FirstOrDefault();
			if (item != null)
			{
				// update logger with your textboxes data
				item.nama = textBoxNama.Text;
				item.nim = textBoxNIM.Text;
				item.prodi = textBoxProdi.Text;
				item.angkatan = textBoxAngkatan.Text;

				// Save everything
				string output = JsonConvert.SerializeObject(item, Formatting.Indented);
				var postdata = new WebClient();
				postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
				string response = postdata.UploadString(baseurl + "UpdateMahasiswa", output);
				Console.WriteLine(response);
				TampilData();

			}
		}

        private void btDelete_Click(object sender, EventArgs e)
        {
			var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
			var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

			if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{

				string nim = textBoxNIM.Text;
				var item = data.Where(x => x.nim == textBoxNIM.Text).FirstOrDefault();
				if (item != null)
				{
					data.Remove(item);
					// Save everything
					string output = JsonConvert.SerializeObject(item, Formatting.Indented);
					var postdata = new WebClient();
					postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
					string response = postdata.UploadString(baseurl + "DeleteMahasiswa", output);
					Console.WriteLine(response);
					TampilData();
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
