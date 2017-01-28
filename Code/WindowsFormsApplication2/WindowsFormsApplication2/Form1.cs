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
using System.Collections;

namespace WindowsFormsApplication2
{ 
    public partial class Form1 : Form
    {
        String[] data = new String[100];
        int sp;
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        private BindingSource bindingSource3 = new BindingSource();
        private BindingSource bindingSource4 = new BindingSource();
        private BindingSource bindingSource5 = new BindingSource();
        private BindingSource bindingSource6 = new BindingSource();
        private BindingSource bindingSource7 = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            this.comboBox1.Items.Add(Convert.ToString("30%"));
            this.comboBox1.Items.Add(Convert.ToString("40%"));
            this.comboBox1.Items.Add(Convert.ToString("50%"));
            this.comboBox1.Items.Add(Convert.ToString("60%"));
            this.comboBox1.Items.Add(Convert.ToString("70%"));
            this.comboBox1.Sorted = true;
            this.comboBox1.Refresh();
        }
        private void apriorialgorithm(int sup)
        {


            //int p = 0;
            Dictionary<string, int> l1 = new Dictionary<string, int>();
            Dictionary<string, int> ht = new Dictionary<string, int>();
            Dictionary<string, int> l30 = new Dictionary<string, int>();
            Dictionary<string, int> l4 = new Dictionary<string, int>();
            Dictionary<string, int> l5 = new Dictionary<string, int>();
            Dictionary<string, int> l6 = new Dictionary<string, int>();
            Dictionary<string, int> l7 = new Dictionary<string, int>();
            Dictionary<string, int> l2 = new Dictionary<string, int>();
            Dictionary<string, int> hti = new Dictionary<string, int>();
            Dictionary<string, int> l3 = new Dictionary<string, int>();
            Dictionary<string, int> tp = new Dictionary<string, int>();
            int finish = 0;
            //while (finish == 0)
            //{
            int itr = 0;
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
                int count40 = 0;
                int count50 = 0;
                int count60 = 0;
                int count70 = 0;
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
            if (itr == 1)
            {
                bindingSource1.DataSource = l1;
                dataGridView1.DataSource = bindingSource1;
                label7.Text = "Count:" + l1.Count;
            }

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
                            fill =  fill + "," + words1[i];
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
                        {   if (fill == null)
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
                                fill =   fill + "," + l30.ElementAt(j).Key;
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
                        if(count30==0)
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
                            else if (itr == 5)
                            {
                                l6.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
                                //  bindingSource3.DataSource = l3;
                                //dataGridView3.DataSource = bindingSource3;
                            }
                            else if (itr == 6)
                            {
                                l6.Add(ht.ElementAt(g).Key, ht.ElementAt(g).Value);
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
                if (itr == 1)
                {
                    if (l2.Count != 0)
                    {
                        bindingSource2.DataSource = l2;
                        dataGridView2.DataSource = bindingSource2;
                        label11.Text = "Count:" + l2.Count;
                    }
                    
                }
                else if (itr == 2)
                {
                    if (l3.Count != 0)
                    {
                        bindingSource3.DataSource = l3;
                        dataGridView3.DataSource = bindingSource3;
                        label12.Text = "Count:"  + l3.Count;
                    }
                }
                else if (itr == 3)
                {
                    if (l4.Count != 0)
                    {
                        bindingSource4.DataSource = l4;
                        dataGridView4.DataSource = bindingSource4;
                        label13.Text = "Count:"  + l4.Count;
                    }
                }
                else if (itr == 4)
                {
                    if (l5.Count != 0)
                    {
                        bindingSource5.DataSource = l5;
                        dataGridView5.DataSource = bindingSource5;
                        label8.Text = "Count:"+l5.Count;
                    }
                }
                else if (itr == 5)
                {
                    if (l6.Count != 0)
                    {
                        bindingSource6.DataSource = l6;
                        dataGridView6.DataSource = bindingSource6;
                        label10.Text = "Count:" + l6.Count;
                    }
                }
                else if (itr == 6)
                {
                    if (l7.Count != 0)
                    {
                        bindingSource7.DataSource = l7;
                        dataGridView7.DataSource = bindingSource7;
                        label15.Text = "Count:" + l7.Count;
                    }
                }




                itr++;
                

                if (count30==1 || count30 == 0)
                {
                    finish = 1;
                    break;
                }
                }
        
           
           

        }

        private void button1_Click(object sender, EventArgs e)
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
                for(int i=1;i<=100;i++)
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
            apriorialgorithm(sp);
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox comboBox1 = (ComboBox)sender;
            
            string selectedname = (string)comboBox1.SelectedItem;

            int resultIndex = -1;


            resultIndex = comboBox1.FindStringExact(selectedname);


            sp = Convert.ToInt32(selectedname.Substring(0,2));
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    public class itemset
    {
        public string name { get; set; }
        public int count { get; set; }
    }
}
