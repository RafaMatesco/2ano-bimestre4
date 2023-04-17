using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private void nomeFoto()
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                label9.Text = opnfd.FileName;
                string nome = label9.Text;
                int found = 0;
                found = nome.IndexOf("imagem");
                nome = nome.Substring(found + 7);
                label9.Text = nome;
            }
        }
        private void deleteCodigo(string codigo)
        {
            MySqlConnection connection1 = new MySqlConnection(database);
            MySqlCommand command1 = connection1.CreateCommand();
            connection1.Open();
            command1.CommandText = "delete from tabela1 where codigo = '" + codigo + "';";
            MySqlDataReader Query1 = command1.ExecuteReader();
            label7.Text = "Registro excluído";
            connection1.Close();
        }
        private void updateCodigo(string cpf, string nome, string cidade, string bairro, string telefone, string imagem, string codigo)
        {
            MySqlConnection connection2 = new MySqlConnection(database);
            MySqlCommand command2 = connection2.CreateCommand();
            connection2.Open();
            command2.CommandText = "update tabela1 set cpf = '" + cpf + "', nome = '" + nome + "', cidade = '" + cidade + "', bairro = '" + bairro + "', telefone = '" + telefone + "', imagem = '" + imagem + "' where codigo =  '" + codigo + "';";
            MySqlDataReader Query2 = command2.ExecuteReader();
            label7.Text = "Registro atualizado";
            connection2.Close();
        }
        private void insertCodigo(string cpf, string nome, string cidade, string bairro, string telefone, string imagem, string codigo)
        {
            MySqlConnection connection1 = new MySqlConnection(database);
            MySqlCommand command1 = connection1.CreateCommand();
            connection1.Open();
            command1.CommandText = "insert into tabela1 values('" + codigo + "','" + cpf + "','" + nome + "','" + cidade + "','" + bairro + "','" + telefone + "', '" + imagem + "');";
            MySqlDataReader Query1 = command1.ExecuteReader();
            label7.Text = "Registro inserido";
            connection1.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //codigo
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //cpf
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //nome  
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //cidade
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //bairro
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //telefone
        }

        string database = "SERVER=localhost;DATABASE=bd;UID=root;PASSWORD=;";
        string[] reg;
        string[] cpf;
        string[] nome;
        string[] cidade;
        string[] bairro;
        string[] telefone;
        string[] imagem;
        int l = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            label9.Text = "";
            string codigo = textBox1.Text;
            MySqlConnection connection3 = new MySqlConnection(database);
            MySqlCommand command3 = connection3.CreateCommand();
            connection3.Open();
            command3.CommandText = "select * from tabela1 where codigo = '" + codigo + "';";
            MySqlDataReader Query3 = command3.ExecuteReader();
            bool res = Query3.Read();
            if(res == true)
            {
                textBox2.Text = Query3.GetString("cpf");
                textBox3.Text = Query3.GetString("nome");
                textBox4.Text = Query3.GetString("cidade");
                textBox5.Text = Query3.GetString("bairro");
                textBox6.Text = Query3.GetString("telefone");
                string dir = Query3.GetString("imagem");
                if (dir == "C:/imagem/")
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.Load(dir);
                }
                connection3.Close();
            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                pictureBox1.Image = null;
                connection3.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            label7.Text = "";
            MySqlConnection connection3 = new MySqlConnection(database);
            MySqlCommand command3 = connection3.CreateCommand();
            connection3.Open();
            command3.CommandText = "select * from tabela1 order by codigo;";
            MySqlDataReader Query3 = command3.ExecuteReader();
            bool res = Query3.Read();
            if (res == true)
            {
                int x = 1;
                while (Query3.Read())
                {
                    x += 1;
                }
                reg = new string[x];
                cpf = new string[x];
                nome = new string[x];
                cidade = new string[x];
                bairro = new string[x];
                telefone = new string[x];
                imagem = new string[x];

                MySqlConnection connection = new MySqlConnection(database);
                MySqlCommand command = connection.CreateCommand();
                connection.Open();
                command.CommandText = "select * from tabela1;";
                MySqlDataReader Query = command.ExecuteReader();
                int y = 0;
                while (Query.Read())
                {
                    reg[y] = Query.GetString("codigo");
                    cpf[y] = Query.GetString("cpf");
                    nome[y] = Query.GetString("nome");
                    cidade[y] = Query.GetString("cidade");
                    bairro[y] = Query.GetString("bairro");
                    telefone[y] = Query.GetString("telefone");
                    imagem[y] = Query.GetString("imagem");
                    y += 1;
                }

                int j = reg.Length - 1;
                l = j - j;
                textBox1.Text = reg[l];
                textBox2.Text = cpf[l];
                textBox3.Text = nome[l];
                textBox4.Text = cidade[l];
                textBox5.Text = bairro[l];
                textBox6.Text = telefone[l];
                string dir = imagem[l];
                if (dir == "C:/imagem/")
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.Load(dir);
                }
                connection3.Close();
                connection.Close();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                pictureBox1.Image = null;
                label7.Text = "Registro não existe";
                connection3.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            label7.Text = "";
            MySqlConnection connection3 = new MySqlConnection(database);
            MySqlCommand command3 = connection3.CreateCommand();
            connection3.Open();
            command3.CommandText = "select * from tabela1 order by codigo;";
            MySqlDataReader Query3 = command3.ExecuteReader();
            bool res = Query3.Read();
            if (res == true)
            {
                int x = 1;
                while (Query3.Read())
                {
                    x += 1;
                }
                reg = new string[x];
                cpf = new string[x];
                nome = new string[x];
                cidade = new string[x];
                bairro = new string[x];
                telefone = new string[x];
                imagem = new string[x];

                MySqlConnection connection = new MySqlConnection(database);
                MySqlCommand command = connection.CreateCommand();
                connection.Open();
                command.CommandText = "select * from tabela1;";
                MySqlDataReader Query = command.ExecuteReader();
                int y = 0;
                while (Query.Read())
                {
                    reg[y] = Query.GetString("codigo");
                    cpf[y] = Query.GetString("cpf");
                    nome[y] = Query.GetString("nome");
                    cidade[y] = Query.GetString("cidade");
                    bairro[y] = Query.GetString("bairro");
                    telefone[y] = Query.GetString("telefone");
                    imagem[y] = Query.GetString("imagem");
                    y += 1;
                }

                if (l <= reg.Length)
                {
                    if(l > 0) { 
                        textBox1.Text = reg[l-1];
                        textBox2.Text = cpf[l-1];
                        textBox3.Text = nome[l-1];
                        textBox4.Text = cidade[l-1];
                        textBox5.Text = bairro[l-1];
                        textBox6.Text = telefone[l - 1];
                        string dir = imagem[l-1];
                        if (dir == "C:/imagem/")
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            pictureBox1.Load(dir);
                        }
                        l -= 1;
                    }
                    else
                    {
                        l = reg.Length;
                        textBox1.Text = reg[l - 1];
                        textBox2.Text = cpf[l - 1];
                        textBox3.Text = nome[l - 1];
                        textBox4.Text = cidade[l - 1];
                        textBox5.Text = telefone[l - 1];
                        string dir = imagem[l - 1];
                        if (dir == "C:/imagem/")
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            pictureBox1.Load(dir);
                        }
                        l -= 1;
                    }

                }
                else
                {
                    l = 0;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    pictureBox1.Image = null;
                    label7.Text = "Registro não existe";
                }
                connection3.Close();
                connection.Close();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                pictureBox1.Image = null;
                label7.Text = "Registro não existe";
                connection3.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            label7.Text = "";
            MySqlConnection connection3 = new MySqlConnection(database);
            MySqlCommand command3 = connection3.CreateCommand();
            connection3.Open();
            command3.CommandText = "select * from tabela1 order by codigo;";
            MySqlDataReader Query3 = command3.ExecuteReader();
            bool res = Query3.Read();
            if (res == true)
            {
                int x = 1;
                while (Query3.Read())
                {
                    x += 1;
                }
                reg = new string[x];
                cpf = new string[x];
                nome = new string[x];
                cidade = new string[x];
                bairro = new string[x];
                telefone = new string[x];
                imagem = new string[x];

                MySqlConnection connection = new MySqlConnection(database);
                MySqlCommand command = connection.CreateCommand();
                connection.Open();
                command.CommandText = "select * from tabela1;";
                MySqlDataReader Query = command.ExecuteReader();
                int y = 0;
                while(Query.Read())
                {
                    reg[y] = Query.GetString("codigo");
                    cpf[y] = Query.GetString("cpf");
                    nome[y] = Query.GetString("nome");
                    cidade[y] = Query.GetString("cidade");
                    bairro[y] = Query.GetString("bairro");
                    telefone[y] = Query.GetString("telefone");
                    imagem[y] = Query.GetString("imagem");
                    y += 1;
                }

                if (l <= reg.Length-1) { 
                    textBox1.Text = reg[l];
                    textBox2.Text = cpf[l];
                    textBox3.Text = nome[l];
                    textBox4.Text = cidade[l];
                    textBox5.Text = bairro[l];
                    textBox6.Text = telefone[l];
                    string dir = imagem[l];
                    if (dir == "C:/imagem/")
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        pictureBox1.Load(dir);
                    }
                    l += 1;
                }
                else
                {
                    l = 0;
                    textBox1.Text = reg[l];
                    textBox2.Text = cpf[l];
                    textBox3.Text = nome[l];
                    textBox4.Text = cidade[l];
                    textBox5.Text = bairro[l];
                    textBox6.Text = telefone[l];
                    string dir = imagem[l];
                    if (dir == "C:/imagem/")
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        pictureBox1.Load(dir);
                    }
                    l += 1;
                }
                connection3.Close();
                connection.Close();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                pictureBox1.Image = null;
                label7.Text = "Registro não existe";
                connection3.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            label7.Text = "";
            MySqlConnection connection3 = new MySqlConnection(database);
            MySqlCommand command3 = connection3.CreateCommand();
            connection3.Open();
            command3.CommandText = "select * from tabela1 order by codigo;";
            MySqlDataReader Query3 = command3.ExecuteReader();
            bool res = Query3.Read();
            if (res == true)
            {
                int x = 1;
                while (Query3.Read())
                {
                    x += 1;
                }
                reg = new string[x];
                cpf = new string[x];
                nome = new string[x];
                cidade = new string[x];
                bairro = new string[x];
                telefone = new string[x];
                imagem = new string[x];

                MySqlConnection connection = new MySqlConnection(database);
                MySqlCommand command = connection.CreateCommand();
                connection.Open();
                command.CommandText = "select * from tabela1;";
                MySqlDataReader Query = command.ExecuteReader();
                int y = 0;
                while (Query.Read())
                {
                    reg[y] = Query.GetString("codigo");
                    cpf[y] = Query.GetString("cpf");
                    nome[y] = Query.GetString("nome");
                    cidade[y] = Query.GetString("cidade");
                    bairro[y] = Query.GetString("bairro");
                    telefone[y] = Query.GetString("telefone");
                    imagem[y] = Query.GetString("imagem");
                    y += 1;
                }

                l = reg.Length - 1;
                    textBox1.Text = reg[l];
                    textBox2.Text = cpf[l];
                    textBox3.Text = nome[l];
                    textBox4.Text = cidade[l];
                    textBox5.Text = bairro[l];
                    textBox6.Text = telefone[l];
                    string dir = imagem[l];
                if (dir == "C:/imagem/")
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.Load(dir);
                }
                
                connection3.Close();
                connection.Close();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                pictureBox1.Image = null;
                label7.Text = "Registro não existe";
                connection3.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label7.Text = "";

            string codigo = textBox1.Text;
            string cpf = textBox2.Text;
            string nome = textBox3.Text;
            string cidade = textBox4.Text;
            string bairro = textBox5.Text;
            string telefone = textBox6.Text;
            string imagem = label9.Text;
            string dir = "C:/imagem/";
            imagem = dir + imagem;
            string strFraseNova = Strings.StrConv(nome, VbStrConv.ProperCase);
            nome = strFraseNova;
            string strFraseNova1 = Strings.StrConv(cidade, VbStrConv.ProperCase);
            cidade = strFraseNova1;
            string strFraseNova2 = Strings.StrConv(bairro, VbStrConv.ProperCase);
            bairro = strFraseNova2;

            MySqlConnection connection = new MySqlConnection(database);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "select * from tabela1  where codigo = '" + codigo + "' ";
            MySqlDataReader Query = command.ExecuteReader();
            bool res = Query.Read();
          
                
                if (res == false) {
                    insertCodigo(cpf, nome, cidade, bairro, telefone, imagem, codigo);
                }
                else if(res == true)
                {
                    updateCodigo(cpf, nome, cidade, bairro, telefone, imagem, codigo);
                }
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label7.Text = "";            
            string codigo = textBox1.Text;

            MySqlConnection connection = new MySqlConnection(database);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "select * from tabela1  where codigo = '" + codigo + "' ";
            MySqlDataReader Query = command.ExecuteReader();
            bool res = Query.Read();
            

            if(res == true)
            {
                deleteCodigo(codigo);
                connection.Close();
            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                connection.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            nomeFoto();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
