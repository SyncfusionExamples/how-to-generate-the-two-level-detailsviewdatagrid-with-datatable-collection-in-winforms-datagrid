# How to generate the two level DetailsViewDataGrid with DataTable collection in WinForms DataGrid(SfDataGrid)

By default, the DetailsView will be added for single relation when the AutoGenerateRelations is enabled. To add multiple related tables in SfDataGrid, AutoGenerateRelations for each grid can be enabled through [SfDataGrid.AutoGeneratingRelations](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html?_gl=1*o7zm2r*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2OTcyMzQ0My4zMjIuMS4xNjY5NzI1MjgxLjAuMC4w&_ga=2.126733898.696256746.1669612014-766490130.1650530957) event.

```
//Event subscription
this.sfDataGrid1.AutoGeneratingRelations += new Syncfusion.WinForms.DataGrid.Events.AutoGeneratingRelationsEventHandler(SfDataGrid1_AutoGeneratingRelations);
 
//Event customization
private void SfDataGrid1_AutoGeneratingRelations(object sender, Syncfusion.WinForms.DataGrid.Events.AutoGeneratingRelationsEventArgs e)
{
    //To enable AutoGenerateColumns for child grid.
    e.GridViewDefinition.DataGrid.AutoGenerateRelations = true;
}
```