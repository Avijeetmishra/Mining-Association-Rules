using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        Dictionary<string, float> rl = new Dictionary<string, float>();
        Dictionary<string, int> l1 = new Dictionary<string, int>();
        Dictionary<string, int> ht = new Dictionary<string, int>();
        Dictionary<string, int> l30 = new Dictionary<string, int>();
        Dictionary<string, int> l4 = new Dictionary<string, int>();
        Dictionary<string, int> l5 = new Dictionary<string, int>();
        Dictionary<string, int> l6 = new Dictionary<string, int>();
        Dictionary<string, int> l2 = new Dictionary<string, int>();
        Dictionary<string, int> hti = new Dictionary<string, int>();
        Dictionary<string, int> l3 = new Dictionary<string, int>();
        Dictionary<string, int> l7 = new Dictionary<string, int>();
        Dictionary<string, int> tp = new Dictionary<string, int>();
        string rlstr = "";
        String[] data = new String[100];
        int itr = 0;
        int support;
        double conf;
        disp[] q1 = new disp[150];
        disp[] q2 = new disp[150];
        disp[] q3 = new disp[150];
        disp[] q4 = new disp[150];
        disp[] q5 = new disp[150];
        disp[] q6 = new disp[150];
        disp[] q7 = new disp[150];
        disp[] q8 = new disp[150];
        disp[] q9 = new disp[150];
        disp[] q10 = new disp[150];
        disp[] q12 = new disp[150];
        disp[] q13 = new disp[150];
        disp[] q14 = new disp[150];
        disp[] q15 = new disp[150];
        disp[] q16 = new disp[150];
        disp[] q17 = new disp[150];
        disp[] q18 = new disp[150];
        disp[] q19 = new disp[150];
        disp[] q11 = new disp[150];
        disp[] q20 = new disp[150];
        int n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19, n20;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        
        public Form2()
        {
            InitializeComponent();
            this.comboBox1.Items.Add(Convert.ToString("30%"));
            this.comboBox1.Items.Add(Convert.ToString("40%"));
            this.comboBox1.Items.Add(Convert.ToString("50%"));
            this.comboBox1.Items.Add(Convert.ToString("60%"));
            this.comboBox1.Items.Add(Convert.ToString("70%"));
            this.comboBox1.Sorted = true;
            this.comboBox1.Refresh();

            this.comboBox2.Items.Add(Convert.ToString("30%"));
            this.comboBox2.Items.Add(Convert.ToString("40%"));
            this.comboBox2.Items.Add(Convert.ToString("50%"));
            this.comboBox2.Items.Add(Convert.ToString("60%"));
            this.comboBox2.Items.Add(Convert.ToString("70%"));
            this.comboBox2.Sorted = true;
            this.comboBox2.Refresh();
        }

        public void rulegene(string[] rule_temp)
        {
            string[] rul = new string[10000];
            int r = 0;
            for (int x = 0; x < rule_temp.Length; x++)
            {
                if (rule_temp[x] != null)
                {
                    string[] str = rule_temp[x].Split('-');
                    if (str.Length > 1)
                    {
                        string[] str1 = str[0].Split(',');
                        if (str1.Length == 1 || str1.Length == 0)
                        {
                            return;
                        }

                        int val1 = 0;
                        for (int s = 0; s < 100; s++)
                        {
                            String temp = null;
                            for (int i = 0; i < str1.Length; i++)
                            {
                                if (data[s].Contains(str1[i]))
                                {
                                    temp = str1[i] + ',' + temp;
                                    if (i == str1.Length - 1)
                                    {
                                        val1++;
                                        break;
                                    }
                                }//if(data[s].Contains(str1[i]))
                                else
                                {
                                    break;
                                }
                            }


                        }

                        for (int y = 0; y < str1.Length; y++)
                        {

                            for (int q = 0; q < str1.Length; q++)
                            {
                                if (str1[y] != str1[q])
                                {
                                    if (rul[r] == null)
                                    {
                                        rul[r] = str1[q];
                                    }
                                    else
                                    {
                                        rul[r] = rul[r] + "," + str1[q];
                                    }

                                }
                            }
                            if (!rlstr.Contains(";" + rul[r] + ";"))
                            {

                                
                                string[] words = rul[r].Split(',');
                                int val2 = 0;
                                for (int s = 0; s < 100; s++)
                                {
                                    String temp = null;
                                    for (int i = 0; i < words.Length; i++)
                                    {
                                        if (data[s].Contains(words[i]))
                                        {
                                            temp = words[i] + ',' + temp;
                                            if (i == words.Length - 1)
                                            {
                                                val2++;
                                                break;
                                            }
                                        }//if(data[s].Contains(words[i]))
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }


                                float v1 = Convert.ToSingle(val1);
                                float v2 = Convert.ToSingle(val2);
                                float v = v1 / v2;
                                if (v >= (conf / 100))
                                {
                                    rul[r] = rul[r] + "-" + str[1] + "," + str1[y];
                                    rlstr = rlstr + ";" + rul[r] + ";";
                                    
                                        string[] keys = rul[r].Split('-');
                                        string[] keys1 = keys[0].Split(',');
                                        string[] keys2 = keys[1].Split(',');
                                        int flag = 0;
                                        for (int h = 0; h < rl.Count; h++)
                                        {
                                            string[] key = rl.ElementAt(h).Key.Split('-');

                                            int len1 = 0;
                                            int len2 = 0;
                                            for (int a = 0; a < keys1.Length; a++)
                                            {
                                                if (key[0].Contains(keys1[a]))
                                                {
                                                    len1++;
                                                }
                                            }
                                            for (int a = 0; a < keys2.Length; a++)
                                            {
                                                if (key[1].Contains(keys2[a]))
                                                {
                                                    len2++;
                                                }
                                            }
                                            if (len1 == keys1.Length && len2 == keys2.Length)
                                            {
                                                flag = 1;
                                            }


                                        }
                                        if (flag == 0)
                                        {
                                            rl.Add(rul[r], v);
                                        }

                                    
                                    
                                }

                            }
                            r++;

                        }
                    }


                }


            }

            if (rul[0] == null)
            {
                return;
            }
            else
            {
                rulegene(rul);
            } 
            return;
        }


        public void rules_gene(Dictionary<string, int> l)
        {
            String[] nm = new String[204];
            int[] ct = new int[204];
            string[] genes;
            
            for(int m=0;m<l.Count;m++)
            {
                string[] rule = new string[200];
                if (l.ElementAt(m).Key.Contains(","))
                {
                    genes = l.ElementAt(m).Key.Split(',');

                    int val1 = 0;
                    for (int s = 0; s < 100; s++)
                    {
                        String temp = null;
                        for (int i = 0; i < genes.Length; i++)
                        {
                            if (data[s].Contains(genes[i]))
                            {
                                temp = genes[i] + ',' + temp;
                                if (i == genes.Length - 1)
                                {
                                    val1++;
                                    break;
                                }
                            }//if(data[s].Contains(genes[i]))
                            else
                            {
                                break;
                            }
                        }
                    }

                    for (int p = 0; p < genes.Length; p++)
                    {
                        for (int q = 0; q < genes.Length; q++)
                        {
                            if (genes[p] != genes[q])
                            {
                                if (rule[p] == null)
                                {
                                    rule[p] = genes[q];
                                }
                                else
                                {
                                    rule[p] = rule[p] + "," + genes[q];
                                }

                            }
                        }//for loop of q
                        string[] words = rule[p].Split(',');
                        int val2 = 0;
                        for (int s = 0; s < 100; s++)
                        {
                            String temp = null;
                            for (int i = 0; i < words.Length; i++)
                            {
                                if (data[s].Contains(words[i]))
                                {
                                    temp = words[i] + ',' + temp;
                                    if (i == words.Length - 1)
                                    {
                                        val2++;
                                        break;
                                    }
                                }//inner if
                                else
                                {
                                    break;
                                }
                            }//for loop ofi

                        }// for loop of s
                        float v1 = Convert.ToSingle(val1);
                        float v2 = Convert.ToSingle(val2);
                        float v = v1 / v2;
                        if (v >= (conf/100) )
                        {
                            rule[p] = rule[p] + "-" + genes[p];
                            if (!rlstr.Contains(rule[p]))
                            {
                                rlstr = rlstr + ";" + rule[p] + ";";
                                float va = 0;
                                if (!rl.TryGetValue(rule[p], out va))
                                {
                                    rl.Add(rule[p], v);
                                }
                            }

                        }
                    }// for loop of p
                }// if (l30.ElementAt(0).Key.Contains(","))
             if(rule[0] == null)
            {
                    return;
                }
            else
            {
                    rulegene(rule);
                }
            }
  
        }


        private void apriorialgorithm(int sup)
        {


            //int p = 0;
            
            int finish = 0;
            //while (finish == 0)
            //{
            
            for (int k = 0; k < 100; k++)
            {
                //

                string[] words = data[k].Split(',');

                int c = 1;
                for (int i = 1; i < words.Length; i++)
                {
                    int val1 = 0;
                    if (ht.TryGetValue(words[i], out val1))
                    {
                        continue;
                    }
                    else
                    {
                        ht.Add(words[i], 1);
                    }
                    for (int p = (k + 1); p < 100; p++)
                    {
                        if (data[p].Contains(words[i]))
                        {
                            int val = 0;
                            if (ht.TryGetValue(words[i], out val))
                            {
                                val++;
                                ht[words[i]] = val;
                            }
                        }
                    }
                }//inner for i
            }//outer for k
            int count30 = 0;
            foreach (KeyValuePair<string, int> kp in ht)
            {
                if (kp.Value >= sup)
                {
                    l30.Add(kp.Key, kp.Value);

                    l1.Add(kp.Key, kp.Value);
                    count30++;
                }

            }//foreach

            itr++;
             while (finish == 0)
            {
                ht.Clear();
                hti.Clear();
                string fill = null;
                if (l30.ElementAt(0).Key.Contains(","))
                {
                    string[] words1 = l30.ElementAt(0).Key.Split(',');
                    for (int i = 0; i < words1.Length; i++)
                    {
                        if (fill == null)
                        {
                            fill = words1[i];
                        }
                        else
                        {
                            fill = fill + "," + words1[i];
                        }

                    }
                }
                else
                {
                    fill = l30.ElementAt(0).Key;
                }
                if (l30.ElementAt(1).Key.Contains(","))
                {
                    string[] words1 = l30.ElementAt(1).Key.Split(',');
                    for (int i = 0; i < words1.Length; i++)
                    {
                        if (!fill.Contains(words1[i]))
                        {
                            if (fill == null)
                            {
                                fill = words1[i];
                            }
                            else
                            {
                                fill = fill + "," + words1[i];
                            }
                        }
                    }
                }
                else
                {
                    if (!fill.Contains(l30.ElementAt(1).Key))
                    {
                        if (fill == null)
                        {
                            fill = l30.ElementAt(1).Key;
                        }
                        else
                        {
                            fill = fill + "," + l30.ElementAt(1).Key;
                        }
                    }
                }
                /*   if (fill.Last() == ',')
                   {
                       fill = fill.Substring(0, fill.Length - 1);
                   }*/
                hti.Add(fill, 0);
                for (int i = 0; i < l30.Count; i++)
                {
                    fill = null;
                    var item = l30.ElementAt(i);
                    var itemKey = item.Key;
                    var itemValue = item.Value;
                    for (int j = i + 1; j < l30.Count; j++)
                    {
                        fill = null;
                        if (l30.ElementAt(i).Key.Contains(","))
                        {
                            string[] words1 = l30.ElementAt(i).Key.Split(',');
                            for (int i1 = 0; i1 < words1.Length; i1++)
                            {
                                if (fill == null)
                                {
                                    fill = words1[i1];
                                }
                                else
                                {
                                    if (!fill.Contains(words1[i1]))
                                    {
                                        fill = fill + "," + words1[i1];


                                    }
                                }
                            }


                        }
                        else
                        {
                            if (fill == null)
                            {
                                fill = l30.ElementAt(i).Key;
                            }
                            else
                            {
                                if (!fill.Contains(l30.ElementAt(i).Key))
                                {
                                    fill = l30.ElementAt(i).Key;
                                    //fill = fill.Substring(0, fill.Length - 1);
                                }
                            }

                        }
                        if (l30.ElementAt(j).Key.Contains(","))
                        {
                            string[] words1 = l30.ElementAt(j).Key.Split(',');
                            for (int i1 = 0; i1 < words1.Length; i1++)
                            {
                                if (!fill.Contains(words1[i1]))
                                {
                                    string fill1 = fill + "," + words1[i1];

                                    int val1 = 0;
                                    /*if (fill1.Last() == ',')
                                    {
                                        fill1 = fill1.Substring(0, fill1.Length - 1);
                                    }*/
                                    if (!hti.TryGetValue(fill1, out val1))
                                    {
                                        hti.Add(fill1, 0);
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (!fill.Contains(l30.ElementAt(j).Key))
                            {
                                fill = fill + "," + l30.ElementAt(j).Key;
                                /* if (fill.Last() == ',')
                                 {
                                     fill = fill.Substring(0, fill.Length - 1);
                                 }*/
                                int val = 0;
                                if (!hti.TryGetValue(fill, out val))
                                {
                                    hti.Add(fill, 0);
                                }

                                //fill = fill.Substring(0, fill.Length - 1);
                            }
                        }

                    }
                }
                //C2->L2
                for (int k1 = 0; k1 < hti.Count; k1++)
                {
                    string[] words = hti.ElementAt(k1).Key.Split(',');




                    for (int p = 0; p < 100; p++)
                    {
                        String temp = null;
                        int temp1;
                        int i = 0;

                        while (data[p].Contains(words[i]))
                        {   //temp1 = 
                            if (temp == null)
                            {
                                temp = words[i];
                            }
                            else
                            {
                                temp = temp + ',' + words[i];
                            }
                            if (i == words.Length - 1)
                            {
                                //temp = temp.Substring(0, temp.Length - 1);
                                int val1 = 0;
                                if (ht.TryGetValue(temp, out val1))
                                {
                                    val1++;
                                    ht[temp] = val1;
                                }
                                else
                                {
                                    ht.Add(temp, 1);
                                }

                                break;
                            }
                            /* int val = 0;
                             if (ht.TryGetValue(words[i], out val))
                             {
                                 val++;
                                 ht[words[i]] = val;
                             }*/
                            i++;
                        }//inner while
                    }//inner for p
                }//outer for k
                l30.Clear();
                count30 = 0;


                for (int g = 0; g < ht.Count; g++)
                {
                    if (itr == 1)
                    {
                        if (ht.ElementAt(g).Value >= sup)
                        {
                            l30.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                            l2.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                            count30++;
                            
                        }
                    }
                    else if (ht.ElementAt(g).Value >= sup)
                    {
                        if (count30 == 0)
                        {
                            l30.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                            count30++;
                            if (itr == 2)
                            {
                                l3.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                //  bindingSource3.DataSource = l3;
                                //dataGridView3.DataSource = bindingSource3;
                            }
                            else if (itr == 3)
                            {
                                l4.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                //  bindingSource3.DataSource = l3;
                                //dataGridView3.DataSource = bindingSource3;
                            }
                            else if (itr == 4)
                            {
                                l5.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                //  bindingSource3.DataSource = l3;
                                //dataGridView3.DataSource = bindingSource3;
                            }
                            continue;
                        }
                        else
                        {

                            if (itr == 2)
                            {
                                tp = l3;
                            }
                            else if (itr == 3)
                            {
                                tp = l4;
                            }
                            else if (itr == 4)
                            {
                                tp = l5;
                            }
                            else if (itr == 5)
                            {
                                tp = l6;
                            }
                            else if (itr == 6)
                            {
                                tp = l7;
                            }


                            string[] keys1 = ht.ElementAt(g).Key.Split(',');
                            int flag = 0;
                            for (int h = 0; h < tp.Count; h++)
                            {
                                if (tp.ElementAt(h).Value >= sup)
                                {
                                    int len = 0;
                                    for (int a = 0; a < keys1.Length; a++)
                                    {
                                        if (tp.ElementAt(h).Key.Contains(keys1[a]))
                                        {
                                            len++;
                                        }
                                    }
                                    if (len == keys1.Length)
                                    {
                                        flag = 1;
                                    }

                                }
                            }
                            if (flag == 0)
                            {
                                l30.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                count30++;

                                if (itr == 2)
                                {
                                    l3.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                    //bindingSource3.DataSource = l3;
                                    //dataGridView3.DataSource = bindingSource3;
                                }
                                else if (itr == 3)
                                {
                                    l4.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);

                                }
                                else if (itr == 4)
                                {
                                    l5.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                    // bindingSource3.DataSource = l3;
                                    //dataGridView3.DataSource = bindingSource3;
                                }
                                else if (itr == 5)
                                {
                                    l6.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                    // bindingSource3.DataSource = l3;
                                    //dataGridView3.DataSource = bindingSource3;
                                }
                                else if (itr == 6)
                                {
                                    l7.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                    // bindingSource3.DataSource = l3;
                                    //dataGridView3.DataSource = bindingSource3;
                                }

                            }
                        }



                    }
                }
                itr++;
                
                

                if (count30 == 1 || count30 == 0)
                {
                    finish = 1;
                    break;
                }
            }
             

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=aos.acsu.buffalo.edu:1521/aos.buffalo.edu;PASSWORD=cse601;USER ID=AVIJEETM";
            OracleConnection conn = new OracleConnection(oradb);  // C#

            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * from Assignment2";
            OracleDataReader dr = cmd.ExecuteReader();

            int length1;
            int j = 0;

            while (dr.Read())
            {
                var abc = dr.GetValue(0);
                String sname = Convert.ToString(abc);
                data[j] = sname;
                for (int i = 1; i <= 100; i++)
                {
                    var abc1 = dr.GetValue(i);
                    data[j] = data[j] + "," + "G" + i + "_" + Convert.ToString(abc1);

                }
                var abc2 = dr.GetValue(101);
                String dis = Convert.ToString(abc2);
                data[j] = data[j] + "," + dis;


                j++;

            }
            length1 = j;
            conn.Close();
            apriorialgorithm(support);
            /*if (l1.Count != 0)
            {
                rules_gene(l1);
            }*/
            if (l2.Count != 0)
            {
                rules_gene(l2);
            }
            if (l3.Count != 0)
            {
                rules_gene(l3);
            }
            if (l4.Count != 0)
            {
                rules_gene(l4);
            }
            if (l5.Count != 0)
            {
                rules_gene(l5);
            }
            bindingSource1.DataSource = rl;
            dataGridView1.DataSource = bindingSource1;
            label25.Text = "Total Number of Rules:" + (rl.Count);
            int val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                if (rl.ElementAt(q).Key.Contains("G6_UP"))
                {
                    q1[val] = new disp();
                    q1[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n1 = val;

                label3.Text = "1. RULE HAS ANY OF G6_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                if (rl.ElementAt(q).Key.Contains("G1_UP"))
                {
                    q2[val] = new disp();
                    q2[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n2 = val;
                label4.Text = "2. RULE HAS 1 OF G1_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                if ((!(rl.ElementAt(q).Key.Contains("G1_UP")) && (rl.ElementAt(q).Key.Contains("G10_Down")))|| (rl.ElementAt(q).Key.Contains("G1_UP") && (!rl.ElementAt(q).Key.Contains("G10_Down"))))
                {
                    q3[val] = new disp();
                    q3[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n3 = val;
                label5.Text = "3. RULE HAS 1 OF (G1_UP, G10_Down):" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if (str[0].Contains("G6_UP"))
                {
                    q4[val] = new disp();
                    q4[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n4 = val;
                label6.Text = "4. BODY HAS ANY OF G6_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if (!str[0].Contains("G72_UP"))
                {
                    q5[val] = new disp();
                    q5[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n5 = val;

                label7.Text = "5. BODY HAS NONE OF G72_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if ((!(str[0].Contains("G1_UP")) && (str[0].Contains("G10_Down"))) || (str[0].Contains("G1_UP") && (!str[0].Contains("G10_Down"))))
                {
                    q6[val] = new disp();
                    q6[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n6 = val;

                label8.Text = "6. BODY HAS 1 OF (G1_UP, G10_Down):" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if (str[1].Contains("G6_UP"))
                {
                    q7[val] = new disp();
                    q7[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n7 = val;
                label9.Text = "7. HEAD HAS ANY OF G6_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if ((!str[1].Contains("G1_UP")) && (!str[1].Contains("G6_UP")))
                {
                    q8[val] = new disp();
                    q8[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n8 = val;
                label10.Text = "8. HEAD HAS NONE OF (G1_UP, G6_UP):" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if ((!(str[1].Contains("G6_UP")) && (str[1].Contains("G8_UP"))) || (str[1].Contains("G6_UP") && (!str[1].Contains("G8_UP"))))
                {
                    q9[val] = new disp();
                    q9[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n9 = val;
                label11.Text = "9. HEAD HAS 1 OF (G6_UP, G8_UP):" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                if (rl.ElementAt(q).Key.Contains("G1_UP"))
                {
                    if ((!rl.ElementAt(q).Key.Contains("G6_UP")) && (!rl.ElementAt(q).Key.Contains("G72_UP")))
                    {
                        q10[val] = new disp();
                        q10[val].value = rl.ElementAt(q).Key;
                        val++;
                    }
                }

                else
                {
                    if (rl.ElementAt(q).Key.Contains("G6_UP"))
                    {
                        if ((!rl.ElementAt(q).Key.Contains("G1_UP")) && (!rl.ElementAt(q).Key.Contains("G72_UP")))
                        {
                            q10[val] = new disp();
                            q10[val].value = rl.ElementAt(q).Key;
                            val++;
                        }
                    }
                    else
                    {
                        if (rl.ElementAt(q).Key.Contains("G72_UP"))
                        {
                            if ((!rl.ElementAt(q).Key.Contains("G6_UP")) && (!rl.ElementAt(q).Key.Contains("G1_UP")))
                            {
                                q10[val] = new disp();
                                q10[val].value = rl.ElementAt(q).Key;
                                val++;
                            }
                        }
                    }
                }

                n10 = val;
                label12.Text = "10. RULE HAS 1 OF (G1_UP, G6_UP, G72_UP):" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                if (rl.ElementAt(q).Key.Contains("G1_UP") || rl.ElementAt(q).Key.Contains("G6_UP") || rl.ElementAt(q).Key.Contains("G72_UP"))
                {
                    q11[val] = new disp();
                    q11[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n11 = val;
                label13.Text = "11. RULE HAS ANY OF (G1_UP, G6_UP, G72_UP):" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                string[] str1 = str[0].Split(',');
                string[] str2 = str[1].Split(',');
                int len = str1.Length + str2.Length;
                if(len>=3)
                {
                    q12[val] = new disp();
                    q12[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n12 = val;
                label15.Text = "1. SIZE OF RULE >= 3:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                string[] str1 = str[0].Split(',');
                if (str1.Length >= 2)
                {
                    q13[val] = new disp();
                    q13[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n13 = val;
                label16.Text = "2. SIZE OF BODY >= 2:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                string[] str1 = str[1].Split(',');
                if (str1.Length >= 2)
                {
                    q14[val] = new disp();
                    q14[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n14 = val;
                label17.Text = "3. SIZE OF HEAD >= 2:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if (str[0].Contains("G1_UP") && str[1].Contains("G59_UP"))
                {
                    q15[val] = new disp();
                    q15[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n15 = val;
                label19.Text = "1. BODY HAS ANY OF G1_UP AND HEAD HAS 1 OF G59_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if (str[0].Contains("G1_UP") || str[1].Contains("G6_UP"))
                {
                    q16[val] = new disp();
                    q16[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n16 = val;
                label20.Text = "2. BODY HAS ANY OF G1_UP OR HEAD HAS 1 OF G6_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                string[] str1 = str[1].Split(',');
                if (str[0].Contains("G1_UP"))
                {
                    q17[val] = new disp();
                    q17[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                int val1 = 0;
                for(int o = 0; o < str1.Length; o++)
                {
                    if (str1[o]== "G6_UP")
                    {
                        
                        val1++;
                    }
                }
                if (val1 == 2)
                {
                    q17[val] = new disp();
                    q17[val].value = rl.ElementAt(q).Key;
                    val++;
                }

                n17 = val;
                label21.Text = "3. BODY HAS 1 OF G1_UP OR HEAD HAS 2 OF G6_UP:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if (str[1].Contains("G1_UP") && (!str[0].Contains("ALL") || !str[0].Contains("AML") || !str[0].Contains("Colon Cancer") || !str[0].Contains("Breast Cancer")))
                {
                    q18[val] = new disp();
                    q18[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n18 = val;
                label22.Text = "4. HEAD HAS 1 OF G1_UP AND BODY HAS 0 OF DISEASE:" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                if ((str[1].Contains("ALL") || str[1].Contains("AML") || str[1].Contains("Colon Cancer") || str[1].Contains("Breast Cancer")) || (!(rl.ElementAt(q).Key.Contains("G72_UP")) && (rl.ElementAt(q).Key.Contains("G96_Down")))|| (rl.ElementAt(q).Key.Contains("G72_UP") && (!rl.ElementAt(q).Key.Contains("G96_Down"))))
                {
                    q19[val] = new disp();
                    q19[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n19 = val;
                label23.Text = "5. HEAD HAS 1 OF DISEASE OR RULE HAS 1 OF (G72_UP, G96_DOWN):" + val;
            }
            val = 0;
            for (int q = 0; q < rl.Count; q++)
            {
                string[] str = rl.ElementAt(q).Key.Split('-');
                string[] str1 = str[0].Split(',');
                string[] str2 = str[1].Split(',');
                int len = str1.Length + str2.Length;
                
                if ((((!str[0].Contains("G59_UP")) && str[0].Contains("G96_Down")) || ((str[0].Contains("G59_UP")) && (!str[0].Contains("G96_Down")))) && (len >= 3))
                {
                    q20[val] = new disp();
                    q20[val].value = rl.ElementAt(q).Key;
                    val++;
                }
                n20 = val;

                label24.Text = "6. BODY HAS 1 of (G59_UP, G96_DOWN) AND SIZE OF RULE >=3:" + val;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q1;
            dataGridView2.DataSource = bindingSource2;
            label28.Text= "Query Rules:" +n1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

            bindingSource2.DataSource = q2;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n2;

        }
        private void label5_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q3;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n3;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q4;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n4;
        }
        private void label7_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q5;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n5;
        }
        private void label8_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q6;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n6;
        }
        private void label9_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q7;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n7;
        }
        private void label10_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q8;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n8;
        }
        private void label11_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q9;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n9;
        }
        private void label12_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q10;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n10;
        }
        private void label13_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q11;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n11;
        }
        private void label15_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q12;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n12;
        }
        private void label16_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q13;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n13;
        }
        private void label17_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q14;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n14;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void label19_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q15;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n15;
        }
        private void label20_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q16;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n16;
        }
        private void label21_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q17;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n17;
        }
        private void label22_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q18;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n18;
        }
        private void label23_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q19;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n19;
        }
        private void label24_Click(object sender, EventArgs e)
        {
            bindingSource2.DataSource = q20;
            dataGridView2.DataSource = bindingSource2;
            label28.Text = "Query Rules:" + n20;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox1 = (ComboBox)sender;

            string selectedname = (string)comboBox1.SelectedItem;

            int resultIndex = -1;


            resultIndex = comboBox1.FindStringExact(selectedname);


            support = Convert.ToInt32(selectedname.Substring(0, 2));
            l1.Clear();
            l2.Clear();
            l3.Clear();
            l4.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox1 = (ComboBox)sender;

            string selectedname = (string)comboBox1.SelectedItem;

            int resultIndex = -1;


            resultIndex = comboBox1.FindStringExact(selectedname);


            conf = Convert.ToDouble(selectedname.Substring(0, 2));
            l1.Clear();
            l2.Clear();
            l3.Clear();
            l4.Clear();
        }
        public class disp
        {
            public string value { get; set; }
        }
    }
}
