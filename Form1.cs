

#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
//using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.XlsIO;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System;

namespace DetailsViewStackedHeaderRows
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            SampleCustomization();
            this.Load += new System.EventHandler(Form1_Load);
        }

        /// <summary>
        /// Occurs when the form is loading.
        /// </summary>
        /// <param name="sender">The sender of event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> that contains event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.sfDataGrid1.ExpandAllDetailsView();
        }

        /// <summary>
        /// Sets the sample customization settings.
        /// </summary>
        private void SampleCustomization()
        {
            this.sfDataGrid1.AllowGrouping = true;
            this.sfDataGrid1.ShowGroupDropArea = true;
            this.sfDataGrid1.AutoGenerateRelations = true;
            this.sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            this.sfDataGrid1.HideEmptyGridViewDefinition = true;
            DataTable parentTable = GetParentDataTable();
            DataTable childTable = GetChildDataTable();
            DataTable secondLevelTable = GetSecondLevelTable();
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(parentTable);
            dataSet.Tables.Add(childTable);
            dataSet.Tables.Add(secondLevelTable);

            dataSet.Relations.Add(new DataRelation("Parent_Child", dataSet.Tables[0].Columns["Customer ID"], dataSet.Tables[1].Columns["Customer ID"]));
            dataSet.Relations.Add(new DataRelation("SecondLevel", dataSet.Tables[1].Columns["Purchase ID"], dataSet.Tables[2].Columns["Purchase ID"]));

            //Event subscription
            this.sfDataGrid1.AutoGeneratingRelations += new Syncfusion.WinForms.DataGrid.Events.AutoGeneratingRelationsEventHandler(SfDataGrid1_AutoGeneratingRelations);
            this.sfDataGrid1.DataSource = dataSet.Tables[0];


        }

        //Event customization
        private void SfDataGrid1_AutoGeneratingRelations(object sender, Syncfusion.WinForms.DataGrid.Events.AutoGeneratingRelationsEventArgs e)
        {
            //To enable AutoGenerateColumns for child grid.
            e.GridViewDefinition.DataGrid.AutoGenerateRelations = true;
        }

        Random r = new Random();
        private DataTable GetParentDataTable()
        {
            DataTable OrderInfo = new DataTable();
            OrderInfo.Columns.Add("Order ID", typeof(int));
            OrderInfo.Columns.Add("Customer ID", typeof(int));
            OrderInfo.Columns.Add("Customer Name", typeof(string));
            OrderInfo.Columns.Add("Purchase Date", typeof(DateTime));
            OrderInfo.Columns.Add("Total Amount", typeof(float));
            OrderInfo.Rows.Add(2020,1001, "Belgim", DateTime.Now.AddDays(-r.Next(0,50)),r.Next(1000,5000));
            OrderInfo.Rows.Add(2021,1002, "Oliver", DateTime.Now.AddDays(-r.Next(0, 50)), r.Next(1000, 5000));
            OrderInfo.Rows.Add(2022,1003, "Bernald", DateTime.Now.AddDays(-r.Next(0, 50)), r.Next(1000, 5000));
            OrderInfo.Rows.Add(2023,1004, "James", DateTime.Now.AddDays(-r.Next(0, 50)), r.Next(1000, 5000));

            return OrderInfo;
        }

        private DataTable GetChildDataTable()
        {
            DataTable customerInfo = new DataTable();
            customerInfo.Columns.Add("Customer ID", typeof(int));
            customerInfo.Columns.Add("Name", typeof(string));
            customerInfo.Columns.Add("City", typeof(string));
            customerInfo.Columns.Add("Quantity", typeof(int));
            customerInfo.Columns.Add("UnitPrice", typeof(int));
            customerInfo.Columns.Add("Purchase ID", typeof(int));

            customerInfo.Rows.Add(1001, "Belgim", "California",10,50,2020);
            customerInfo.Rows.Add(1002, "Oliver", "California", 32, 40, 2021);
            customerInfo.Rows.Add(1003, "Bernald", "California", 89, 35, 2022);
            customerInfo.Rows.Add(1004, "James", "Colorado", 22, 50, 2023);

            return customerInfo;

        }

        private DataTable GetSecondLevelTable()
        {
            DataTable productInfo = new DataTable();
            productInfo.Columns.Add("Purchase ID", typeof(int));
            productInfo.Columns.Add("Product ID", typeof(int));
            productInfo.Columns.Add("Quantity", typeof(int));
            productInfo.Columns.Add("UnitPrice", typeof(int));

            productInfo.Rows.Add(2020, r.Next(1000, 1500), 10, 50);
            productInfo.Rows.Add(2020, r.Next(1000, 1500), 20, 35);

            productInfo.Rows.Add(2021, r.Next(1000, 1500), 98, 50);
            productInfo.Rows.Add(2021, r.Next(1000, 1500), 78, 65);

            productInfo.Rows.Add(2021, r.Next(1000, 1500), 89, 35);
            productInfo.Rows.Add(2021, r.Next(1000, 1500), 10, 65);

            productInfo.Rows.Add(2022, r.Next(1000, 1500), 22, 50);
            productInfo.Rows.Add(2022, r.Next(1000, 1500), 53, 40);
            productInfo.Rows.Add(2022, r.Next(1000, 1500), 65, 65);

            return productInfo;

        }


    }
}
