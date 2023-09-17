using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions; 

namespace MobilePro
{
    class clsCommon
    {
        private static string qryString;

        #region Property
        internal string _connectionStr
        {
            get
            {
                return qryString;
            }
            set
            {
                qryString = value;
            }
        }

        private string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

                if (attributes.Length == 0)
                    return "";

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        #endregion

        internal bool TestDatabase()
        {
            clsEncryption obj = new clsEncryption();
            string QryStr = ConfigurationManager.ConnectionStrings["MobileProConnectionString"].ToString();
            //string decryptedQryStr = obj.DecryptPwd(encryptedQryStr);

            try
            {
                using (SqlConnection conn = new SqlConnection(QryStr))
                {
                    conn.Open();
                    conn.Close();
                    qryString = QryStr;
                    return true;
                }
            }
            catch (Exception exp)
            {
                this.MessageBoxFunction(exp.Message.ToString(), true);
                return false;
            }
        }

        internal void MessageBoxFunction(string msg, bool isError)
        {
            string projectName = this.AssemblyDescription;
            
            if (isError == true)
            {
                MessageBox.Show(msg, projectName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(msg, projectName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } // MessageBoxFunction end

        internal bool GetAccess(string UserID, string ModuleNm, DateTime dateEdited, bool checkEditRight)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_sysModuleAccess", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                    cmd.Parameters.Add("@ModuleNm", SqlDbType.VarChar, 20).Value = ModuleNm;

                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                if (dt != null)
                                {
                                    int role = Convert.ToInt16(dt.Rows[0]["Role"]);
                                    if (role != 1)
                                    {
                                        short accessRight = Convert.ToInt16(dt.Rows[0]["Access"]);
                                        bool blnTmp = false;
                                        switch (accessRight)
                                        {
                                            case 0:
                                                blnTmp = false;
                                                break;

                                            case 1:
                                                if (checkEditRight == true)
                                                    blnTmp = false;
                                                else
                                                    blnTmp = true;
                                                break;

                                            case 2:
                                                if (checkEditRight == true)
                                                    blnTmp = false;
                                                else
                                                    blnTmp = true;
                                                break;
                                        }
                                        return blnTmp;
                                    }
                                    else
                                    {
                                        return true; // Admin.
                                    }
                                }
                                else
                                {
                                    return false; // Unable to get security.
                                }
                            }
                        }    
                    }
                    catch (SqlException ex)
                    {
                        this.MessageBoxFunction(ex.Message.ToString(), true);
                        return false;
                    }
                    catch (Exception exp)
                    {
                        this.MessageBoxFunction(exp.Message.ToString(), true);
                        return false;
                    }
                }
            }
        }

        internal DataTable SystemUserGet(string UpdatedBy, string UserID)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_frmSysUserGet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (UserID != String.Empty)
                    {
                        cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 15).Value = UpdatedBy;
                    }
                    else
                    {
                        cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 15).Value = DBNull.Value;
                    }

                    if (UserID != String.Empty)
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                    }
                    else
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = DBNull.Value;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                        catch (SqlException ex)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                            return null;
                        }
                        catch (Exception exp)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(exp.Message.ToString(), true);
                            return null;
                        }
                    }
                }
            }
        }

        internal DataTable SystemBrandGet(int? BrandCode, string BrandName)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_frm_get_Brands", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (BrandCode != null)
                    {
                        cmd.Parameters.Add("@BrandCode", SqlDbType.Int).Value = BrandCode;
                        cmd.Parameters.Add("@BrandName", SqlDbType.VarChar, 100).Value = BrandName;
                    }
                    else
                    {
                        cmd.Parameters.Add("@BrandCode", SqlDbType.Int).Value = DBNull.Value;
                        cmd.Parameters.Add("@BrandName", SqlDbType.VarChar, 100).Value = BrandName;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                        catch (SqlException ex)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                            return null;
                        }
                        catch (Exception exp)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(exp.Message.ToString(), true);
                            return null;
                        }
                    }
                }
            }
        }

        internal DataTable SystemCategoryGet(int? CategoryCode, string CategoryName)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_frm_get_Categories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (CategoryCode != null)
                    {
                        cmd.Parameters.Add("@CategoryCode", SqlDbType.Int).Value = CategoryCode;
                        cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 100).Value = CategoryName;
                    }
                    else
                    {
                        cmd.Parameters.Add("@CategoryCode", SqlDbType.Int).Value = DBNull.Value;
                        cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 100).Value = CategoryName;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                        catch (SqlException ex)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                            return null;
                        }
                        catch (Exception exp)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(exp.Message.ToString(), true);
                            return null;
                        }
                    }
                }
            }
        }

        internal DataTable RoleGet(string UserID, int Role)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_frmRoleGet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (UserID != String.Empty)
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                    }
                    else
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = DBNull.Value;
                    }

                    if (Role != -1) // -1 get all role
                    {
                        cmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
                    }
                    else
                    {
                        cmd.Parameters.Add("@Role", SqlDbType.Int).Value = DBNull.Value;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                        catch (SqlException ex)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                            return null;
                        }
                        catch (Exception exp)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(exp.Message.ToString(), true);
                            return null;
                        }
                    }
                }
            }
        }

        internal DataTable SystemModuleGet(string UserID, string ModuleNm)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_frmSysModuleGet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (UserID != String.Empty)
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                    }
                    else
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = DBNull.Value;
                    }

                    if (ModuleNm != String.Empty)
                    {
                        cmd.Parameters.Add("@ModuleNm", SqlDbType.VarChar).Value = ModuleNm;
                    }
                    else
                    {
                        cmd.Parameters.Add("@ModuleNm", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                        catch (SqlException ex)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                            return null;
                        }
                        catch (Exception exp)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(exp.Message.ToString(), true);
                            return null;
                        }
                    }
                }
            }
        }

        internal DataTable SystemModuleAccessGet(string UserID, string ModuleNm, int Role)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_frmSysModuleAccessGet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (UserID != String.Empty)
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                    }
                    else
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = DBNull.Value;
                    }

                    if (ModuleNm != String.Empty)
                    {
                        cmd.Parameters.Add("@ModuleNm", SqlDbType.VarChar).Value = ModuleNm;
                    }
                    else
                    {
                        cmd.Parameters.Add("@ModuleNm", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    cmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                        catch (SqlException ex)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                            return null;
                        }
                        catch (Exception exp)
                        {
                            clsCommon objCommon = new clsCommon();
                            objCommon.MessageBoxFunction(exp.Message.ToString(), true);
                            return null;
                        }
                    }
                }
            }
        }

        internal bool ValidateEmail(string email)
        {
            string strPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex r = new Regex(strPattern);
            if (r.IsMatch(email))
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
