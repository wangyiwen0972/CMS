using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Utility.Core.Generater
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public static class CodeGenerater
    {
        public static bool GenerateCode(string FirstChar, int MaxLength, int CurrentIndex, out string Code)
        {
            Code = string.Empty;

            int retuenIndex = CurrentIndex;

            int index = 1;

            int indexLength = CurrentIndex.ToString().Length;

            if (indexLength >= MaxLength)
            {
                return false;
            }
            for (int i = indexLength; i < MaxLength - 1; i++)
            {
                index *= 10;
            }

            Code = string.Format("{0}{1}", FirstChar.ToUpper(), (index + CurrentIndex + 1).ToString());

            return true;
        }
    }
}
