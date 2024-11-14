using RentAndSell.Car.FormApp.Commons.Enums;
using RentAndSell.Car.FormApp.Models;
using System.Drawing.Text;
using System.Net.Http.Json;

namespace RentAndSell.Car.FormApp
{
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        private const string _endPoint = "Cars";
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7168/api/");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cBoxYakitTuru.DataSource = Enum.GetValues(typeof(YakitTuru));
            cBoxMotorTipi.DataSource = Enum.GetValues(typeof(MotorTipi));
            cBoxSanzimanTipi.DataSource = Enum.GetValues(typeof(SanzimanTipi));

            //MessageBox.Show(cBoxYakitTuru.SelectedValue.ToString());
            //MessageBox.Show(cBoxMotorTipi.SelectedValue.ToString());
            //MessageBox.Show(cBoxSanzimanTipi.SelectedValue.ToString());

            //MessageBox.Show("" + (int)cBoxYakitTuru.SelectedValue);
            //MessageBox.Show("" + (int)cBoxMotorTipi.SelectedValue);
            //MessageBox.Show("" + (int)cBoxSanzimanTipi.SelectedValue);

            nbrUpDownYil.Maximum = DateTime.Now.Year;
            //nbrUpDownYil.Minimum = DateTime.Now.Year +50; //son 50 y�ll�k i� yap�yoruz

            for (short i = 1940; i <= DateTime.Now.Year; i++)
            {
                cBoxYil.Items.Add(i);
            }
            cBoxYil.SelectedIndex = 0;

            ReloadedDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ArabaViewModel model = new ArabaViewModel();

            model.Marka = txtMarka.Text;
            model.Model = txtModel.Text;
            model.Yili = (short)cBoxYil.SelectedItem;
            model.YakitTuru = (YakitTuru)cBoxYakitTuru.SelectedItem;
            model.MotorTipi = (MotorTipi)cBoxMotorTipi.SelectedItem;
            model.SanzimanTipi = (SanzimanTipi)cBoxSanzimanTipi.SelectedItem;

            HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(_endPoint, model).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Kay�t ba�ar�l�d�r. Yan�t : " + responseMessage.Content.ReadAsStringAsync().Result);
                ReloadedDataGridView();
            }
            else
            {
                MessageBox.Show("Kay�t Yap�lamad� :(");
            }
        }

        private void ReloadedDataGridView()
        {
            List<ArabaViewModel> arabaViewModels = _httpClient.GetFromJsonAsync<List<ArabaViewModel>>(_endPoint).Result;

            dgvArabaList.DataSource = arabaViewModels;
            ClearForm();
        }

        private void dgvArabaList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //List<ArabaViewModel> arabaViewModels = _httpClient.GetFromJsonAsync<List<ArabaViewModel>>(_endPoint).Result;

            ArabaViewModel selectedAraba = (ArabaViewModel)dgvArabaList.SelectedRows[0].DataBoundItem;

            txtId.Text = selectedAraba.Id.ToString();
            txtMarka.Text = selectedAraba.Marka;
            txtModel.Text = selectedAraba.Model;
            cBoxYil.SelectedItem = selectedAraba.Yili;
            cBoxYakitTuru.SelectedItem = selectedAraba.YakitTuru;
            cBoxMotorTipi.SelectedItem = selectedAraba.MotorTipi;
            cBoxSanzimanTipi.SelectedItem = selectedAraba.SanzimanTipi;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ArabaViewModel model = new ArabaViewModel();

            model.Marka = txtMarka.Text;
            model.Model = txtModel.Text;
            model.Yili = (short)cBoxYil.SelectedItem;
            model.YakitTuru = (YakitTuru)cBoxYakitTuru.SelectedItem;
            model.MotorTipi = (MotorTipi)cBoxMotorTipi.SelectedItem;
            model.SanzimanTipi = (SanzimanTipi)cBoxSanzimanTipi.SelectedItem;

            string id = txtId.Text;

            //https://localhost:7168/api/Cars/3 => Put id geliyor

            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(_endPoint + $"/{id}", model).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("G�ncelleme ba�ar�l�d�r. Yan�t : " + responseMessage.Content.ReadAsStringAsync().Result);
                ReloadedDataGridView();
            }
            else
            {
                MessageBox.Show("G�ncelleme Yap�lamad� :(");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            //https://localhost:7168/api/Cars/3 => Delete id geliyor

            HttpResponseMessage responseMessage = _httpClient.DeleteAsync(_endPoint + $"/{id}").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Silme i�lemi ba�ar�l�d�r. Yan�t : " + responseMessage.Content.ReadAsStringAsync().Result);
                ReloadedDataGridView();
            }
            else
            {
                MessageBox.Show("Silme i�lemi Yap�lamad� :(");
            }
        }
        private void ClearForm()
        {
            txtId.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            cBoxYil.SelectedIndex = 0;
            cBoxMotorTipi.SelectedIndex = 0;
            cBoxYakitTuru.SelectedIndex = 0;
            cBoxSanzimanTipi.SelectedIndex = 0;

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //buras� dbden orijinal kayd� okumak i�in ge�erli ve bu san�r�m daha sa�l�kl�. ��nk� dgvden se�ti�imiz kay�t hen�z dbden yenilenmemi� kay�t olabilir.
            string carId = txtcarId.Text;

            ArabaViewModel model = _httpClient.GetFromJsonAsync<ArabaViewModel>(_endPoint + $"/{carId}").Result;
            if (model!= null)
            {
                string metin = $@"
                                Marka : {model.Marka},
                                Model : {model.Model},
                                Yili : {model.Yili},
                                Yak�t T�r� : {model.YakitTuru},
                                Motor Tipi : {model.MotorTipi},
                                �anz�man Tipi : {model.SanzimanTipi},
                                ";
                MessageBox.Show(metin);
            }
            else
            {
                MessageBox.Show("Silme i�lemi Yap�lamad� :(");
            }
        }
    }
}
