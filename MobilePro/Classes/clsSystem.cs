using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MobilePro
{
    class clsSystem
    {
        #region Property
        private string _connectionStr
        {
            // ------------------------------------------------
            // 1. Get the connection string.
            // ------------------------------------------------
            get
            {
                clsCommon objCommon = new clsCommon();
                return objCommon._connectionStr;
            }
        }
        #endregion

        #region System User
        internal bool SubmitToUser(string UpdatedBy, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.InsertCommand = SaveUser(UpdatedBy, conn);
                    da.UpdateCommand = SaveUser(UpdatedBy, conn);
                    da.DeleteCommand = DeleteUser(UpdatedBy, conn);

                    try
                    {
                        da.Update(dt);
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        clsCommon objCommon = new clsCommon();
                        if (ex.Number.ToString() != "547")
                        {
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                        }
                        else
                        {
                            objCommon.MessageBoxFunction("Deletion of this record is not allowed.", true);
                        }
                        return false;
                    }
                }
            }
        }

        private SqlCommand SaveUser(string UpdatedBy, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frmSysUserEdit", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 15).Value = UpdatedBy;
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15, "UserID").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50, "UserName").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50, "Password").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@NRIC", SqlDbType.NVarChar, 10, "NRIC").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 256, "Email").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar, 20, "ContactNo").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Role", SqlDbType.Int, 0, "Role").SourceVersion = DataRowVersion.Current;
                return cmd;
            }
        }

        private SqlCommand DeleteUser(string UpdatedBy, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frmSysUserDelete", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 15).Value = UpdatedBy;
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15, "UserID").SourceVersion = DataRowVersion.Current;
                return cmd;
            }
        }

        internal bool ChangePassword(string UpdatedBy, string UserID, string Password)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_frmSysUserChangePwd", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 15).Value = UpdatedBy;
                    cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15, "UserID").Value = UserID;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50, "Password").Value = Password;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        if (conn != null)
                            conn.Close();

                        clsCommon objCommon = new clsCommon();
                        objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                        return false;
                    }
                }
            }
        }
        #endregion

        #region Master Tables

        internal bool SubmitToBrand(string _UserId, string _BrandCode, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.InsertCommand = SaveBrand(_UserId, _BrandCode, conn);
                    da.UpdateCommand = SaveBrand(_UserId, _BrandCode, conn);
                   
                    try
                    {
                        da.Update(dt);
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        clsCommon objCommon = new clsCommon();
                        if (ex.Number.ToString() != "547")
                        {
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                        }
                        else
                        {
                            objCommon.MessageBoxFunction("Deletion of this record is not allowed.", true);
                        }
                        return false;
                    }
                }
            }
        }

        private SqlCommand SaveBrand(string UserId, string BrandCode, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frm_add_upd_Brand", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.VarChar, 15).Value = UserId;
                //cmd.Parameters.Add("@BrandCode", SqlDbType.Int).Value = Convert.ToInt16(BrandCode);
                cmd.Parameters.Add("@BrandCode", SqlDbType.Int, 0, "BrandCode").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@BrandName", SqlDbType.VarChar, 100, "BrandName").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@BrandDesc", SqlDbType.NVarChar, 256, "BrandDesc").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Status", SqlDbType.Bit, 0, "Status").SourceVersion = DataRowVersion.Current;
               
                return cmd;
            }
        }

        internal bool SubmitToCategory(string _UserId, string _CategoryCode, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.InsertCommand = SaveCategory(_UserId, _CategoryCode, conn);
                    da.UpdateCommand = SaveCategory(_UserId, _CategoryCode, conn);

                    try
                    {
                        da.Update(dt);
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        clsCommon objCommon = new clsCommon();
                        if (ex.Number.ToString() != "547")
                        {
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                        }
                        else
                        {
                            objCommon.MessageBoxFunction("Deletion of this record is not allowed.", true);
                        }
                        return false;
                    }
                }
            }
        }

        private SqlCommand SaveCategory(string UserId, string CategoryCode, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frm_add_upd_Category", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.VarChar, 15).Value = UserId;
                cmd.Parameters.Add("@CategoryCode", SqlDbType.Int, 0, "CategoryCode").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 100, "CategoryName").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@CategoryDesc", SqlDbType.NVarChar, 256, "CategoryDesc").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Status", SqlDbType.Bit, 0, "Status").SourceVersion = DataRowVersion.Current;

                return cmd;
            }
        }       
        
        #endregion

       
        #region System Role
        internal bool SubmitToRole(string UserID, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.InsertCommand = SaveRole(UserID, conn);
                    da.UpdateCommand = SaveRole(UserID, conn);
                    //da.DeleteCommand = DeleteUser(UpdatedBy, conn);

                    try
                    {
                        da.Update(dt);
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        clsCommon objCommon = new clsCommon();
                        objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                        return false;
                    }
                }
            }
        }

        private SqlCommand SaveRole(string UserID, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frmRoleEdit", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                cmd.Parameters.Add("@Role", SqlDbType.Int, 0, "Role").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@RoleDesc", SqlDbType.VarChar, 50, "RoleDesc").SourceVersion = DataRowVersion.Current;
                return cmd;
            }
        }

        internal bool DeleteRoleAndAccess(string UserID, int Role)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        bool deletedAccess = DeleteAccessByRole(UserID, Role, conn, trans);
                        if (deletedAccess == true)
                        {
                            bool deletedRole = DeleteRole(UserID, Role, conn, trans);
                            if (deletedRole == true)
                            {
                                trans.Commit();
                                conn.Close();
                                return true;
                            }
                            else
                            {
                                trans.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            conn.Close();
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (conn != null)
                        conn.Close();
                    clsCommon objCommon = new clsCommon();
                    objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                    return false;
                }
            }
        }

        private bool DeleteRole(string UserID, int Role, SqlConnection conn, SqlTransaction trans)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frmRoleDelete", conn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                cmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    clsCommon objCommon = new clsCommon();
                    if (ex.Number.ToString() != "547")
                    {
                        objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                    }
                    else
                    {
                        objCommon.MessageBoxFunction("Deletion of this record is not allowed.", true);
                    }
                    return false;
                }
            }
        }

        private bool DeleteAccessByRole(string UserID, int Role, SqlConnection conn, SqlTransaction trans)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frmSysModuleAccessDeleteByRole", conn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                cmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    clsCommon objCommon = new clsCommon();
                    objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                    return false;
                }
            }
        }
        #endregion

        #region Module Access
        internal bool SubmitToModuleAccess(string UserID, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.InsertCommand = SaveAccess(UserID, conn);
                    da.UpdateCommand = SaveAccess(UserID, conn);
                    da.DeleteCommand = DeleteAccess(UserID, conn);

                    try
                    {
                        da.Update(dt);
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        clsCommon objCommon = new clsCommon();
                        if (ex.Number.ToString() != "547")
                        {
                            objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                        }
                        else
                        {
                            objCommon.MessageBoxFunction("Deletion of this record is not allowed.", true);
                        }
                        return false;
                    }
                }
            }
        }

        private SqlCommand SaveAccess(string UserID, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frmSysModuleAccessEdit", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                cmd.Parameters.Add("@ModuleNm", SqlDbType.VarChar, 20, "ModuleNm").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Role", SqlDbType.Int, 0, "Role").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Access", SqlDbType.SmallInt, 0, "Access").SourceVersion = DataRowVersion.Current;                
                return cmd;
            }
        }

        private SqlCommand DeleteAccess(string UserID, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_frmSysModuleAccessDelete", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 15).Value = UserID;
                cmd.Parameters.Add("@ModuleNm", SqlDbType.VarChar, 20, "ModuleNm").SourceVersion = DataRowVersion.Current;
                cmd.Parameters.Add("@Role", SqlDbType.Int, 0, "Role").SourceVersion = DataRowVersion.Current;
                return cmd;
            }
        }
        #endregion
      
    }
}
