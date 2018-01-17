using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asgmt4_GeriKona.Models;
using Oracle.ManagedDataAccess.Client;

namespace Asgmt4_GeriKona
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }
        // DISPLAY TABLE
        public void Display()
        {
            Vendors vendors = new Vendors();
            List<Vendors> vendorList = vendors.GetAll();

            ClearTable();

            foreach (Vendors v in vendorList)
            {
                TableRow tblRow = new TableRow();

                TableCell idCell = new TableCell();
                idCell.Text = v.VendorID.ToString();

                TableCell nameCell = new TableCell();
                nameCell.Text = v.VendorName;

                TableCell adrs1Cell = new TableCell();
                adrs1Cell.Text = v.VendorAddress1;

                TableCell adrs2Cell = new TableCell();
                if (v.VendorAddress2 == "NULL")
                {
                    adrs2Cell.Text = "";
                }
                else
                {
                    adrs2Cell.Text = v.VendorAddress2;
                }

                TableCell cityCell = new TableCell();
                cityCell.Text = v.VendorCity;

                TableCell stateCell = new TableCell();
                stateCell.Text = v.VendorState;

                TableCell zipCell = new TableCell();
                zipCell.Text = v.VendorZip;

                tblRow.Cells.Add(idCell);
                tblRow.Cells.Add(nameCell);
                tblRow.Cells.Add(adrs1Cell);
                tblRow.Cells.Add(adrs2Cell);
                tblRow.Cells.Add(cityCell);
                tblRow.Cells.Add(stateCell);
                tblRow.Cells.Add(zipCell);

                tbl_vendors.Rows.Add(tblRow);
            }
        }

        public void ClearTable()
        {
            tbl_vendors.Rows.Clear();

            TableHeaderRow tblH = new TableHeaderRow();

            TableHeaderCell idCell = new TableHeaderCell();
            idCell.Text = "ID";

            TableHeaderCell nameCell = new TableHeaderCell();
            nameCell.Text = "Name";

            TableHeaderCell adrs1Cell = new TableHeaderCell();
            adrs1Cell.Text = "Address 1";

            TableHeaderCell adrs2Cell = new TableHeaderCell();
            adrs2Cell.Text = "Address 2";

            TableHeaderCell cityCell = new TableHeaderCell();
            cityCell.Text = "City";

            TableHeaderCell stateCell = new TableHeaderCell();
            stateCell.Text = "State";

            TableHeaderCell zipCell = new TableHeaderCell();
            zipCell.Text = "Zip Code";

            tblH.Cells.Add(idCell);
            tblH.Cells.Add(nameCell);
            tblH.Cells.Add(adrs1Cell);
            tblH.Cells.Add(adrs2Cell);
            tblH.Cells.Add(cityCell);
            tblH.Cells.Add(stateCell);
            tblH.Cells.Add(zipCell);

            tbl_vendors.Rows.Add(tblH);
        }

        // ADD VENDOR BUTTON
        protected void btn_add_vendor_Click(object sender, EventArgs e)
        {
            if (ValidAdd())
            {
                int v_id = Convert.ToInt32(txt_id.Text.Trim());
                string v_name = txt_name.Text.Trim();
                string v_adrs1 = txt_adrs1.Text.Trim();
                string v_adrs2 = txt_adrs2.Text.Trim();
                string v_city = txt_city.Text.Trim();
                string v_state = txt_state.Text.Trim();
                string v_zip = txt_zip.Text.Trim();

                Vendors db = new Vendors();

                if (db.AddV(v_id, v_name, v_adrs1, v_adrs2, v_city, v_state, v_zip))
                {
                    lbl_status.Text = "- Success! -";
                    lbl_details.Text = "<strong>ID: </strong>" + v_id + "<br>" +
                                       "<strong>Name: </strong>" + v_name + "<br>" +
                                       "<strong>Address 1: </strong>" + v_adrs1 + "<br>" +
                                       "<strong>Address 2: </strong>" + v_adrs2 + "<br>" +
                                       "<strong>City: </strong>" + v_city + "<br>" +
                                       "<strong>State: </strong>" + v_state + "<br>" +
                                       "<strong>Zip Code: </strong>" + v_zip;
                    
                    Display();

                }
                else
                {
                    lbl_status.Text = "- Failed! -";
                    lbl_details.Text = db.ErrorMsg;
                }
            }
        }
        // UPDATE VENDORS BUTTON
        protected void btn_update_vendor_Click(object sender, EventArgs e)
        {
            if (ValidUpdate())
            {

                int v_id = Convert.ToInt32(txt_id.Text.Trim());
                string v_name = txt_name.Text.Trim();
                string v_adrs1 = txt_adrs1.Text.Trim();
                string v_adrs2 = txt_adrs2.Text.Trim();
                string v_city = txt_city.Text.Trim();
                string v_state = txt_state.Text.Trim();
                string v_zip = txt_zip.Text.Trim();

                Vendors db = new Vendors();
                if (db.UpdateV(v_id, v_name, v_adrs1, v_adrs2, v_city, v_state, v_zip))
                {

                    lbl_status.Text = "- Success! -";
                    lbl_details.Text = "<strong>ID: </strong>" + v_id + "<br>" +
                                       "<strong>Name: </strong>" + v_name + "<br>" +
                                       "<strong>Address 1: </strong>" + v_adrs1 + "<br>" +
                                       "<strong>Address 2: </strong>" + v_adrs2 + "<br>" +
                                       "<strong>City: </strong>" + v_city + "<br>" +
                                       "<strong>State: </strong>" + v_state + "<br>" +
                                       "<strong>Zip Code: </strong>" + v_zip;
                    Display();
                }
                else
                {
                    lbl_status.Text = "- Failed! -";
                    lbl_details.Text = db.ErrorMsg;
                }
            }
        }
        // DELETE VENDOR BUTTON
        protected void btn_delete_vendor_Click(object sender, EventArgs e)
        {
            if (ValidDelete())
            {
                int v_id = Convert.ToInt32(txt_id.Text.Trim());

                Vendors db = new Vendors();
                if (db.DeleteV(v_id))
                {
                    lbl_status.Text = "- Success! -";
                    lbl_details.Text = "Record was deleted <br>" + "ID: " + v_id;
                    Display();
                }
                else
                {               
                    lbl_status.Text = "- Failed! -";
                    lbl_details.Text = db.ErrorMsg;
                }
            }

        }
        // CLEAR BUTON
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();
            Display();
        }

        // CLEAR
        public void Clear()
        {
            Vendors vendors = new Vendors();
            vendors.ErrorMsg = "";

            statusBlock.Style.Add("background-color", "#4A8CCC");

            lbl_status.Text = "- Status -";
            lbl_details.Text = "";

            txt_id.Text = "";
            txt_name.Text = "";
            txt_adrs1.Text = "";
            txt_adrs2.Text = "";
            txt_city.Text = "";
            txt_state.Text = "";
            txt_zip.Text = "";

        }

        // - - - FORM VALIDATION - - -

        // DELETE VALIDATION !!!
        public bool ValidDelete()
        {
            ClearValid();
            Vendors vendor = new Vendors();

            // Vendor ID
            if (Empty(txt_id.Text.Trim()) || !NotString(txt_id.Text.Trim()))
            {
                txt_id.Style.Add("background-color", "#a4c5fc");
                txt_id.Style.Add("border", "1px solid red");
                txt_id.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_id.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a Vendor ID";
                }
                else
                {
                    lbl_details.Text = "Vendor ID must be a number";

                }

                return false;
            }

            // Vendor ID Duplicate 
            else if (!vendor.DuplicatePK(Convert.ToInt32(txt_id.Text.Trim())))
            {
                txt_id.Style.Add("background-color", "#a4c5fc");
                txt_id.Style.Add("border", "1px solid red");
                txt_id.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Vendor ID doesn't exist";

                return false;
            }
            else
            {
                return true;
            }
        }

        // UPDATE VALIDATION !!!
        public bool ValidUpdate()
        {
            ClearValid();
            Vendors vendor = new Vendors();

            // Vendor ID
            if (Empty(txt_id.Text.Trim()) || !NotString(txt_id.Text.Trim()))
            {
                txt_id.Style.Add("background-color", "#a4c5fc");
                txt_id.Style.Add("border", "1px solid red");
                txt_id.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_id.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a Vendor ID";
                }
                else
                {
                    lbl_details.Text = "Vendor ID must be a number";

                }

                return false;
            }

            // Vendor ID Duplicate 
            else if (!vendor.DuplicatePK(Convert.ToInt32(txt_id.Text.Trim())))
            {
                txt_id.Style.Add("background-color", "#a4c5fc");
                txt_id.Style.Add("border", "1px solid red");
                txt_id.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Vendor ID doesn't exist";

                return false;
            }
            
            // Name 
            else if (Empty(txt_name.Text.Trim()) || NotString(txt_name.Text.Trim()) || TooLong(txt_name.Text.Trim(), 50))
            {
                txt_name.Style.Add("background-color", "#a4c5fc");
                txt_name.Style.Add("border", "1px solid red");
                txt_name.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_name.Text.Trim()))
                {
                    lbl_details.Text = "Please provide your name";
                }
                else if (NotString(txt_name.Text.Trim()))
                {
                    lbl_details.Text = "Beep...  Boop..";
                }
                else
                {
                    lbl_details.Text = "Name can't be longer than 50 characters long";
                }

                return false;
            }
            
            // Name Duplicate
            else if (vendor.DuplicateNameUpdate(Convert.ToInt32(txt_id.Text.Trim()), txt_name.Text.Trim()))
            {
                txt_name.Style.Add("background-color", "#a4c5fc");
                txt_name.Style.Add("border", "1px solid red");
                txt_name.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Name already exists";

                return false;
            }

            // Address 1 
            else if (TooLong(txt_adrs1.Text.Trim(), 50))
            {
                txt_adrs1.Style.Add("background-color", "#a4c5fc");
                txt_adrs1.Style.Add("border", "1px solid red");
                txt_adrs1.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Address can't be longer than 50 characters long";

                return false;
            }
            // Address 2
            else if (TooLong(txt_adrs2.Text.Trim(), 50))
            {
                txt_adrs2.Style.Add("background-color", "#a4c5fc");
                txt_adrs2.Style.Add("border", "1px solid red");
                txt_adrs2.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Address can't be longer than 50 characters long";

                return false;
            }
            // City
            else if (Empty(txt_city.Text.Trim()) || NotString(txt_city.Text.Trim()) || TooLong(txt_city.Text.Trim(), 50))
            {
                txt_city.Style.Add("background-color", "#a4c5fc");
                txt_city.Style.Add("border", "1px solid red");
                txt_city.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_city.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a city";
                }
                else if (NotString(txt_city.Text.Trim()))
                {
                    lbl_details.Text = "Beep...  Boop..";
                }
                else
                {
                    lbl_details.Text = "City can't be longer than 50 characters long";
                }

                return false;
            }
            // State
            else if (Empty(txt_state.Text.Trim()) || NotString(txt_city.Text.Trim()) || !(txt_state.Text.Trim().Length == 2))
            {
                txt_state.Style.Add("background-color", "#a4c5fc");
                txt_state.Style.Add("border", "1px solid red");
                txt_state.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_state.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a state";
                }
                else if (NotString(txt_state.Text.Trim()))
                {
                    lbl_details.Text = "Beep...  Boop..";
                }
                else
                {
                    lbl_details.Text = "State must be 2 chracters long";
                }

                return false;
            }
            // Zip Code
            else if (Empty(txt_zip.Text.Trim()) || TooLong(txt_zip.Text.Trim(), 20))
            {
                txt_zip.Style.Add("background-color", "#a4c5fc");
                txt_zip.Style.Add("border", "1px solid red");
                txt_zip.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_zip.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a Zip Code";
                }
                else
                {
                    lbl_details.Text = "Zip Code can't be longer than 20 characters long";
                }

                return false;
            }
            else
            {
                return true;
            }

        }

        // ADD VALIDATION !!!
        public bool ValidAdd()
        {
            ClearValid();
            Vendors vendor = new Vendors();

            // Vendor ID
            if (Empty(txt_id.Text.Trim()) || !NotString(txt_id.Text.Trim()))
            {
                txt_id.Style.Add("background-color", "#a4c5fc");
                txt_id.Style.Add("border", "1px solid red");
                txt_id.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_id.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a Vendor ID";
                }
                else
                {
                    lbl_details.Text = "Vendor ID must be a number";

                }
                
                return false;
            }
            // Vendor ID Duplicate 
            else if (vendor.DuplicatePK(Convert.ToInt32(txt_id.Text.Trim())))
            {
                txt_id.Style.Add("background-color", "#a4c5fc");
                txt_id.Style.Add("border", "1px solid red");
                txt_id.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Vendor ID already exists";

                return false;
            }
            // Name 
            else if (Empty(txt_name.Text.Trim()) || NotString(txt_name.Text.Trim()) || TooLong(txt_name.Text.Trim(), 50))
            {
                txt_name.Style.Add("background-color", "#a4c5fc");
                txt_name.Style.Add("border", "1px solid red");
                txt_name.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_name.Text.Trim()))
                {
                    lbl_details.Text = "Please provide your name";
                }
                else if (NotString(txt_name.Text.Trim()))
                {
                    lbl_details.Text = "Beep...  Boop..";
                }
                else
                {
                    lbl_details.Text = "Name can't be longer than 50 characters long";
                }

                return false;
            }

            // Name Duplicate
            else if (vendor.DuplicateName(txt_name.Text.Trim()))
            {
                txt_name.Style.Add("background-color", "#a4c5fc");
                txt_name.Style.Add("border", "1px solid red");
                txt_name.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Name already exists";

                return false;
            }

            // Address 1 
            else if (TooLong(txt_adrs1.Text.Trim(), 50))
            {
                txt_adrs1.Style.Add("background-color", "#a4c5fc");
                txt_adrs1.Style.Add("border", "1px solid red");
                txt_adrs1.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Address can't be longer than 50 characters long";

                return false;
            }
            // Address 2
            else if (TooLong(txt_adrs2.Text.Trim(), 50))
            {
                txt_adrs2.Style.Add("background-color", "#a4c5fc");
                txt_adrs2.Style.Add("border", "1px solid red");
                txt_adrs2.Focus();
                lbl_status.Text = "- ERROR! -";
                lbl_details.Text = "Address can't be longer than 50 characters long";

                return false;
            }
            // City
            else if (Empty(txt_city.Text.Trim()) || NotString(txt_city.Text.Trim()) || TooLong(txt_city.Text.Trim(), 50))
            {
                txt_city.Style.Add("background-color", "#a4c5fc");
                txt_city.Style.Add("border", "1px solid red");
                txt_city.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_city.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a city";
                }
                else if (NotString(txt_city.Text.Trim()))
                {
                    lbl_details.Text = "Beep...  Boop..";
                }
                else
                {
                    lbl_details.Text = "City can't be longer than 50 characters long";
                }

                return false;
            }
            // State
            else if (Empty(txt_state.Text.Trim()) || NotString(txt_city.Text.Trim()) || !(txt_state.Text.Trim().Length == 2))
            {
                txt_state.Style.Add("background-color", "#a4c5fc");
                txt_state.Style.Add("border", "1px solid red");
                txt_state.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_state.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a state";
                }
                else if (NotString(txt_state.Text.Trim()))
                {
                    lbl_details.Text = "Beep...  Boop..";
                }
                else
                {
                    lbl_details.Text = "State must be 2 chracters long";
                }

                return false;
            }
            // Zip Code
            else if (Empty(txt_zip.Text.Trim()) || TooLong(txt_zip.Text.Trim(), 20))
            {
                txt_zip.Style.Add("background-color", "#a4c5fc");
                txt_zip.Style.Add("border", "1px solid red");
                txt_zip.Focus();
                lbl_status.Text = "- ERROR! -";
                if (Empty(txt_zip.Text.Trim()))
                {
                    lbl_details.Text = "Please provide a Zip Code";
                }
                else
                {
                    lbl_details.Text = "Zip Code can't be longer than 20 characters long";
                }

                return false;
            }
            else
            {
                return true;
            }
        }
        // CLEAR VALIDATION STYLING
        public void ClearValid()
        {
            txt_id.Style.Clear();
            txt_name.Style.Clear();
            txt_adrs1.Style.Clear();
            txt_adrs2.Style.Clear();
            txt_city.Style.Clear();
            txt_state.Style.Clear();
            txt_zip.Style.Clear();
        }
        // VALIDATION - CHECK EMPTY FIELD
        public bool Empty(string input)
        {
            if (input == "" || input == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // VALIDATION - CHECK NO STRING IN FIELD
        public bool NotString(string input)
        {
            if (input.Any(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // VALIDATION - CHECK MAX FIELD LENGTH
        public bool TooLong(string input, int length)
        {
            if (input.Length > length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}