using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Stock_System.Class;
using System.Data.SqlClient;
namespace Stock_System.Forms
{
    public partial class frmLookups : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        public frmLookups()
        {
            InitializeComponent();
        }
        #region ListView
        private void fillProductGroup()
        {
            lstProductGroup.Items.Clear();
            DataTable dt = obj.GetData("SELECT   GroupID, GroupName, Convert(varchar(12),SystemDate,107) as SystemDate FROM  IMIS_tblProductGroup");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["GroupID"].ToString());
                item.SubItems.Add(dr["GroupName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductGroup.Items.Add(item);
            }
        }
        private void fillProductCategory()
        {
            lstProductCategory.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        IMIS_tblProductCategory.CategoryCode, IMIS_tblProductCategory.CategoryName, IMIS_tblProductCategory.GroupID, Convert(varchar(12),IMIS_tblProductCategory.SystemDate,107) as SystemDate, 
                         IMIS_tblProductGroup.GroupName
FROM            IMIS_tblProductCategory INNER JOIN
                         IMIS_tblProductGroup ON IMIS_tblProductCategory.GroupID = IMIS_tblProductGroup.GroupID");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CategoryCode"].ToString());
                item.SubItems.Add(dr["CategoryName"].ToString());
                item.SubItems.Add(dr["GroupName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                item.SubItems.Add(dr["GroupID"].ToString());
                lstProductCategory.Items.Add(item);
            }
        }
        private void fillProductBrand()
        {
            lstProductGenericName.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT  BrandID, BrandName,Convert(varchar(12),SystemDate,107) as SystemDate FROM  IMIS_tblBrand");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["BrandID"].ToString());
                item.SubItems.Add(dr["BrandName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductGenericName.Items.Add(item);
            }
        }
        private void fillProductOrigin()
        {
            lstProductOrigin.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT ProductOriginID, ProductOriginName,Convert(varchar(12),SystemDate,107) as SystemDate FROM  IMIS_tblProductOrigin");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ProductOriginID"].ToString());
                item.SubItems.Add(dr["ProductOriginName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductOrigin.Items.Add(item);
            }
        }
        private void fillProductUnit()
        {
            lstProductUnit.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        UnitID, UnitName,Convert(varchar(12), SystemDate,107) as SystemDate
FROM            IMIS_tblUnitOfMeasurement");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["UnitID"].ToString());
                item.SubItems.Add(dr["UnitName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductUnit.Items.Add(item);
            }
        }
        private void fillProductPaking()
        {
            lstProductPacking.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        PackingID, PackingName,Convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblProductPaking");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["PackingID"].ToString());
                item.SubItems.Add(dr["PackingName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductPacking.Items.Add(item);
            }
        }
        private void fillProductColor()
        {
            lstProductColor.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        ColorID, ColorName, ColorShortName,convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblColor");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ColorID"].ToString());
                item.SubItems.Add(dr["ColorName"].ToString());
                item.SubItems.Add(dr["ColorShortName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductColor.Items.Add(item);
            }
        }
        private void fillProductSiz()
        {
            lstProductSize.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        SizeID, SizeName, SizeShortName, StoreID, UserID,convert(varchar(12),SystemDate,107) as SystemDate, LastUpdatedBy, LastUpdateDate
FROM            IMIS_tblSize");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["SizeID"].ToString());
                item.SubItems.Add(dr["SizeName"].ToString());
                item.SubItems.Add(dr["SizeShortName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductSize.Items.Add(item);
            }
        }
        private void fillProductlstManufacturer()
        {
            lstManufacturer.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT  ManufacturerID, ManufacturerName, UserID, convert(varchar(12),SystemDate,107) as SystemDate FROM IMIS_tblManufacturer");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ManufacturerID"].ToString());
                item.SubItems.Add(dr["ManufacturerName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstManufacturer.Items.Add(item);
            }
        }
        private void fillProductlstClassification()
        {
            lstClassification.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT ClassificationID, ClassificationName,convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblDrugClassification");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ClassificationID"].ToString());
                item.SubItems.Add(dr["ClassificationName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstClassification.Items.Add(item);
            }
        }
        private void fillProductGenericName()
        {
            lstProductGenericName.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        GenericID, GenericName,Convert(varchar(12), SystemDate,107) as SystemDate
FROM            IMIS_tblProductGenericName");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["GenericID"].ToString());
                item.SubItems.Add(dr["GenericName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductGenericName.Items.Add(item);
            }
        }
        private void fillLocation()
        {
            lstLocation.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        LocationID, LocationName, Convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblProductLocation");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["LocationID"].ToString());
                item.SubItems.Add(dr["LocationName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstLocation.Items.Add(item);
            }
        }
        #endregion
        private void frmLookups_Load(object sender, EventArgs e)
        {
            fillProductGroup();
            fillProductCategory();
            fillProductBrand();
            fillProductOrigin();
            fillProductUnit();
            fillProductPaking();
            fillProductColor();
            fillProductSiz();
            fillProductlstManufacturer();
            fillProductlstClassification();
            fillProductGenericName();
            fillLocation();
            fillAreas();
            FillMonths();
            obj.fillcmb(cmbCalendarType, "CalendarTypeName", "CalendarTypeID", "SELECT        CalendarTypeID, CalendarTypeName FROM  Lookup_tblCalendarType");
            obj.fillcmb(cmbProductGroup, "GroupName", "GroupID", "SELECT    GroupID, GroupName FROM  IMIS_tblProductGroup ");
        }
        private void btnSaveProductGroup_Click(object sender, EventArgs e)
        {
            if (btnSaveProductGroup.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblProductGroup(GroupName, UserID) values(N'"+txtProductGroupName.Text+"',N'"+conclass.User_ID+"')");
            }
            else
            {
                obj.ExecuteQuery("update IMIS_tblProductGroup set GroupName=N'" + txtProductGroupName.Text + "',LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdatedDate=getdate() where GroupID=" + txtProductGroupName.Tag.ToString() + "");
            
            }
            obj.fillcmb(cmbProductGroup, "GroupName", "GroupID", "SELECT    GroupID, GroupName FROM  IMIS_tblProductGroup ");
            MessageBox.Show("Record Saved Successfully..");
            fillProductGroup();
            txtProductGroupName.Text = "";
            btnSaveProductGroup.Text = "Save";
            txtProductGroupName.Focus();
        }
        private void lstProductGroup_DoubleClick(object sender, EventArgs e)
        {
            txtProductGroupName.Tag = lstProductGroup.SelectedItems[0].SubItems[0].Text;
            txtProductGroupName.Text = lstProductGroup.SelectedItems[0].SubItems[1].Text;
            btnSaveProductGroup.Text = "Update";
        }
        private void btnSaveProductCategory_Click(object sender, EventArgs e)
        {
            if (btnSaveProductCategory.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblProductCategory(CategoryName, GroupID, UserID) values(N'"+txtProductCategoryName.Text+"', "+cmbProductGroup.SelectedValue+", N'"+conclass.User_ID+"')");
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblProductCategory set CategoryName=N'"+txtProductCategoryName.Text+"',GroupID="+cmbProductGroup.SelectedValue+",LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdatedDate=getdate() where CategoryCode="+txtProductCategoryName.Tag.ToString()+"");
            }
            MessageBox.Show("Record Saved Successfully..");
            txtProductCategoryName.Text = "";
            btnSaveProductCategory.Text = "Save";
            fillProductCategory();
            txtProductCategoryName.Focus();

        }
        private void lstProductCategory_DoubleClick(object sender, EventArgs e)
        {
            txtProductCategoryName.Tag = lstProductCategory.SelectedItems[0].SubItems[0].Text;
            txtProductCategoryName.Text = lstProductCategory.SelectedItems[0].SubItems[1].Text;
            cmbProductGroup.SelectedValue = lstProductCategory.SelectedItems[0].SubItems[4].Text;
            btnSaveProductCategory.Text = "Update";
        }
        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            lstProductCategory.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        IMIS_tblProductCategory.CategoryCode, IMIS_tblProductCategory.CategoryName, IMIS_tblProductCategory.GroupID, Convert(varchar(12),IMIS_tblProductCategory.SystemDate,107) as SystemDate, 
                         IMIS_tblProductGroup.GroupName
FROM            IMIS_tblProductCategory INNER JOIN
                         IMIS_tblProductGroup ON IMIS_tblProductCategory.GroupID = IMIS_tblProductGroup.GroupID where CategoryName like N'%" + txtProductCategoryName.Text + "%'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CategoryCode"].ToString());
                item.SubItems.Add(dr["CategoryName"].ToString());
                item.SubItems.Add(dr["GroupName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                item.SubItems.Add(dr["GroupID"].ToString());
                lstProductCategory.Items.Add(item);
            }
        }
        private void btnSearchProductBrand_Click(object sender, EventArgs e)
        {
            lstProductGenericName.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        GenericID, GenericName,Convert(varchar(12), SystemDate,107) as SystemDate
FROM            IMIS_tblProductGenericName where GenericName like N'%"+txtGenericName.Text+"%'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["GenericID"].ToString());
                item.SubItems.Add(dr["GenericName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductGenericName.Items.Add(item);
            }
        }
        private void btnSaveProductOrigin_Click(object sender, EventArgs e)
        {
            if (btnSaveProductOrigin.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblProductOrigin(ProductOriginName, UserID) values(N'" + txtProductOriginName.Text + "', N'" + conclass.User_ID + "')");
            }
            else
            {
                obj.ExecuteQuery("update IMIS_tblProductOrigin set ProductOriginName=N'" + txtProductOriginName.Text + "',LastUpdatedBy=N'" + conclass.User_ID + "',LastUpdatedDate=getdate() where ProductOriginID=" + txtProductOriginName.Tag.ToString() + "");
            }
            fillProductOrigin();
            txtProductOriginName.Text = "";
            btnSaveProductOrigin.Text = "Save";
            MessageBox.Show("Record Saved Successfully..");
            txtProductOriginName.Focus();
        }
        private void btnSearchProductOrigin_Click(object sender, EventArgs e)
        {
            lstProductOrigin.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT ProductOriginID, ProductOriginName,Convert(varchar(12),SystemDate,107) as SystemDate FROM  IMIS_tblProductOrigin where ProductOriginName=N'"+txtProductOriginName.Text+"'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ProductOriginID"].ToString());
                item.SubItems.Add(dr["ProductOriginName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductOrigin.Items.Add(item);
            }
        }
        private void lstProductOrigin_DoubleClick(object sender, EventArgs e)
        {
            txtProductOriginName.Tag = lstProductOrigin.SelectedItems[0].SubItems[0].Text;
            txtProductOriginName.Text = lstProductOrigin.SelectedItems[0].SubItems[1].Text;
            btnSaveProductOrigin.Text = "Update";
        }
        private void btnSearchProductUnit_Click(object sender, EventArgs e)
        {
            lstProductUnit.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        UnitID, UnitName,Convert(varchar(12), SystemDate,107) as SystemDate
FROM            IMIS_tblUnitOfMeasurement where UnitName like '%"+txtProductUnitName.Text+"%'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["UnitID"].ToString());
                item.SubItems.Add(dr["UnitName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductUnit.Items.Add(item);
            }
        }
        private void lstProductUnit_DoubleClick(object sender, EventArgs e)
        {
            txtProductUnitName.Tag = lstProductUnit.SelectedItems[0].SubItems[0].Text;
            txtProductUnitName.Text = lstProductUnit.SelectedItems[0].SubItems[1].Text;
            btnSaveProductUnit.Text = "Update";
        }
        private void btnSaveProductUnit_Click(object sender, EventArgs e)
        {
            if (btnSaveProductUnit.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblUnitOfMeasurement(UnitName, UserID) values(N'"+txtProductUnitName.Text+"', N'"+conclass.User_ID+"')");
            }
            else
            {
                obj.ExecuteQuery("update IMIS_tblUnitOfMeasurement set UnitName=N'"+txtProductUnitName.Text+"',LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdatedDate=getdate() where UnitID="+txtProductUnitName.Tag.ToString()+"");
            
            }
            MessageBox.Show("Record Saved Successfully..");
            txtProductUnitName.Text = "";
            btnSaveProductUnit.Text = "Save";
            fillProductUnit();
            txtProductUnitName.Focus();

        }
        private void btnSearchProductPacking_Click(object sender, EventArgs e)
        {
            lstProductPacking.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        PackingID, PackingName,Convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblProductPaking where PackingName like '%"+txtProductPackingName.Text.Trim()+"%'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["PackingID"].ToString());
                item.SubItems.Add(dr["PackingName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductPacking.Items.Add(item);
            }
        }
        private void lstProductPacking_DoubleClick(object sender, EventArgs e)
        {
            txtProductPackingName.Tag = lstProductPacking.SelectedItems[0].SubItems[0].Text;
            txtProductPackingName.Text = lstProductPacking.SelectedItems[0].SubItems[1].Text;
            btnSaveProductPacking.Text = "Update";
        }
        private void btnSaveProductPacking_Click(object sender, EventArgs e)
        {
            if (btnSaveProductPacking.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblProductPaking( PackingName, UserID) values(N'"+txtProductPackingName.Text+"', N'"+conclass.User_ID+"')");
            }
            else
            {
                obj.ExecuteQuery("update IMIS_tblProductPaking set PackingName=N'"+txtProductPackingName.Text+"',LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdateDate=getdate() where PackingID="+txtProductPackingName.Tag.ToString()+"");
            
            }
            txtProductPackingName.Text = "";
            fillProductPaking();
            btnSaveProductPacking.Text = "Save";
            MessageBox.Show("Record Saved Successfully..");
            txtProductPackingName.Focus();
        }
        private void btnSaveProductColor_Click(object sender, EventArgs e)
        {
            if (btnSaveProductColor.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblColor(ColorName, ColorShortName,UserID) values(N'"+txtProductColorName.Text+"', N'"+txtColorShortName.Text+"',N'"+conclass.User_ID+"')");
            }
            else
            {
                obj.ExecuteQuery("update IMIS_tblColor set ColorName=N'"+txtProductColorName.Text+"',ColorShortName=N'"+txtColorShortName.Text+"',LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdatedDate=getdate() where ColorID="+txtProductColorName.Tag.ToString()+"");
            }
            txtProductColorName.Text = "";
            txtColorShortName.Text = "";
            btnSaveProductColor.Text = "Save";
            fillProductColor();
            MessageBox.Show("Record Saved Successfully..");
            txtProductColorName.Focus();
        }
        private void btnSearchProductColor_Click(object sender, EventArgs e)
        {
            lstProductColor.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        ColorID, ColorName, ColorShortName,convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblColor where ColorName like '%"+txtProductColorName.Text+"%'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ColorID"].ToString());
                item.SubItems.Add(dr["ColorName"].ToString());
                item.SubItems.Add(dr["ColorShortName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductColor.Items.Add(item);
            }
        }
        private void lstProductColor_DoubleClick(object sender, EventArgs e)
        {
            txtProductColorName.Tag = lstProductColor.SelectedItems[0].SubItems[0].Text;
            txtProductColorName.Text = lstProductColor.SelectedItems[0].SubItems[1].Text;
            txtColorShortName.Text = lstProductColor.SelectedItems[0].SubItems[2].Text;
            btnSaveProductColor.Text = "Update";
        }
        private void lstProductSize_DoubleClick(object sender, EventArgs e)
        {
            txtSizeName.Tag = lstProductSize.SelectedItems[0].SubItems[0].Text;
            txtSizeName.Text = lstProductSize.SelectedItems[0].SubItems[1].Text;
            txtSizeShortName.Text = lstProductSize.SelectedItems[0].SubItems[2].Text;
            btnSaveProductSize.Text = "Update";
        }
        private void btnSaveProductSize_Click(object sender, EventArgs e)
        {
            if (btnSaveProductSize.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblSize(SizeName, SizeShortName, StoreID, UserID) values(N'" + txtSizeName.Text + "', N'" + txtSizeShortName.Text + "', " + conclass.StoreID + ", N'" + conclass.User_ID + "')");
            }
            else
            {
                obj.ExecuteQuery("update IMIS_tblSize set SizeName=N'" + txtSizeName.Text + "',SizeShortName=N'" + txtSizeShortName.Text + "',LastUpdatedBy=N'" + conclass.User_ID + "', LastUpdateDate=getdate() where SizeID=" + txtSizeName.Tag.ToString() + " ");
            }
            fillProductSiz();
            txtSizeName.Text = "";
            txtSizeShortName.Text = "";
            btnSaveProductSize.Text = "Save";
            MessageBox.Show("Record Saved Successfully..");
            txtSizeName.Focus();
        }
        private void btnSaveManufacturer_Click(object sender, EventArgs e)
        {
            if (btnSaveManufacturer.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblManufacturer(ManufacturerName, UserID) values(N'"+txtManufacturerName.Text+"', N'"+conclass.User_ID+"')");
            }
            else
            {
                obj.ExecuteQuery(@"Update IMIS_tblManufacturer set ManufacturerName=N'" + txtManufacturerName.Text + "',LastUpdatedBy=N'" + conclass.User_ID + "',LastUpdatedDate=getdate() where ManufacturerID="+txtManufacturerName.Tag.ToString()+" ");
            }
            MessageBox.Show("Record Saved Successfully..");
            fillProductlstManufacturer();
            txtManufacturerName.Text = "";
            btnSaveManufacturer.Text = "Save";
            txtManufacturerName.Focus();
        }
        private void lstManufacturer_DoubleClick(object sender, EventArgs e)
        {
            txtManufacturerName.Tag = lstManufacturer.SelectedItems[0].SubItems[0].Text;
            txtManufacturerName.Text = lstManufacturer.SelectedItems[0].SubItems[1].Text;
            btnSaveManufacturer.Text = "Update";
            txtManufacturerName.Focus();
        }
        private void btnSearchManufacturer_Click(object sender, EventArgs e)
        {
            lstManufacturer.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT  ManufacturerID, ManufacturerName, UserID, convert(varchar(12),SystemDate,107) as SystemDate FROM IMIS_tblManufacturer where ManufacturerName like '%"+txtManufacturerName.Text+"%' ");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ManufacturerID"].ToString());
                item.SubItems.Add(dr["ManufacturerName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstManufacturer.Items.Add(item);
            }
        }
        private void btnSaveClassification_Click(object sender, EventArgs e)
        {
            if (btnSaveClassification.Text == "Save")
            {
                obj.ExecuteQuery("insert into IMIS_tblDrugClassification( ClassificationName, UserID, SystemDate) values(N'"+txtClassificationName.Text+"', N'"+conclass.User_ID+"', getdate())");
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblDrugClassification set ClassificationName=N'" + txtClassificationName.Text + "',LastUpdatedBy='" + conclass.User_ID + "',LastUpdatedDate=getdate() where ClassificationID=" + txtClassificationName.Tag + "");
            }
            btnSaveClassification.Text = "Save";
            txtClassificationName.Text = "";
            fillProductlstClassification();

            MessageBox.Show("Record Saved Successfully..");
            txtClassificationName.Focus();
        }
        private void btnSearchClassification_Click(object sender, EventArgs e)
        {
            lstClassification.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT ClassificationID, ClassificationName,convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblDrugClassification where ClassificationName like N'%" + txtClassificationName.Text + "%'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ClassificationID"].ToString());
                item.SubItems.Add(dr["ClassificationName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstClassification.Items.Add(item);
            }
        }
        private void lstClassification_DoubleClick(object sender, EventArgs e)
        {
            txtClassificationName.Tag = lstClassification.SelectedItems[0].SubItems[0].Text;
            txtClassificationName.Text = lstClassification.SelectedItems[0].SubItems[1].Text;
            btnSaveClassification.Text = "Update";
            txtClassificationName.Focus();
        }
        private void btnSaveGenericName_Click(object sender, EventArgs e)
        {
            if (btnSaveGenericName.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblProductGenericName(GenericName, UserID,SystemDate) values(N'"+txtGenericName.Text+"', N'"+conclass.User_ID+"',getdate())");
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblProductGenericName set GenericName=N'"+txtGenericName.Text+"',LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdatedDate=getdate() where GenericID="+txtGenericName.Tag+"");
            }
            txtGenericName.Text = "";
            btnSaveGenericName.Text = "Save";
            fillProductGenericName();
            MessageBox.Show("Record Saved Successfully..");
          
            txtGenericName.Focus();
        }
        private void lstProductGenericName_DoubleClick(object sender, EventArgs e)
        {
            txtGenericName.Tag = lstProductGenericName.SelectedItems[0].SubItems[0].Text;
            txtGenericName.Text = lstProductGenericName.SelectedItems[0].SubItems[1].Text;
            btnSaveGenericName.Text = "Update";
            txtGenericName.Focus();
        }
        private void btnSearchProductGroup_Click(object sender, EventArgs e)
        {
            lstProductGroup.Items.Clear();
            DataTable dt = obj.GetData("SELECT   GroupID, GroupName, Convert(varchar(12),SystemDate,107) as SystemDate FROM  IMIS_tblProductGroup where GroupName like N'%"+txtProductGroupName.Text+"%'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["GroupID"].ToString());
                item.SubItems.Add(dr["GroupName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstProductGroup.Items.Add(item);
            }
        }
        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            if (btnSaveLocation.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblProductLocation(LocationName, UserID, SystemDate) values(N'" + txtProductLocationName.Text + "', N'"+conclass.User_ID+"', getdate())");
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblProductLocation set LocationName=N'" + txtProductLocationName.Text + "',LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdatedDate=getdate() where LocationID=" + txtProductLocationName.Tag + "");
            }
            txtProductLocationName.Text = "";
            btnSaveLocation.Text = "Save";
            fillLocation();
            MessageBox.Show("Record Saved Successfully..");
            txtProductLocationName.Focus();
        }
        private void btnSearchLocation_Click(object sender, EventArgs e)
        {
            lstLocation.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        LocationID, LocationName, Convert(varchar(12),SystemDate,107) as SystemDate
FROM            IMIS_tblProductLocation where LocationName like N'%"+txtProductLocationName.Text+"%'  ");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["LocationID"].ToString());
                item.SubItems.Add(dr["LocationName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstLocation.Items.Add(item);
            }
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            txtProductLocationName.Tag = lstLocation.SelectedItems[0].SubItems[0].Text;
            txtProductLocationName.Text = lstLocation.SelectedItems[0].SubItems[1].Text;
            btnSaveLocation.Text = "Update";
            txtProductLocationName.Focus();
        }

        private void btnSaveArea_Click(object sender, EventArgs e)
        {
            if (btnSaveLocation.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into lookup_tblAreas(AreaName,UserID) values(N'"+txtAreaName.Text+"',N'"+conclass.User_ID+"')");
            }
            else
            {
                obj.ExecuteQuery(@"update lookup_tblAreas set AreaName=N'" + txtAreaName.Text + "' where AreaCode=" + txtAreaName.Tag + "");
            }
            txtAreaName.Text = "";
            btnSaveArea.Text = "Save";
            fillAreas();
            MessageBox.Show("Record Saved Successfully..");
            txtAreaName.Focus();
        }

        private void fillAreas()
        {
            lstArea.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT   AreaCode, AreaName,convert(varchar(12), SystemDate,107) as SystemDate, UserID FROM  lookup_tblAreas order by AreaCode");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["AreaCode"].ToString());
                item.SubItems.Add(dr["AreaName"].ToString());
                item.SubItems.Add(dr["SystemDate"].ToString());
                lstArea.Items.Add(item);
            }
        }

        private void btnSaveMonths_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = obj.GetData("select * from HRMIS_tblPayrollMonths where year=" + txtYear.Text + "");
            if (dtCheck.Rows.Count > 0)
            {
                MessageBox.Show("This year record is exist");
                return;
            }
            DataTable dtMonths = obj.GetData("SELECT  MonthID, MonthName, CalendarTypeID FROM Lookup_tblMonths where CalendarTypeID=" + cmbCalendarType.SelectedValue + "");
            if (obj.con.State == ConnectionState.Closed)
                obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Transaction = tran;
                cmd.Connection = obj.con;
                foreach (DataRow dr in dtMonths.Rows)
                {
                    string Query1 = @"insert into HRMIS_tblPayrollMonths(MonthName, Year) values(N'" + dr["MonthName"].ToString() + "', " + txtYear.Text + ")";
                    cmd.CommandText = Query1;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                FillMonths();
            }
            catch (SqlException Sexp)
            {
                tran.Rollback();
                obj.con.Close();
            }
            catch (Exception ex)
            {
                obj.con.Close();
            }
            finally
            {
                obj.con.Close();
            }
        }
        private void FillMonths()
        {
            lstMonths.Items.Clear();
            DataTable dt = obj.GetData(@"SELECT        MonthID, MonthName, Year FROM HRMIS_tblPayrollMonths where Year=(select max(Year) from HRMIS_tblPayrollMonths)");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["MonthID"].ToString());
                item.SubItems.Add(dr["MonthName"].ToString());
                item.SubItems.Add(dr["Year"].ToString());
                lstMonths.Items.Add(item);
            }
        }
    }
}
