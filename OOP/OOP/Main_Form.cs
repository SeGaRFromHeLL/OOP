﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;

namespace OOP
{
    public partial class Main_Form : Form
    {
        const string tables_data_path = "tables.dat";
        const string ip_info_path = "ip.ini";
        const string branches_info_path = "branches.inf";

        private TableManager tableManager;
        private DataGridView[] Tables;

        public Main_Form()
        {
            InitializeComponent();

            Tables = new DataGridView[] {
                first_dataGridView, second_dataGridView, third_dataGridView,
                fourth_dataGridView, fifth_dataGridView, sixth_dataGridView,
                seventh_dataGridView, eighth_dataGridView, ninth_dataGridView,
                tenth_dataGridView };

            TableManager.InitializeTables(Tables);
            tableManager = new TableManager(Tables);
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tableManager.FillTable((DataGridView)sender);
        }

        private void Save_send_button_Click(object sender, EventArgs e)
        {
            DataManager.Serialize(Tables, tables_data_path);
            DataManager.SendRequest(DataManager.MessageType.SendFile, tables_data_path);
            /*
            if (!DataManager.SendRequest(address, DataManager.MessageType.SendFile, tables_data_path))
            {
                MessageBox.Show(this, "Не удалось отправить данные на сервер\n\rПопробуйте позже",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            DataManager.ParseIp(ip_info_path);

            Login_Form login_Form = new Login_Form(branches_info_path);
            login_Form.ShowDialog(this);
            if (DataManager.BranchIndex < 0)
                Close();
            
            Text += ": Данные " + DataManager.BranchName;
            DataManager.Deserialize(Tables, tables_data_path);
        }
    }
}
