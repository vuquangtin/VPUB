using System;
using System.Collections.Specialized;
using System.Text;

namespace sWorldModel.Parser
{
    public class TeacherDataParser
    {
        private const string SchoolCode = "HCMUT";
        private static Encoding encoding = new UTF8Encoding();

        private static byte[] schoolCodeBytes = null;
        public static byte[] SchoolCodeBytes
        {
            get
            {
                if (schoolCodeBytes == null)
                {
                    schoolCodeBytes = encoding.GetBytes(SchoolCode);
                }
                return schoolCodeBytes;
            }
        }

        public static byte[] ToByteArray(string departmentCode, string facultyCode, string title, string degree, string positionCode, string scaleOfSalary, string teacherCode, string teacherFullName)
        {
            if(degree.Equals("DH", StringComparison.CurrentCultureIgnoreCase) || degree.Equals("ĐH", StringComparison.CurrentCultureIgnoreCase))
            {
                degree = "KS";
            }
            else if (degree.Equals("CH", StringComparison.CurrentCultureIgnoreCase))
            {
                degree = "ThS";
            }

            byte[] facultyCodeBytes = encoding.GetBytes(facultyCode);
            byte[] departmentCodeBytes = encoding.GetBytes(departmentCode);
            byte[] titleBytes = encoding.GetBytes(title);
            byte[] degreeBytes = encoding.GetBytes(degree);
            byte[] positionCodeBytes = encoding.GetBytes(positionCode);
            byte[] scaleOfSalaryBytes = encoding.GetBytes(scaleOfSalary);
            byte[] teacherCodeBytes = encoding.GetBytes(teacherCode);
            byte[] teacherFullNameBytes = encoding.GetBytes(teacherFullName);

            byte[] result = new byte[SchoolCodeBytes.Length + departmentCodeBytes.Length + facultyCodeBytes.Length + titleBytes.Length + degreeBytes.Length + positionCodeBytes.Length + scaleOfSalaryBytes.Length + teacherCodeBytes.Length + teacherFullNameBytes.Length + 8];     // 8 is number of arguments - 1

            int i = 0, j;

            SchoolCodeBytes.CopyTo(result, i);
            i += SchoolCodeBytes.Length;
            j = facultyCodeBytes.Length;
            result[i++] = (byte)j;

            facultyCodeBytes.CopyTo(result, i);
            i += facultyCodeBytes.Length;
            j = departmentCodeBytes.Length;
            result[i++] = (byte)j;

            departmentCodeBytes.CopyTo(result, i);
            i += departmentCodeBytes.Length;
            j = titleBytes.Length;
            result[i++] = (byte)j;

            titleBytes.CopyTo(result, i);
            i += titleBytes.Length;
            j = degreeBytes.Length;
            result[i++] = (byte)j;

            degreeBytes.CopyTo(result, i);
            i += degreeBytes.Length;
            j = positionCodeBytes.Length;
            result[i++] = (byte)j;

            positionCodeBytes.CopyTo(result, i);
            i += positionCodeBytes.Length;
            j = scaleOfSalaryBytes.Length;
            result[i++] = (byte)j;

            scaleOfSalaryBytes.CopyTo(result, i);
            i += scaleOfSalaryBytes.Length;
            j = teacherCodeBytes.Length;
            result[i++] = (byte)j;

            teacherCodeBytes.CopyTo(result, i);
            i += teacherCodeBytes.Length;
            j = teacherFullNameBytes.Length;
            result[i++] = (byte)j;

            teacherFullNameBytes.CopyTo(result, i);

            return result;
        }

        public static StringCollection FromByteArray(byte[] bytes)
        {
            StringCollection result = new StringCollection();
            int curLen = SchoolCodeBytes.Length, curPos = 0, i = 0;

            // Get school code
            byte[] temp = new byte[curLen];
            if (bytes.Length < curLen)
            {
                Array.Copy(bytes, curPos, temp, 0, bytes.Length);
                return result;
            }
            Array.Copy(bytes, curPos, temp, 0, temp.Length);
            result.Add(encoding.GetString(temp));

            // Get other fields
            while (i++ < 8)
            {
                curLen++;
                if (bytes.Length < curLen)
                {
                    break;
                }
                curPos = curLen;
                curLen += bytes[curLen - 1];
                temp = new byte[curLen - curPos];

                if (bytes.Length < curLen)
                {
                    Array.Copy(bytes, curPos, temp, 0, bytes.Length - curPos);
                    result.Add(encoding.GetString(temp));
                    break;
                }
                Array.Copy(bytes, curPos, temp, 0, temp.Length);
                result.Add(encoding.GetString(temp));
            }

            return result;
        }
    }
}
