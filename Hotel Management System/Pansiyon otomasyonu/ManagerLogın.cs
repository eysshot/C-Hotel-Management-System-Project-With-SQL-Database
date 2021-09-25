﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pansiyon_otomasyonu
{
    public partial class ManagerLogın : Form
    {
        public ManagerLogın()
        {
            InitializeComponent();
        }

        SqlCon con = new SqlCon();
        public static string picture;
        public static string user;
        public static string username;
        private void BtnExit_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();
        }

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            if (TxtUser.Text == "Username")
            {
                TxtUser.Text = "";
                TxtUser.ForeColor = Color.Black;
            }
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (TxtUser.Text == "")
            {
        TxtUser.Text = "Username";
        TxtUser.ForeColor = Color.SteelBlue;

            }
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            if (TxtPass.Text == "Password")
            {
        TxtPass.Text = "";
        TxtPass.ForeColor = Color.Black;
        TxtPass.PasswordChar = '*';
            }
        }

        char? none = null;
        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if (TxtPass.Text == "")
            { 
                TxtPass.Text = "Password";
                TxtPass.ForeColor = Color.SteelBlue;
                TxtPass.PasswordChar = Convert.ToChar(none);
            }
        }

        private void BtnLogın_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Manager where MUsername=@p1 and MPass=@p2", con.bgl());
            cmd.Parameters.AddWithValue("@p1", TxtUser.Text);
            cmd.Parameters.AddWithValue("@p2", Sha256.pass256(TxtPass.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                username = dr[4].ToString();
                user = dr[1].ToString() + " " + dr[2].ToString();
                picture =  dr[9].ToString();
                ManagerPanel mp = new ManagerPanel();
                mp.Show();
                this.Hide();
            }
            
            else
            {
                MessageBox.Show("Username or Password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.bgl().Close();
            
        }

        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!islem)
            {
                this.Opacity += 0.009;
            }
            if(islem)
            {
                this.Opacity -= 0.009;
            }
        }

        private void ManagerLogın_Load(object sender, EventArgs e)
        {

        }
    }
}





