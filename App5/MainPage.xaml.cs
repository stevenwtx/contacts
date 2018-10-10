using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace App5
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>

  

    public sealed partial class MainPage : Page
    {
        public String dis="0";
        string exp;
        char[] tempChar;
        string result = "0";
        Stack shuStack = new Stack();
        Stack fuStack = new Stack("#");
        string op1 = "";
        string op2 = "";
        string operand = "";
        char[] operaters = { '#', '+', '-', '*', '/', '(', ')' };
        double tempRes = 0;

        public MainPage()
        {
            this.InitializeComponent();
            screen.Text = dis.ToString();
        }

        public bool isOpter(char cchar)
        {
            bool flag = false;
            for (int i = 0; i < operaters.Length; i++)
            {
                if (cchar == operaters[i])
                {
                    flag = true;
                    break;
                }

            }
            return flag;
        }

        public int beforeStack(string befSta)
        {
            switch (befSta)
            {
                case "#": return 0;
                case ")": return 1;
                case "+": return 2;
                case "-": return 3;
                case "*": return 4;
                case "/": return 5;
                case "(": return 6;
                default: return -1;
            }
        }

        public int inStack(string inSta)
        {
            switch (inSta)
            {
                case "#": return 0;
                case "(": return 1;
                case "+": return 2;
                case "-": return 3;
                case "*": return 4;
                case "/": return 5;
                case ")": return 6;
                default: return -1;
            }
        }

        public int kuohao()
        {
            int n = 0;
            while (tempChar[n] == '(')
            {
                n++;
            }
            return n;

        }
        public double calculate(string[] opnd, string[] optr)
        {

            string value;
            int iopnd = 0, ioptr = 0;
            for (int i = 0; i < kuohao(); i++)
            {
                fuStack.push(optr[ioptr++]);
            }
            shuStack.push(opnd[iopnd++]);
            while (fuStack.getValue().CompareTo("#") != 0 || iopnd < opnd.Length)
            {
                if (beforeStack(optr[ioptr]) > inStack(fuStack.getValue()))
                {
                    while (optr[ioptr + 1] == "(")
                    {
                        fuStack.push(optr[ioptr++]);
                        continue;
                    }
                    fuStack.push(optr[ioptr++]);
                    shuStack.push(opnd[iopnd++]);
                }
                else
                {
                    if (optr[ioptr] == ")" && fuStack.getValue() == "(")
                    {
                        fuStack.pop(out value);
                        ioptr++;
                    }
                    else
                    {
                        shuStack.pop(out op2);
                        shuStack.pop(out op1);
                        fuStack.pop(out operand);
                        switch (operand)
                        {
                            case "+": tempRes = double.Parse(op1) + double.Parse(op2); break;
                            case "-": tempRes = double.Parse(op1) - double.Parse(op2); break;
                            case "*": tempRes = double.Parse(op1) * double.Parse(op2); break;
                            case "/": tempRes = double.Parse(op1) / double.Parse(op2); break;

                            default: break;
                        }
                        shuStack.push(tempRes.ToString());

                    }
                }
            }
            shuStack.pop(out result);
            return double.Parse(result);
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            exp = "0";
            dis = "0";
            screen.FontSize = 72;
            screen.Text = dis.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("1");
            }
           
        }

        private void Click(String key)
        {
            if (dis.Equals("0"))
            {
                dis = key;
                exp = key;
            }
            else
            {
                dis += key;
                exp += key;
            }
            LongerAsync();
            screen.Text = dis.ToString();
        }
        public async System.Threading.Tasks.Task LongerAsync()
        {   
            if(dis.Length>=9)
                screen.FontSize = 36;
            if (dis.Length >= 36)
                screen.FontSize = 22;
            if (dis.Length >= 120)
            {
                var dialog = new MessageDialog("算式超出位数", "请问您是在皮吗？");
                dialog.Commands.Add(new UICommand("爸爸我错了", cmd => { }, commandId: 0));
                var a = await dialog.ShowAsync();
                Clear();
            }
                
        }
        private void Click2(char key)
        {
            if (!dis.Equals("0"))
            {
                dis += key;
                exp += key;
            }
            LongerAsync();
            screen.Text = dis.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("2");
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("3");
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("4");
            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("5");
            }

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("6");
            }

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("7");
            }

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("8");
            }

        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click("9");
            }

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] == ')'))
            {
                Click2('0');
            }
           
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (dis[dis.Length - 1] >= '0' && dis[dis.Length - 1] <= '9')
            {
                dis += '.';
                exp += '.';
                screen.Text = dis.ToString();
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (dis.Equals("-")) {
                Clear();
            }
            else if((dis[dis.Length-1]>='0'&& dis[dis.Length - 1]<='9')|| dis[dis.Length - 1]==')')
            {
                dis += '+';
                exp += '+';
                screen.Text = dis;
            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if ((dis[dis.Length - 1] >= '0' && dis[dis.Length - 1] <= '9') || dis[dis.Length - 1] == ')')
            {
                dis += '×';
                exp += '*';
                screen.Text = dis;
            }
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
          if (((dis[dis.Length - 1] >= '0' && dis[dis.Length - 1] <= '9') && !dis.Equals("0"))|| dis[dis.Length - 1] == ')')
            {
                dis+='÷';
                exp += '/';
                screen.Text = dis;
            }
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
          if ((dis[dis.Length - 1] >= '0' && dis[dis.Length - 1] <= '9') || dis[dis.Length - 1] == ')')
            {
                Click2('-');
            }else if(dis.Equals("0"))
            {
                dis = "-";
                exp += '-';
                LongerAsync();
                screen.Text = dis.ToString();
            }
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (dis[dis.Length - 1] > '0' && dis[dis.Length - 1] <='9')
            {
                Click2(')');
            }
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if (!(dis[dis.Length - 1] >= '0' && dis[dis.Length - 1] <= '9')&&!dis.Equals(")") && !dis.Equals("("))
            {
                Click2('(');
            }
            if (dis.Equals("0"))
            {
                dis = "(";
                exp = "(";
                screen.Text = dis;
            }
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
           
            
            string[] opnd = exp.Split(operaters, StringSplitOptions.RemoveEmptyEntries);
            tempChar = exp.ToCharArray();
            string[] optr = new string[30];
            int j = 0;
            for (int i = 0; i < tempChar.Length; i++)
            {
                if (isOpter(tempChar[i]))
                {
                    optr[j++] = tempChar[i].ToString();
                }
            }
            screen.FontSize = 36;
            screen.Text = calculate(opnd, optr).ToString();

        }
        
    }
}
