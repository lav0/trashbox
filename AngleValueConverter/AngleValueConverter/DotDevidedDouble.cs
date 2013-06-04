using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngleValueConverter
{
  struct DotDevidedDouble
  {
    
    public static bool TryParse(string a_s, out double a_out_value)
    {
      string[] s_array = a_s.Split('.');
      int i_array_len = s_array.GetLength(0);
      int i_first_el_len = s_array[0].Length;
      if (i_array_len != 2 || i_first_el_len == 0)
      {
        a_out_value = 0;
        return false;
      }

      int i_sign = 1;
      if (s_array[0][0] == '-')
      {
        i_sign = -1;
      }

      double d_int;
      double d_fract;
      if (Double.TryParse(s_array[0], out d_int) &&
        Double.TryParse(s_array[1], out d_fract) &&
        s_array[1].Length > 0)
      {
        a_out_value = d_int + i_sign * d_fract / Math.Pow(10, s_array[1].Length);
        return true;
      }
      else
      {
        a_out_value = 0;
        return false;
      }
      
    }

    
  }
}
