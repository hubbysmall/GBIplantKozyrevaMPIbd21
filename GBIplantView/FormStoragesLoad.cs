﻿using GBIplantService.BindingModels;
using GBIplantService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBIplantView
{
    public partial class FormStoragesLoad : Form
    {
        private readonly IReportingService service;

        public FormStoragesLoad(IReportingService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormStoragesLoad_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = service.GetStorageLoad();
                if (dict != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView1.Rows.Add(new object[] { elem.StorageName, "", "" });
                        foreach (var listElem in elem.GBIingridients)
                        {
                            dataGridView1.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView1.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView1.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    service.SaveStorageLoad(new ReportingBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

   
    }
}