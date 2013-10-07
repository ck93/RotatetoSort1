using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace RotatetoSort1
{
    public partial class Form1 : Form
    {
        const int bgsize = 340;// picturebox尺寸
        int n = 6;//数字个数
        int[] num;
        int[] numbackup;
        int step = 0;//步数
        bool solved = false;
        Stack<int> method = new Stack<int>();
        Stack<int> methodbackup = new Stack<int>();
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBoxItem1.SelectedIndex = 1;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
        }
        class node
        {
            public int[] array;
            public int depth;
            public node parent;
            public int rotate;
            public node()
            {
                depth = 0;
                parent = null;
                rotate = 0;
            }
            public node(node old)
            {
                array = old.array;
                depth = old.depth + 1;
                parent = old;
                rotate = 0;
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    n = 6;
                    buttonX3.Visible = false;
                    buttonX4.Visible = false;
                    break;
                case 1:
                    n = 8;
                    buttonX3.Visible = true;
                    buttonX4.Visible = false;
                    break;
                case 2:
                    n = 9;
                    buttonX3.Visible = true;
                    buttonX4.Visible = true;
                    break;
            }
            num = new int[n];
            numbackup = new int[n];
            RandomSort(num, n);
            PaintStars();
        }
        private void RandomSort(int[] num, int n)
        {
            Random rd = new Random();
            List<int> list = new List<int>();
            while (list.Count < n)
            {
                int temp = rd.Next(1, n + 1);
                if (!list.Contains(temp))
                {
                    num[list.Count] = temp;
                    list.Add(temp);
                }
            }
            list.Clear();
        }
        private bool victory(int[] num)
        {
            for (int i = 0; i < num.Length; i++)
                if (num[i] != i + 1)
                    return false;
            return true;
        }
        private Bitmap numtopic(int i)
        {
            switch (i)
            {
                case 1:
                    return Properties.Resources._1;
                case 2:
                    return Properties.Resources._2;
                case 3:
                    return Properties.Resources._3;
                case 4:
                    return Properties.Resources._4;
                case 5:
                    return Properties.Resources._5;
                case 6:
                    return Properties.Resources._6;
                case 7:
                    return Properties.Resources._7;
                case 8:
                    return Properties.Resources._8;
                case 9:
                    return Properties.Resources._9;
                default:
                    return null;
            }
        }
        private void PaintStars()
        {
            pictureBox1.Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            int x;
            int y;
            for (int i = 0; i < n; i++)
            {
                x = i - i / 3 * 3;
                y = i / 3;
                g.DrawImage(numtopic(num[i]), x * 135, y * 135);
            }
            g.Dispose();
        }
        private void RePaint4Stars(int i1, int i2, int i3, int i4, int[] num)
        {
            Graphics g = pictureBox1.CreateGraphics();
            int x = i1 - i1 / 3 * 3;
            int y = i1 / 3;
            g.DrawImage(Properties.Resources.紫色星星, x * 135, y * 135);
            x = i2 - i2 / 3 * 3;
            y = i2 / 3;
            g.DrawImage(Properties.Resources.紫色星星, x * 135, y * 135);
            x = i3 - i3 / 3 * 3;
            y = i3 / 3;
            g.DrawImage(Properties.Resources.紫色星星, x * 135, y * 135);
            x = i4 - i4 / 3 * 3;
            y = i4 / 3;
            g.DrawImage(Properties.Resources.紫色星星, x * 135, y * 135);
            Thread.Sleep(150);
            x = i1 - i1 / 3 * 3;
            y = i1 / 3;
            g.DrawImage(numtopic(num[i1]), x * 135, y * 135);
            x = i2 - i2 / 3 * 3;
            y = i2 / 3;
            g.DrawImage(numtopic(num[i2]), x * 135, y * 135);
            x = i3 - i3 / 3 * 3;
            y = i3 / 3;
            g.DrawImage(numtopic(num[i3]), x * 135, y * 135);
            x = i4 - i4 / 3 * 3;
            y = i4 / 3;
            g.DrawImage(numtopic(num[i4]), x * 135, y * 135);
            g.Dispose();
        }
        private int[] rotate1(int[] num)
        {
            int[] temp = new int[num.Length];
            num.CopyTo(temp, 0);
            temp[0] = num[3];
            temp[1] = num[0];
            temp[3] = num[4];
            temp[4] = num[1];
            return temp;
        }
        private int[] rotate2(int[] num)
        {
            int[] temp = new int[num.Length];
            num.CopyTo(temp, 0);
            temp[1] = num[4];
            temp[2] = num[1];
            temp[4] = num[5];
            temp[5] = num[2];
            return temp;
        }
        private int[] rotate3(int[] num)
        {
            int[] temp = new int[num.Length];
            num.CopyTo(temp, 0);
            temp[3] = num[6];
            temp[4] = num[3];
            temp[6] = num[7];
            temp[7] = num[4];
            return temp;
        }
        private int[] rotate4(int[] num)
        {
            int[] temp = new int[num.Length];
            num.CopyTo(temp, 0);
            temp[4] = num[7];
            temp[5] = num[4];
            temp[7] = num[8];
            temp[8] = num[5];
            return temp;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            num = rotate1(num);
            RePaint4Stars(0, 1, 3, 4, num);
            if (victory(num))
                MessageBox.Show("你赢了！");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            num = rotate2(num);
            RePaint4Stars(1, 2, 4, 5, num);
            if (victory(num))
                MessageBox.Show("你赢了！");
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            num = rotate3(num);
            RePaint4Stars(3, 4, 6, 7, num);
            if (victory(num))
                MessageBox.Show("你赢了！");
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            num = rotate4(num);
            RePaint4Stars(4, 5, 7, 8, num);
            if (victory(num))
                MessageBox.Show("你赢了！");
        }
        private string GetKey(int[] num)
        {
            string temp = null;
            int n = num.Length;
            for (int i = 0; i < n; i++)
            {
                temp += num[i].ToString();
            }
            return temp;
        }
        private void GetPath(node dest)
        {
            solved = true;
            while (dest.rotate != 0)
            {
                method.Push(dest.rotate);
                dest = dest.parent;
            }
        }
        private void BFS()
        {
            node start = new node();
            start.array = num;
            Queue<node> open = new Queue<node>();
            Queue<node> closed = new Queue<node>();
            Hashtable ht = new Hashtable();
            open.Enqueue(start);
            if (victory(start.array))
            {
                solved = true;
                return;
            }
            ht.Add(GetKey(start.array), null);
            while (open.Count != 0)
            {
                node old = open.Dequeue();
                closed.Enqueue(old);
                node newnode1 = new node(old);
                newnode1.array = rotate1(newnode1.array);
                newnode1.rotate = 1;
                string s1 = GetKey(newnode1.array);
                if (!ht.ContainsKey(s1))
                {
                    open.Enqueue(newnode1);
                    ht.Add(s1, null);
                    if (victory(newnode1.array))
                    {
                        GetPath(newnode1);
                        break;
                    }
                }
                node newnode2 = new node(old);
                newnode2.rotate = 2;
                newnode2.array = rotate2(newnode2.array);
                string s2 = GetKey(newnode2.array);
                if (!ht.ContainsKey(s2))
                {
                    open.Enqueue(newnode2);
                    ht.Add(s2, null);
                    if (victory(newnode2.array))
                    {
                        GetPath(newnode2);
                        break;
                    }
                }
                if (n == 6)
                    continue;
                node newnode3 = new node(old);
                newnode3.rotate = 3;
                newnode3.array = rotate3(newnode3.array);
                string s3 = GetKey(newnode3.array);
                if (!ht.ContainsKey(s3))
                {
                    open.Enqueue(newnode3);
                    ht.Add(s3, null);
                    if (victory(newnode3.array))
                    {
                        GetPath(newnode3);
                        break;
                    }
                }
                if (n == 8)
                    continue;
                node newnode4 = new node(old);
                newnode4.rotate = 4;
                newnode4.array = rotate4(newnode4.array);
                string s4 = GetKey(newnode4.array);
                if (!ht.ContainsKey(s4))
                {
                    open.Enqueue(newnode4);
                    ht.Add(s4, null);
                    if (victory(newnode4.array))
                    {
                        GetPath(newnode4);
                        break;
                    }
                }
            }
        }
        private void DFS()
        {
            node start = new node();
            start.array = num;
            Stack<node> open = new Stack<node>();
            Stack<node> closed = new Stack<node>();
            open.Push(start);
            if (victory(start.array))
            {
                solved = true;
                return;
            }
            while (open.Count > 0)
            {
                node old = open.Pop();
                closed.Push(old);
                if (old.depth >= 20)
                    continue;
                if (old.rotate != 1 || old.parent.rotate != 1 || old.parent.rotate != 1)
                {
                    node newnode1 = new node(old);
                    newnode1.array = rotate1(newnode1.array);
                    newnode1.rotate = 1;
                    open.Push(newnode1);
                    if (victory(newnode1.array))
                    {
                        GetPath(newnode1);
                        break;
                    }
                }
                if (old.rotate != 2 || old.parent.rotate != 2 || old.parent.rotate != 2)
                {
                    node newnode2 = new node(old);
                    newnode2.array = rotate2(newnode2.array);
                    newnode2.rotate = 2;
                    open.Push(newnode2);
                    if (victory(newnode2.array))
                    {
                        GetPath(newnode2);
                        break;
                    }
                }
                if (n == 6)
                    continue;
                if (old.rotate != 3 || old.parent.rotate != 3 || old.parent.rotate != 3)
                {
                    node newnode3 = new node(old);
                    newnode3.array = rotate3(newnode3.array);
                    newnode3.rotate = 3;
                    open.Push(newnode3);
                    if (victory(newnode3.array))
                    {
                        GetPath(newnode3);
                        break;
                    }
                }
                if (n == 8)
                    continue;
                if (old.rotate != 4 || old.parent.rotate != 4 || old.parent.rotate != 4)
                {
                    node newnode4 = new node(old);
                    newnode4.array = rotate4(newnode4.array);
                    newnode4.rotate = 4;
                    open.Push(newnode4);
                    if (victory(newnode4.array))
                    {
                        GetPath(newnode4);
                        break;
                    }
                }
            }

        }
        private int abs(int x)
        {
            return x > 0 ? x : -x;
        }
        private int f(node p)
        {
            int temp = p.depth;
            for (int i = 0; i < n; i++)
                temp += abs(p.array[i] - i - 1);
            return temp;
        }
        private int binsearch(List<node> open, int start, int end, int key)
        {
            int left, right;
            int mid;
            left = start;
            right = end;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (key < f(open[mid]))
                    right = mid - 1;
                else if (key > f(open[mid]))
                    left = mid + 1;
                else
                    return mid;
            }
            return left;
        }
        private void ASTAR()
        {
            node start = new node();
            start.array = num;
            List<node> open = new List<node>();
            Stack<node> closed = new Stack<node>();
            Hashtable ht = new Hashtable();
            open.Insert(0, start);
            ht.Add(GetKey(start.array), null);
            while (open.Count > 0)
            {
                node bestnode = open[0];
                open.RemoveAt(0);
                closed.Push(bestnode);
                if (victory(bestnode.array))
                {
                    GetPath(bestnode);
                    break;
                }
                if (bestnode.rotate != 1 || bestnode.parent.rotate != 1 || bestnode.parent.rotate != 1)
                {
                    node newnode1 = new node(bestnode);
                    newnode1.array = rotate1(newnode1.array);
                    newnode1.rotate = 1;
                    string s1 = GetKey(newnode1.array);
                    if (!ht.ContainsKey(s1))
                    {
                        open.Insert(binsearch(open, 0, open.Count - 1, f(newnode1)), newnode1);
                        ht.Add(GetKey(newnode1.array), null);
                    }
                }
                if (bestnode.rotate != 2 || bestnode.parent.rotate != 2 || bestnode.parent.rotate != 2)
                {
                    node newnode2 = new node(bestnode);
                    newnode2.array = rotate2(newnode2.array);
                    newnode2.rotate = 2;
                    string s2 = GetKey(newnode2.array);
                    if (!ht.ContainsKey(s2))
                    {
                        open.Insert(binsearch(open, 0, open.Count - 1, f(newnode2)), newnode2);
                        ht.Add(GetKey(newnode2.array), null);
                    }
                }
                if (n == 6)
                    continue;
                if (bestnode.rotate != 3 || bestnode.parent.rotate != 3 || bestnode.parent.rotate != 3)
                {
                    node newnode3 = new node(bestnode);
                    newnode3.array = rotate3(newnode3.array);
                    newnode3.rotate = 3;
                    string s3 = GetKey(newnode3.array);
                    if (!ht.ContainsKey(s3))
                    {
                        open.Insert(binsearch(open, 0, open.Count - 1, f(newnode3)), newnode3);
                        ht.Add(GetKey(newnode3.array), null);
                    }
                }
                if (n == 8)
                    continue;
                if (bestnode.rotate != 4 || bestnode.parent.rotate != 4 || bestnode.parent.rotate != 4)
                {
                    node newnode4 = new node(bestnode);
                    newnode4.array = rotate4(newnode4.array);
                    newnode4.rotate = 4;
                    string s4 = GetKey(newnode4.array);
                    if (!ht.ContainsKey(s4))
                    {
                        open.Insert(binsearch(open, 0, open.Count - 1, f(newnode4)), newnode4);
                        ht.Add(GetKey(newnode4.array), null);
                    }
                }
            }
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            method.Clear();
            solved = false;
            num.CopyTo(numbackup, 0);
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    BFS();
                    break;
                case 1:
                    DFS();
                    break;
                case 2:
                    ASTAR();
                    break;
            }
            if (solved == true)
                MessageBox.Show(method.Count.ToString());
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (comboBoxItem1.SelectedIndex == 2)
            {
                while (methodbackup.Count > 0)
                {
                    method.Push(methodbackup.Pop());
                }
                numbackup.CopyTo(num, 0);
                PaintStars();
            }
            while (method.Count > 0)
            {
                int i = method.Pop();
                methodbackup.Push(i);
                switch (i)
                {
                    case 1:
                        num = rotate1(num);
                        RePaint4Stars(0, 1, 3, 4, num);
                        Thread.Sleep(200);
                        break;
                    case 2:
                        num = rotate2(num);
                        RePaint4Stars(1, 2, 4, 5, num);
                        break;
                    case 3:
                        num = rotate3(num);
                        RePaint4Stars(3, 4, 6, 7, num);
                        break;
                    case 4:
                        num = rotate4(num);
                        RePaint4Stars(4, 5, 7, 8, num);
                        break;
                }
                if (comboBoxItem1.SelectedIndex == 0)
                    break;
                Thread.Sleep(1000 - slider1.Value * 10);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            method.Clear();
            num = new int[n];
            RandomSort(num, n);
            PaintStars();
        }

    }
}
