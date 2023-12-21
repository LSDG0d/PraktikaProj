using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace praktika_galaktika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source=LSDGOD\SQLEXPRESS;Initial Catalog=praktik;Integrated Security=True");
        DataTable dtbl = new DataTable();
        DataTable dtbl2 = new DataTable();
        DataTable dtbl3 = new DataTable();
        SqlCommand cmd = new SqlCommand();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlDataAdapter adp = new SqlDataAdapter();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'praktikDataSet2.МаниРейн' table. You can move, or remove it, as needed.
            this.маниРейнTableAdapter.Fill(this.praktikDataSet2.МаниРейн);
            // TODO: This line of code loads data into the 'praktikDataSet2.Комиссии' table. You can move, or remove it, as needed.
            this.комиссииTableAdapter.Fill(this.praktikDataSet2.Комиссии);
            // TODO: This line of code loads data into the 'praktikDataSet2.Потребность' table. You can move, or remove it, as needed.
            this.потребностьTableAdapter.Fill(this.praktikDataSet2.Потребность);
            // TODO: This line of code loads data into the 'praktikDataSet2.Адрес' table. You can move, or remove it, as needed.
            this.адресTableAdapter.Fill(this.praktikDataSet2.Адрес);
            // TODO: This line of code loads data into the 'praktikDataSet2.Риэлтор' table. You can move, or remove it, as needed.
            this.риэлторTableAdapter.Fill(this.praktikDataSet2.Риэлтор);
            // TODO: This line of code loads data into the 'praktikDataSet2.Клиент' table. You can move, or remove it, as needed.
            this.клиентTableAdapter.Fill(this.praktikDataSet2.Клиент);
            // TODO: This line of code loads data into the 'praktikDataSet2.Сделка' table. You can move, or remove it, as needed.
            this.сделкаTableAdapter.Fill(this.praktikDataSet2.Сделка);
            // TODO: This line of code loads data into the 'praktikDataSet2.Предложение' table. You can move, or remove it, as needed.
            this.предложениеTableAdapter.Fill(this.praktikDataSet2.Предложение);
            // TODO: This line of code loads data into the 'praktikDataSet2.потребляйкины' table. You can move, or remove it, as needed.
            this.потребляйкиныTableAdapter.Fill(this.praktikDataSet2.потребляйкины);
            sqlcon.Open();
            if (sqlcon.State == ConnectionState.Open)
            {
                MessageBox.Show("Успешно!");
                adp = new SqlDataAdapter("SELECT * FROM [Клиент]", sqlcon);
                cmd = new SqlCommand($"SELECT * FROM [Клиент]", sqlcon);
                adp.SelectCommand = cmd;
                adp.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                adp = new SqlDataAdapter("SELECT * FROM [Риэлтор]", sqlcon);
                cmd = new SqlCommand($"SELECT * FROM [Риэлтор]", sqlcon);
                adp.SelectCommand = cmd;
                adp.Fill(dtbl2);
                dataGridView2.DataSource = dtbl2;
                adp = new SqlDataAdapter("select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                cmd = new SqlCommand($"select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                adp.SelectCommand = cmd;
                adp.Fill(dtbl3);
                dataGridView3.DataSource = dtbl3;
            }
            else
            {
                MessageBox.Show("Не удалось запустить БД.\nПопробуйте ещё раз.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [Клиент] (Фамилия, Имя, Отчество, НомерТелефона, ЭлектроннаяПочта) values (@Фамилия, @Имя, @Отчество, @НомерТелефона, @ЭлектроннаяПочта)", sqlcon);
            cmd.Parameters.AddWithValue("Фамилия", textBox1.Text);
            cmd.Parameters.AddWithValue("Имя", textBox2.Text);
            cmd.Parameters.AddWithValue("Отчество", textBox3.Text);
            cmd.Parameters.AddWithValue("НомерТелефона", textBox4.Text);
            cmd.Parameters.AddWithValue("ЭлектроннаяПочта", textBox5.Text);
            if (textBox4.Text == "" & textBox5.Text == "")
            {
                MessageBox.Show("Вы не указали Номер телефона или эл. почту!");
            }
            else
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Успех!");
                    adp = new SqlDataAdapter("SELECT * FROM [Клиент]", sqlcon);
                    cmd = new SqlCommand($"SELECT * FROM [Клиент]", sqlcon);
                    adp.SelectCommand = cmd;
                    dtbl.Clear();
                    adp.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                catch
                {
                    MessageBox.Show("Ошибка конвертации данных.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    cmd = new SqlCommand(@"DELETE FROM [Клиент] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Запись {id} была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Refresh();
                    adp = new SqlDataAdapter("SELECT * FROM [Клиент]", sqlcon);
                    cmd = new SqlCommand($"SELECT * FROM [Клиент]", sqlcon);
                    adp.SelectCommand = cmd;
                    dtbl.Clear();
                    adp.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
            else
            {
                MessageBox.Show("Выберите одну строку.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cmd = new SqlCommand($"UPDATE [Клиент] SET  Фамилия = @Фамилия, Имя = @Имя, Отчество = @Отчество, НомерТелефона = @НомерТелефона, ЭлектроннаяПочта = @ЭлектроннаяПочта  WHERE id = @id", sqlcon);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("Фамилия", textBox1.Text);
            cmd.Parameters.AddWithValue("Имя", textBox2.Text);
            cmd.Parameters.AddWithValue("Отчество", textBox3.Text);
            cmd.Parameters.AddWithValue("НомерТелефона", textBox4.Text);
            cmd.Parameters.AddWithValue("ЭлектроннаяПочта", textBox5.Text);
            if (textBox4.Text == "" & textBox5.Text == "")
            {
                MessageBox.Show("Вы не указали Номер телефона или эл. почту!");
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show($"Вы действительно хотите изменить запись {id}? Это действие нельзя будет отменить", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Запись {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        adp = new SqlDataAdapter("SELECT * FROM [Клиент]", sqlcon);
                        cmd = new SqlCommand($"SELECT * FROM [Клиент]", sqlcon);
                        adp.SelectCommand = cmd;
                        dtbl.Clear();
                        adp.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [Риэлтор] (Фамилия, Имя, Отчество, ДоляОтКомиссии) values (@Фамилия, @Имя, @Отчество, @ДоляОтКомиссии)", sqlcon);
            cmd.Parameters.AddWithValue("Фамилия", textBox9.Text);
            cmd.Parameters.AddWithValue("Имя", textBox8.Text);
            cmd.Parameters.AddWithValue("Отчество", textBox7.Text);
            cmd.Parameters.AddWithValue("ДоляОтКомиссии", textBox6.Text);
            if (textBox6.Text == "" || Convert.ToInt32(textBox6.Text) >= 0 && Convert.ToInt32(textBox6.Text) <= 100)
            {
                if (textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("Заполните поля ФИО");
                }
                else
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Успех!");
                        adp = new SqlDataAdapter("SELECT * FROM [Риэлтор]", sqlcon);
                        cmd = new SqlCommand($"SELECT * FROM [Риэлтор]", sqlcon);
                        adp.SelectCommand = cmd;
                        dtbl2.Clear();
                        adp.Fill(dtbl2);
                        dataGridView1.DataSource = dtbl2;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка конвертации данных.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильное значения комиссии!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    cmd = new SqlCommand(@"DELETE FROM [Риэлтор] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Запись {id} была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Refresh();

                    adp = new SqlDataAdapter("SELECT * FROM [Риэлтор]", sqlcon);
                    cmd = new SqlCommand($"SELECT * FROM [Риэлтор]", sqlcon);
                    adp.SelectCommand = cmd;
                    dtbl2.Clear();
                    adp.Fill(dtbl2);
                    dataGridView2.DataSource = dtbl2;
                }
            }
            else
            {
                MessageBox.Show("Выберите одну строку.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id;
            try
            {
                id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                cmd = new SqlCommand($"UPDATE [Риэлтор] SET  Фамилия = @Фамилия, Имя = @Имя, Отчество = @Отчество, ДоляОтКомиссии = @ДоляОтКомиссии  WHERE id = @id", sqlcon);

                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("Фамилия", textBox9.Text);
                cmd.Parameters.AddWithValue("Имя", textBox8.Text);
                cmd.Parameters.AddWithValue("Отчество", textBox7.Text);
                cmd.Parameters.AddWithValue("ДоляОтКомиссии", textBox6.Text);
                
                    if (MessageBox.Show($"Вы действительно хотите изменить запись {id}? Это действие нельзя будет отменить", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Запись {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Refresh();
                    }
                adp = new SqlDataAdapter("SELECT * FROM [Риэлтор]", sqlcon);
                cmd = new SqlCommand($"SELECT * FROM [Риэлтор]", sqlcon);
                adp.SelectCommand = cmd;
                dtbl2.Clear();
                adp.Fill(dtbl2);
                dataGridView2.DataSource = dtbl2;

            }
            catch
            {
                MessageBox.Show("Выберите строку");
            }
        }
    

        private void button8_Click(object sender, EventArgs e)
        {
            double x = 0;
            double x1 = 0;
            try
            {
                
                x = Convert.ToDouble(shirotatxt.Text);
                x1 = Convert.ToDouble(dolgotatxt.Text);
            }
            catch
            {
                MessageBox.Show("Не указаны координаты, взято значение 0/0");
            }
            if (x < - 90 || x>90 || x1 < -180 || x1 > 180)
            {
                MessageBox.Show("Некорректное значение координат");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO [Адрес] (Город, Улица, НомерДома, НомерКвартиры) values (@Город, @Улица, @НомерДома, @НомерКвартиры)", sqlcon);
                    cmd.Parameters.AddWithValue("Город", gorodtxt.Text);
                    cmd.Parameters.AddWithValue("Улица", ulicatxt.Text);
                    cmd.Parameters.AddWithValue("НомерДома", domtxt.Text);
                    cmd.Parameters.AddWithValue("НомерКвартиры", kvartiratxt.Text);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить в Адрес");
                }
                try
                {
                    cmd = new SqlCommand($"INSERT INTO [Координаты] (Долгота, Широта) values (@Долгота, @Широта)", sqlcon);
                    cmd.Parameters.AddWithValue("Долгота", dolgotatxt.Text);
                    cmd.Parameters.AddWithValue("Широта", shirotatxt.Text);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить в координаты");
                }

                if (radioButton2.Checked == true)
                {
                    try
                    {
                        cmd = new SqlCommand($"INSERT INTO [Дом] (ЭтажностьДома, КоличествоКомнат, Площадь) values (@ЭтажностьДома, @КоличествоКомнат, @Площадь)", sqlcon);
                        cmd.Parameters.AddWithValue("ЭтажностьДома", Etaj.Text);
                        cmd.Parameters.AddWithValue("КоличествоКомнат", Komnata.Text);
                        cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить в Дом. Попробуйте изменить данные, указав адрес.");
                    }
                }
                if (radioButton3.Checked == true)
                {
                    try
                    {
                        cmd = new SqlCommand($"INSERT INTO [Квартира] (Этаж, КоличествоКомнат, Площадь) values (@Этаж, @КоличествоКомнат, @Площадь)", sqlcon);
                        cmd.Parameters.AddWithValue("Этаж", Etaj.Text);
                        cmd.Parameters.AddWithValue("КоличествоКомнат", Komnata.Text);
                        cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить в Квартира. Попробуйте изменить данные, указав адрес.");
                    }
                }
                if (radioButton4.Checked == true)
                {
                    try
                    {
                        cmd = new SqlCommand($"INSERT INTO [Земля] (Площадь) values (@Площадь)", sqlcon);
                        cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить в Земля. Попробуйте изменить данные, указав адрес.");
                    }
                }
                MessageBox.Show("Успех!");
                adp = new SqlDataAdapter("select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                cmd = new SqlCommand($"select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                adp.SelectCommand = cmd;
                dtbl3.Clear();
                adp.Fill(dtbl3);
                dataGridView3.DataSource = dtbl3;
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 1)
            {
                string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                double x = 0;
                double x1 = 0;
                try
                {
                    x = Convert.ToDouble(shirotatxt.Text);
                    x1 = Convert.ToDouble(dolgotatxt.Text);
                }
                catch
                {
                    MessageBox.Show("Не указаны координаты, взято значение 0/0");
                }
                if (x < -90 || x > 90 || x1 < -180 || x1 > 180)
                {
                    MessageBox.Show("Некорректное значение координат");
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand($"UPDATE [Адрес] SET Город = @Город, Улица = @Улица, НомерДома = @НомерДома, НомерКвартиры = @НомерКвартиры  WHERE id = @id", sqlcon);
                        cmd.Parameters.AddWithValue("Город", gorodtxt.Text);
                        cmd.Parameters.AddWithValue("Улица", ulicatxt.Text);
                        cmd.Parameters.AddWithValue("НомерДома", domtxt.Text);
                        cmd.Parameters.AddWithValue("НомерКвартиры", kvartiratxt.Text);
                        cmd.Parameters.AddWithValue("id", id);
                        if (dataGridView1.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show($"Вы действительно хотите изменить запись {id}? Это действие нельзя будет отменить", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show($"Запись {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось изменить Адрес");
                    }
                    try
                    {
                        try
                        {
                            cmd = new SqlCommand($"UPDATE [Координаты] SET Долгота = @Долгота, Широта = @Широта where id = @id", sqlcon);
                            cmd.Parameters.AddWithValue("Долгота", dolgotatxt.Text);
                            cmd.Parameters.AddWithValue("Широта", shirotatxt.Text);
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"Координаты {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            cmd = new SqlCommand($"INSERT INTO [Координаты] (id, Долгота, Широта) values (@id, @Долгота, @Широта)", sqlcon);
                            cmd.Parameters.AddWithValue("Долгота", dolgotatxt.Text);
                            cmd.Parameters.AddWithValue("Широта", shirotatxt.Text);
                            cmd.Parameters.AddWithValue("id", id);
                            MessageBox.Show($"Координаты {id} была успешно добавлена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось изменить координаты");
                    }
                    if (radioButton2.Checked == true)
                    {
                        try
                        {
                            try
                            {
                                cmd = new SqlCommand($"UPDATE [Дом] SET ЭтажностьДома = @ЭтажностьДома, КоличествоКомнат = @КоличествоКомнат, Площадь = @Площадь where id = @id", sqlcon);
                                cmd.Parameters.AddWithValue("ЭтажностьДома", Etaj.Text);
                                cmd.Parameters.AddWithValue("КоличествоКомнат", Komnata.Text);
                                cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                                cmd.Parameters.AddWithValue("id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show($"Дом {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                cmd = new SqlCommand($"INSERT INTO [Дом] (id, ЭтажностьДома, КоличествоКомнат, Площадь) values (@id, @ЭтажностьДома, @КоличествоКомнат, @Площадь)", sqlcon);
                                cmd.Parameters.AddWithValue("ЭтажностьДома", Etaj.Text);
                                cmd.Parameters.AddWithValue("КоличествоКомнат", Komnata.Text);
                                cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                                cmd.Parameters.AddWithValue("id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show($"Дом {id} была успешно добавлена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось изменить Дом");
                        }
                    }
                    if (radioButton3.Checked == true)
                    {
                        try
                        {
                            try
                            {
                                cmd = new SqlCommand($"UPDATE [Квартира] SET Этаж = @Этаж, КоличествоКомнат = @КоличествоКомнат, Площадь = @Площадь where id = @id", sqlcon);
                                cmd.Parameters.AddWithValue("Этаж", Etaj.Text);
                                cmd.Parameters.AddWithValue("КоличествоКомнат", Komnata.Text);
                                cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                                cmd.Parameters.AddWithValue("id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show($"Квартира {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                cmd = new SqlCommand($"INSERT INTO [Квартира] (id, Этаж, КоличествоКомнат, Площадь) values (@id, @Этаж, @КоличествоКомнат, @Площадь)", sqlcon);
                                cmd.Parameters.AddWithValue("Этаж", Etaj.Text);
                                cmd.Parameters.AddWithValue("КоличествоКомнат", Komnata.Text);
                                cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                                cmd.Parameters.AddWithValue("id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show($"Квартира {id} была успешно добавлена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось изменить Квартира");
                        }
                    }
                    if (radioButton4.Checked == true)
                    {
                        try
                        {
                            try
                            {
                                cmd = new SqlCommand($"UPDATE [Земля] SET Площадь = @Площадь where id = @id", sqlcon);
                                cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                                cmd.Parameters.AddWithValue("id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show($"Земля {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                cmd = new SqlCommand($"INSERT INTO [Земля] (id, Площадь) values (@id, @Площадь)", sqlcon);
                                cmd.Parameters.AddWithValue("Площадь", ploshad.Text);
                                cmd.Parameters.AddWithValue("id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show($"Земля {id} была успешно добавлена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось изменить Земля");
                        }
                    }
                    MessageBox.Show("Успех!");
                    dataGridView3.Refresh();
                    dtbl3.Clear();
                    adp.Fill(dtbl3);
                    dataGridView3.DataSource = dtbl3;
                }
            }
            else
            {
                MessageBox.Show("Выберите одну строку");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 1)
            {
                string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageBox.Show($"Вы действительно хотите удалить запись {id}? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand(@"DELETE FROM [Дом] WHERE id = @id", sqlcon);
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось удалить из Дом");
                    }
                    try
                    {
                        cmd = new SqlCommand(@"DELETE FROM [Квартира] WHERE id = @id", sqlcon);
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось удалить из Квартира");
                    }
                    try
                    {
                        cmd = new SqlCommand(@"DELETE FROM [Земля] WHERE id = @id", sqlcon);
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось удалить из Квартира");
                    }

                    try
                    {
                        cmd = new SqlCommand(@"DELETE FROM [Координаты] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось удалить из Координаты");
                    }
                    try
                    {
                        cmd = new SqlCommand(@"DELETE FROM [Адрес] WHERE id = @id", sqlcon);
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось удалить из Адрес");
                    }
                MessageBox.Show($"Запись {id} была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView3.Refresh();

                    adp = new SqlDataAdapter("select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                    cmd = new SqlCommand($"select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                    adp.SelectCommand = cmd;
                    dtbl3.Clear();
                    adp.Fill(dtbl3);
                    dataGridView3.DataSource = dtbl3;
                }
            }
            else
            {
                MessageBox.Show("Выберите одну строку.");
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                dtbl3.Clear();

                adp = new SqlDataAdapter("select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                cmd = new SqlCommand($"select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Квартира.КоличествоКомнат,Квартира.Площадь,Квартира.Этаж, Земля.Площадь, Координаты.Долгота, Координаты.Широта from Адрес left join Дом on Дом.id = Адрес.id left join Квартира on Квартира.id = Адрес.id left join Земля on Земля.id = Адрес.id left join Координаты on Координаты.id = Адрес.id;", sqlcon);
                adp.SelectCommand = cmd;
                adp.Fill(dtbl3);
                dataGridView3.DataSource = dtbl3;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dtbl3.Clear();

                adp = new SqlDataAdapter("select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Координаты.Долгота, Координаты.Широта from [Дом] inner join[Адрес] on Дом.id = Адрес.id inner join[Координаты] on Координаты.id = Адрес.id; ", sqlcon);
                cmd = new SqlCommand($"select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Дом.ЭтажностьДома, Дом.КоличествоКомнат, Дом.Площадь, Координаты.Долгота, Координаты.Широта from [Дом] inner join[Адрес] on Дом.id = Адрес.id inner join[Координаты] on Координаты.id = Адрес.id; ", sqlcon);
                adp.SelectCommand = cmd;
                adp.Fill(dtbl3);
                dataGridView3.DataSource = dtbl3;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                dtbl3.Clear();

                adp = new SqlDataAdapter("select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Квартира.КоличествоКомнат, Квартира.Площадь, Квартира.Этаж, Координаты.Долгота, Координаты.Широта from [Квартира] inner join[Адрес] on Квартира.id = Адрес.id inner join[Координаты] on Координаты.id = Адрес.id; ", sqlcon);
                cmd = new SqlCommand($"select Адрес.id, Адрес.Город, Адрес.Улица, Адрес.НомерДома, Адрес.НомерКвартиры, Квартира.КоличествоКомнат, Квартира.Площадь, Квартира.Этаж, Координаты.Долгота, Координаты.Широта from [Квартира] inner join[Адрес] on Квартира.id = Адрес.id inner join[Координаты] on Координаты.id = Адрес.id;  ", sqlcon);
                adp.SelectCommand = cmd;
                adp.Fill(dtbl3);
                dataGridView3.DataSource = dtbl3;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            dtbl3.Clear();

            adp = new SqlDataAdapter("select Адрес.id, Адрес.Город, Адрес.Улица, Земля.Площадь, Координаты.Долгота, Координаты.Широта from [Земля] inner join[Адрес] on Земля.id = Адрес.id inner join[Координаты] on Координаты.id = Адрес.id; ", sqlcon);
            cmd = new SqlCommand($"select Адрес.id, Адрес.Город, Адрес.Улица, Земля.Площадь, Координаты.Долгота, Координаты.Широта from [Земля] inner join[Адрес] on Земля.id = Адрес.id inner join[Координаты] on Координаты.id = Адрес.id; ", sqlcon);
            adp.SelectCommand = cmd;
            adp.Fill(dtbl3);
            dataGridView3.DataSource = dtbl3;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string id = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
                    cmd = new SqlCommand(@"DELETE FROM [ПотребностьВДоме] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(@"DELETE FROM [ПотребностьВЗемле] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(@"DELETE FROM [ПотребностьВКвартире] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(@"DELETE FROM [Потребность] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Запись {id} была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView4.Refresh();
                    this.потребляйкиныTableAdapter.Fill(this.praktikDataSet2.потребляйкины);
                }
            }
            else
            {
                MessageBox.Show("Выберите одну строку.");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string id = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
                    cmd = new SqlCommand(@"DELETE FROM [Предложение] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Запись {id} была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.предложениеTableAdapter.Fill(this.praktikDataSet2.Предложение);
                }
            }
            else
            {
                MessageBox.Show("Выберите одну строку.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string value = comboBox1.SelectedValue.ToString();
            if (comboBox1.SelectedValue.ToString() != ""&& comboBox2.SelectedValue.ToString() != "" && comboBox3.SelectedValue.ToString() != ""&& textBox10.Text != "")
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO [Предложение] (Клиент, Риэлтор, ОбъектНедвижимости, Цена) values (@Клиент, @Риэлтор, @ОбъектНедвижимости, @Цена)", sqlcon);
                cmd.Parameters.AddWithValue("Клиент", comboBox1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Риэлтор", comboBox2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("ОбъектНедвижимости", comboBox3.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Цена", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Успех!");
                this.предложениеTableAdapter.Fill(this.praktikDataSet2.Предложение);
            }
            else
            {
                MessageBox.Show("Укажите все поля!");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
                cmd = new SqlCommand($"UPDATE [Предложение] SET  Клиент = @Клиент, Риэлтор = @Риэлтор, ОбъектНедвижимости = @ОбъектНедвижимости, Цена = @Цена WHERE id = @id", sqlcon);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("Клиент", comboBox1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Риэлтор", comboBox2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("ОбъектНедвижимости", comboBox3.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Цена", textBox10.Text);
                if (comboBox1.SelectedValue.ToString() == "" && comboBox2.SelectedValue.ToString() == "" && comboBox3.SelectedValue.ToString() == "" && textBox10.Text == "")
                {
                    MessageBox.Show("Вы не указали значения!");
                }
                else
                {
                    if (dataGridView5.SelectedRows.Count == 1)
                    {
                        if (MessageBox.Show($"Вы действительно хотите изменить запись {id}? Это действие нельзя будет отменить", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            this.предложениеTableAdapter.Fill(this.praktikDataSet2.Предложение);
                            MessageBox.Show($"Запись {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите строку.");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView6.SelectedRows.Count == 1)
            {
                string id = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageBox.Show($"Вы действительно хотите удалить запись {id}? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cmd = new SqlCommand(@"DELETE FROM [Сделка] WHERE id = @id", sqlcon);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Запись {id} была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.сделкаTableAdapter.Fill(this.praktikDataSet2.Сделка);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку.");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [Сделка] (Потребность, Предложение) values (@Потребность, @Предложение)", sqlcon);
            cmd.Parameters.AddWithValue("Потребность", comboBox8.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("Предложение", comboBox7.SelectedValue.ToString());
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Успех!");
                this.сделкаTableAdapter.Fill(this.praktikDataSet2.Сделка);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении!");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [Потребность] (Клиент, Риэлтор, ТипОбъектаНедвижимости, МинимальнаяЦена, МаксимальнаяЦена) values (@Клиент, @Риэлтор, @ТипОбъектаНедвижимости, @МинимальнаяЦена, @МаксимальнаяЦена)", sqlcon);
            cmd.Parameters.AddWithValue("Клиент", comboBox6.SelectedValue);
            cmd.Parameters.AddWithValue("Риэлтор", comboBox5.SelectedValue);
            cmd.Parameters.AddWithValue("ТипОбъектаНедвижимости", comboBox4.Text);
            cmd.Parameters.AddWithValue("МинимальнаяЦена", textBox11.Text);
            cmd.Parameters.AddWithValue("МаксимальнаяЦена", textBox12.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Добавлено в Потребность.");
            }
            catch
            {
                MessageBox.Show("Не удалость добавить в Потребность.");
            }
            this.потребляйкиныTableAdapter.Fill(this.praktikDataSet2.потребляйкины);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string id;
            try
            {
                id = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
                cmd = new SqlCommand($"UPDATE [Сделка] SET  Потребность = @Потребность, Предложение = @Предложение WHERE id = @id", sqlcon);

                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("Потребность", comboBox8.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Предложение", comboBox7.SelectedValue.ToString());
                if (dataGridView6.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show($"Вы действительно хотите изменить запись {id}? Это действие нельзя будет отменить", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Запись {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.сделкаTableAdapter.Fill(this.praktikDataSet2.Сделка);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string id;
            try
            {
                id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                
                

                if (MessageBox.Show($"Вы действительно хотите изменить запись {id}? Это действие нельзя будет отменить", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand($"UPDATE [Потребность] SET Клиент = @Клиент, Риэлтор = @Риэлтор, ТипОбъектаНедвижимости = @ТипОбъектаНедвижимости, МинимальнаяЦена = @МинимальнаяЦена, МаксимальнаяЦена = @МаксимальнаяЦена where id = @id", sqlcon);
                        cmd.Parameters.AddWithValue("Клиент", comboBox6.SelectedValue);
                        cmd.Parameters.AddWithValue("Риэлтор", comboBox5.SelectedValue);
                        cmd.Parameters.AddWithValue("ТипОбъектаНедвижимости", comboBox4.Text);
                        cmd.Parameters.AddWithValue("МинимальнаяЦена", textBox11.Text);
                        cmd.Parameters.AddWithValue("МаксимальнаяЦена", textBox12.Text);
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Потребность {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось изменить Потребность.");
                    }

                    if (comboBox4.Text == "Дом")
                    {
                        try
                        {
                            cmd = new SqlCommand($"UPDATE [ПотребностьВДоме] SET МинимальнаяПлощадь = @МинимальнаяПлощадь, МаксимальнаяПлощадь = @МаксимальнаяПлощадь, МинимальноеКоличествоКомнат = @МинимальноеКоличествоКомнат, МаксимальноеКоличествоКомнат = @МаксимальноеКоличествоКомнат, МинимальнаяЭтажностьКомнат = @МинимальнаяЭтажностьКомнат, МаксимальнаяЭтажностьКомнат = @МаксимальнаяЭтажностьКомнат where id = @id", sqlcon);
                            cmd.Parameters.AddWithValue("МинимальнаяПлощадь", textBox14.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяПлощадь", textBox13.Text);
                            cmd.Parameters.AddWithValue("МинимальноеКоличествоКомнат", textBox16.Text);
                            cmd.Parameters.AddWithValue("МаксимальноеКоличествоКомнат", textBox15.Text);
                            cmd.Parameters.AddWithValue("МинимальнаяЭтажностьКомнат", textBox18.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяЭтажностьКомнат", textBox17.Text);
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"ПотребностьВДоме {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {

                            id = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
                            cmd = new SqlCommand($"INSERT INTO [ПотребностьВДоме] (id, МинимальнаяПлощадь, МаксимальнаяПлощадь, МинимальноеКоличествоКомнат, МаксимальноеКоличествоКомнат, МинимальнаяЭтажностьКомнат, МаксимальнаяЭтажностьКомнат) values (@id, @МинимальнаяПлощадь, @МаксимальнаяПлощадь, @МинимальноеКоличествоКомнат, @МаксимальноеКоличествоКомнат, @МинимальнаяЭтажностьКомнат, @МаксимальнаяЭтажностьКомнат)", sqlcon);
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.Parameters.AddWithValue("МинимальнаяПлощадь", textBox14.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяПлощадь", textBox13.Text);
                            cmd.Parameters.AddWithValue("МинимальноеКоличествоКомнат", textBox16.Text);
                            cmd.Parameters.AddWithValue("МаксимальноеКоличествоКомнат", textBox15.Text);
                            cmd.Parameters.AddWithValue("МинимальнаяЭтажностьКомнат", textBox18.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяЭтажностьКомнат", textBox17.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"ПотребностьВДоме {id} была успешно создана", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (comboBox4.Text == "Квартира")
                    {
                        try
                        {
                            cmd = new SqlCommand($"UPDATE [ПотребностьВКвартире] SET МинимальнаяПлощадь = @МинимальнаяПлощадь, МаксимальнаяПлощадь = @МаксимальнаяПлощадь, МинимальноеКоличествоКомнат = @МинимальноеКоличествоКомнат, МаксимальноеКоличествоКомнат = @МаксимальноеКоличествоКомнат, МинимальныйЭтаж = @МинимальныйЭтаж, МаксимальныйЭтаж = @МаксимальныйЭтаж where id = @id", sqlcon);
                            cmd.Parameters.AddWithValue("МинимальнаяПлощадь", textBox14.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяПлощадь", textBox13.Text);
                            cmd.Parameters.AddWithValue("МинимальноеКоличествоКомнат", textBox16.Text);
                            cmd.Parameters.AddWithValue("МаксимальноеКоличествоКомнат", textBox15.Text);
                            cmd.Parameters.AddWithValue("МинимальныйЭтаж", textBox18.Text);
                            cmd.Parameters.AddWithValue("МаксимальныйЭтаж", textBox17.Text);
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"ПотребностьВКвартире {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {

                            id = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
                            cmd = new SqlCommand($"INSERT INTO [ПотребностьВКвартире] (id, МинимальнаяПлощадь, МаксимальнаяПлощадь, МинимальноеКоличествоКомнат, МаксимальноеКоличествоКомнат, МинимальныйЭтаж, МаксимальныйЭтаж) values (@id, @МинимальнаяПлощадь, @МаксимальнаяПлощадь, @МинимальноеКоличествоКомнат, @МаксимальноеКоличествоКомнат, @МинимальныйЭтаж, @МаксимальныйЭтаж)", sqlcon);
                            cmd.Parameters.AddWithValue("МинимальнаяПлощадь", textBox14.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяПлощадь", textBox13.Text);
                            cmd.Parameters.AddWithValue("МинимальноеКоличествоКомнат", textBox16.Text);
                            cmd.Parameters.AddWithValue("МаксимальноеКоличествоКомнат", textBox15.Text);
                            cmd.Parameters.AddWithValue("МинимальныйЭтаж", textBox18.Text);
                            cmd.Parameters.AddWithValue("МаксимальныйЭтаж", textBox17.Text);
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"ПотребностьВДоме {id} была успешно создана", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (comboBox4.Text == "Земля")
                    {
                        try
                        {
                            cmd = new SqlCommand($"UPDATE [ПотребностьВЗемле] SET МинимальнаяПлощадь = @МинимальнаяПлощадь, МаксимальнаяПлощадь = @МаксимальнаяПлощадь where id = @id", sqlcon);
                            cmd.Parameters.AddWithValue("МинимальнаяПлощадь", textBox14.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяПлощадь", textBox13.Text);
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"ПотребностьВЗемле {id} была успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {

                            id = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
                            cmd = new SqlCommand($"INSERT INTO [ПотребностьВКвартире] (id, МинимальнаяПлощадь, МаксимальнаяПлощадь) values (@id, @МинимальнаяПлощадь, @МаксимальнаяПлощадь)", sqlcon);
                            cmd.Parameters.AddWithValue("МинимальнаяПлощадь", textBox14.Text);
                            cmd.Parameters.AddWithValue("МаксимальнаяПлощадь", textBox13.Text);
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"ПотребностьВЗемле {id} была успешно создана", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void chillmode_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView7_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id, type;
            int kom2;
            try
            {
                id = dataGridView7.SelectedRows[0].Cells[0].Value.ToString();
                sdelid.Text = id;
                kom2 =Convert.ToInt32(dataGridView7.SelectedRows[0].Cells[1].Value.ToString());
                kompok.Text = $"3% ({kom2/100*3})";
                type = dataGridView7.SelectedRows[0].Cells[2].Value.ToString();
                if (type == "Квартира")
                {
                    komprod.Text = $"36000+1% ({36000 + kom2/100})";
                }
                else if (type == "Дом")
                {
                    komprod.Text = $"30000+1% ({30000 + kom2 / 100})";
                }
                else if (type == "Земля")
                {
                    komprod.Text = $"30000+2% ({30000 + kom2 / 100 * 2})";
                }
                else
                {

                }
            }
            catch
            {

            }
        }
    }
}
