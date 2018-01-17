using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Asgmt4_GeriKona.Models
{
    public class Vendors : DBVendors
    {
        //Fields
        private int _vendor_id;
        private string _vendor_name;
        private string _vendor_address1;
        private string _vendor_address2;
        private string _vendor_city;
        private string _vendor_state;
        private string _vendor_zip;
        protected List<Vendors> vendorsList = new List<Vendors>();
        public string _errorMsg;

        //Properties
        public int VendorID
        {
            get { return this._vendor_id; }
            set { this._vendor_id = value; }
        }
        public string VendorName
        {
            get { return this._vendor_name; }
            set { this._vendor_name = value; }
        }
        public string VendorAddress1
        {
            get { return this._vendor_address1; }
            set { this._vendor_address1 = value; }
        }
        public string VendorAddress2
        {
            get { return this._vendor_address2; }
            set { this._vendor_address2 = value; }
        }
        public string VendorCity
        {
            get { return this._vendor_city; }
            set { this._vendor_city = value; }
        }
        public string VendorState
        {
            get { return this._vendor_state; }
            set { this._vendor_state = value; }
        }
        public string VendorZip
        {
            get { return this._vendor_zip; }
            set { this._vendor_zip = value; }
        }
        public string ErrorMsg
        {
            get { return this._errorMsg; }
            set { this._errorMsg = value; }
        }

        //Methods
        public List<Vendors> GetAll()
        {
            string command = "SELECT vendor_id, initcap(vendor_name), initcap(vendor_address1), initcap(vendor_address2), initcap(vendor_city), vendor_state, vendor_zip_code FROM vendors ORDER BY vendor_id DESC";
            vendorsList.Clear();

            try
            {
                conn.Open();
                cmd = new OracleCommand(command, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Vendors vendors = new Vendors();
                    vendors._vendor_id = Convert.ToInt32(rdr["vendor_id"]);
                    vendors._vendor_name = rdr["initcap(vendor_name)"].ToString();
                    vendors._vendor_address1 = rdr["initcap(vendor_address1)"].ToString();
                    vendors._vendor_address2 = rdr["initcap(vendor_address2)"].ToString();
                    vendors._vendor_city = rdr["initcap(vendor_city)"].ToString();
                    vendors._vendor_state = rdr["vendor_state"].ToString().ToUpper();
                    vendors._vendor_zip = rdr["vendor_zip_code"].ToString().ToUpper();

                    vendorsList.Add(vendors);
                }

                rdr.Close();
                cmd.Dispose();
                conn.Close();

            }
            catch (OracleException ex)
            {
                _errorMsg = ex.Message;
            }
            return vendorsList;
        }

        public bool DuplicatePK(int v_id)
        {
            string command = "SELECT vendor_id FROM vendors WHERE vendor_id = :v_id";

            try
            {
                conn.Open();

                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("v_id", v_id));
                rdr = cmd.ExecuteReader();

                int check = 0;

                while (rdr.Read())
                {
                    check++;
                }

                rdr.Close();
                cmd.Dispose();
                conn.Close();

                if (check == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (OracleException ex)
            {
                _errorMsg = ex.Message;
                return false;
            }
        }

        public bool DuplicateName(string v_name)
        {
            string command = "SELECT count(vendor_name) FROM vendors WHERE upper(vendor_name) = upper(:v_name)";

            try
            {
                conn.Open();

                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("v_name", v_name));
                rdr = cmd.ExecuteReader();
                rdr.Read();

                int check = Convert.ToInt32(rdr["count(vendor_name)"]);

                rdr.Close();
                cmd.Dispose();
                conn.Close();

                if (check == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (OracleException ex)
            {
                _errorMsg = ex.Message;
                return false;
            }
        }

        public bool DuplicateNameUpdate(int v_id, string v_name)
        {
            string command = "SELECT count(vendor_name) FROM vendors WHERE vendor_id != :v_id AND upper(vendor_name) = upper(:v_name)";

            try
            {
                conn.Open();

                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("v_id", v_id));
                cmd.Parameters.Add(new OracleParameter("v_name", v_name));
                rdr = cmd.ExecuteReader();
                rdr.Read();

                int check = Convert.ToInt32(rdr["count(vendor_name)"]);

                rdr.Close();
                cmd.Dispose();
                conn.Close();

                if (check == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (OracleException ex)
            {
                _errorMsg = ex.Message;
                return false;
            }
        }

        public bool AddV(int v_id, string v_name, string v_adrs1, string v_adrs2, string v_city, string v_state, string v_zip)
        {
            string command = "INSERT INTO vendors (vendor_id, vendor_name, vendor_address1, vendor_address2, vendor_city, vendor_state, vendor_zip_code, default_terms_id, default_account_number) VALUES(:v_id, :v_name, :v_adrs1, :v_adrs2, :v_city, :v_state, :v_zip, :def_terms, :def_acnt)";

            try
            {
                conn.Open();

                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("v_id", v_id));
                cmd.Parameters.Add(new OracleParameter("v_name", v_name));
                cmd.Parameters.Add(new OracleParameter("v_adrs1", v_adrs1));
                cmd.Parameters.Add(new OracleParameter("v_adrs2", v_adrs2));
                cmd.Parameters.Add(new OracleParameter("v_city", v_city));
                cmd.Parameters.Add(new OracleParameter("v_state", v_state));
                cmd.Parameters.Add(new OracleParameter("v_zip", v_zip));
                //cmd.Parameters.Add(new OracleParameter("v_phone", v_zip));
                //cmd.Parameters.Add(new OracleParameter("v_last_name", v_zip));
                //cmd.Parameters.Add(new OracleParameter("v_first_name", v_zip));
                cmd.Parameters.Add(new OracleParameter("def_terms", 1));
                cmd.Parameters.Add(new OracleParameter("def_acnt", 552));
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                conn.Close();

                return true;
            }
            catch (OracleException ex)
            {
                _errorMsg = ex.Message;
                return false;
            }
        }

        public bool UpdateV(int v_id, string v_name, string v_adrs1, string v_adrs2, string v_city, string v_state, string v_zip)
        {
            string command = "UPDATE vendors SET vendor_name = :v_name, vendor_address1 = :v_adrs1, vendor_address2 = :v_adrs2, vendor_city = :v_city, vendor_state = :v_state, vendor_zip_code = :v_zip WHERE vendor_id = :v_id";

            try
            {
                conn.Open();

                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("v_name", v_name));
                cmd.Parameters.Add(new OracleParameter("v_adrs1", v_adrs1));
                cmd.Parameters.Add(new OracleParameter("v_adrs2", v_adrs2));
                cmd.Parameters.Add(new OracleParameter("v_city", v_city));
                cmd.Parameters.Add(new OracleParameter("v_state", v_state));
                cmd.Parameters.Add(new OracleParameter("v_zip", v_zip));
                cmd.Parameters.Add(new OracleParameter("v_id", v_id));
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                conn.Close();

                return true;
            }
            catch (OracleException ex)
            {
                _errorMsg = ex.Message;
                return false;
            }
        }

        public bool DeleteV(int v_id)
        {
            string command = "DELETE FROM vendors WHERE vendor_id = :v_id";

            try
            {
                conn.Open();

                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("v_id", v_id));
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                conn.Close();

                return true;
            }
            catch (OracleException ex)
            {
                _errorMsg = ex.Message;
                return false;
            }
        }
    }
}