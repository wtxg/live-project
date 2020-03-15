using System;

public static bool IsValidIDNumber(string strId)
{
    Regex regId = new Regex(@"^\d{17}(\d|x)$", RegexOptions.IgnoreCase);
    if (strId.Length != 18)
    {
        return false;
    }
    else
    {
        if (!regId.IsMatch(strId))
        {
            return false;
        }
        else
        {
            int iS = 0;
            int[] iW = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            string LastCode = "10X98765432";
            for (int i = 0; i < 17; i++)
            {
                iS += int.Parse(strId.Substring(i, 1)) * iW[i];
            }
            int iY = iS % 11;
            if (strId.Substring(17, 1) != LastCode.Substring(iY, 1))
                return false;
            return true;
        }
    }
}
