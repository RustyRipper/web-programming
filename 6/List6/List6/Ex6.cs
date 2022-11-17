using System;


namespace List6
{

    class Ex6
    {
        public static int[] Params(params object[] list)
        {
            int integers = 0;
            int doublesPlus = 0;
            int stringsMore5 = 0;
            int others = 0;
            foreach (Object obj in list)
            {
                switch (Type.GetTypeCode(obj.GetType()))
                {
                    case TypeCode.Int32:

                        int i = (int)obj;
                        if(i % 2 == 0) {
                            integers++;
                        }
                        
                        break;

                    case TypeCode.Double:
                        double d = (Double)obj;
                        if (d > 0.0)
                        {
                            doublesPlus++;
                        }
                        break;

                    case TypeCode.String:
                        String s = (String)obj;
                        if (s.Length >= 5)
                        {
                            stringsMore5++;
                        }
                        break;

                    default:
                        others++;
                        break;

                }
                
            }
            return new int[] { integers, doublesPlus, stringsMore5, others };
        }
        public static void test()
        {
            int[] array = Params(2, 5, "napis", 0, 0.0, 0.1, "dddd", "1234444", new int[] { 1, 2 });
            Console.WriteLine("int= " + array[0]);
            Console.WriteLine("double= " + array[1]);
            Console.WriteLine("string= " + array[2]);
            Console.WriteLine("other= " + array[3]);
        }
        
    }
}
