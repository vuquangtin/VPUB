using CommonHelper.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using CryptoHelper.Hashing;
using sWorldModel.Integrating;

namespace MemberMgtComponent.WorkItems.Integrating
{
    public class AccessDbReader
    {
        private OleDbConnection connection;
        private string connectionString;
        private XXHashUnsafe hashEngine;
        
        public AccessDbReader(string filePath, string userName, string password)
        {
            connectionString = BuildConnectionString(filePath, userName, password);
            connection = new OleDbConnection(connectionString);
            hashEngine = new XXHashUnsafe();
        }

        public static bool TestConnection(string filePath, string userId, string password)
        {
            OleDbConnection conn = null;
            string connString = BuildConnectionString(filePath, userId, password);
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<ALL_BO_MON> SelectAllDepartments()
        {
            DataTable table = DoSelectQuery("SELECT MS_BM, TEN_BM, TEN_TIENG_ANH, MS_KHOA FROM ALL_BO_MON WHERE XOA=FALSE", "ALL_BO_MON");

            List<ALL_BO_MON> result = new List<ALL_BO_MON>();
            foreach (DataRow r in table.Rows)
            {
                ALL_BO_MON bm = new ALL_BO_MON
                    {
                        MS_BM = r["MS_BM"].ToString(),
                        TEN_BM = r["TEN_BM"].ToString(),
                        TEN_TIENG_ANH = r["TEN_TIENG_ANH"].ToString(),
                        MS_KHOA = r["MS_KHOA"].ToString(),
                    };
                bm.HashCode = hashEngine.Hash(bm.ToString()).ToString();
                result.Add(bm);
            }

            return result;
        }

        public List<ALL_KHOA> SelectAllFaculties()
        {
            DataTable table = DoSelectQuery("SELECT MS_KHOA, TEN_KHOA, TEN_TIENG_ANH, TEN_KHOA_TAT FROM ALL_KHOA WHERE XOA=FALSE", "ALL_KHOA");

            List<ALL_KHOA> result = new List<ALL_KHOA>();
            foreach (DataRow r in table.Rows)
            {
                var kh = new ALL_KHOA
                {
                    MS_KHOA = r["MS_KHOA"].ToString(),
                    TEN_KHOA = r["TEN_KHOA"].ToString(),
                    TEN_TIENG_ANH = r["TEN_TIENG_ANH"].ToString(),
                    TEN_KHOA_TAT = r["TEN_KHOA_TAT"].ToString(),
                };
                kh.HashCode = hashEngine.Hash(kh.ToString()).ToString();
                result.Add(kh);
            }

            return result;
        }

        public List<ALL_CBCNV> SelectAllTeachers()
        {
            DataTable table = DoSelectQuery("SELECT NGHI, IS_NNGOAI, LOAI, SHCC, HO, TEN, PHAI, HD_KY_DEN, CHUC_DANH, TRINH_DO, MS_CVU, NGACH, MS_BM FROM ALL_CBCNV", "ALL_CBCNV");

            List<ALL_CBCNV> result = new List<ALL_CBCNV>();
            foreach (DataRow r in table.Rows)
            {
                var cb = new ALL_CBCNV
                {
                    NGHI = r["NGHI"] == null ? null : (r["NGHI"].ToString().Equals("T")) ? (bool?)true : (bool?)false,
                    IS_NNGOAI = r["IS_NNGOAI"] == null ? null : (bool?)bool.Parse(r["IS_NNGOAI"].ToString()),
                    LOAI = r["LOAI"].ToString(),
                    SHCC = r["SHCC"].ToString(),
                    HO = r["HO"].ToString(),
                    TEN = r["TEN"].ToString(),
                    PHAI = r["PHAI"] == null ? 'O' : (r["PHAI"].ToString().Equals("NAM", StringComparison.CurrentCultureIgnoreCase) ? 'M' : 'F'),
                    //HD_KY_DEN = r["HD_KY_DEN"] == null ? null : (DateTime?)DateTime.Parse(r["HD_KY_DEN"].ToString()),
                    CHUC_DANH = r["CHUC_DANH"].ToString(),
                    TRINH_DO = r["TRINH_DO"].ToString(),
                    MS_CVU = r["MS_CVU"].ToString(),
                    NGACH = r["NGACH"].ToString(),
                    MS_BM = r["MS_BM"].ToString(),
                };

                string tmp = r["HD_KY_DEN"] == null ? null : r["HD_KY_DEN"].ToString();
                cb.HD_KY_DEN = tmp == null || tmp.Length == 0 ? null : (DateTime?)DateTime.Parse(tmp);

                cb.HashCode = hashEngine.Hash(cb.ToString()).ToString();
                result.Add(cb);
            }

            return result;
        }

        public List<ALL_NGACH> SelectAllScales()
        {
            DataTable table = DoSelectQuery("SELECT NGACH, TEN_NGACH, NHIEM_VU_DAM_TRACH FROM ALL_NGACH", "ALL_NGACH");

            List<ALL_NGACH> result = new List<ALL_NGACH>();
            foreach (DataRow r in table.Rows)
            {
                var ng = new ALL_NGACH
                {
                    NGACH = r["NGACH"].ToString(),
                    TEN_NGACH = r["TEN_NGACH"].ToString(),
                    NHIEM_VU_DAM_TRACH = r["NHIEM_VU_DAM_TRACH"].ToString(),
                };
                ng.HashCode = hashEngine.Hash(ng.ToString()).ToString();
                result.Add(ng);
            }

            return result;
        }

        public List<ALL_CHUC_VU> SelectAllPositions()
        {
            DataTable table = DoSelectQuery("SELECT MS_CVU, CHUC_VU, Ghi_chu FROM CHUC_VU WHERE Xoa=FALSE", "CHUC_VU");

            List<ALL_CHUC_VU> result = new List<ALL_CHUC_VU>();
            foreach (DataRow r in table.Rows)
            {
                var cv = new ALL_CHUC_VU
                {
                    MS_CVU = r["MS_CVU"].ToString(),
                    CHUC_VU = r["CHUC_VU"].ToString(),
                    Ghi_chu = r["Ghi_chu"].ToString(),
                };
                cv.HashCode = hashEngine.Hash(cv.ToString()).ToString();
                result.Add(cv);
            }

            return result;
        }

        private DataTable DoSelectQuery(string query, string dataSetName)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    DataTable result = new DataTable();
                    result.TableName = dataSetName;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result.Columns.Add(reader.GetName(i));
                    }

                    while (reader.Read())
                    {
                        DataRow row = result.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader.GetValue(i);
                            if (row[i].GetType() == typeof(string))
                            {
                                row[i] = EncodingUtils.VniToUnicode(row[i].ToString().Trim());
                            }
                        }
                        result.Rows.Add(row);
                    }

                    return result;
                }
            }
            catch (OleDbException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string BuildConnectionString(string filePath, string userId, string password)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }
            filePath = filePath.Trim();
            if (filePath.Length == 0)
            {
                throw new ArgumentNullException("filePath");
            }
            string result = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath;

            if (!string.IsNullOrEmpty(userId))
            {
                result += ";User Id=" + userId + ";Password=";

                if (string.IsNullOrEmpty(password))
                {
                    result += password;
                }
            }

            return result;
        }
    }
}